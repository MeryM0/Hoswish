using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace SQLDAL
{
    public class Hos
    {
        public Model.Hos HosMes(string Hos_Name) 
        {
            string str = "select Hos_name,Hos_detail,Hos_how,Hos_title from tb_Hos where Hos_name =@Hos_Name";
            MySqlParameter[] parameters = { new MySqlParameter("@Hos_Name", MySqlDbType.VarChar, 100) };
            parameters[0].Value = Hos_Name;
            Model.Hos model = new Model.Hos();
            DataTable dt = SqlDbHelper.ExecuteDataTable(str,CommandType.Text, parameters);
            if(dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Hos_name"] != null && dt.Rows[0]["Hos_name"].ToString() != "")
                {
                    model.Hos_Name = dt.Rows[0]["Hos_name"].ToString();
                }
                if (dt.Rows[0]["Hos_detail"] != null && dt.Rows[0]["Hos_detail"].ToString() != "")
                {
                    model.Hos_detail = dt.Rows[0]["Hos_detail"].ToString();
                }
                if (dt.Rows[0]["Hos_how"] != null && dt.Rows[0]["Hos_how"].ToString() != "")
                {
                    model.Hos_how = int.Parse(dt.Rows[0]["Hos_how"].ToString());
                }
                if (dt.Rows[0]["Hos_title"] != null && dt.Rows[0]["Hos_title"].ToString() != "")
                {
                    model.Hos_title = dt.Rows[0]["Hos_title"].ToString();
                }
            }
            return model;
        }

    }
}
