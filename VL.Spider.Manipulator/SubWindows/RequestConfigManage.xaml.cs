using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VL.Spider.Manipulator.Configs;
using VL.Spider.Manipulator.Entities;

namespace VL.Spider.Manipulator.SubWindows
{
    /// <summary>
    /// RequestConfigManage.xaml 的交互逻辑
    /// </summary>
    public partial class RequestConfigManage : Window
    {
        public MainWindow MainWindow { set; get; }
        public SpiderManager Spider { set; get; }
        public ConfigOfRequest RequestConfig { set; get; }

        public RequestConfigManage(MainWindow mainWindow, SpiderManager spider,ConfigOfRequest requestConfig)
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
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            RequestConfig.Method = cb_Method.Text;
            RequestConfig.UserAgent = tb_Agent.Text;
            RequestConfig.URL = tb_URL.Text;
            CheckAccessibility(RequestConfig.URL);
            MainWindow.LoadConfig(Spider.CurrentConfigOfSpider);
            this.Close();
        }
        private void CheckAccessibility(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                if (Spider.CurrentConfigOfSpider.RequestConfig.CheckAccessibility(Spider.Context) != CheckAccessibilityResult.Success)
                {
                    MessageBox.Show("URL验证失败");
                }
            }
        }
    }
}
