using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datadesign
{
    class AGSI
    {
        public Student student = new Student();
        List<Student> slist = new List<Student>();
        string year;

        public AGSI(string year)
        {
            this.year = year;
        }
        public bool notin(string id)
        {
            string sql = "select sid from DS where sid ='" + id + "'";
            MYSql mYSql = new MYSql();
            DataTable dt = mYSql.ExecuteQuery(sql);
            try
            {
                string ids = dt.Rows[0]["sid"].ToString();
                return false;
            }
            catch
            {
                return true;
            }

        }
        public int getMaxsize(string buildingnum, string roomnum)
        {
            string s = "select size from broom where buildingnum = '" + buildingnum + "' and roomnum = '" + roomnum + "'";

            int size;
            MYSql mYSql = new MYSql();
            DataTable dt = mYSql.ExecuteQuery(s);
            if (dt.Rows[0]["size"] == null)
                size = 0;
            else
                size = Convert.ToInt32(dt.Rows[0]["size"]);
            return size;
        }
        public int getacsize(string buildingnum, string roomnum)
        {
            string s = "select count(*) as size from DS where buildingnum = '" + buildingnum + "' and roomnum = '" + roomnum + "'";
            int size;
            MYSql mYSql = new MYSql();
            DataTable dt = mYSql.ExecuteQuery(s);
            if (dt.Rows[0]["size"] == null)
                size = 0;
            else
                size = Convert.ToInt32(dt.Rows[0]["size"]);
            return size;
        }
        /// <summary>
        /// 现阶段住宿情况
        /// </summary>

        static DataTable GetStudentTableSchema()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("sid",typeof(String)),
                new DataColumn("scollege",typeof(String)),
                new DataColumn("sname",typeof(String)),
                new DataColumn("Ssex",typeof(string))
            });
            return dt;
        }
        /// <summary>
        /// 使用 bulk 插入各个信息
        /// </summary>
        public void prepare()
        {
            slist = student.GetStudentList(year);
        }
        public void StudentToDB()
        {
            String conn = "server=localhost;database=SDM;user id=sa;password=1";
            DataTable studt = GetStudentTableSchema();
            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                try
                {
                    SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnection);
                    bulkCopy.DestinationTableName = "student";
                    bulkCopy.BatchSize = studt.Rows.Count;
                    sqlConnection.Open();
                    foreach (Student i in slist)
                    {
                        DataRow dr = studt.NewRow();
                        dr[0] = i.sid;
                        dr[1] = i.sdept;
                        dr[2] = i.sname;
                        dr[3] = i.ssex;
                        studt.Rows.Add(dr);
                    }
                    if (studt != null && studt.Rows.Count != 0)
                    {
                        bulkCopy.WriteToServer(studt);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        /// <summary>
        /// 自动为学生分配寝室
        /// </summary>
        public List<Room> geteRoom(string sex)
        {
            MYSql mYSql = new MYSql();
            List<Room> roomlist = new List<Room>();
            string sql = "select * from broom where brsex = '" + sex + "'";
            DataTable dt = mYSql.ExecuteQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string buildingnum = dt.Rows[i]["buildingnum"].ToString();
                string roomnum = dt.Rows[i]["roomnum"].ToString();
                string brsex = dt.Rows[i]["brsex"].ToString();
                int size = Convert.ToInt32(dt.Rows[i]["size"]);
                roomlist.Add(new Room(buildingnum, roomnum, brsex, size));
            }
            return roomlist;
        }
        public void DAlloc()
        {
            prepare();
            StudentToDB();
            string sx = slist[10].sid;
            List<Student> boy = new List<Student>();
            List<Student> girl = new List<Student>();
            for (int i = 0; i < slist.Count; i++)
            {
                if (slist[i].ssex.Equals("男"))
                    boy.Add(slist[i]);
                else
                    girl.Add(slist[i]);
            }
            List<Room> boyroom = geteRoom("男生宿舍");
            List<Room> girlroom = geteRoom("女生宿舍");
            //安排男生入住
            string s = boyroom[11].brsex;
            MYSql mysql = new MYSql();
            int stu = 0;
            for (int i = 0; i < boyroom.Count; i++)
            {
                int maxsize = getMaxsize(boyroom[i].buildingnum, boyroom[i].roomnum);
                int asize = getacsize(boyroom[i].buildingnum, boyroom[i].roomnum);
                for (; stu < boy.Count; stu++)
                {
                    if (asize == maxsize)
                        break;
                    string year = "20" + boy[stu].sid.Substring(0, 2);
                    string intoDS = "insert into DS(buildingnum,roomnum,sid,livetime)values('" + boyroom[i].buildingnum + "','" + boyroom[i].roomnum + "','" + boy[stu].sid + "','" + year + "')";
                    mysql.ExecuteQuery(intoDS);
                    asize++;
                }
            }
            stu = 0;
            for (int i = 0; i < girlroom.Count; i++)
            {
                int asize = getacsize(girlroom[i].buildingnum, girlroom[i].roomnum);
                int maxsize = getMaxsize(girlroom[i].buildingnum, girlroom[i].roomnum);
                for (; stu < girl.Count; stu++)
                {
                    if (asize == maxsize)
                        break;
                    string year = "20" + girl[stu].sid.Substring(0, 2);
                    string intoDS = "insert into DS(buildingnum,roomnum,sid,livetime)values('" + girlroom[i].buildingnum + "','" + girlroom[i].roomnum + "','" + girl[stu].sid + "','" + year + "')";
                    mysql.ExecuteQuery(intoDS);
                    asize++;
                }
            }
        }
    }
}
