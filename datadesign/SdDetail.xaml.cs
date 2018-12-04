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
using System.Data;
using System.Data.SqlClient;
using MahApps.Metro.Controls.Dialogs;

namespace datadesign
{
    /// <summary>
    /// SdDetail.xaml 的交互逻辑
    /// </summary>
    public partial class SdDetail : MetroWindow
    {
        MYSql mysql = new MYSql();
        DataTable dt = new DataTable();

        public SdDetail()
        {
            InitializeComponent();
            string s = "select student.sid as '学号',student.sname as '姓名',student.Ssex as '性别',student.scollege as '学院',DS.buildingnum as '栋号',DS.roomnum as '寝室号' ,DS.livetime as '入住时间' from student,DS where student.sid=DS.sid";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;

        }

        private void button_Click(object sender, RoutedEventArgs e)//学号查询
        {
            string no = textBox.Text;
            string s = "select * from student,DS where student.sid=DS.sid and student.sid='"+no+"'";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void button1_Click(object sender, RoutedEventArgs e)//学院查询
        {
            string college = textBox1.Text;
            string s = "select * from student,DS where student.sid = DS.sid and student.scollege = '" + college + "'";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void button2_Click(object sender, RoutedEventArgs e)//栋号查询
        {
            string buildingnum = comboBox.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""); 
            Console.Write(buildingnum);
            string s = "select * from DS where buildingnum = '" + buildingnum + "'";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void button3_Click(object sender, RoutedEventArgs e)//寝室号查询
        {
            string roomnum = textBox2.Text;
            string s = "select * from DS where roomnum = '" + roomnum + "'";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
        }
        private void button4_Click(object sender, RoutedEventArgs e)//入住时间查询
        {
            string year = textBox3.Text;
            string s = "select * from DS where livetime = '" + year + "'";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private async void MenuItem_Click(object sender, RoutedEventArgs e)//删除住宿信息
        {
            MessageDialogResult result1=await this.ShowMessageAsync("删除信息", "您真的要删除吗?", MessageDialogStyle.AffirmativeAndNegative);
            if (result1 != MessageDialogResult.Negative)//取消
            {
                DataRowView d = (DataRowView)this.dataGrid.SelectedItems[this.dataGrid.SelectedItems.Count - 1];
                string result = d.Row[0].ToString();
                string s = "delete from DS where sid='" + result + "'";
                mysql.ExecuteUpdate(s);
                await this.ShowMessageAsync("提示", "删除成功");
                this.dt.Rows.Remove(d.Row);
            }

        }
        
    }
}
