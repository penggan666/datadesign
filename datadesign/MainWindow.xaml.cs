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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Data.SqlClient;
using System.Data;

namespace datadesign
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private int selected = 0;
                            MYSql mysql = new MYSql();
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            IntPtr p = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(this.passid.SecurePassword);
            string password = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(p);
            if (userid.Text == "" || password == "")
            {
                await this.ShowMessageAsync("提示", "用户名和密码不能为空");
            }
            else
            {
                if (selected == 0)
                    await this.ShowMessageAsync("提示", "请选择登陆属性");
                if (selected == 1)//弹出普通用户界面
                {
                    string username = userid.Text.Trim();//账号
                    string pw = password; ;//密码
                    string s1 = "select wnum,pwd,bnum from worker where wnum='" + username + "' and pwd='" + password + "'";

                    DataTable dt = new DataTable();
                    dt = mysql.ExecuteQuery(s1);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        userMain u = new userMain();
                        Source.build = dt.Rows[0][2].ToString();
                        this.Close();
                        u.Show();
                    }
                    else
                        await this.ShowMessageAsync("提示", "用户名或密码错误");
                }
                if (selected == 2)//弹出管理员界面
                {
                    if (userid.Text == "admin" && password == "admin")
                    {
                        manmain man = new manmain();
                        this.Close();
                        man.Show();
                    }
                    else
                        await this.ShowMessageAsync("提示", "用户名或密码错误");
                }
            }
            //userMain u = new userMain();
            //this.Close();
            //u.Show();
            //manmain man= new manmain();
            //this.Close();
            //man.Show();
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            selected = 1;
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            selected = 2;
        }

        private void label1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            passchange ch = new passchange();
            ch.Show();
        }
    }
}
