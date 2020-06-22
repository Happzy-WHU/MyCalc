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
    public partial class DForm : Form
    {
        private Form3 _form3;  //定义Form1窗体变量
        public DForm()
        {
            InitializeComponent();
        }
        public DForm(Form3 form) : this()
        {
            InitializeComponent();
            _form3 = form;
        }

        private void DForm_Load(object sender, EventArgs e)
        {

        }
        public static string addDou(string s)
        {
            if (s.Length >= 4)
            {
                return addDou(s.Substring(0, s.Length - 3))
                    + "," + s.Substring(s.Length - 3, 3);
            }
            else
            {
                return s;
            }
        }
        private void processNumNot0(string m)
        {
            string s = _form3.textBox1.Text;
            if (s == "0")
            {
                _form3.UpdateTextBox(_form3.textBox1, m);
            }
            else
            {
                _form3.UpdateTextBox(_form3.textBox1, s + m);
                s += m;
                _form3.UpdateTextBox(_form3.textBox1, addDou(s.Replace(",", "")));
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button10_Click(object sender, EventArgs e)
        {
            processNumNot0("8");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            processNumNot0("9");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string s = _form3.textBox1.Text;
            if (s != "0")
            {
                _form3.UpdateTextBox(_form3.textBox1, s + "0");
                s += "0";
                _form3.UpdateTextBox(_form3.textBox1, addDou(s.Replace(",", "")));
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string s = _form3.textBox1.Text;
            if (s.Length != 1)
            {
                s = s.Substring(0, s.Length - 1);
                _form3.UpdateTextBox(_form3.textBox1, addDou(s.Replace(",", "")));
            }
            else
            {
                _form3.UpdateTextBox(_form3.textBox1, "0");
            }
        }
        public static string myDTB(string s)
        {
            s = s.Replace(",", "");
            return Convert.ToString(Convert.ToInt32(s), 2);
        }
        public static string myDTH(string s)
        {
            s = s.Replace(",", "");
            return Convert.ToString(Convert.ToInt32(s), 16);
        }
        public static string myDTO(string s)
        {
            s = s.Replace(",", "");
            return Convert.ToString(Convert.ToInt32(s), 8);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            _form3.UpdateTextBox(_form3.textBox4, BForm.addKong(myDTB(_form3.textBox1.Text)));
            _form3.UpdateTextBox(_form3.textBox3, HForm.addKong(myDTH(_form3.textBox1.Text)));
            _form3.UpdateTextBox(_form3.textBox2, OForm.addKong(myDTO(_form3.textBox1.Text)));
        }
    }
}
