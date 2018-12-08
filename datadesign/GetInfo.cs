using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datadesign
{
    class GetInfo
    {
        public Boolean setin(string id, string bunum)
        {
            MYSql mYSql = new MYSql();
            string sql = "select Ssex from student where sid = '" + id + "'"; ;
            DataTable dt = mYSql.ExecuteQuery(sql);
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            string sex = dt.Rows[0]["Ssex"].ToString();
            if (sex == "男")
            {
                if (Convert.ToInt32(bunum) % 2 == 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (Convert.ToInt32(bunum) % 2 != 0)
                    return true;
                else
                    return false;
            }
        }
        public int getMnum(string buildingnum)
        {
            string s = "select count(*) as num from worker group by bnum";
            MYSql mYSql = new MYSql();
            DataTable dt = mYSql.ExecuteQuery(s);
            int num = Convert.ToInt32(dt.Rows[0]["num"]);
            return num;
        }
        public string[] GetTable(string sid)
        {
            string[] temp = { "", "" };
            string sql = "select buildingnum,roomnum from DS where sid = '" + sid + "'";
            DataTable dt = new DataTable();
            MYSql mysql = new MYSql();
            dt = mysql.ExecuteQuery(sql);
            try
            {
                temp[0] = dt.Rows[0]["buildingnum"].ToString();
                temp[1] = dt.Rows[0]["roomnum"].ToString();
            }
            catch (Exception ex)
            {
                temp[0] = "error";
                temp[1] = "error";
            }
            return temp;
        }
        public string GetBuildingnum(string wnum)
        {
            MYSql mYSql = new MYSql();
            DataTable dt = new DataTable();
            dt = mYSql.ExecuteQuery("select bnum from worker where wnum = '" + wnum + "'");
            string bnum = dt.Rows[0]["bnum"].ToString();
            return bnum;
        }
        public int getYear()
        {
            MYSql mYSql = new MYSql();
            int lastyear;
            string sql = "select MAX(livetime) as 'MAX' from DS";
            DataTable dt = mYSql.ExecuteQuery(sql);
            try
            {
                lastyear = Convert.ToInt32(dt.Rows[0]["MAX"].ToString());

            }
            catch
            {
                lastyear = 0;
            }
            return lastyear;
        }
    }
}
