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
using MahApps.Metro.Controls.Dialogs;
using System.Data;

namespace datadesign
{
    /// <summary>
    /// Exchange.xaml 的交互逻辑
    /// </summary>
    public partial class Exchange : MetroWindow
    {
        private int selected = 0;
        MYSql my = new MYSql();
        public Exchange()
        {
            InitializeComponent();
            comboBox1.ItemsSource = my.ExecuteQuery("select distinct buildingnum from broom").DefaultView;
            comboBox1.DisplayMemberPath = "buildingnum";
            comboBox2.ItemsSource = my.ExecuteQuery("select distinct buildingnum from broom").DefaultView;
            comboBox2.DisplayMemberPath = "buildingnum";


        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)//修改个人住宿信息
        {
            Label num = canvas.FindName("label3") as Label;
            ComboBox tex = canvas.FindName("comboBox2") as ComboBox;
            Label num1 = canvas.FindName("label") as Label;
            num.Visibility = Visibility.Hidden;
            tex.Visibility = Visibility.Hidden;
            num1.Content = "学号";
            selected = 1;
        }
        public bool Getin(string buildingnum, string roomnum, int type) //type等于1 判断一个人入住，等于2 判断两个人入住情况
        {
            int size;
            buildingnum = buildingnum.Replace("System.Windows.Controls.ComboBoxItem: ", "");
            MYSql mYSql = new MYSql();
            DataTable dt = mYSql.ExecuteQuery("select 'size'=count(*) from DS where buildingnum = '" + buildingnum + "' and roomnum = '" + roomnum + "'");
            if (dt.Rows.Count == 0)
            {
                size = 0;
                return true;
            }
            size = Convert.ToInt32(dt.Rows[0]["size"]);
            dt = mYSql.ExecuteQuery("select size from broom where buildingnum = '" + buildingnum + "' and roomnum = '" + roomnum + "'");
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            int maxsize = Convert.ToInt32(dt.Rows[0]["size"]);
            switch (type)
            {
                case 1:
                    if (size == maxsize)
                    {
                        return false;
                    }
                    else
                        return true;
                case 2:
                    if (size != 0)
                        return false;
                    return true;
                default:
                    break;
            }
            return false;
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)//修改整个寝室住宿信息
        {
            Label year = canvas.FindName("year") as Label;
            Label num1 = canvas.FindName("label") as Label;
            Label num2 = canvas.FindName("label1") as Label;
            Label num3 = canvas.FindName("label3") as Label;
            Label num4 = canvas.FindName("label2") as Label;
            ComboBox tex = canvas.FindName("comboBox2") as ComboBox;
            ComboBox newCombobox = canvas.FindName("comboBox1") as ComboBox;
            TextBox textBox1 = canvas.FindName("textBox1") as TextBox;
            TextBox textBox2 = canvas.FindName("textBox") as TextBox;
            TextBox yearbox = canvas.FindName("yeartextbox") as TextBox;
            num3.Visibility = Visibility.Visible;
            num1.Visibility = Visibility.Visible;
            num4.Visibility = Visibility.Visible;
            num2.Visibility = Visibility.Visible;
            textBox1.Visibility = Visibility.Visible;
            textBox2.Visibility = Visibility.Visible;
            tex.Visibility = Visibility.Visible;
            newCombobox.Visibility = Visibility.Visible;
            year.Visibility = Visibility.Hidden;
            yearbox.Visibility = Visibility.Hidden;
            num1.Content = "旧寝室号";
            selected = 2;
        }
        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            Label year = canvas.FindName("year") as Label;
            Label label = canvas.FindName("label1") as Label;
            Label num = canvas.FindName("label3") as Label;
            Label num1 = canvas.FindName("label") as Label;
            Label num2 = canvas.FindName("label2") as Label;
            TextBox yearbox = canvas.FindName("yeartextbox") as TextBox;
            TextBox textBox = canvas.FindName("textBox") as TextBox;
            TextBox textBox1 = canvas.FindName("textBox1") as TextBox;
            ComboBox tex1 = canvas.FindName("comboBox1") as ComboBox;
            ComboBox tex = canvas.FindName("comboBox2") as ComboBox;

