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

namespace datadesign
{
    /// <summary>
    /// usreDor.xaml 的交互逻辑
    /// </summary>
    public partial class usreDor : MetroWindow
    {
        MYSql mysql = new MYSql();
        string s = "select broom.buildingnum as '栋号',broom.roomnum as '寝室号',brsex as '女寝or男寝',size as '寝室大小',count(sid) as '实际人数' from DS,broom where DS.buildingnum=broom.buildingnum and DS.roomnum=broom.roomnum and broom.buildingnum='" + Source.build + "'group by broom.buildingnum,broom.roomnum,size,brsex";
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dta = new DataTable();//赋值dt表中的数据，以便进行查询
        public usreDor()
        {
            InitializeComponent();
            dt = mysql.ExecuteQuery(s);
            string s1 = "select buildingnum,roomnum,brsex,size from broom where buildingnum+roomnum not in(select buildingnum+roomnum from DS) and buildingnum='"+Source.build+"'";
            dt1 = mysql.ExecuteQuery(s1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dRow = dt.NewRow();
                dRow[0] = dt1.Rows[i][0];
                dRow[1] = dt1.Rows[i][1];
                dRow[2] = dt1.Rows[i][2];
                dRow[3] = dt1.Rows[i][3];
                dRow[4] = 0;
                dt.Rows.Add(dRow);
            }
            dataGrid.ItemsSource = dt.DefaultView;
            dta.Columns.Add("栋号");
            dta.Columns.Add("寝室号");
            dta.Columns.Add("女寝or男寝");
            dta.Columns.Add("寝室大小");
            dta.Columns.Add("实际人数");
        }

        private void button1_Click(object sender, RoutedEventArgs e)//寝室号查询
        {

        }
    }
}
