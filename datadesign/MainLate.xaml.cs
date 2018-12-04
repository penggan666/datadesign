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
    /// MainLate.xaml 的交互逻辑
    /// </summary>
    public partial class MainLate : MetroWindow
    {
        MYSql mysql = new MYSql();
        DataTable dt = new DataTable();
        public MainLate()
        {
            InitializeComponent();
            string s1 = "select roomnum as '寝室号',sid as '学号',time as '时间',thing as '原因' from Late where buildingnum= '" + Source.build + "'";
            dt = mysql.ExecuteQuery(s1);
            dataGrid.ItemsSource = dt.DefaultView;
            string s = "select roomnum from broom where buildingnum='" + Source.build + "'";
            comboBox.ItemsSource = mysql.ExecuteQuery(s).DefaultView;
            comboBox.DisplayMemberPath = "roomnum";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)//增加
        {
            Late l = new Late();
            l.setML(this);
            l.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)//删除
        {

        }

        private async void button_Click(object sender, RoutedEventArgs e)//学号查询
        {
            if (textBox.Text == "")
                await this.ShowMessageAsync("提示", "请输入学号");
            else {
                try
                {
                    if (datepicker.Text != "")
                    {
                        string time = Convert.ToDateTime(datepicker.Text).ToString("yyyy-MM-dd");
                        string s = "select roomnum as '寝室号',sid as '学号',time as '时间',thing as '原因' from Late where buildingnum= '" + Source.build + "'and time like'" + time + "%" + "'and sid='"+textBox.Text+"'";
                        dataGrid.ItemsSource = mysql.ExecuteQuery(s).DefaultView;
                    }
                    else
                    {
                        string s1 = "select roomnum as '寝室号',sid as '学号',time as '时间',thing as '原因' from Late where buildingnum= '" + Source.build + "'and sid='" + textBox.Text + "'";
                        dataGrid.ItemsSource = mysql.ExecuteQuery(s1).DefaultView;
                    }
                }
                catch(Exception ex)
                {
                    await this.ShowMessageAsync("错误", ex.ToString());
                }
            }

        }

        private async void button1_Click(object sender, RoutedEventArgs e)//寝室号查询
        {
            if (comboBox.Text == "")
                await this.ShowMessageAsync("提示", "请输入寝室号");
            else
            {
                try
                {
                    if (datepicker.Text != "")
                    {
                        string time = Convert.ToDateTime(datepicker.Text).ToString("yyyy-MM-dd");
                        string s = "select roomnum as '寝室号',sid as '学号',time as '时间',thing as '原因' from Late where buildingnum= '" + Source.build + "'and time like'" + time + "%" + "'and roomnum='" + comboBox.Text + "'";
                        dataGrid.ItemsSource = mysql.ExecuteQuery(s).DefaultView;
                    }
                    else
                    {
                        string s1 = "select roomnum as '寝室号',sid as '学号',time as '时间',thing as '原因' from Late where buildingnum= '" + Source.build + "'and roomnum='" + comboBox.Text + "'";
                        dataGrid.ItemsSource = mysql.ExecuteQuery(s1).DefaultView;
                    }
                }
                catch (Exception ex)
                {
                    await this.ShowMessageAsync("错误", ex.ToString());
                }
            }
        }

        private async void button2_Click(object sender, RoutedEventArgs e)//时间查询
        {
            if (datepicker.Text == "")
                await this.ShowMessageAsync("提示", "请选择日期");
            else
            {
                try
                {
                    string time = Convert.ToDateTime(datepicker.Text).ToString("yyyy-MM-dd");
                    string s="select roomnum as '寝室号',sid as '学号',time as '时间',thing as '原因' from Late where buildingnum= '" + Source.build + "'and time like'" + time + "%" + "'";
                    dataGrid.ItemsSource = mysql.ExecuteQuery(s).DefaultView;
                }
                catch (Exception ex)
                {
                    await this.ShowMessageAsync("错误", ex.ToString());
                }
            }
        }
    }
}
