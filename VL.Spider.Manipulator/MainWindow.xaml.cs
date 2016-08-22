using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using VL.Spider.Manipulator.Entities;
using VL.Spider.Manipulator.Configs;
using VL.Spider.Manipulator.SubWindows;
using System.Threading.Tasks;

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
        SpiderManager Spider { set; get; } = new SpiderManager();

        public MainWindow()
        {
            InitializeComponent();

            //加载所有配置
            if (!File.Exists(Spider.ConfigOfSpiders.OutputFilePath))
            {
                Spider.ConfigOfSpiders.Save();
            }
            Spider.ConfigOfSpiders.Load();
            cb_Solution.ItemsSource = Spider.ConfigOfSpiders.Configs.Select(c => c.SpiderName);
            //加载最近一项处理的配置
            Spider.CurrentConfigOfSpider = Spider.ConfigOfSpiders.Configs.FirstOrDefault(c => c.SpiderName == Spider.ConfigOfSpiders.LatestSpiderConfigName);
            cb_Solution.SelectedValue = Spider.ConfigOfSpiders.LatestSpiderConfigName;
            LoadConfig(Spider.CurrentConfigOfSpider);
        }

        #region 配置管理
        private void cb_Solution_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //添加 未有的 爬虫
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (string.IsNullOrEmpty(cb_Solution.Text))
                {
                    MessageBox.Show("请输入有效的爬虫名称");
                    return;
                }
                var newSpiderConfig = new ConfigOfSpider(cb_Solution.Text);
                Spider.ConfigOfSpiders.Configs.Add(newSpiderConfig);
                OnSpiderConfigSourceChanged(newSpiderConfig);
            }
            //删除 已有的 爬虫
            if (e.Key == System.Windows.Input.Key.Delete || e.Key == System.Windows.Input.Key.Back)
            {
                if (string.IsNullOrEmpty(cb_Solution.Text))
                {
                    MessageBox.Show("请输入有效的爬虫名称");
                    return;
                }
                var spiderConfig = Spider.ConfigOfSpiders.Configs.FirstOrDefault(c => c.SpiderName == cb_Solution.Text);
                if (spiderConfig == null)
                {
                    MessageBox.Show("未找到对应名称的爬虫");

                }
                Spider.ConfigOfSpiders.Configs.Remove(spiderConfig);
                var newSpiderConfig = Spider.ConfigOfSpiders.Configs.FirstOrDefault(c => c.SpiderName == cb_Solution.Text);
                OnSpiderConfigSourceChanged(newSpiderConfig ?? new ConfigOfSpider(""));
            }
            if (e.Key == System.Windows.Input.Key.F2)
            {
                Spider.CurrentConfigOfSpider.SpiderName = cb_Solution.Text;
                MessageBox.Show("更名成功");
            }
        }
        private void OnSpiderConfigSourceChanged(ConfigOfSpider newSpiderConfig)
        {
            LoadConfig(newSpiderConfig);
            cb_Solution.ItemsSource = Spider.ConfigOfSpiders.Configs.Select(c => c.SpiderName);
        }

        private void cb_Solution_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //爬虫配置变更 无爬虫时终止
            if (cb_Solution.SelectedValue == null)
            {
                return;
            }
            //爬虫配置变更 加载对应名称的配置
            string spiderName = cb_Solution.SelectedValue.ToString();
            if (string.IsNullOrEmpty(spiderName))
            {
                MessageBox.Show("配置的爬虫名称不可为空");
                return;
            }
            var spiderConfig = Spider.ConfigOfSpiders.Configs.First(c => c.SpiderName == spiderName);
            LoadConfig(spiderConfig);
        }
        public void LoadConfig(ConfigOfSpider spiderConfig)
        {
            if (spiderConfig == null)
                return;

            Spider.CurrentConfigOfSpider = spiderConfig;
            Spider.ConfigOfSpiders.LatestSpiderConfigName = spiderConfig.SpiderName;
            //加载配置内容
            ConfigOfRequest requestConfig = spiderConfig.RequestConfig;
            tb_SourceURL.Text = requestConfig.URL;
            ConfigOfProcess managerConfig = spiderConfig.ManageConfig;
            List<IGrabConfig> grabConfigs = new List<IGrabConfig>();
            grabConfigs.AddRange(spiderConfig.GrabConfigs);
            var grabTypeStrings = Enum.GetNames(typeof(EGrabType));
            foreach (var grabTypeString in grabTypeStrings)
            {
                if (!grabConfigs.Exists(c => c.GetGrabType().ToString() == grabTypeString))
                {
                    var grabType = (EGrabType)Enum.Parse(typeof(EGrabType), grabTypeString);
                    grabConfigs.Add(IGrabConfig.GetGrabConfig(grabType, spiderConfig));
                }
            }
            lb_GrabConfigs.ItemsSource = grabConfigs;
        }
        public void UpdateConfig()
        {
            //爬虫配置变更 无爬虫为异常
            var spiderName = cb_Solution.SelectedValue.ToString();
            if (string.IsNullOrEmpty(spiderName))
            {
                MessageBox.Show("配置的爬虫名称不可为空");
                return;
            }
            //更新对应的配置
            var spiderConfig = Spider.ConfigOfSpiders.Configs.First(c => c.SpiderName == spiderName);
            ConfigOfRequest requestConfig = spiderConfig.RequestConfig;
            requestConfig.URL = tb_SourceURL.Text;
            ConfigOfProcess managerConfig = spiderConfig.ManageConfig;
            //spiderConfig.GrabConfigs
        }
        private void SaveConfig(object sender, RoutedEventArgs e)
        {
            if (SaveConfig())
            {
                MessageBox.Show("保存配置成功");
            }
            else
            {
                MessageBox.Show("保存配置时出错");
            }
        }
        private bool SaveConfig()
        {
            try
            {
                Spider.ConfigOfSpiders.Save();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        #endregion

        #region 配置参数项变更
        private void tb_SourceURL_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Spider.CurrentConfigOfSpider == null)
            {
                tb_SourceURL.Text = "";
                MessageBox.Show("请先设置新爬虫的名称");
                return;
            }
            Spider.CurrentConfigOfSpider.RequestConfig.URL = tb_SourceURL.Text;
            if (!CheckAccessibility(Spider.CurrentConfigOfSpider.RequestConfig.URL))
            {
                MessageBox.Show("URL校验未通过");
                return;
            }
        }
        private bool CheckAccessibility(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                return Spider.CurrentConfigOfSpider.RequestConfig.CheckAccessibility(url);
            }
            return true;
        }
        private void SetDetailForRequestConfig(object sender, RoutedEventArgs e)
        {
            if (Spider.CurrentConfigOfSpider == null)
            {
                MessageBox.Show("请先设置新爬虫的名称");
                return;
            }
            SubWindows.ManageOfRequest win = new SubWindows.ManageOfRequest(this, Spider, Spider.CurrentConfigOfSpider.RequestConfig);
            win.Show();
        }
        #endregion

        #region 有效方法
        private void SetOutputFilePath(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fdlg = new System.Windows.Forms.FolderBrowserDialog();
            fdlg.RootFolder = Environment.SpecialFolder.Desktop;
            fdlg.Description = "Contents Root Folder";
            var result = fdlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                //(Spider.ConfigOfSpider.GrabConfigs.First(c=>c.GetGrabType()==EGrabType.File)as GrabConfigOfFile).DirectoryName = fdlg.SelectedPath;
            }
        }
        private void tb_FileOutput_TextChanged(object sender, TextChangedEventArgs e)
        {
            //(Spider.ConfigOfSpider.GrabConfigs.First(c => c.GetGrabType() == EGrabType.File) as GrabConfigOfFile).DirectoryName = tb_FileOutput.Text;
        }
        private void ChangeMaxConnection(object sender, TextChangedEventArgs e)
        {
            //var value = tb_MaxConnection.Text;
            //int maxConnection;
            //if (Int32.TryParse(value, out maxConnection))
            //{
            //    Spider.ConfigOfSpider.ManageConfig.MaxConnectionNumber = maxConnection;
            //}
            //else
            //{
            //    MessageBox.Show("请输入有效的最大连接数");
            //}
        }
        private void StartDownload(object sender, RoutedEventArgs e)
        {
            if (!CheckAccessibility(Spider.CurrentConfigOfSpider.RequestConfig.URL))
            {
                MessageBox.Show("URL校验未通过");
                return;

            }

            //var config = Spider.CurrentConfigOfSpider.GrabConfigs.First(c => c.GetGrabType() == EGrabType.File) as GrabConfigOfFile;
            //var outPutPath = Path.Combine(config.DirectoryPath, config.FileName ?? Utilities.GrabNamingHelper.GetNameForFile(config.FileNameTag));
            //File.WriteAllText(outPutPath, "123");



            foreach (var grabConfig in Spider.CurrentConfigOfSpider.GrabConfigs)
            {
                if (grabConfig.OnGrabFinish == null)
                {
                    grabConfig.OnGrabFinish += (isSuccess, message) =>
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            var item = new
                            {
                                GrabStatus = isSuccess,
                                GrabType = grabConfig.GrabType.ToString(),
                                URL = Spider.CurrentConfigOfSpider.RequestConfig.URL,
                                Message = message
                            };
                            ListDownload.Items.Add(item);
                            ListDownload.SelectedIndex = ListDownload.Items.Count - 1;
                            ListDownload.UpdateLayout();
                            ListDownload.ScrollIntoView(ListDownload.SelectedItem);//TODO失效
                        });
                        if (isSuccess)
                        {
                            SaveConfig();
                        };
                    };
                }
                Task.Factory.StartNew(() =>
                {
                    grabConfig.StartGrabbing(Spider.CurrentConfigOfSpider.RequestConfig);
                });
            }
        }
        private void StopDownload(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        #endregion

        #region backup
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
        private WorkingUnitCollection _workingSignals = null;
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
        #endregion

        private void SetDetailForGrabConfig(object sender, RoutedEventArgs e)
        {
            string type = (e.OriginalSource as Button).Content.ToString();
            EGrabType grabType = (EGrabType)Enum.Parse(typeof(EGrabType), type);
            var grabConfig = Spider.CurrentConfigOfSpider.GrabConfigs.FirstOrDefault(c => c.GrabType == type);
            switch (grabType)
            {
                case EGrabType.File:
                    new GrabManageOfFileGrab(this, Spider, grabConfig == null ? new GrabConfigOfFile(Spider.CurrentConfigOfSpider) : grabConfig as GrabConfigOfFile).Show();
                    break;
                case EGrabType.SListContent:
                case EGrabType.DListContent:
                default:
                    MessageBox.Show("未实现该类型的编辑窗口");
                    break;
            }
        }

    }
}
