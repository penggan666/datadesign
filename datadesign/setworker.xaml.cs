using System;
using System.Collections.Generic;
using System.Data;
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
    /// setworker.xaml 的交互逻辑
    /// </summary>
    public partial class setworker : MetroWindow
    {
        int id;
        MYSql mysql = new MYSql();
        private fix f;
        public void setFix(fix f)
        {
            this.f = f;
        }
        public DataTable getRepairman()
        {
            MYSql mYSql = new MYSql();
            DataTable dt = new DataTable();
            dt = mYSql.ExecuteQuery("select rid from repairman");
            return dt;
        }
        public setworker(int id)
        {
            InitializeComponent();
            recomboBox.ItemsSource = getRepairman().DefaultView;
            recomboBox.DisplayMemberPath = "rid";
            this.id = id;
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            string time = Convert.ToDateTime(datepicker.Text).ToString("yyyy-MM-dd");
            string rid = recomboBox.Text;
            string sql = "update record set repairdate = '" + time + "',rid = '" + rid + "' ,status = '" + 2 + "' where recordid = '" + id + "'";
            try
            {
                mysql.ExecuteUpdate(sql);
                await this.ShowMessageAsync("提示", "成功安排修理工作");
                f.dataGrid.ItemsSource = mysql.ExecuteQuery("select recordid as '单号', roomnum as '寝室号', content as '报修内容', redate as '报修时间' from record where buildingnum = '" + Source.build + "' and status = '" + 1 + "'").DefaultView;
                this.Close();
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("提示", ex.ToString());
            }

        }
    }
}