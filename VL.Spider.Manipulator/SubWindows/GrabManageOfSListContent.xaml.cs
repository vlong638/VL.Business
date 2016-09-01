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
            tb_Pattern.Text = grabConfig.Pattern;
            tb_IndexOfTitle.Text = grabConfig.IndexOfTitle.ToString();
            tb_IndexOfURL.Text = grabConfig.IndexOfURL.ToString();
            cb_IsGrabDetail.IsChecked = grabConfig.IsGrabDetail;
            tb_DetailOutPutDirectoryPath.Text = grabConfig.DetailOutputDirectoryPath;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            GrabConfig.Pattern = tb_Pattern.Text;
            GrabConfig.IndexOfTitle = Convert.ToInt32(tb_IndexOfTitle.Text);
            GrabConfig.IndexOfURL = Convert.ToInt32(tb_IndexOfURL.Text);
            GrabConfig.IsGrabDetail = cb_IsGrabDetail.IsChecked.Value;
            if (GrabConfig.IsGrabDetail&&string.IsNullOrEmpty(tb_DetailOutPutDirectoryPath.Text))
            {
                MessageBox.Show("请输入有效的详情输出文件夹目录位置");
                return;
            }
            GrabConfig.DetailOutputDirectoryPath=tb_DetailOutPutDirectoryPath.Text;
            MainWindow.LoadConfig(Spider.CurrentConfigOfSpider);
            this.Close();
        }

        private void SelectPath(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fdlg = new System.Windows.Forms.FolderBrowserDialog();
            fdlg.RootFolder = Environment.SpecialFolder.Desktop;
            fdlg.Description = "Contents Root Folder";
            var result = fdlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                tb_DetailOutPutDirectoryPath.Text = fdlg.SelectedPath;
                GrabConfig.DetailOutputDirectoryPath = tb_DetailOutPutDirectoryPath.Text;
            }
        }
    }
}
