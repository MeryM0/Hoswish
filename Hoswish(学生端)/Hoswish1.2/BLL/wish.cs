using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class wish
    {
        SQLDAL.wish Wish = new SQLDAL.wish();
        public DataTable HasHos()
        {
            return Wish.HasHos();
        }
        public bool update(Model.wish model, string username) 
        {
            return Wish.update(model,username);
        }
        public Model.wish select(string UserName) 
        {
            return Wish.select(UserName);
        }
    }
}
