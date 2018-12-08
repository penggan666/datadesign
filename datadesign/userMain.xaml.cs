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
using System.Windows.Threading;

namespace datadesign
{
    /// <summary>
    /// userMain.xaml 的交互逻辑
    /// </summary>
    public partial class userMain : MetroWindow
    {
        DispatcherTimer timer = new DispatcherTimer();
        MYSql mysql = new MYSql();
        string buildingnum;
        public userMain(string buildingnum)
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            this.buildingnum = buildingnum;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            this.Title = string.Concat(Source.build, "栋寝室楼管理                                                    ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void Tile_Click(object sender, RoutedEventArgs e)//学生信息
        {
            userStu u1 = new userStu();
            u1.Show();
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)//寝室信息
        {
            usreDor u = new usreDor();
            u.Show();
        }

        private void Tile_Click_2(object sender, RoutedEventArgs e)//夜归信息
        {
            MainLate la = new MainLate();
            la.Show();
        }

        private void Tile_Click_3(object sender, RoutedEventArgs e)//外来人员信息
        {
            MainCome mc = new MainCome();
            mc.Show();
        }

        private void Tile_Click_4(object sender, RoutedEventArgs e)//报修信息
        {
            fix f = new fix(buildingnum);
            f.Show();
        }
    }
}
