using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SQLDAL
{
    public class Score
    {
        public bool tianjia(Model.Score model)
        {
            string sql = "update tb_score set formula=@formula where username=@username";
            MySqlParameter[] parameters = {
                    new MySqlParameter("@username", MySqlDbType.VarChar,50),
                    new MySqlParameter("@formula", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Formula;
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

        //查询所有信息
        public string chaxun(Model.Score model)
        {
            string description = "";
            string strSql = "select formula from tb_score where username = @UserName";
            MySqlParameter[] parameters = {
                    new MySqlParameter("@UserName", MySqlDbType.VarChar,200)};

            parameters[0].Value = model.UserName;

            MySqlDataReader sdr = SqlDbHelper.ExecuteReader(strSql, CommandType.Text, parameters);
            if (sdr.Read())
            {
                description = sdr[0].ToString();
            }
            return description;
        }

        public string huoqu(Model.Score model)
        {
            string result = "";
            string sql = "select formula from tb_score where username = @username";
            MySqlParameter[] parameters = {
                    new MySqlParameter("@username",MySqlDbType.VarChar,50)};
            parameters[0].Value = model.UserName;
            MySqlDataReader sdr = SqlDbHelper.ExecuteReader(sql, CommandType.Text, parameters);
            if (sdr.Read())
            {
                result = sdr[0].ToString();
            }
            return result;
        }

        public bool add(Model.Score model)
        {
            string sql = "update tb_score set endresult=@endresult where username=@username";
            MySqlParameter[] parameters = {
                    new MySqlParameter("@endresult", MySqlDbType.VarChar,50),
                    new MySqlParameter("@username",MySqlDbType.VarChar,50)};
            parameters[0].Value = model.Endresult;
            parameters[1].Value = model.UserName;
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
        public DataTable select(Model.Score model)
        {
            string strSql = "select username as '学生姓名',endresult as '最终成绩' from tb_score where username = @UserName";
            MySqlParameter[] parameters = {
                    new MySqlParameter("@UserName", MySqlDbType.VarChar,200)};

            parameters[0].Value = model.UserName;

            DataTable dt = SqlDbHelper.ExecuteDataTable(strSql, CommandType.Text, parameters);

            return dt;
        }
    }
}
