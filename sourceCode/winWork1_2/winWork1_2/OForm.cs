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
    public partial class OForm : Form
    {
        public OForm()
        {
            InitializeComponent();
        }
        private Form3 _form3;  //定义Form1窗体变量
        public OForm(Form3 form) : this()
        {
            InitializeComponent();
            _form3 = form;
        }
        public static string addKong(string s)
        {
            if (s.Length >= 4)
            {
                return addKong(s.Substring(0, s.Length - 3))
                    + " " + s.Substring(s.Length - 3, 3);
            }
            else
            {
                return s;
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void OForm_Load(object sender, EventArgs e)
        {

        }
        private void processNumNot0(string m)
        {
            string s = _form3.textBox2.Text;
            if (s == "0")
            {
                _form3.UpdateTextBox(_form3.textBox2, m);
            }
            else
            {
                _form3.UpdateTextBox(_form3.textBox2, s + m);
                s += m;
                _form3.UpdateTextBox(_form3.textBox2, addKong(s.Replace(" ", "")));
            }
        }
        private void button1_Click(object sender, EventArgs e)  // 1
        {
            processNumNot0("1");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            processNumNot0("2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            processNumNot0("3");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            processNumNot0("4");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            processNumNot0("5");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            processNumNot0("6");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            processNumNot0("7");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string s = _form3.textBox2.Text;
            if (s != "0")
            {
                _form3.UpdateTextBox(_form3.textBox2, s + "0");
                s += "0";
                _form3.UpdateTextBox(_form3.textBox2, addKong(s.Replace(" ", "")));
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string s = _form3.textBox2.Text;
            if (s.Length != 1)
            {
                s = s.Substring(0, s.Length - 1);
                _form3.UpdateTextBox(_form3.textBox2, addKong(s.Replace(" ", "")));
            }
            else
            {
                _form3.UpdateTextBox(_form3.textBox2, "0");
            }
        }
        public string myOTB(string s)
        {
            return DForm.myDTB(myOTD(s));
        }
        public string myOTH(string s)
        {
            return DForm.myDTH(myOTD(s));
        }
        public string myOTD(string s)
        {
            s = s.Replace(" ", "");
            return Convert.ToInt32(s, 8) + "";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            _form3.UpdateTextBox(_form3.textBox4, BForm.addKong(myOTB(_form3.textBox2.Text)));
            _form3.UpdateTextBox(_form3.textBox3, HForm.addKong(myOTH(_form3.textBox2.Text)));
            _form3.UpdateTextBox(_form3.textBox1, DForm.addDou(myOTD(_form3.textBox2.Text)));
        }
    }
}
