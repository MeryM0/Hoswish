using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoswish1._2
{
    public partial class Hosmes : Form
    {
        public Hosmes()
        {
            InitializeComponent();
        }
        string Hos_name;
        public Hosmes(string Hos_name) 
        {
            this.Hos_name = Hos_name;
            InitializeComponent();
        }
        
        private void Hosmes_Load(object sender, EventArgs e)
        {
            BLL.Hos hos = new BLL.Hos(); 
            //Model.Hos model = new Model.Hos();为新建model
            Model.Hos model = hos.HosMes(Hos_name);
            if(model == null)      
            {
                MessageBox.Show("数据查询错误");
                return;
            }
            else
            {
                label1.Text = model.Hos_Name;
                label2.Text = model.Hos_title;
                textBox1.Text = model.Hos_detail;
                label4.Text = model.Hos_how.ToString();
            }
        }
    }
}
