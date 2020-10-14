using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Hoswish1._3
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

        private void FormMain_Load(object sender, EventArgs e)
        {
            panel2.Visible = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.RowHeadersWidth = 40;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 13, FontStyle.Regular);
            dataGridView1.DefaultCellStyle.Font = new Font("宋体", 12);
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 13, FontStyle.Regular);
            dataGridView2.DefaultCellStyle.Font = new Font("宋体", 10);

            //过滤空白行
            dataGridView3.AllowUserToAddRows = false;

            drawControls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel2.Size = panel1.Size;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel3.Size = panel1.Size;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BLL.Stumes stumes = new BLL.Stumes();
            Model.Stumes model = new Model.Stumes();
            model.Name = textBox2.Text.Trim();
            model.Number = textBox1.Text.Trim();
            model.Major = textBox4.Text.Trim();
            model.Stuclass = textBox5.Text.Trim();

            string mes = "";
            if (stumes.update(model, UserName, out mes) == true)
            {
                MessageBox.Show("更新成功!");
            }
            else
            {
                MessageBox.Show(mes);
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂不支持此功能！");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BLL.Stumes stumes = new BLL.Stumes();
            Model.Stumes model = new Model.Stumes();
            if (textBox6.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("请输入数据");
            }
            else
            {
                model.Name = textBox6.Text.Trim();
                model.Number = textBox3.Text.Trim();
                DataTable myDatatable = stumes.getmes(model);
                dataGridView1.DataSource = myDatatable;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            BLL.Stumes stumes = new BLL.Stumes();
            DataTable myDatatable = stumes.getAll();
            dataGridView1.DataSource = myDatatable;
        }
        TextBox[] names = new TextBox[5];
        TextBox[] ratios = new TextBox[5];
        CheckBox[] chk = new CheckBox[5];
        DataTable custom_condition;
        void drawControls()
        {
            int y = 0, x = 40;
            for (int i = 0; i < 5; i++)
            {
                y = 35 * (i + 1);
                names[i] = new TextBox();
                names[i].Top = y;
                names[i].Left = x;
                names[i].Enabled = false;
                names[i].Font = new System.Drawing.Font("宋体", 19F);
                names[i].Width = 138;
                this.panel3.Controls.Add(names[i]);

                ratios[i] = new TextBox();
                ratios[i].Width = (int)names[i].Width / 2;
                ratios[i].Top = y;
                ratios[i].Left = names[i].Right + 10;
                ratios[i].Enabled = false;
                ratios[i].Font = new System.Drawing.Font("宋体", 19F);
                this.panel3.Controls.Add(ratios[i]);


                chk[i] = new CheckBox();
                chk[i].Top = y;
                chk[i].Left = ratios[i].Right + 10;
                chk[i].CheckedChanged += new System.EventHandler(this.check_click);
                this.panel3.Controls.Add(chk[i]);
            }
            names[0].Text = "初始成绩";
            names[1].Text = "创新创业分";
            names[2].Text = "技能培养分";
            names[3].Text = "文化活动分";
            names[4].Text = "社会服务分";
        }

        //选择控件
        void check_click(object sender, EventArgs e)
        {
            for (int i = 0; i < chk.Length; i++)
            {
                if (chk[i] == sender)
                {
                    if (chk[i].Checked)
                    {
                        ratios[i].Enabled = true;
                    }
                    else
                    {
                        ratios[i].Enabled = false;
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            custom_condition = new DataTable("condition");
            custom_condition.Columns.Add("号码", Type.GetType("System.String"));
            custom_condition.Columns.Add("项目", Type.GetType("System.String"));
            custom_condition.Columns.Add("分值", Type.GetType("System.Int32"));
            DataRow newRow;

            for (int i = 0; i < chk.Length; i++)
            {
                if (chk[i].Checked)
                {
                    newRow = custom_condition.NewRow();
                    newRow[0] = "condition_" + i;
                    newRow[1] = names[i].Text;
                    newRow[2] = Convert.ToInt32(ratios[i].Text);
                    custom_condition.Rows.Add(newRow);
                }
            }
            Common.Translate translate = new Common.Translate();
            this.dataGridView2.DataSource = custom_condition;
            string description = translate.datatable2string(custom_condition);
            textBox7.Text = description;

            BLL.Score score = new BLL.Score();
            Model.Score model = new Model.Score();
            model.UserName = textBox8.Text;
            model.Formula = description;
            string mesg = "";
            if (score.tianjia(model, out mesg) == true)
            {
                MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show(mesg);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            BLL.Score score = new BLL.Score();
            Common.Translate translate = new Common.Translate();
            Model.Score model = new Model.Score();
            model.UserName = textBox8.Text;

            string description = score.chaxun(model);
            this.dataGridView2.DataSource = translate.string2datatable(description);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (custom_condition == null)
            {
                MessageBox.Show("没有数据");
            }
            else
            {
                custom_condition.Clear();
                this.dataGridView2.DataSource = custom_condition;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            BLL.Score score = new BLL.Score();
            Common.Translate translate = new Common.Translate();
            Model.Score model = new Model.Score();
            model.UserName = textBox8.Text;

            this.dataGridView2.DataSource = score.select(model);
        }

        private void Auto_fenpei_Click(object sender, EventArgs e)
        {
            BLL.Wish wish = new BLL.Wish();

            dataGridView3.DataSource = wish.getdatatable();
        }
        private void man_fenpei_Click(object sender, EventArgs e)
        {
            Model.Wish model = new Model.Wish();
            model.UserName = textBox10.Text;
            model.Result = textBox9.Text;

            BLL.Wish wish = new BLL.Wish();
            if (wish.manadd(model) == true)
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }
        private Microsoft.Office.Interop.Excel.Application G_ea;
        private object G_missing = System.Reflection.Missing.Value;
        private void popexcel_Click(object sender, EventArgs e)
        {
            List<Model.Wish> result = new List<Model.Wish>();

            foreach (DataGridViewRow dgvr in dataGridView3.Rows)
            {
                result.Add(new Model.Wish()
                {
                    UserName = dgvr.Cells[0].Value.ToString(),
                    Result = dgvr.Cells[1].Value.ToString()
                });
            }
            SaveFileDialog P_SaveFileDialog = new SaveFileDialog();
            P_SaveFileDialog.Filter = "*.xls|*.xls";
            if (DialogResult.OK == P_SaveFileDialog.ShowDialog())
            {
                ThreadPool.QueueUserWorkItem(
                (pp) =>
                {
                    G_ea = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook P_wk = G_ea.Workbooks.Add(G_missing);
                    Microsoft.Office.Interop.Excel.Worksheet P_ws = (Microsoft.Office.Interop.Excel.Worksheet)P_wk.Worksheets.Add(G_missing, G_missing, G_missing, G_missing);
                    for (int i = 0; i < result.Count; i++)
                    {
                        P_ws.Cells[i + 1, 1] = result[i].UserName;
                        P_ws.Cells[i + 1, 2] = result[i].Result.ToString();
                    }
                    P_wk.SaveAs(
                        P_SaveFileDialog.FileName, G_missing, G_missing, G_missing,
                        G_missing, G_missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, G_missing,
                        G_missing, G_missing, G_missing, G_missing);
                    ((Microsoft.Office.Interop.Excel._Application)G_ea.Application).Quit();
                    this.Invoke(
                        (MethodInvoker)(() =>
                        {
                            MessageBox.Show("成功创建Excel文档！", "提示！");
                        }));
                });
            }
        }

        private void duqu_Click(object sender, EventArgs e)
        {
            BLL.Wish wish = new BLL.Wish();

            textBox11.Text = wish.getlost();
        }

        private void man_fenpei_Click_1(object sender, EventArgs e)
        {
            Model.Wish model = new Model.Wish();
            model.UserName = textBox10.Text;
            model.Result = textBox9.Text;

            BLL.Wish wish = new BLL.Wish();
            if (wish.manadd(model) == true)
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("添加失败");
            }
        }
    }
}
