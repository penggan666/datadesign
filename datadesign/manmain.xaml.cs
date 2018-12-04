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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Threading;

namespace datadesign
{
    /// <summary>
    /// manmain.xaml 的交互逻辑
    /// </summary>
    public partial class manmain : MetroWindow
    {
        DispatcherTimer timer = new DispatcherTimer();
        public manmain()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        void timer_Tick(object sender,EventArgs e)
        {
            this.Title = string.Concat("寝室楼管理                                                    ",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        private void Tile_Click(object sender, RoutedEventArgs e)//查看学生信息
        {
            Progress1.IsActive = true;
            SdDetail sd = new SdDetail();
            sd.Show();
            Progress1.IsActive = false;
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)//查看寝室信息
        {
            Progress1.IsActive = true;
            DrMain dr = new DrMain();
            dr.Show();
            Progress1.IsActive = false;
        }

        private void Tile_Click_4(object sender, RoutedEventArgs e)//宿舍调整
        {
            Exchange ex = new Exchange();
            ex.Show();
        }

        private void Tile_Click_5(object sender, RoutedEventArgs e)//管理人员调整
        {
            ManageUd mu = new ManageUd();
            mu.Show();
        }
    }
}
