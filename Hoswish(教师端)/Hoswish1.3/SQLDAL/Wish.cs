using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace SQLDAL
{
    public class Wish
    {
        public Wish() { }
        public string getHosname()
        {
            string Hosname = "";
            string str = " select Hos_name from tb_Hos ";
            MySqlDataReader sdr = SqlDbHelper.ExecuteReader(str, CommandType.Text);

            while (sdr.Read())
            {
                Hosname += string.Format("{0};", sdr[0].ToString());
            }

            return Hosname;
        }

        public DataTable gettable()
        {
            StringBuilder selectmes = new StringBuilder();
            selectmes.Append(" select tb_wish.username,tb_first,tb_second,tb_third ");
            selectmes.Append(" from tb_wish ");
            selectmes.Append(" join tb_score on tb_wish.username = tb_score.username ");
            selectmes.Append(" order by tb_score.endresult desc; ");

            DataTable dt = SqlDbHelper.ExecuteDataTable(selectmes.ToString(), CommandType.Text);

            return dt;
        }

        public string getstring(DataTable dt)
        {
            string description = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                description += string.Format("{0}:{1}:{2}:{3};", dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString());
            }

            return description;
        }

        public void update_r(string line, string username)
        {
            string sql = "update tb_wish set tb_result=@tb_result where username=@username";
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tb_result", MySqlDbType.VarChar,50),
                    new MySqlParameter("@username",MySqlDbType.VarChar,50)};
            parameters[0].Value = line;
            parameters[1].Value = username;

            int n = SqlDbHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
        }


        public DataTable getend()
        {
            DataTable dt = new DataTable();

            string selectall = "select username as '学生姓名',tb_result as '匹配结果' from tb_wish";
            dt = SqlDbHelper.ExecuteDataTable(selectall, CommandType.Text);
            return dt;
        }

        public string getlost()
        {
            string sql = " select username from tb_wish where tb_result = '' ";
            MySqlDataReader sdr = SqlDbHelper.ExecuteReader(sql, CommandType.Text);
            string lost = "";
            while (sdr.Read())
            {
                lost += string.Format("{0}", sdr[0].ToString()) + ';';
            }
            return lost;
        }

        public bool manadd(Model.Wish model)
        {
            string sql = "update tb_wish set tb_result=@tb_result where username='" + model.UserName + "'";
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tb_result", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.Result;

            int n = SqlDbHelper.ExecuteNonQuery(sql, CommandType.Text, parameters);
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
