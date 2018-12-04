using MahApps.Metro.Controls;
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
using System.Data;

namespace datadesign
{
    /// <summary>
    /// InsertS.xaml 的交互逻辑
    /// </summary>
    /// 
    public partial class InsertS : MetroWindow
    {
        MYSql mysql = new MYSql();
        string roomnum;
        string buildingnum;
        string sex;
        int maxsize;
        int asize;
        private DrMain drmain;
        public void SetDr(DrMain d)
        {
            drmain = d;
        }
        public InsertS(string buildingnum, string roomnum, string sex, int maxsize, int asize)
        {
            InitializeComponent();
            this.buildingnum = buildingnum;
            this.roomnum = roomnum;
            this.asize = asize;
            this.sex = sex;
            this.maxsize = maxsize;
            buildingnum1.Content = buildingnum;
            roomnum1.Content = roomnum;
        }
        public List<String> getstu()
        {
            List<string> slist = new List<String>();
            MYSql mYSql = new MYSql();
            DataTable dt = mYSql.ExecuteQuery("select sid from student where sid not in (select sid from DS)");
            for (int i = 0; i < dt.Rows.Count; i++)
                slist.Add(dt.Rows[i]["sid"].ToString());
            return slist;
        }
        public String GetSex(string id)
        {
            string s = "select Ssex from student where sid = '" + id + "'";
            MYSql mYSql = new MYSql();
            DataTable dt = mYSql.ExecuteQuery(s);
            return dt.Rows[0]["Ssex"].ToString();
        }
        private async void button_Click(object sender, RoutedEventArgs e)//办理入住
        {
            MYSql mysql = new MYSql();
            if (asize + 1 > maxsize)
            {
                await this.ShowMessageAsync("提示", "该宿舍已经满员");
            }
            else
            {
                string sid = textBox.Text;
                string year = yearBox.Text;
                if (sid == "")
                {
                    await this.ShowMessageAsync("提示", "请勿输入空值");
                }
                else
                {
                    if (!getstu().Contains(sid))
                    {
                        await this.ShowMessageAsync("提示", "此学生已有住宿信息或不存在此学号");
                    }
                    else
                    {
                        string s = "insert into DS(buildingnum,roomnum,sid,livetime)values('" + buildingnum + "','" + roomnum + "','" + sid + "','" + year + "')";
                        if (GetSex(sid).Equals(sex[0].ToString()) == true)
                        {
                            mysql.ExecuteUpdate(s);
                            await this.ShowMessageAsync("提示", "插入成功");
                            this.Close();
                            drmain.first();
                        }
                        else
                        {
                            await this.ShowMessageAsync("提示", "不能将" + GetSex(sid) + "生添加进" + sex[0] + "寝室");
                        }
                    }
                }
            }
        }

    }
}
