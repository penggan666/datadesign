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
using System.Data;

namespace datadesign
{
    /// <summary>
    /// fix.xaml 的交互逻辑
    /// </summary>
    public partial class fix : MetroWindow
    {
        private int selected = 1;

        public fix()
        {
            InitializeComponent();
            MYSql mysql = new MYSql();
            DataTable dt = new DataTable();
            dt = mysql.ExecuteQuery("select * from broom");
            dataGrid.ItemsSource = dt.DefaultView;


        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)//未处理
        {
            selected = 1;
        }

        
        private void radioButton1_Checked(object sender, RoutedEventArgs e)//已处理
        {
            selected = 2;
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)//已完成
        {
            selected = 3;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)//处理
        {
            setworker sw = new setworker();
            sw.Show();
        }

        private void dataGrid_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (selected == 2||selected==3)
            {
                e.Handled = true;
            }

        }
    }
}
