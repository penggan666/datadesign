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
    /// addDor.xaml 的交互逻辑
    /// </summary>
    public partial class addDor : MetroWindow
    {
        public addDor()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)//增加寝室
        {
            string buildingnum = textBox.Text;
            string roomnum = textBox1.Text;
            string sex = textBox3.Text;
            int size;
            if (buildingnum == "" || roomnum == "" || sex == "" || textBox2.Text == "")
            {
                await this.ShowMessageAsync("提示", "请输入完整信息");
            }
            //性别选项
            try
            {
                size = Convert.ToInt32(textBox2.Text);
                string s = "insert into DS(buildingnum,roomnum,brsex,size)values('" + buildingnum + "','" + sex + "','" + roomnum + "','" + size + "')";
                MYSql mYSql = new MYSql();
                try
                {
                    mYSql.ExecuteQuery(s);
                    await this.ShowMessageAsync("提示", "修改成功");
                }
                catch
                {
                    await this.ShowMessageAsync("提示", "已存在该宿舍");
                }
            }
            catch
            {
                await this.ShowMessageAsync("提示", "数据未按格式输入");
            }
        }
    }
}
