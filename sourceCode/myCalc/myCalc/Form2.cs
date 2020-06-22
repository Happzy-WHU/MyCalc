using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winWork1_1;
using winWork1_2;
namespace myCalc
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(@"..\..\白色背景.jpg");
            panel1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            CreateMDIControl(new Form1());
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
            catch (Exception ex) { }

            finally { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.panel1.Controls.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            CreateMDIControl(new Form3());
        }
    }
}
