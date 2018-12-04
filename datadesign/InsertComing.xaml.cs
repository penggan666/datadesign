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

namespace datadesign
{
    /// <summary>
    /// Coming.xaml 的交互逻辑
    /// </summary>
   
    public partial class Coming : MetroWindow
    {
        MYSql mysql = new MYSql();
        private MainCome maincome;
        public void setCo(MainCome m)
        {
            maincome = m;
        }
        public Coming()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)//确定
        {
            if (textBox.Text == "" || textBox1.Text == "")
                await this.ShowMessageAsync("提示", "信息填写不完整");
            else
            {
                try
                {
                    string currenttime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string name = textBox.Text;
                    string thing = textBox1.Text;
                    string build = Source.build;
                    string s = "Insert into Come values('"+build+"','"+name+"','"+currenttime+"','"+thing+"')";
                    mysql.ExecuteUpdate(s);
                    this.Close();
                    maincome.dataGrid.ItemsSource = mysql.ExecuteQuery("select ctime as '时间',name as '姓名',thing as '原因' from Come where buildingnum='" + Source.build + "'").DefaultView;//刷新新表格
                }
                catch (Exception ex)
                {
                    await this.ShowMessageAsync("错误", ex.ToString());
                }

            }
        }
    }
}
