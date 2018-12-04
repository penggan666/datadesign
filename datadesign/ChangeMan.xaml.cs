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
using MahApps.Metro.Controls;
using System.Data;

namespace datadesign
{
    /// <summary>
    /// ChangeMan.xaml 的交互逻辑
    /// </summary>
    public partial class ChangeMan : MetroWindow
    {
        private ManageUd man;
        public void SetMange(ManageUd u)
        {
            man = u;
        }
        MYSql mysql = new MYSql();
        public int selected = 0;
        public ChangeMan()
        {
            InitializeComponent();
            string s = "select distinct buildingnum from broom";
            DataTable dt = mysql.ExecuteQuery(s);
            comboBox.ItemsSource = dt.DefaultView;
            comboBox.DisplayMemberPath = "buildingnum";
        }

        private async void button_Click(object sender, RoutedEventArgs e)//修改
        {
            string ss = comboBox.Text;
            if (ss == "")
                await this.ShowMessageAsync("提示", "请选择栋号");
          
            else
            {
                MessageDialogResult result1 = await this.ShowMessageAsync("修改信息", "您真的要修改吗?", MessageDialogStyle.AffirmativeAndNegative);
                if (result1 != MessageDialogResult.Negative)//取消
                {
                    string s = "update worker set bnum='" + ss + "'where wnum='" + label3.Content + "'";
                    mysql.ExecuteUpdate(s);
                    await this.ShowMessageAsync("提示", "修改成功");
                    man.dataGrid.ItemsSource = mysql.ExecuteQuery("select wnum as '工号',wname as '姓名',bnum as '管理栋号' from worker").DefaultView;
                    this.Close();
                }
            }
        }
    }
}
