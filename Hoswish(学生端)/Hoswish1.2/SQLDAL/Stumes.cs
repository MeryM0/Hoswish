using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace SQLDAL
{
    public class Stumes
    {
        public bool update(Model.Stumes model,string UserName) 
        {
            string str = "update tb_stumes set username=@UserName,number=@Number,major=@Major,stuclass=@Stuclass where username='"+UserName+"'";
            MySqlParameter[] parameters = {
					new MySqlParameter("@UserName", MySqlDbType.VarChar,50),
                   new MySqlParameter("@Number", MySqlDbType.VarChar,50),
                   new MySqlParameter("@Major", MySqlDbType.VarChar,50),
                   new MySqlParameter("@Stuclass", MySqlDbType.VarChar,50),
                   //new SqlParameter("@Pic", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Number;
            parameters[2].Value = model.Major;
            parameters[3].Value = model.Stuclass;
            //parameters[4].Value = model.Pic;
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

        public Model.Stumes select(string UserName)
        {
            string str = "select username,number,major,stuclass from tb_stumes where username=@UserName";
            MySqlParameter[] parameters = {
					new MySqlParameter("@UserName", MySqlDbType.VarChar,50)};
            parameters[0].Value = UserName;

            Model.Stumes model = new Model.Stumes();
            model.Name = "";
            model.Number = "";
            model.Stuclass = "";
            model.Major = "";
            //model.Pic = "";
            DataTable dt = SqlDbHelper.ExecuteDataTable(str, CommandType.Text, parameters);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["username"] != null && dt.Rows[0]["username"].ToString() != "")
                {
                    model.Name = dt.Rows[0]["username"].ToString();
                }
                if (dt.Rows[0]["number"] != null && dt.Rows[0]["number"].ToString() != "")
                {
                    model.Number = dt.Rows[0]["number"].ToString();
                }
                if (dt.Rows[0]["major"] != null && dt.Rows[0]["major"].ToString() != "")
                {
                    model.Major = dt.Rows[0]["major"].ToString();
                }
                if (dt.Rows[0]["stuclass"] != null && dt.Rows[0]["stuclass"].ToString() != "")
                {
                    model.Stuclass = dt.Rows[0]["stuclass"].ToString();
                }
                /*if (dt.Rows[0]["pic"] != null && dt.Rows[0]["pic"].ToString() != "")
                {
                    model.Pic = dt.Rows[0]["pic"].ToString();
                }*/
            }
            return model;

        }
    }
}
