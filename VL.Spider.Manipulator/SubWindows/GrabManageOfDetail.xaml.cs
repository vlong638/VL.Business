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
    public partial class GrabManageOfDetail : Window
    {
        public MainWindow MainWindow { set; get; }
        public SpiderManager Spider { set; get; }
        public GrabConfigOfDetail GrabConfig { set; get; }

        public GrabManageOfDetail(MainWindow mainWindow, SpiderManager spider, GrabConfigOfDetail grabConfig)
        {
            InitializeComponent();

            MainWindow = mainWindow;
            Spider = spider;
            GrabConfig = grabConfig;
            InitData(grabConfig);
        }

        public void InitData(GrabConfigOfDetail grabConfig)
        {
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.LoadConfig(Spider.CurrentConfigOfSpider);
            this.Close();
        }

        private void SelectPath(object sender, RoutedEventArgs e)
        {
        }
    }
}
