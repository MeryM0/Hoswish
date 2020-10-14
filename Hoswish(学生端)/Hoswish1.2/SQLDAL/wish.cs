using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace SQLDAL
{
    public class wish
    {
        public bool update(Model.wish model, string username)
        {
            string str = "update tb_wish set tb_first=@First,tb_second=@Second,tb_third=@Third,tb_result='' where username='" + username + "'";
            MySqlParameter[] parameters = {
					new MySqlParameter("@First", MySqlDbType.VarChar,50),
                   new MySqlParameter("@Second", MySqlDbType.VarChar,50),
                   new MySqlParameter("@Third", MySqlDbType.VarChar,50),};
            parameters[0].Value = model.First;
            parameters[1].Value = model.Second;
            parameters[2].Value = model.Third;
            int rows = SqlDbHelper.ExecuteNonQuery(str, CommandType.Text, parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable HasHos()
        {
            DataTable dt;

            string str = "select Hos_name from tb_Hos";

            return dt = SqlDbHelper.ExecuteDataTable(str, CommandType.Text);

        }

        public Model.wish select(string UserName)
        {
            string str = "select tb_first,tb_second,tb_third,tb_result from tb_wish where username=@UserName";
            MySqlParameter[] parameters = {
					new MySqlParameter("@UserName", MySqlDbType.VarChar,50)};
            parameters[0].Value = UserName;

            Model.wish model = new Model.wish();
            model.First = "";
            model.Second = "";
            model.Third = "";
            model.Result = "";
            DataTable dt = SqlDbHelper.ExecuteDataTable(str, CommandType.Text, parameters);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["tb_first"] != null && dt.Rows[0]["tb_first"].ToString() != "")
                {
                    model.First = dt.Rows[0]["tb_first"].ToString();
                }
                if (dt.Rows[0]["tb_second"] != null && dt.Rows[0]["tb_second"].ToString() != "")
                {
                    model.Second = dt.Rows[0]["tb_second"].ToString();
                }
                if (dt.Rows[0]["tb_third"] != null && dt.Rows[0]["tb_third"].ToString() != "")
                {
                    model.Third = dt.Rows[0]["tb_third"].ToString();
                }
                if (dt.Rows[0]["tb_result"] != null && dt.Rows[0]["tb_result"].ToString() != "")
                {
                    model.Result = dt.Rows[0]["tb_result"].ToString();
                }

            }
            return model;

        }
    }
}
