using MahApps.Metro.Controls;
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
using System.Data;
using MahApps.Metro.Controls.Dialogs;

namespace datadesign
{
    /// <summary>
    /// ManageUd.xaml 的交互逻辑
    /// </summary>
    public partial class ManageUd : MetroWindow
    {
        MYSql mysql = new MYSql();
        DataTable dt = new DataTable();

        string s = "select wnum as '工号',wname as '姓名',bnum as '管理栋号' from worker";
        public ManageUd()
        {
            InitializeComponent();
            string s = "select wnum as '工号',wname as '姓名',bnum as '管理栋号' from worker";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void button_Click1(object sender, RoutedEventArgs e)//查询工号按钮
        {
            string wnum = textBox.Text;
            string s = "select wnum as '工号',wname as '姓名',bnum as '管理栋号' from worker where wnum ='"+wnum+"'";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
        }
        private void button_Click2(object sender, RoutedEventArgs e)//查询栋号
        {
            string bnum = bnumBox.Text;
            string s = "select wnum as '工号',wname as '姓名',bnum as '管理栋号' from worker where bnum ='" + bnum + "'";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)//新增
        {
            AddMan a = new AddMan();
            a.Show();
            dt = mysql.ExecuteQuery(s);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)//修改
        {
            DataRowView d = (DataRowView)this.dataGrid.SelectedItems;
            ChangeMan cm = new ChangeMan();
            cm.Show();
        }

        private async void MenuItem_Click_2(object sender, RoutedEventArgs e)//删除
        {
            MessageDialogResult result1 = await this.ShowMessageAsync("删除信息", "您真的要删除吗?", MessageDialogStyle.AffirmativeAndNegative);
            if (result1 != MessageDialogResult.Negative)//取消
            {
                DataRowView d = (DataRowView)this.dataGrid.SelectedItems[this.dataGrid.SelectedItems.Count - 1];
                string result = d.Row[0].ToString();
                string s = "delete from worker where wnum='" + result + "'";
                mysql.ExecuteUpdate(s);
                await this.ShowMessageAsync("提示", "删除成功");
                this.dt.Rows.Remove(d.Row);
            }
        }

       
    }
}
