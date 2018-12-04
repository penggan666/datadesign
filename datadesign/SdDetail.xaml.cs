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
        List<String> list = new List<string>();

        public SdDetail()
        {
            InitializeComponent();
            string s = "select student.sid as '学号',student.sname as '姓名',student.Ssex as '性别',student.scollege as '学院',DS.buildingnum as '栋号',DS.roomnum as '寝室号' from student,DS where student.sid=DS.sid";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
            string s1 = "select distinct scollege from student";
            DataTable d1 = mysql.ExecuteQuery(s1);
            comboBox1.ItemsSource = d1.DefaultView;
            comboBox1.DisplayMemberPath = "scollege";
            string s2 = "select distinct buildingnum from broom";
            DataTable d2 = mysql.ExecuteQuery(s2);
            for (int i = 0; i < d2.Rows.Count; i++)
            {
                string r = d2.Rows[i][0].ToString();
                list.Add(r);
            }
            comboBox.ItemsSource = list;

        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ss = comboBox.SelectedValue.ToString();
            string s1 = "select roomnum from broom where buildingnum='" + ss + "'";
            DataTable d = mysql.ExecuteQuery(s1);
            comboBox3.ItemsSource = d.DefaultView;
            comboBox3.DisplayMemberPath = "roomnum";
        }
        private async void button_Click(object sender, RoutedEventArgs e)//学号查询
        {
            if (textBox.Text == "")
                await this.ShowMessageAsync("提示", "请输入学号");
            else
            {
                string no = textBox.Text;
                string s = "select student.sid as '学号',student.sname as '姓名',student.Ssex as '性别',student.scollege as '学院',DS.buildingnum as '栋号',DS.roomnum as '寝室号' from student,DS where student.sid=DS.sid and student.sid='" + no + "'";
                dt = mysql.ExecuteQuery(s);
                dataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private async void button1_Click(object sender, RoutedEventArgs e)//学院查询
        {
            string college = comboBox1.Text;
            if (college == "")
                await this.ShowMessageAsync("提示", "请选择学院");
            else
            {
                string s = "select student.sid as '学号',student.sname as '姓名',student.Ssex as '性别',student.scollege as '学院',DS.buildingnum as '栋号',DS.roomnum as '寝室号' from student,DS where student.sid=DS.sid and student.scollege = '" + college + "'";
                dt = mysql.ExecuteQuery(s);
                dataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private async void button2_Click(object sender, RoutedEventArgs e)//栋号查询
        {
            string buildingnum = comboBox.Text;
            if (buildingnum == "")
                await this.ShowMessageAsync("提示", "请选择栋号");
            else
            {
                string s = "select student.sid as '学号',student.sname as '姓名',student.Ssex as '性别',student.scollege as '学院',DS.buildingnum as '栋号',DS.roomnum as '寝室号' from student,DS where student.sid=DS.sid and buildingnum = '" + buildingnum + "'";
                dt = mysql.ExecuteQuery(s);
                dataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private async void button3_Click(object sender, RoutedEventArgs e)//寝室号查询
        {
            if (comboBox.Text == "" || comboBox3.Text == "")
                await this.ShowMessageAsync("提示", "检索信息不完整 请选择栋号和寝室号");
            else
            {
                string s = "select student.sid as '学号',student.sname as '姓名',student.Ssex as '性别',student.scollege as '学院',DS.buildingnum as '栋号',DS.roomnum as '寝室号' from student,DS where student.sid=DS.sid and buildingnum = '" + comboBox.Text + "'and roomnum='"+comboBox3.Text+"'";
                dt = mysql.ExecuteQuery(s);
                dataGrid.ItemsSource = dt.DefaultView;
            }
        }
        private async void button4_Click(object sender, RoutedEventArgs e)//入住时间查询
        {
            string year = comboBox2.Text;
            if (year == "")
                await this.ShowMessageAsync("提示", "请选择入住时间");
            else
            {
                try
                {
                    string s = "select student.sid as '学号',student.sname as '姓名',student.Ssex as '性别',student.scollege as '学院',DS.buildingnum as '栋号',DS.roomnum as '寝室号' from student,DS where student.sid=DS.sid and livetime = '" + year + "'";
                    dt = mysql.ExecuteQuery(s);
                    dataGrid.ItemsSource = dt.DefaultView;
                }
                catch (Exception ex)
                {
                    await this.ShowMessageAsync("提示", ex.ToString());
                }

            }
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
