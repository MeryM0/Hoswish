using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class Wish
    {
        SQLDAL.Wish wish = new SQLDAL.Wish();
        //public Wish() { }

        DataTable dt = new DataTable();
        public void update_r(string line, string username)
        {
            wish.update_r(line, username);
        }

        public void addrow(string[] Hos, string[] lines)
        {
            bool flag = true;
            for (int j = 1; j < 4 && flag == true; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (lines[j] == Hos[i])
                    {
                        //设置医院限额
                        string line = lines[j];

                        /*newRow = dt.NewRow();
                        newRow[j] = lines[0];
                        dt.Rows.Add(newRow);*/

                        update_r(line, lines[0]);
                        flag = false;
                        break;
                    }
                }
            }
        }

        public DataTable getdatatable()
        {
            string[] Hos = new string[6];
            string wishget = wish.getHosname();
            Hos = wish.getHosname().Split(new char[] { ';' }, options: StringSplitOptions.RemoveEmptyEntries);

            /*for (int i = 0; i < 6;i++ )
            {
                dt.Columns.Add(Hos[i], Type.GetType("System.String"));
            }*/
            DataTable dta = wish.gettable();
            string wish_r = wish.getstring(dta);

            string[] stringwish = wish_r.Split(new char[] { ';' }, options: StringSplitOptions.RemoveEmptyEntries);
            string[] row;
            for (int x = 0; x < stringwish.Length; x++)
            {
                row = stringwish[x].Split(':');
                addrow(Hos, row);
            }
            dt = wish.getend();
            return dt;
        }

        public string getlost()
        {
            return wish.getlost();
        }

        public bool manadd(Model.Wish model)
        {
            bool panduan = false;
            if (wish.manadd(model) == true)
            {
                panduan = true;
            }
            return panduan;
        }
    }
}
