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
    /// MainCome.xaml 的交互逻辑
    /// </summary>
    public partial class MainCome : MetroWindow
    {
        MYSql mysql = new MYSql();
        DataTable dt = new DataTable();
        public MainCome()
        {
            InitializeComponent();
            string s = "select ctime as '时间',name as '姓名',thing as '原因' from Come where buildingnum='"+Source.build+"'";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private async void button_Click(object sender, RoutedEventArgs e)//查询
        {
            if (datepicker.Text == "")
                await this.ShowMessageAsync("提示", "请选择日期");
            else
            {
                try {
                    string time = Convert.ToDateTime(datepicker.Text).ToString("yyyy-MM-dd");
                    string s = "select ctime as '时间',name as '姓名',thing as '原因' from Come where buildingnum='" + Source.build + "'and ctime like'" + time + "%" + "'";
                    dataGrid.ItemsSource = mysql.ExecuteQuery(s).DefaultView;
                }
                catch(Exception ex)
                {
                    await this.ShowMessageAsync("错误", ex.ToString());
                }
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)//新增
        {
            Coming c = new Coming();
            c.setCo(this);
            c.Show();
        }
    }
}
