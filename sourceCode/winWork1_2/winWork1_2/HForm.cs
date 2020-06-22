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
    public partial class HForm : Form
    {
        public HForm()
        {
            InitializeComponent();
        }

        private Form3 _form3;  //定义Form1窗体变量
        public HForm(Form3 form) : this()
        {
            InitializeComponent();
            _form3 = form;
        }
        public static string addKong(string s)
        {
            if (s.Length >= 5)
            {
                return addKong(s.Substring(0, s.Length - 4))
                    + " " + s.Substring(s.Length - 4, 4);
            }
            else
            {
                return s;
            }
        }
        private void processNumNot0(string m)
        {
            string s = _form3.textBox3.Text;
            if (s == "0")
            {
                _form3.UpdateTextBox(_form3.textBox3, m);
            }
            else
            {
                _form3.UpdateTextBox(_form3.textBox3, s + m);
                s += m;
                _form3.UpdateTextBox(_form3.textBox3, addKong(s.Replace(" ", "")));
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            processNumNot0("2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            processNumNot0("3");
        }

        private void HForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            processNumNot0("1");
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
            string s = _form3.textBox3.Text;
            if (s != "0")
            {
                _form3.UpdateTextBox(_form3.textBox3, s + "0");
                s += "0";
                _form3.UpdateTextBox(_form3.textBox3, addKong(s.Replace(" ", "")));
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            processNumNot0("A");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            processNumNot0("B");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            processNumNot0("C");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            processNumNot0("D");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            processNumNot0("E");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            processNumNot0("F");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string s = _form3.textBox3.Text;
            if (s.Length != 1)
            {
                s = s.Substring(0, s.Length - 1);
                _form3.UpdateTextBox(_form3.textBox3, addKong(s.Replace(" ", "")));
            }
            else
            {
                _form3.UpdateTextBox(_form3.textBox3, "0");
            }
        }
        public  string myHTB(string s)
        {
           return DForm.myDTB(myHTD(s));
        }
        public  string myHTO(string s)
        {
            return DForm.myDTO(myHTD(s));
        }
        public  string myHTD(string s)
        {
            s = s.Replace(" ", "");
            return Convert.ToInt32(s, 16)+"";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            _form3.UpdateTextBox(_form3.textBox4, BForm.addKong(myHTB(_form3.textBox3.Text)));
            _form3.UpdateTextBox(_form3.textBox2, OForm.addKong(myHTO(_form3.textBox3.Text)));
            _form3.UpdateTextBox(_form3.textBox1, DForm.addDou(myHTD(_form3.textBox3.Text)));
        }
    }
}
