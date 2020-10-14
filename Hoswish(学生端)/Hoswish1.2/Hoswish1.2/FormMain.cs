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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        string UserName;
        public FormMain(string UserName)
        {
            this.UserName = UserName;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel5.Visible = false; 
            panel6.Visible = false;
            panel1.Size = panel2.Size;

            /*BLL.Stumes stumes = new BLL.Stumes();
            
            Model.Stumes model = stumes.select(UserName);

            textBox1.Text = model.Name;
            textBox2.Text = model.Number;
            textBox3.Text = model.Major;
            textBox4.Text = model.Stuclass;*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;

            BLL.wish wish = new BLL.wish();

            DataTable dt = wish.HasHos();

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    comboBox6.Items.Add(row[i].ToString());
                    comboBox5.Items.Add(row[i].ToString());
                    comboBox4.Items.Add(row[i].ToString());
                }
            }
        }
        //上方第三个按钮
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
            panel1.Size = panel5.Size;
        }
        //Model.Hos model = new Model.Hos();
        private void hos_1_Click(object sender, EventArgs e)
        {
            Hosmes hosmes = new Hosmes(hos_1.Text);
            hosmes.Show();
        }

        private void hos_2_Click(object sender, EventArgs e)
        {
            Hosmes hosmes = new Hosmes(hos_2.Text);
            hosmes.Show();
        }

        private void hos_3_Click(object sender, EventArgs e)
        {
            Hosmes hosmes = new Hosmes(hos_3.Text);
            hosmes.Show();
        }

        private void hos_4_Click(object sender, EventArgs e)
        {
            Hosmes hosmes = new Hosmes(hos_4.Text);
            hosmes.Show();
        }

        private void hos_5_Click(object sender, EventArgs e)
        {
            Hosmes hosmes = new Hosmes(hos_5.Text);
            hosmes.Show();
        }

        private void hos_6_Click(object sender, EventArgs e)
        {
            Hosmes hosmes = new Hosmes(hos_6.Text);
            hosmes.Show();
        }
        //修改/提交
        private void button13_Click(object sender, EventArgs e)
        {
            BLL.Stumes stumes = new BLL.Stumes();
            Model.Stumes model = new Model.Stumes();
            model.Name = textBox1.Text.Trim();
            model.Number = textBox2.Text.Trim();
            model.Major = textBox3.Text.Trim();
            model.Stuclass = textBox4.Text.Trim();

            string mes = "";
            if (stumes.update(model,UserName,out mes) == true)
            {
                MessageBox.Show("更新成功!");
            }
            else
            {
                MessageBox.Show(mes);
            }

        }
        //上方第四个按钮，结果查询
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel1.Size = panel6.Size;

            BLL.Stumes stumes = new BLL.Stumes();
            Model.Stumes model = stumes.select(UserName);

            textBox12.Text = model.Name;
            textBox11.Text = model.Number;
            textBox10.Text = model.Major;
            textBox9.Text = model.Stuclass;
            
            BLL.wish Wish = new BLL.wish();
            Model.wish wishModel = Wish.select(UserName);

            textBox5.Text = wishModel.First;
            textBox6.Text = wishModel.Second;
            textBox7.Text = wishModel.Third;
            textBox8.Text = wishModel.Result;
        }

        //填报志愿按钮
        private void button5_Click(object sender, EventArgs e)
        {
            BLL.wish Wish = new BLL.wish();
            Model.wish model = new Model.wish();
            model.First = comboBox6.Text;
            model.Second = comboBox5.Text;
            model.Third = comboBox4.Text;

            if (Wish.update(model,UserName) == true)
            {
                MessageBox.Show("更新成功！");
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
