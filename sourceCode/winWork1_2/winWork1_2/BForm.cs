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
    public partial class BForm : Form
    {
        public BForm()
        {
            InitializeComponent();
        }
        private Form3 _form3;  //定义Form1窗体变量
        public BForm(Form3 form) : this()
        {
            InitializeComponent();
            _form3 = form;
        }


        private void BForm_Load(object sender, EventArgs e)
        {
            //Form3 myform = new Form3();
            //myform.Owner = this;
            //myform.ShowDialog();
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
        private void button7_Click(object sender, EventArgs e)  //点击0
        {
            string s = _form3.textBox4.Text;
            if (s != "0")
            {
                _form3.UpdateTextBox(_form3.textBox4, s + "0");
                s += "0";
                _form3.UpdateTextBox(_form3.textBox4, addKong(s.Replace(" ", "")));
            }
        }
        
        private void button1_Click(object sender, EventArgs e)  //点击1
        {
            string s = _form3.textBox4.Text;
            if (s=="0")
            {
                _form3.UpdateTextBox(_form3.textBox4, "1");
            }
            else
            {
                _form3.UpdateTextBox(_form3.textBox4, s+"1");
                s += "1";
                _form3.UpdateTextBox(_form3.textBox4, addKong(s.Replace(" ", "")));
            }
        }

        private void button9_Click(object sender, EventArgs e)  //点击<-
        {
            string s = _form3.textBox4.Text;
            if (s.Length != 1)
            {
                s = s.Substring(0, s.Length - 1);
                _form3.UpdateTextBox(_form3.textBox4, addKong(s.Replace(" ", "")));
            }
            else
            {
                _form3.UpdateTextBox(_form3.textBox4, "0");
            }
        }
        public string myBTH(string s)
        {
            return DForm.myDTH(myBTD(s));
        }
        public string myBTD(string s)
        {
            s = s.Replace(" ", "");
            return Convert.ToInt32(s, 2) + "";
        }
        public string myBTO(string s)
        {
            return DForm.myDTO(myBTD(s));
        }
        private void button8_Click(object sender, EventArgs e)  //二进制转换
        {
            _form3.UpdateTextBox(_form3.textBox1, DForm.addDou(myBTD(_form3.textBox4.Text)));
            _form3.UpdateTextBox(_form3.textBox3, HForm.addKong(myBTH(_form3.textBox4.Text)));
            _form3.UpdateTextBox(_form3.textBox2, OForm.addKong(myBTO(_form3.textBox4.Text)));
        }
    }
}
