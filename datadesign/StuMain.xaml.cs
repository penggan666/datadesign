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
    /// StuMain.xaml 的交互逻辑
    /// </summary>
    public partial class StuMain : MetroWindow
    {
        private int selected = 1;
        string buildingnum;
        string roomnum;
        DataTable dt = new DataTable();
        MYSql mysql = new MYSql();
        public StuMain(string buildingnum, string roomnum)
        {
            InitializeComponent();
            this.buildingnum = buildingnum;
            this.roomnum = roomnum;
        }
        public string getB()
        {
            return buildingnum;
        }
        public string getR()
        {
            return roomnum;
        }
        private void button_Click(object sender, RoutedEventArgs e)//添加报修
        {
            addFix af = new addFix(buildingnum, roomnum);
            af.setStu(this);
            af.Show();
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)//未处理
        {
            selected = 1;
            string s = "select recordid as '单号',content as '报修内容', redate as '报修时间' from record where buildingnum = '" + buildingnum + "' and roomnum = '" + roomnum + "' and status = '" + 1 + "'";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)//正在处理
        {
            selected = 2;
            string s = "select recordid as '单号',content as '报修内容', redate as '报修时间', repairdate as '预计维修时间' " +
                "from record where buildingnum = '" + buildingnum + "' and roomnum = '" + roomnum + "' and status = '" + 2 + "'";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)//已完成
        {
            selected = 3;
            string s = "select recordid as '单号',content as '报修内容', redate as '报修时间',repairdate as '预计维修时间',repaireddate as '完成维修时间',oassess as '是否完成',sassess as '评价'" +
                "from record where buildingnum = '" + buildingnum + "' and roomnum = '" + roomnum + "' and status = '" + 3 + "'";
            dt = mysql.ExecuteQuery(s);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private async void MenuItem_Click(object sender, RoutedEventArgs e)//确认修理，并且评价
        {
            try {
                DataRowView mySelectedElement = (DataRowView)dataGrid.SelectedItem;
                string rid = mySelectedElement.Row[0].ToString();
                Assess assess = new Assess(rid);
                assess.setStu(this);
                assess.Show();
                //string s = "select recordid as '单号',content as '报修内容', redate as '保修时间', repairdate as '预计维修时间' " +
                //    "from record where buildingnum = '" + buildingnum + "' and roomnum = '" + roomnum + "' and status = '" + 2 + "'";
                //dt = mysql.ExecuteQuery(s);
                //dataGrid.ItemsSource = dt.DefaultView;
            }
            catch(Exception ex)
            {
                await this.ShowMessageAsync("错误", ex.ToString());
            }
        }

        private void dataGrid_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (selected == 1 || selected == 3)
            {
                e.Handled = true;
            }

        }
    }
}