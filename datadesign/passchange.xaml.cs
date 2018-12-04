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
using System.Data.SqlClient;
using System.Data;

namespace datadesign
{
    /// <summary>
    /// passchange.xaml 的交互逻辑
    /// </summary>
    public partial class passchange : MetroWindow
    {
        public passchange()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            IntPtr p = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(this.passwordBox.SecurePassword);
            string password = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(p);
            IntPtr p1 = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(this.passwordBox1.SecurePassword);
            string password1 = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(p1);
            MYSql mysql = new MYSql();
            if (textBox.Text == "" || password == ""||password1=="")
            {
                await this.ShowMessageAsync("提示", "信息填写不完整");
            }
            else
            {
                string username = textBox.Text.Trim();
                string s1 = "select wnum,pwd from worker where wnum='" + username + "' and pwd='" + password + "'";
                DataTable dt = new DataTable();
                dt=mysql.ExecuteQuery(s1);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string s2 = "update worker set pwd='" + password1 + "'where wnum='" + username + "'";
                    int n = mysql.ExecuteUpdate(s2);
                    if (n != 0)
                    {
                        await this.ShowMessageAsync("提示", "修改成功");
                        this.Close();
                    }
                }
                else
                {
                    await this.ShowMessageAsync("提示", "用户名或旧密码输入错误");
                }
            
            }
        }
    }
}
