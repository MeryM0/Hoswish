using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Common
{
    public class Translate
    {
        /// <summary>
        /// datatable变成string
        /// </summary>
        /// <param name="dt">DateaTable</param>
        /// <returns>string</returns>
        public string datatable2string(DataTable dt)
        {
            string description = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                description += string.Format("{0}:{1}:{2};", dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString());
            }

            return description;
        }

        /// <summary>
        /// string变成DataTable
        /// </summary>
        /// <param name="description">string</param>
        /// <returns>DataTable</returns>
        public DataTable string2datatable(string description)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("号码", Type.GetType("System.String"));
            dt.Columns.Add("项目", Type.GetType("System.String"));
            dt.Columns.Add("分值", Type.GetType("System.Int32"));

            string[] lines = description.Split(';');
            string[] row;
            DataRow newRow;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "")
                    break;
                row = lines[i].Split(':');
                newRow = dt.NewRow();
                newRow[0] = row[0];
                newRow[1] = row[1];
                newRow[2] = Convert.ToInt32(row[2]);
                dt.Rows.Add(newRow);
            }
            return dt;
        }
    }
}
