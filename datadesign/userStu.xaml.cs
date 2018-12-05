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
using MahApps.Metro.Controls.Dialogs;

namespace datadesign
{
    /// <summary>
    /// userStu.xaml 的交互逻辑
    /// </summary>
    public partial class userStu : MetroWindow
    {
        MYSql mysql = new MYSql();
        DataTable dt = new DataTable();
        List<String> list = new List<string>();
        public userStu()
        {
            InitializeComponent();
            string s = "select student.sid as '学号',student.sname as '姓名',student.Ssex as '性别',student.scollege as '学院',DS.buildingnum as '栋号',DS.roomnum as '寝室号' from student,DS where student.sid=DS.sid and DS.buildingnum='"+Source.build+"'";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
            string s1 = "select distinct scollege from student,DS where buildingnum='" + Source.build + "'and student.sid=DS.sid";
            DataTable d1 = mysql.ExecuteQuery(s1);
            comboBox.ItemsSource = d1.DefaultView;
            comboBox.DisplayMemberPath = "scollege";
            string s2 = "select roomnum from broom where buildingnum='"+Source.build+"'";
            DataTable d2 = mysql.ExecuteQuery(s2);
            comboBox1.ItemsSource = d2.DefaultView;
            comboBox1.DisplayMemberPath = "roomnum";
        }

        private async void button_Click(object sender, RoutedEventArgs e)//学号查询
        {
            if (textBox.Text == "")
                await this.ShowMessageAsync("提示", "请输入学号");
            else
            {
                string no = textBox.Text;
                string s = "select * from student,DS where student.sid=DS.sid and student.sid='" + no + "'and buildingnum='"+Source.build+"'";
                dt = mysql.ExecuteQuery(s);
                dataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private async void button1_Click(object sender, RoutedEventArgs e)//学院查询
        {
            string college = comboBox.Text;
            if (college == "")
                await this.ShowMessageAsync("提示", "请选择学院");
            else
            {
                string s = "select student.sid as '学号',student.sname as '姓名',student.Ssex as '性别',student.scollege as '学院',DS.buildingnum as '栋号',DS.roomnum as '寝室号' from student,DS where student.sid=DS.sid and student.scollege = '" + college + "'and buildingnum='"+Source.build+"'";
                dt = mysql.ExecuteQuery(s);
                dataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private async void button3_Click(object sender, RoutedEventArgs e)//寝室号查询
        {
            if (comboBox1.Text == "")
                await this.ShowMessageAsync("提示", "检索信息不完整 请选择栋号和寝室号");
            else
            {
                string s = "select student.sid as '学号',student.sname as '姓名',student.Ssex as '性别',student.scollege as '学院',DS.buildingnum as '栋号',DS.roomnum as '寝室号' from student,DS where student.sid=DS.sid and buildingnum = '" + Source.build + "'and roomnum='" + comboBox1.Text + "'";
                dt = mysql.ExecuteQuery(s);
                dataGrid.ItemsSource = dt.DefaultView;
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)//入住时间查询
        {

        }
    }
}
