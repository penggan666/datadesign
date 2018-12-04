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
namespace datadesign
{
    /// <summary>
    /// userMain.xaml 的交互逻辑
    /// </summary>
    public partial class userMain : MetroWindow
    {
        public userMain()
        {
            InitializeComponent();
        }

        private void Tile_Click(object sender, RoutedEventArgs e)//查看寝室信息
        {
            DrMain dr = new DrMain();
            dr.Show();
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)//查看学生信息
        {
            SdDetail sd = new SdDetail();
            sd.Show();
        }
    }
}