            num2.Visibility = Visibility.Hidden;
            num.Visibility = Visibility.Hidden;
            label.Visibility = Visibility.Hidden;
            num1.Visibility = Visibility.Hidden;
            textBox.Visibility = Visibility.Hidden;
            textBox1.Visibility = Visibility.Hidden;
            tex1.Visibility = Visibility.Hidden;
            tex.Visibility = Visibility.Hidden;

            year.Visibility = Visibility.Visible;
            yearbox.Visibility = Visibility.Visible;
            selected = 3;
        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            GetInfo getInfo = new GetInfo();
            string sid = textBox.Text.Trim();
            string newroomnum = textBox1.Text.Trim();


            MYSql mysql = new MYSql();
            string s;
            if (selected == 0 || selected == 2 || selected == 1)
            {
                if (newroomnum == "" || sid == "")
                    await this.ShowMessageAsync("提示", "您还有属性未填写");
                else
                {
                    if (selected == 0)
                    {
                        await this.ShowMessageAsync("提示", "请先选择更改属性");
                    }
                    if (selected == 1)//修改个人
                    {
                        string newbuildingnum = comboBox1.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                        if (Getin(newbuildingnum, newroomnum, 1))
                        {
                            s = "update DS set buildingnum = '" + newbuildingnum + "' ,roomnum = '" + newroomnum + "' where sid = '" + sid + "'";//sql语句
                            MessageDialogResult result = await this.ShowMessageAsync("更改信息", "您真的要修改吗?", MessageDialogStyle.AffirmativeAndNegative);
                            if (result != MessageDialogResult.Negative)//取消
                            {
                                if (getInfo.setin(sid, newbuildingnum))
                                {

                                    try
                                    {
                                        mysql.ExecuteUpdate(s);
                                        await this.ShowMessageAsync("提示", "修改成功");
                                        this.Close();
                                    }
                                    catch
                                    {
                                        await this.ShowMessageAsync("提示", "无此寝室号");
                                    }
                                }
                                else
                                {
                                    await this.ShowMessageAsync("提示", "不同性别学生不能安排在同一寝室");

                                }
                            }

                        }
                        else
                        {
                            await this.ShowMessageAsync("提示", "寝室无空余床位或是无此寝室号");
                        }
                    }
                    if (selected == 2)//修改整个寝室
                    {
                        string newbuildingnum = comboBox1.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                        string oldbuildingnum = comboBox2.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                        if (Getin(newbuildingnum, newroomnum, 2))
                        {
                            s = "update DS set buildingnum = '" + newbuildingnum + "',roomnum = '" + newroomnum + "'where buildingnum ='" + sid + "'and roomnum ='" + oldbuildingnum + "'";
                            MessageDialogResult result = await this.ShowMessageAsync("更改信息", "您真的要修改吗?", MessageDialogStyle.AffirmativeAndNegative);
                            if (result != MessageDialogResult.Negative)//取消
                            {
                                if ((Convert.ToInt32(newbuildingnum) % 2) != (Convert.ToInt32(oldbuildingnum) % 2))
                                {
                                    await this.ShowMessageAsync("提示", "不同性别不能安排在同一个寝室楼");
                                }
                                else
                                {
                                    try
                                    {
                                        mysql.ExecuteUpdate(s);
                                        await this.ShowMessageAsync("提示", "修改成功");
                                        this.Close();
                                    }
                                    catch
                                    {
                                        await this.ShowMessageAsync("提示", "无此寝室号");
                                    }
                                }
                            }

                        }
                        else
                        {
                            await this.ShowMessageAsync("提示", "寝室无空余床位或是无此寝室号");
                        }
                    }


                }
            }
            else if (selected == 3)
            {
                string year = yeartextbox.Text;
                if (year == "")
                    await this.ShowMessageAsync("提示", "请输入年份");
                else
                {
                    AGSI gs = new AGSI(year);

                    try
                    {
                        Progress1.IsActive = true;
                        gs.DAlloc();
                        Progress1.IsActive = false;
                        await this.ShowMessageAsync("提示", "完成");

                    }
                    catch (Exception ex)
                    {
                        await this.ShowMessageAsync("异常", ex.ToString());
                    }

                    this.Close();
                }
            }
        }
    }
}
