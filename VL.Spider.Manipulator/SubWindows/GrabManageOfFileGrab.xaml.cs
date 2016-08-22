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
    public partial class GrabManageOfFileGrab : Window
    {
        public MainWindow MainWindow { set; get; }
        public SpiderManager Spider { set; get; }
        public GrabConfigOfFile GrabConfig { set; get; }

        public GrabManageOfFileGrab(MainWindow mainWindow, SpiderManager spider,GrabConfigOfFile grabConfig)
        {
            InitializeComponent();

            MainWindow = mainWindow;
            Spider = spider;
            GrabConfig = grabConfig;
            InitData(grabConfig);
        }

        public void InitData(GrabConfigOfFile grabConfig)
        {
            tb_FileName.Text = GrabConfig.FileName;
            tb_FileTag.Text = GrabConfig.FileNameTag;
            tb_Directory.Text = GrabConfig.DirectoryPath;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            GrabConfig.FileName = tb_FileName.Text;
            GrabConfig.FileNameTag = tb_FileTag.Text;
            GrabConfig.DirectoryPath= tb_Directory.Text;
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
            GrabConfig.DirectoryPath= tb_Directory.Text;
            {
                tb_Directory.Text = fdlg.SelectedPath;
                GrabConfig.DirectoryPath = tb_Directory.Text;
            }
        }
    }
}
