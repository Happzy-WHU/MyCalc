using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winWork1_2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            CreateMDIControl(new DForm(this));
        }
        private Form f = null;
        private void CreateMDIControl(Form frmBase)
        {
            if (f != null)
            {
                f.Dispose();
                f.Close();
            }
            f = frmBase;
            try
            {

                this.panel1.Controls.Clear();
                frmBase.FormBorderStyle = FormBorderStyle.None;
                frmBase.TopLevel = false;
                frmBase.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(frmBase);
                frmBase.Show();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //loading.CloseWaitForm();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void UpdateTextBox(System.Windows.Forms.TextBox tb1, string newData)
        {
            tb1.Text = newData;  //这里是修改text值，也可以修改其它属性。
        }


        private void label1_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Blue;
            label6.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            this.panel1.Controls.Clear();
            panel1.Visible = true;
            CreateMDIControl(new DForm(this));
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Blue;
            label1.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            this.panel1.Controls.Clear();
            panel1.Visible = true;
            CreateMDIControl(new HForm(this));
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Blue;
            label1.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            this.panel1.Controls.Clear();
            panel1.Visible = true;
            CreateMDIControl(new OForm(this));
        }

        private void label5_Click(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Blue;
            label1.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            this.panel1.Controls.Clear();
            panel1.Visible = true;
            CreateMDIControl(new BForm(this));
        }
    }
}
