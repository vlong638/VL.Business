using System;
using System.Collections.Generic;
using System.Windows;
using VL.Spider.Manipulator.Configs;
using VL.Spider.Manipulator.Entities;

namespace VL.Spider.Manipulator.SubWindows
{
    /// <summary>
    /// RequestConfigManage.xaml 的交互逻辑
    /// </summary>
    public partial class ManageOfRequest : Window
    {
        public MainWindow MainWindow { set; get; }
        public SpiderManager Spider { set; get; }
        public ConfigOfRequest RequestConfig { set; get; }
        public URLStrategy URLStrategy
        {
            set
            {
                switch (value)
                {
                    case URLStrategy.Default:
                        rb_URLStrategy_Classic.IsChecked = true;
                        break;
                    case URLStrategy.IncreaseByValue:
                        rb_URLStrategy_Increase.IsChecked = true;
                        break;
                    default:
                        throw new NotImplementedException("未支持该分类方案");
                }
            }
            get
            {
                if (rb_URLStrategy_Classic.IsChecked == true)
                {
                    return URLStrategy.Default;
                }
                else if (rb_URLStrategy_Increase.IsChecked == true)
                {
                    return URLStrategy.IncreaseByValue;
                }
                else
                {
                    throw new NotImplementedException("未支持该分类方案");
                }
            }
        }


        public ManageOfRequest(MainWindow mainWindow, SpiderManager spider,ConfigOfRequest requestConfig)
        {
            InitializeComponent();

            MainWindow = mainWindow;
            Spider = spider;
            RequestConfig = requestConfig;
            InitData(spider);
        }

        public void InitData(SpiderManager spider)
        {
            cb_Method.ItemsSource = new List<string>() {
                System.Net.WebRequestMethods.Http.Get,
                System.Net.WebRequestMethods.Http.Post,
            };

            tb_URL.Text = RequestConfig.URL;
            cb_Method.SelectedValue = RequestConfig.Method;
            tb_Agent.Text = RequestConfig.UserAgent;
            URLStrategy = RequestConfig.URLStrategy;
            switch (URLStrategy)
            {
                case URLStrategy.Default:
                    break;
                case URLStrategy.IncreaseByValue:
                    tb_StartValue.Text = RequestConfig.StartAt.ToString();
                    tb_IncreaseValue.Text = RequestConfig.IncreaseBy.ToString();
                    tb_StopSize.Text = RequestConfig.StopWhenLT.ToString();
                    break;
                default:
                    break;
            }
            cb_Encoding.ItemsSource = Enum.GetNames(typeof(EEncoding));
            cb_Encoding.SelectedValue = RequestConfig.Encoding.ToString();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            RequestConfig.Method = cb_Method.Text;
            RequestConfig.UserAgent = tb_Agent.Text;
            RequestConfig.URL = tb_URL.Text;
            CheckAccessibility(RequestConfig.URL);
            RequestConfig.URLStrategy = URLStrategy;
            int startAt, increaseBy, StopWhenLT;
            int.TryParse(tb_StartValue.Text, out startAt);
            RequestConfig.StartAt = startAt;
            int.TryParse(tb_IncreaseValue.Text, out increaseBy);
            RequestConfig.IncreaseBy = increaseBy;
            int.TryParse(tb_StopSize.Text, out StopWhenLT);
            RequestConfig.StopWhenLT = StopWhenLT;
            RequestConfig.Encoding = (EEncoding)Enum.Parse(typeof(EEncoding), cb_Encoding.Text);
            MainWindow.LoadConfig(Spider.CurrentConfigOfSpider);
            this.Close();
        }
        private void CheckAccessibility(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                if (!Spider.CurrentConfigOfSpider.RequestConfig.CheckAccessibility(url))
                {
                    MessageBox.Show("URL验证失败");
                }
            }
        }
    }
}
