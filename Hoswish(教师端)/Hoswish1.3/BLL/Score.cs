using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class Score
    {
        SQLDAL.Score score = new SQLDAL.Score();
        public bool tianjia(Model.Score model, out string mesg)
        {
            mesg = "";
            if (score.tianjia(model) == true)
            {
                mesg = "添加成功";
                return true;
            }
            else
            {
                mesg = "添加失败";
                return false;
            }
        }
        public string chaxun(Model.Score model)
        {
            return score.chaxun(model);
        }

        public int cala(string quanzhong, int number)
        {
            if (quanzhong == "初始成绩")
            {
                number = number * 70;
            }
            if (quanzhong == "创新创业分")
            {
                number = number * 10;
            }
            if (quanzhong == "技能培养分")
            {
                number = number * 9;
            }
            if (quanzhong == "文化活动分")
            {
                number = number * 6;
            }
            if (quanzhong == "社会服务分")
            {
                number = number * 5;
            }
            return number;
        }
        DataTable dt;
        public DataTable select(Model.Score model)
        {
            int jiaquan_number, endnumber = 0;
            string result = "";
            if (score.huoqu(model) != null)
            {
                result = score.huoqu(model);

                string[] lines = result.Split(';');
                string[] row;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] == "")
                        break;
                    row = lines[i].Split(':');
                    string condition = row[0];
                    string quanzhong = row[1];
                    int number = Convert.ToInt32(row[2]);

                    jiaquan_number = cala(quanzhong, number);
                    endnumber += jiaquan_number;
                }
                model.Endresult = endnumber.ToString();
                if (score.add(model) == true)
                {
                    dt = score.select(model);
                }
            }
            return dt;
        }
    }
}
