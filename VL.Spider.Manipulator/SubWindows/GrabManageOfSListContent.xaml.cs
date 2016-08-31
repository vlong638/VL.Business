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
    public partial class GrabManageOfSListContent : Window
    {
        public MainWindow MainWindow { set; get; }
        public SpiderManager Spider { set; get; }
        public GrabConfigOfStaticList GrabConfig { set; get; }

        public GrabManageOfSListContent(MainWindow mainWindow, SpiderManager spider, GrabConfigOfStaticList grabConfig)
        {
            InitializeComponent();

            MainWindow = mainWindow;
            Spider = spider;
            GrabConfig = grabConfig;
            InitData(grabConfig);
        }

        public void InitData(GrabConfigOfStaticList grabConfig)
        {
            tb_Pattern.Text = GrabConfig.Pattern;
            tb_IndexOfTitle.Text = GrabConfig.IndexOfTitle.ToString();
            tb_IndexOfURL.Text = GrabConfig.IndexOfURL.ToString();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            GrabConfig.Pattern = tb_Pattern.Text;
            GrabConfig.IndexOfTitle = Convert.ToInt32(tb_IndexOfTitle.Text);
            GrabConfig.IndexOfURL = Convert.ToInt32(tb_IndexOfURL.Text);
            MainWindow.LoadConfig(Spider.CurrentConfigOfSpider);
            this.Close();
        }
    }
}
