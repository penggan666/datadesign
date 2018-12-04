using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datadesign
{
    public class Source
    {
        public static string build;
        public static DataTable dt;
        public static DataTable changeDt()
        {
            MYSql mysql = new MYSql();
            string s = "select wnum as '工号',wname as '姓名',bnum as '管理栋号' from worker";
            return dt = mysql.ExecuteQuery(s);
        }
    }
}
