using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VL.Spider.Manipulator.Entities;

namespace VL.Spider.Manipulator
{
    class RequestState
    {
        private const int BUFFER_SIZE = 131072;
        private byte[] _data = new byte[BUFFER_SIZE];
        private StringBuilder _sb = new StringBuilder();

        public HttpWebRequest Req { get; private set; }
        public string Url { get; private set; }
        public int Depth { get; private set; }
        public int Index { get; private set; }
        public Stream ResStream { get; set; }
        public StringBuilder Html
        {
            get
            {
                return _sb;
            }
        }

        public byte[] Data
        {
            get
            {
                return _data;
            }
        }

        public int BufferSize
        {
            get
            {
                return BUFFER_SIZE;
            }
        }

        public RequestState(HttpWebRequest req, string url, int depth, int index)
        {
            Req = req;
            Url = url;
            Depth = depth;
            Index = index;
        }
    }
    class WorkingUnitCollection
    {
        private int _count;
        //private AutoResetEvent[] _works;
        private bool[] _busy;

        public WorkingUnitCollection(int count)
        {
            _count = count;
            //_works = new AutoResetEvent[count];
            _busy = new bool[count];

            for (int i = 0; i < count; i++)
            {
                //_works[i] = new AutoResetEvent(true);
                _busy[i] = true;
            }
        }

        public void StartWorking(int index)
        {
            if (!_busy[index])
            {
                _busy[index] = true;
                //_works[index].Reset();
            }
        }

        public void FinishWorking(int index)
        {
            if (_busy[index])
            {
                _busy[index] = false;
                //_works[index].Set();
            }
        }

        public bool IsFinished()
        {
            bool notEnd = false;
            foreach (var b in _busy)
            {
                notEnd |= b;
            }
            return !notEnd;
        }

        public void WaitAllFinished()
        {
            while (true)
            {
                if (IsFinished())
                {
                    break;
                }
                Thread.Sleep(1000);
            }
            //WaitHandle.WaitAll(_works);
        }

