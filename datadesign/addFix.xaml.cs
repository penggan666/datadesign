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
    /// addFix.xaml 的交互逻辑
    /// </summary>
    public partial class addFix : MetroWindow
    {
        private string buildingnum;
        private string roomnum;
        private StuMain stu;
        public void setStu(StuMain stu)
        {
            this.stu = stu;
        }

        public addFix(string buildingnum, string roomnum)
        {
            InitializeComponent();
            this.buildingnum = buildingnum;
            this.roomnum = roomnum;
        }
        public string toStd(int date)
        {
            string month;
            if (date < 10)
            {
                month = date.ToString("0#");
            }
            else
            {
                month = date.ToString();
            }
            return month;
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            string info = infoBox.Text;
            string time;
            System.DateTime dateTime = new System.DateTime();
            dateTime = System.DateTime.Now;
            time = dateTime.Year.ToString() + "-" + toStd(dateTime.Month) + "-" + toStd(dateTime.Day);
            MYSql mYSql = new MYSql();
            string sql = "insert into record(content,buildingnum,roomnum,status,redate)values('" + info + "','" + buildingnum + "','" + roomnum + "','" + 1 + "','" + time + "')";
            try
            {
                mYSql.ExecuteQuery(sql);
                await this.ShowMessageAsync(buildingnum + "栋" + roomnum + "号寝室", "您的信息已提交");
                stu.dataGrid.ItemsSource = mYSql.ExecuteQuery("select recordid as '单号',content as '报修内容', redate as '报修时间' from record where buildingnum = '" + buildingnum + "' and roomnum = '" + roomnum + "' and status = '" + 1 + "'").DefaultView;
                this.Close();
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("提示",ex.ToString());
            }
        }
    }
}