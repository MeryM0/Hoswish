using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Stumes
    {
        SQLDAL.Stumes stumes = new SQLDAL.Stumes();
        public bool Check(Model.Stumes model,out string mes) 
        {
            bool check = true;
            mes = "";
            if(model.Name == "")
            {
                mes = "姓名不能为空";
                check = false;
                return check;
            }
            if (model.Number.ToString() == "")
            {
                mes = "学号不能为空";
                check = false;
                return check;
            }
            if (model.Major == "")
            {
                mes = "专业不能为空";
                check = false;
                return check;
            }
            if (model.Stuclass == "")
            {
                mes = "班级不能为空";
                check = false;
                return check;
            }
            //头像
            return check;

        }
        public bool update(Model.Stumes model,string UserName,out string mes) 
        {
            if (!Check(model, out mes))
            {
                return false;
            }
            else 
            {
                return (stumes.update(model,UserName));
            }
        }

        public Model.Stumes select(string UserName) 
        {
            return (stumes.select(UserName));
        }
    }
}
