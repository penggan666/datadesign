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
        public Boolean setin(string id,string bunum)
        {
            MYSql mYSql = new MYSql();
            string sql = "select Ssex from student where sid = '" + id + "'"; ;
            DataTable dt = mYSql.ExecuteQuery(sql);
            if(dt.Rows.Count == 0)
            {
                return false;
            }
            string sex = dt.Rows[0]["Ssex"].ToString();
            if(sex == "男")
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
            catch{
                lastyear = 0;
            }
            return lastyear;
        }
        
    }

}
