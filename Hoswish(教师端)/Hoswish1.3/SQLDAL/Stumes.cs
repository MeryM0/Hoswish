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
        public bool update(Model.Stumes model, string UserName)
        {
            /*SqlServer语句存储过程，还是sqlserver好啊！！！
             * string storeProcedure = "moreupdate";
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
                   new SqlParameter("@Number", SqlDbType.VarChar,50),
                   new SqlParameter("@Major", SqlDbType.VarChar,50),
                   new SqlParameter("@Stuclass", SqlDbType.VarChar,50),};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Number;
            parameters[2].Value = model.Major;
            parameters[3].Value = model.Stuclass;
            int rows = SqlDbHelper.ExecuteNonQuery(storeProcedure, CommandType.StoredProcedure, parameters);*/
            string insert1 = "insert into tb_stumes(username,number,major,stuclass) values(@UserName,@Number,@Major,@Stuclass)";
            string insert2 = "insert into tb_wish(username) values(@Username)";
            string insert3 = "insert into tb_score(username) values(@Username)";
            MySqlParameter[] parameters = {
                    new MySqlParameter("@UserName", MySqlDbType.VarChar,50),
                   new MySqlParameter("@Number", MySqlDbType.VarChar,50),
                   new MySqlParameter("@Major", MySqlDbType.VarChar,50),
                   new MySqlParameter("@Stuclass", MySqlDbType.VarChar,50),};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Number;
            parameters[2].Value = model.Major;
            parameters[3].Value = model.Stuclass;


            MySqlParameter[] pa = { new MySqlParameter("@UserName", MySqlDbType.VarChar, 50) };
            pa[0].Value = model.Name;

            MySqlParameter[] pas = { new MySqlParameter("@UserName", MySqlDbType.VarChar, 50) };
            pas[0].Value = model.Name;

            int a = SqlDbHelper.ExecuteNonQuery(insert1, CommandType.Text, parameters);

            int b = SqlDbHelper.ExecuteNonQuery(insert2, CommandType.Text, pa);

            int rows = SqlDbHelper.ExecuteNonQuery(insert3, CommandType.Text, pas);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable getAll()
        {
            DataTable dt = new DataTable();
            string selectall = "select username as '学生名字',number as '学生学号',major as '专业',stuclass as '班级' from tb_stumes";
            dt = SqlDbHelper.ExecuteDataTable(selectall, CommandType.Text);
            return dt;
        }

        public DataTable getmes(Model.Stumes model)
        {
            DataTable dt = new DataTable();
            StringBuilder selectmes = new StringBuilder();
            selectmes.Append("select tb_stumes.username as '学生名字',tb_stumes.number as '学生学号',tb_stumes.major as '专业',tb_stumes.stuclass as '班级',tb_score.endresult as '最终成绩',tb_wish.tb_result as '最终志愿' ");
            selectmes.Append(" from tb_stumes ");
            selectmes.Append(" join tb_score on tb_stumes.username = tb_score.username ");
            selectmes.Append(" join tb_wish on tb_stumes.username = tb_wish.username ");
            selectmes.Append(" where tb_stumes.username like '%" + model.Name + "%' and number =@Number ");

            MySqlParameter[] parameters = {
                   new MySqlParameter("@Number", MySqlDbType.VarChar,50),};
            parameters[0].Value = model.Number;
            dt = SqlDbHelper.ExecuteDataTable(selectmes.ToString(), CommandType.Text, parameters);
            return dt;
        }
    }
}
