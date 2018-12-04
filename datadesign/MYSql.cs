using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace datadesign
{
    class MYSql
    {
        private string MysqlCon= "server=localhost;database=SDM;uid=sa;pwd=jjh123";
        public DataTable ExecuteQuery(string sqlStr)//执行查询语句
        {
            SqlConnection con = new SqlConnection(MysqlCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlStr;
            DataTable dt = new DataTable();
            SqlDataAdapter msda;
            msda = new SqlDataAdapter(cmd);
            msda.Fill(dt);
            con.Close();
            return dt;
        }

        public SqlDataAdapter updateTable(String sql)
        {
            SqlConnection con = new SqlConnection(MysqlCon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(sql, con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            return da;
        }
        
        public int ExecuteUpdate(string sqlStr)//用于增删改
        {
            SqlConnection con = new SqlConnection(MysqlCon);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlStr;
            int iud = 0;
            iud = cmd.ExecuteNonQuery();
            con.Close();
            return iud;
        }
    }
}
