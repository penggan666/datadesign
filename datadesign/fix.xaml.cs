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
    /// fix.xaml 的交互逻辑
    /// </summary>
    public partial class fix : MetroWindow
    {
        private int selected = 1;
        string buildingnum;
        DataTable dt = new DataTable();
        MYSql mysql = new MYSql();
        public fix(string buildingnum)
        {
            //buildingnum = buildingnum[2].ToString();
            InitializeComponent();
            this.buildingnum = buildingnum;
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)//未处理
        {
            selected = 1;
            string s = "select recordid as '单号',roomnum as '寝室号', content as '报修内容', redate as '报修时间' from record where buildingnum = '" + buildingnum + "' and status = '" + 1 + "'";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
        }


        private void radioButton1_Checked(object sender, RoutedEventArgs e)//已处理
        {
            selected = 2;
            string s = "select recordid as '单号',roomnum as '寝室号', content as '报修内容', redate as '报修时间' ,repairdate as '预计维修时间', record.rid as '工人号码', rname as '工人名字' from record,repairman " +
                "where buildingnum = '" + buildingnum + "' and status = '" + 2 + "' and record.rid = repairman.rid";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)//已完成
        {
            selected = 3;
            string s = "select recordid as '单号',content as '报修内容', redate as '报修时间' ,repairdate as '预计维修时间' , repaireddate as '维修完成时间' ,record.rid as '工人号码'," +
                " rname as '工人名字',oassess as '是否完成',sassess as '学生评价' from record,repairman where record.rid = repairman.rid and buildingnum = '" + buildingnum + "' and status = '" + 3 + "'";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
        }
        private async void MenuItem_Click(object sender, RoutedEventArgs e)//处理
        {
            try {
                DataRowView mySelectedElement = (DataRowView)dataGrid.SelectedItem;
                int id = Convert.ToInt32(mySelectedElement.Row[0]);
                setworker sw = new setworker(id);
                sw.setFix(this);
                sw.Show();
            }
            catch(Exception ex)
            {
                await this.ShowMessageAsync("错误", ex.ToString());
            }
        }

        private void dataGrid_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (selected == 2 || selected == 3)
            {
                e.Handled = true;
            }

        }
    }
}