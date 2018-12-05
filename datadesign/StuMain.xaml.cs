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

namespace datadesign
{
    /// <summary>
    /// StuMain.xaml 的交互逻辑
    /// </summary>
    public partial class StuMain : MetroWindow
    {
        private int selected = 1;
        public StuMain()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)//添加报修
        {

        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)//未处理
        {
            selected = 1;
            dgmenu1.IsEnabled = false;
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)//正在处理
        {
            selected = 2;
            dgmenu1.IsEnabled = false;
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)//已完成
        {
            selected = 3;
            dgmenu1.IsEnabled = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