        public void AbortAllWork()
        {
            for (int i = 0; i < _count; i++)
            {
                _busy[i] = false;
            }
        }
    }
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //目前仅支持单例
            //多例情况下 需要在选项变更事件触发同时进行变更
            DisplayCurrentValue();
        }

        #region 有效方法
        public void DisplayCurrentValue()
        {
            SpiderRequestConfig requestConfig = RequestConfig;
            SpiderManagerConfig managerConfig = ManagerConfig;
            tb_MaxConnection.Text = managerConfig.MaxConnectionNumber.ToString();

        }
        SpiderRequestConfig RequestConfig { set; get; } = new SpiderRequestConfig()
        {
            Method = WebRequestMethods.Http.Get,
            UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0)",
        };
        SpiderManagerConfig ManagerConfig { set; get; } = new SpiderManagerConfig()
        {
            MaxConnectionNumber=1,
        };

        private void CheckAccessibility(object sender, RoutedEventArgs e)
        {
            var url = tb_Source.Text;
            if (!string.IsNullOrEmpty(url))
            {
                RequestConfig.URL = url;
                new SpiderManager().CheckAccessibility(RequestConfig);
            }
        }
        private void SetOutputFilePath(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fdlg = new System.Windows.Forms.FolderBrowserDialog();
            fdlg.RootFolder = Environment.SpecialFolder.Desktop;
            fdlg.Description = "Contents Root Folder";
            var result = fdlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string path = fdlg.SelectedPath;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                ManagerConfig.OutputPath = path;
            }
        }
        private void ChangeMaxConnection(object sender, TextChangedEventArgs e)
        {
            var value = tb_MaxConnection.Text;
            int maxConnection;
            if (Int32.TryParse(value, out maxConnection))
            {
                ManagerConfig.MaxConnectionNumber = maxConnection;
            }
            else
            {
                MessageBox.Show("请输入有效的最大连接数");
            }
        }
        private void StartDownload(object sender, RoutedEventArgs e)
        {

        }

        private void StopDownload(object sender, RoutedEventArgs e)
        {

        }
        #endregion




        private string _method = "GET";
        private string _accept = "text/html";
        private string _userAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0)";
        private bool[] _reqsBusy = null;
        private void TimeoutCallback(object state, bool timedOut)
        {
            if (timedOut)
            {
                RequestState rs = state as RequestState;
                if (rs != null)
                {
                    rs.Req.Abort();
                }
                _reqsBusy[rs.Index] = false;
                DispatchWork();
            }
        }
        private bool _stop = true;
        private int _reqCount = 4;
        private void DispatchWork()
        {
            if (_stop)
            {
                return;
            }
            for (int i = 0; i < _reqCount; i++)
            {
                if (!_reqsBusy[i])
                {
                    RequestResource(i);
                }
            }
        }
        private readonly object _locker = new object();
        private Dictionary<string, int> _urlsLoaded = new Dictionary<string, int>();
        private Dictionary<string, int> _urlsUnload = new Dictionary<string, int>();
        private WorkingUnitCollection _workingSignals;
        private int _maxTime = 2 * 60 * 1000;
        private void RequestResource(int index)
        {
            int depth;
            string url = "";
            try
            {
                lock (_locker)
                {
                    if (_urlsUnload.Count <= 0)
                    {
                        _workingSignals.FinishWorking(index);
                        return;
                    }
                    _reqsBusy[index] = true;
                    _workingSignals.StartWorking(index);
                    depth = _urlsUnload.First().Value;
                    url = _urlsUnload.First().Key;
                    _urlsLoaded.Add(url, depth);
                    _urlsUnload.Remove(url);
                }

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = _method; //请求方法
                req.Accept = _accept; //接受的内容
                req.UserAgent = _userAgent; //用户代理
                RequestState rs = new RequestState(req, url, depth, index);
                var result = req.BeginGetResponse(new AsyncCallback(ReceivedResource), rs);
                ThreadPool.RegisterWaitForSingleObject(result.AsyncWaitHandle,
                        TimeoutCallback, rs, _maxTime, true);
            }
            catch (WebException we)
            {
                MessageBox.Show("RequestResource " + we.Message + url + we.Status);
            }
        }
        private void ReceivedResource(IAsyncResult ar)
        {
            RequestState rs = (RequestState)ar.AsyncState;
            HttpWebRequest req = rs.Req;
            string url = rs.Url;
            try
            {
                HttpWebResponse res = (HttpWebResponse)req.EndGetResponse(ar);
                if (_stop)
                {
                    res.Close();
                    req.Abort();
                    return;
                }
                if (res != null && res.StatusCode == HttpStatusCode.OK)
                {
                    Stream resStream = res.GetResponseStream();
                    rs.ResStream = resStream;
                    var result = resStream.BeginRead(rs.Data, 0, rs.BufferSize,
                        new AsyncCallback(ReceivedData), rs);
                }
                else
                {
                    res.Close();
                    rs.Req.Abort();
                    _reqsBusy[rs.Index] = false;
                    DispatchWork();
                }
            }
            catch (WebException we)
            {
                MessageBox.Show("ReceivedResource " + we.Message + url + we.Status);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private Encoding _encoding = Encoding.GetEncoding("GB18030");
        private void ReceivedData(IAsyncResult ar)
        {
            RequestState rs = (RequestState)ar.AsyncState;
            HttpWebRequest req = rs.Req;
            Stream resStream = rs.ResStream;
            string url = rs.Url;
            int depth = rs.Depth;
            string html = null;
            int index = rs.Index;
            int read = 0;

            try
            {
                read = resStream.EndRead(ar);
                if (_stop)
                {
                    rs.ResStream.Close();
                    req.Abort();
                    return;
                }
                if (read > 0)
                {
                    MemoryStream ms = new MemoryStream(rs.Data, 0, read);
                    StreamReader reader = new StreamReader(ms, _encoding);
                    string str = reader.ReadToEnd();
                    rs.Html.Append(str);
                    var result = resStream.BeginRead(rs.Data, 0, rs.BufferSize,
                        new AsyncCallback(ReceivedData), rs);
                    return;
                }
                html = rs.Html.ToString();
                SaveContents(html, url);
                string[] links = GetLinks(html);
                AddUrls(links, depth + 1);

                _reqsBusy[index] = false;
                DispatchWork();
            }
            catch (WebException we)
            {
                MessageBox.Show("ReceivedData Web " + we.Message + url + we.Status);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.GetType().ToString() + e.Message);
            }
        }
        private int _maxDepth = 2;
        private string _baseUrl = null;
        private void AddUrls(string[] urls, int depth)
        {
            if (depth >= _maxDepth)
            {
                return;
            }
            foreach (string url in urls)
            {
                string cleanUrl = url.Trim();
                int end = cleanUrl.IndexOf(' ');
                if (end > 0)
                {
                    cleanUrl = cleanUrl.Substring(0, end);
                }
                cleanUrl = cleanUrl.TrimEnd('/');
                if (UrlAvailable(cleanUrl))
                {
                    if (cleanUrl.Contains(_baseUrl))
                    {
                        _urlsUnload.Add(cleanUrl, depth);
                    }
                    else
                    {
                        // 外链
                    }
                }
            }
        }
        private bool UrlAvailable(string url)
        {
            if (UrlExists(url))
            {
                return false;
            }
            if (url.Contains(".jpg") || url.Contains(".gif")
                || url.Contains(".png") || url.Contains(".css")
                || url.Contains(".js"))
            {
                return false;
            }
            return true;
        }
        private bool UrlExists(string url)
        {
            bool result = _urlsUnload.ContainsKey(url);
            result |= _urlsLoaded.ContainsKey(url);
            return result;
        }
        private string[] GetLinks(string html)
        {
            const string pattern = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection m = r.Matches(html);
            string[] links = new string[m.Count];

            for (int i = 0; i < m.Count; i++)
            {
                links[i] = m[i].ToString();
            }
            return links;
        }
        private string _path = null;
        private int _index;
        public delegate void ContentsSavedHandler(string path, string url);
        public event ContentsSavedHandler ContentsSaved = null;
        private void SaveContents(string html, string url)
        {
            if (string.IsNullOrEmpty(html))
            {
                return;
            }
            string path = "";
            lock (_locker)
            {
                path = string.Format("{0}\\{1}.txt", _path, _index++);
            }

            try
            {
                using (StreamWriter fs = new StreamWriter(path))
                {
                    fs.Write(html);
                }
            }
            catch (IOException ioe)
            {
                MessageBox.Show("SaveContents IO" + ioe.Message + " path=" + path);
            }

            if (ContentsSaved != null)
            {
                ContentsSaved(path, url);
            }
        }



    }
}
