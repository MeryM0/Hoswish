using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class Hos
    {
        SQLDAL.Hos hos = new SQLDAL.Hos();
        public Model.Hos HosMes(string Hos_Name) 
        {
            return hos.HosMes(Hos_Name);
        }
    }
}
