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
    /// DorChange.xaml 的交互逻辑
    /// </summary>
    public partial class DorChange : MetroWindow
    {
        private int selected = 1;
        MYSql mysql = new MYSql();
        List<string> sex = new List<string>();
        List<string> size = new List<string>();
        public DorChange()
        {
            InitializeComponent();
            comboBox.ItemsSource = mysql.ExecuteQuery("select distinct buildingnum from broom").DefaultView;
            comboBox.DisplayMemberPath = "buildingnum";
            sex.Add("男生宿舍");
            sex.Add("女生宿舍");
            size.Add("4");
            size.Add("6");
            comboBox1.ItemsSource = sex;
            comboBox2.ItemsSource = size;

        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)//删除
        {
            selected = 2;
            label.Visibility = Visibility.Visible;
            comboBox.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Hidden;
            comboBox1.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Hidden;
            comboBox2.Visibility = Visibility.Hidden;
            label3.Visibility = Visibility.Hidden;
            textBox.Visibility = Visibility.Hidden;
            label2_Copy.Visibility = Visibility.Hidden;
            textBox1.Visibility = Visibility.Hidden;
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)//新建
        {
            selected = 3;
            label.Visibility = Visibility.Hidden;
            comboBox.Visibility = Visibility.Hidden;
            label1.Visibility = Visibility.Visible;
            comboBox1.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
            comboBox2.Visibility = Visibility.Visible;
            label3.Visibility = Visibility.Visible;
            textBox.Visibility = Visibility.Visible;
            label2_Copy.Visibility = Visibility.Visible;
            textBox1.Visibility = Visibility.Visible;
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if(selected==1)
            {
                await this.ShowMessageAsync("提示", "请先选择操作类型");
            }
            if (selected == 2)
            {
                if (comboBox.Text == "")
                    await this.ShowMessageAsync("提示", "请选择要删除的栋号");
                else
                {
                    string s = "select * from DS where buildingnum='" + comboBox.Text + "'";
                    DataTable d = mysql.ExecuteQuery(s);
                    if (d.Rows.Count != 0)
                    {
                        await this.ShowMessageAsync("提示", "该寝室楼有人入住，不能删除");
                    }
                    else
                    {
                        MessageDialogResult result = await this.ShowMessageAsync("删除信息", "您真的要删除该寝室楼信息吗?", MessageDialogStyle.AffirmativeAndNegative);
                        if (result != MessageDialogResult.Negative)
                        {
                            mysql.ExecuteUpdate("delete from broom where buildingnum='" + comboBox.Text + "'");
                            await this.ShowMessageAsync("提示", "删除成功");
                            this.Close();
                        }
                    }
                }
            }
            if(selected==3)
            {
                Progress1.IsActive = true;
                DataTable d = mysql.ExecuteQuery("select MAX(buildingnum) from broom");
                int buildingnum = int.Parse(d.Rows[0][0].ToString())+1;
                string b = buildingnum.ToString();
                string brsex = comboBox1.Text;
                string size = comboBox2.Text;
                int Size = int.Parse(size);
                int num = int.Parse(textBox.Text);//层数
                int num1 = int.Parse(textBox1.Text);//每层房间数
                for(int i=1;i<= num;i++)
                {
                    for(int j=1;j<=num1;j++)
                    {
                        int temp = i * 100 + j;
                        string t = temp.ToString();
                        mysql.ExecuteUpdate("insert into broom values('" + b + "','" + t + "','" + brsex + "','" + Size + "')");
                    }
                }
                Progress1.IsActive = false;
                await this.ShowMessageAsync("提示", "成功");
                this.Close();
            }


        }
    }
}
