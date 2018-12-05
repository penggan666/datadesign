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
using System.Data;
using MahApps.Metro.Controls.Dialogs;
namespace datadesign
{
    /// <summary>
    /// DrMain.xaml 的交互逻辑
    /// </summary>
    public partial class DrMain : MetroWindow
    {
        MYSql mysql = new MYSql();
        List<String> list = new List<string>();
        string s = "select broom.buildingnum as '栋号',broom.roomnum as '寝室号',brsex as '女寝or男寝',size as '寝室大小',count(sid) as '实际人数' from DS,broom where DS.buildingnum=broom.buildingnum and DS.roomnum=broom.roomnum group by broom.buildingnum,broom.roomnum,size,brsex";
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dta = new DataTable();//赋值dt表中的数据，以便进行查询
        public void first()
        {

            dt = mysql.ExecuteQuery(s);
            string s1 = "select buildingnum,roomnum,brsex,size from broom where buildingnum+roomnum not in(select buildingnum+roomnum from DS)";
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
        public DrMain()
        {
            InitializeComponent();
            first();
            DataTable d = mysql.ExecuteQuery("select distinct buildingnum from broom");
            for (int i = 0; i < d.Rows.Count; i++)
            {
                list.Add(d.Rows[i][0].ToString());
            }
            comboBox.ItemsSource = list;    
        }

        private async void button1_Click(object sender, RoutedEventArgs e)//根据寝室号进行查看
        {
            if (comboBox.Text != "")
            {
                dta.Clear();
                DataRow drcalc;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0].ToString() == comboBox.Text)
                    {
                        drcalc = dta.NewRow();
                        drcalc.ItemArray = dr.ItemArray;
                        dta.Rows.Add(drcalc);
                    }
                }
                dataGrid.ItemsSource = dta.DefaultView;
            }
            else
            {
                await this.ShowMessageAsync("提示", "请选择查询栋号");
            }      
        }

        private async void button2_Click(object sender, RoutedEventArgs e)//根据栋号进行查看
        {
            if (comboBox.Text != "" && comboBox1.Text != "")
            {
                dta.Clear();
                DataRow drcalc;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0].ToString() == comboBox.Text && dr[1].ToString() == comboBox1.Text)
                    {
                        drcalc = dta.NewRow();
                        drcalc.ItemArray = dr.ItemArray;
                        dta.Rows.Add(drcalc);
                    }
                }
                dataGrid.ItemsSource = dta.DefaultView;
            }
            else
                await this.ShowMessageAsync("提示", "内容填写不完整");
                
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)//新增寝室
        {
            addDor a = new addDor();
            a.Show();
        }

        private async void MenuItem_Click_1(object sender, RoutedEventArgs e)//删除寝室
        {
            DataRowView d = (DataRowView)this.dataGrid.SelectedItems[this.dataGrid.SelectedItems.Count - 1];
            if (d.Row[4].ToString() != "0")
            {
                await this.ShowMessageAsync("提示", "该寝室不可删除");
            }
            else
            {
                MessageDialogResult result1 = await this.ShowMessageAsync("删除信息", "您真的要删除吗?", MessageDialogStyle.AffirmativeAndNegative);
                if (result1 != MessageDialogResult.Negative)//取消
                {
                    string result2 = d.Row[0].ToString();
                    string result3 = d.Row[1].ToString();
                    String s = "delete from broom where buildingnum = '" + result2 + "' and roomnum = '" + result3 + "'";
                    mysql.ExecuteUpdate(s);
                    await this.ShowMessageAsync("提示", "删除成功");
                    this.dt.Rows.Remove(d.Row);
                }
            }

        }

        private async void MenuItem_Click_2(object sender, RoutedEventArgs e)//给该寝室增加人员
        {
            DataRowView mySelectedElement = (DataRowView)dataGrid.SelectedItem;
            string oldbuildingnum = mySelectedElement.Row[0].ToString();
            string oldroomnum = mySelectedElement.Row[1].ToString();
            string sex = mySelectedElement.Row[2].ToString();
            int maxsize = Convert.ToInt32(mySelectedElement.Row[3].ToString());
            int asize = Convert.ToInt32(mySelectedElement.Row[4].ToString());
            if (asize == maxsize)
                await this.ShowMessageAsync("提示", "该寝室已经满员");
            else
            {
                InsertS i = new InsertS(oldbuildingnum, oldroomnum, sex, maxsize, asize);
                i.Show();
                i.SetDr(this);
            }


        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ss = comboBox.SelectedValue.ToString();
            string s1 = "select roomnum from broom where buildingnum='" + ss + "'";
            DataTable d = mysql.ExecuteQuery(s1);
            comboBox1.ItemsSource = d.DefaultView;
            comboBox1.DisplayMemberPath = "roomnum";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DorChange dc = new DorChange();
            dc.Show();
        }
    }
}
