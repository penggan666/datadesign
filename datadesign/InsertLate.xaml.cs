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
    /// 晚归人员的交互逻辑
    /// </summary>
    public partial class Late : MetroWindow
    {
        MYSql mysql = new MYSql();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        List<String> list = new List<string>();
        private MainLate mainlate;
        public void setML(MainLate m)
        {
            mainlate = m;
        }
        public Late()
        {
            InitializeComponent();

            string s = "select roomnum from broom where buildingnum ='" + Source.build + "'";
            dt = mysql.ExecuteQuery(s);

            for(int i=0;i<dt.Rows.Count;i++)
            {
                string r = dt.Rows[i][0].ToString();
                list.Add(r);

            }
            comboBox.ItemsSource = list;


        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.Text == "" || comboBox1.Text == "" || textBox2.Text == "")
                await this.ShowMessageAsync("提示", "信息填写不完整");
            else
            {
                try {
                    string build = Source.build;
                    string roomnum = comboBox.Text;
                    string sid = comboBox1.Text;
                    string nowtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string thing = textBox2.Text;
                    string s = "Insert into Late values('" + build + "','" + roomnum + "','" + sid + "','" + nowtime + "','"+thing+"')";
                    mysql.ExecuteUpdate(s);
                    this.Close();
                    mainlate.dataGrid.ItemsSource = mysql.ExecuteQuery("select roomnum as '寝室号',sid as '学号',time as '时间',thing as '原因' from Late where buildingnum= '" + Source.build + "'").DefaultView;//刷新表格
                }
                catch(Exception ex)
                {
                    await this.ShowMessageAsync("错误", ex.ToString());
                }
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ss = comboBox.SelectedValue.ToString();
            string s1 = "select sid from DS where buildingnum='" + Source.build + "'and roomnum='" + ss + "'";
            dt1 = mysql.ExecuteQuery(s1);
            comboBox1.ItemsSource = dt1.DefaultView;
            comboBox1.DisplayMemberPath = "sid";
        }

    }
}
