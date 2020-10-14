using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace SQLDAL
{
    public class User
    {
        #region Method
        public bool Login(string userName, string userPassword)
        {
            string strSql = "select count(1) from tb_teacher where username=@username and password=@password";
            MySqlParameter[] parameters = {
                    new MySqlParameter("@username", MySqlDbType.VarChar,50),
                    new MySqlParameter("@password", MySqlDbType.VarChar,50),};
            parameters[0].Value = userName;
            parameters[1].Value = userPassword;
            int n = Convert.ToInt32(SqlDbHelper.ExecuteScalar(strSql, CommandType.Text, parameters));
            if (n == 1)
                return true;
            else
                return false;
        }
        #endregion Method
    }
}
