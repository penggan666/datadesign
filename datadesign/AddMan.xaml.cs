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
    /// AddMan.xaml 的交互逻辑
    /// </summary>
    public partial class AddMan : MetroWindow
    {
        private ManageUd man;
        public void setMan(ManageUd u)
        {
            man = u;
        }
        public AddMan()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)//添加
        {
            string buildingnum;
            string wnum;
            GetInfo g = new GetInfo();
            buildingnum = comboBox.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
            int num = g.getMnum(buildingnum) + 1;
            wnum = "00" + buildingnum + "00" + num.ToString();
            string wname = textBox1.Text;
            string pwd = "111111";
            labelwnum.Content = wnum;
            string s = "insert into worker(wnum,wname,bnum,pwd)values('" + wnum + "','" + wname + "','" + buildingnum + "','" + pwd + "')";
            if (wname == "" || buildingnum == "")
            {
                await this.ShowMessageAsync("提示", "请输入完整的信息");
            }
            MYSql mYSql = new MYSql();
            try
            {
                mYSql.ExecuteQuery(s);
                await this.ShowMessageAsync("提示", "插入成功,新的工号是" + wnum);
                man.dataGrid.ItemsSource = mYSql.ExecuteQuery("select wnum as '工号',wname as '姓名',bnum as '管理栋号' from worker").DefaultView;
                this.Close();
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("提示", "未插入成功，已有此工号" + ex);
            }
        }
    }
}
