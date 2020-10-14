using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoswish1._3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //测试验证信息
            string userName = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            if (userName == "" || password == "")
            {
                MessageBox.Show("用户名或密码不能为空！");
                textBox1.Focus();
                return;
            }
            else
            {
                BLL.User user = new BLL.User();
                if (user.Login(userName, password))
                {
                    UserHelper.userName = textBox1.Text.Trim();
                    UserHelper.password = textBox2.Text.Trim();
                    FormMain f = new FormMain(userName);
                    f.Show();
                    this.Hide();
                }
                else
                {

                    MessageBox.Show("用户名或密码错误,请重新输入!", "错误");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(sender, e);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
