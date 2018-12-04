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
namespace datadesign
{
    /// <summary>
    /// ChangeMan.xaml 的交互逻辑
    /// </summary>
    public partial class ChangeMan : MetroWindow
    {
        MYSql mysql = new MYSql();
        public ChangeMan()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)//修改
        {
            MessageDialogResult result1 = await this.ShowMessageAsync("修改信息", "您真的要修改吗?", MessageDialogStyle.AffirmativeAndNegative);
            if (result1 != MessageDialogResult.Negative)//取消
            {
                string s = "";
                mysql.ExecuteUpdate(s);
                await this.ShowMessageAsync("提示", "修改成功");
            }
        }
    }
}
