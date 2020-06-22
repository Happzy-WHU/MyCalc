using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winWork1_1
{
    public partial class Form1 : Form
    {
        public static List<char> inputStr = new List<char>(1000);
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            inputStr.Add('0');

        }

        private bool juidgeNotSym(string s)
        {
            if (s != "")
            {
                string s1 = s.Substring(s.Length - 1, 1);
                if (s1 == "+" | s1 == "-" | s1 == "*" | s1 == "/"|s1=="%"| s1 == "^")
                {
                    return false;
                }
            }
            return true;
        }
        private bool juidgeNotSymForPoint(string s)
        {
            string s1 = s.Substring(s.Length - 1, 1);
            if (s.Contains(".") | !juidgeNotSym(s))
            {
                return false;
            }
            return true;
        }
        private void eraseWRSym()   //擦除最后一个数字
        {
            string s1, s2 = null;
            while (textBox1.Text != s2)
            {
                s2 = textBox1.Text;
                if (textBox1.Text == "")
                {
                    break;
                }
                s1 = textBox1.Text.Substring(textBox1.Text.Length - 1, 1);
                for (int i = 0; i < 10; i++)
                {
                    if (s1[0] == ('0' + i))
                    {
                        textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                        inputStr.RemoveAt(inputStr.Count - 1);
                    }
                }
                if (s1 == ".")
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                    inputStr.RemoveAt(inputStr.Count - 1);
                }
            }
        }


        private void addNum(char c)
        {
            if (textBox1.Text == "0")
            {
                inputStr.Clear();
                inputStr.Add(c);
                textBox1.Text = c+"";
            }
            else
            {
                textBox1.AppendText(c+"");
                inputStr.Add(c);
            }
        }
        private void button0_Click(object sender, EventArgs e)
        {
            addNum('0');
        }


        private void button1_Click(object sender, EventArgs e)
        {
            addNum('1');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addNum('2');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addNum('3');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addNum('4');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addNum('5');
        }
        private void button6_Click(object sender, EventArgs e)
        {
            addNum('6');
        }
        private void button7_Click(object sender, EventArgs e)
        {
            addNum('7');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addNum('8');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            addNum('9');
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                inputStr.Clear();
                inputStr.Add('(');
                textBox1.Text = "(";
            }
            else
            {
                eraseWRSym();   //用（覆盖最后一个数字
                inputStr.Add('(');
                textBox1.AppendText("(");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            inputStr.Add(')');
            if (textBox1.Text == "0")
            {
                textBox1.Text = ")";
            }
            else
            {
                textBox1.AppendText(")");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (inputStr.Count > 0)
            {
                if (inputStr.Count == 1)
                {
                    textBox1.Text = "0";
                    inputStr.Clear();
                }
                else
                {
                    inputStr.RemoveAt(inputStr.Count - 1);
                    textBox1.Text = "";
                    for (int i = 0; i < inputStr.Count; i++)
                    {
                        textBox1.Text += inputStr[i];
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (juidgeNotSym(textBox1.Text))
            {
                inputStr.Add('+');
                textBox1.AppendText("+");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (juidgeNotSym(textBox1.Text))
            {
                inputStr.Add('-');
                textBox1.AppendText("-");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (juidgeNotSym(textBox1.Text))
            {
                inputStr.Add('*');
                textBox1.AppendText("*");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (juidgeNotSym(textBox1.Text))
            {
                inputStr.Add('/');
                textBox1.AppendText("/");
            }
        }
        private void button30_Click(object sender, EventArgs e)
        {
            if (juidgeNotSym(textBox1.Text))
            {
                inputStr.Add('%');
                textBox1.AppendText("%");
            }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            inputStr.Add('.');
            if (juidgeNotSymForPoint(textBox1.Text))
                textBox1.AppendText(".");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            inputStr.Clear();
            inputStr.Add('0');
            textBox1.Text = "0";
            textBox2.Text = "0";
        }



        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("=");
            //textBox2.Text = textBox1.Text;
            textBox1.Text = DataOp.DataMain();
            textBox2.Text = textBox1.Text;
            string temp = DataOp.DataMain();
            inputStr.Clear();
            for (int i = 0; i < temp.Length; i++)
            {
                inputStr.Add(temp[i]);
            }
        }
        private int getLeft(string s)   //得到匹配最后一个右括号的左括号
        {
            Stack<char> newstack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[s.Length - 1 - i])
                {

                    case ')'://右括号，入栈
                        newstack.Push(s[s.Length - i - 1]);
                        break;
                    case '(':
                        if (newstack.Peek() == ')')
                        {
                            newstack.Pop();//出栈
                        }
                        break;
                }
                if (newstack.Count == 0)
                {
                    return s.Length - 1 - i;
                }
            }
            return 0;
        }
        private string findNum()    //得到最后一个数字或带括号的表达式
        {
            string s = textBox1.Text;
            int index = -1;
            if (s[s.Length - 1] == ')')
            {
                index = getLeft(s)-1;
            }
            else
            {
                index = s.LastIndexOf('+') + 1 != 0 ? s.LastIndexOf('+') : index;
                index = s.LastIndexOf('-') + 1 != 0 ? s.LastIndexOf('-') > index ? s.LastIndexOf('-') : index : index;
                index = s.LastIndexOf('*') + 1 != 0 ? s.LastIndexOf('*') > index ? s.LastIndexOf('*') : index : index;
                index = s.LastIndexOf('/') + 1 != 0 ? s.LastIndexOf('/') > index ? s.LastIndexOf('/') : index : index;
            }
            textBox1.Text = textBox1.Text.Substring(0, index + 1);
            return s.Substring(index + 1, s.Length - index - 1);

        }
        private void button18_Click(object sender, EventArgs e)
        {
            if (juidgeNotSym(textBox1.Text))
            {
                string s = findNum();
                if (s != "")
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        inputStr.RemoveAt(inputStr.Count - 1);
                    }
                    inputStr.Add('√');
                    inputStr.Add('(');
                    for (int i = 0; i < s.Length; i++)
                    {
                        inputStr.Add(s[i]);
                    }
                    inputStr.Add(')');
                }
                textBox1.AppendText("√(" + s + ")");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            {
                string s = findNum();
                if (s != "")
                {
                    inputStr.Add('(');
                    for (int i = 0; i < s.Length; i++)
                    {
                        inputStr.Add(s[i]);
                    }
                    inputStr.Add(')');
                    inputStr.Add('^');
                    inputStr.Add('2');
                }
                textBox1.AppendText("(" + s + ")^2");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            {
                string s = findNum();
                if (s != "")
                {
                    inputStr.Add('(');
                    for (int i = 0; i < s.Length; i++)
                    {
                        inputStr.Add(s[i]);
                    }
                    inputStr.Add(')');
                    inputStr.Add('^');
                }
                textBox1.AppendText("(" + s + ")^");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (!juidgeNotSym(textBox1.Text))
            {
                string s = textBox2.Text;
                textBox1.AppendText("(");
                inputStr.Add('(');
                for (int i = 0; i < textBox2.Text.Length; i++)
                {
                    inputStr.Add(s[i]);
                    textBox1.AppendText("" + s[i]);
                }
                textBox1.AppendText(")");
                inputStr.Add(')');
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (!juidgeNotSym(textBox1.Text)|| textBox1.Text == "0")
            {
                inputStr.Add('π');
                if (textBox1.Text == "0")
                {
                    textBox1.Text = "π";
                }
                else
                {
                    textBox1.AppendText("π");
                }
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (juidgeNotSym(textBox1.Text)&textBox1.Text!="0")
            {
                string s = findNum();
                if (s != "")
                {
                    for(int i = 0; i < s.Length; i++)
                    {
                        inputStr.RemoveAt(inputStr.Count - 1);
                    }
                    double d1 = Convert.ToDouble(s);
                    string s1 = Convert.ToString(1 / d1);
                    for (int i = 0; i < s1.Length; i++)
                    {
                        inputStr.Add(s1[i]);
                        textBox1.AppendText("" + s1[i]);
                    }
                }
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (juidgeNotSym(textBox1.Text))
            {
                string s = findNum();
                if (s != "")
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        inputStr.RemoveAt(inputStr.Count - 1);
                    }
                    inputStr.Add('(');
                    for (int i = 0; i < s.Length; i++)
                    {
                        inputStr.Add(s[i]);
                    }
                    inputStr.Add(')');
                    inputStr.Add('!');
                }
                textBox1.AppendText("(" + s + ")!");
            }
        }
        private void myProcess(string s2)
        {
            if (juidgeNotSym(textBox1.Text))
            {
                string s = findNum();
                double d1 = 0;
                if (s != "")
                {
                    switch (s2)
                    {
                        case "sin":
                            d1 = Math.Sin(Convert.ToDouble(s));
                            break;
                        case "cos":
                            d1 = Math.Cos(Convert.ToDouble(s));
                            break;
                        case "tan":
                            d1 = Math.Tan(Convert.ToDouble(s));
                            break;
                        case "ln":
                            d1 = Math.Log(Convert.ToDouble(s));
                            break;
                        case "lg":
                            d1 = Math.Log10(Convert.ToDouble(s));
                            break;
                    }
                    string s1 = "" + d1;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (inputStr.Count != 0)
                        {
                            inputStr.RemoveAt(inputStr.Count - 1);
                        }
                    }
                    for (int i = 0; i < s1.Length; i++)
                    {
                        inputStr.Add(s1[i]);
                        textBox1.AppendText(s1[i] + "");
                    }
                }
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            myProcess("sin");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            myProcess("cos");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            myProcess("tan");
        }

        private void button32_Click(object sender, EventArgs e)
        {
            myProcess("lg");
        }

        private void button31_Click(object sender, EventArgs e)
        {
            myProcess("ln");
        }
        private void addKuo()
        {
            if (juidgeNotSym(textBox1.Text))
            {
                string s = findNum();
                if (s != "")
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        inputStr.RemoveAt(inputStr.Count - 1);
                    }
                    inputStr.Add('(');
                    inputStr.Add('-');
                    for (int i = 0; i < s.Length; i++)
                    {
                        inputStr.Add(s[i]);
                    }
                    inputStr.Add(')');
                }
                textBox1.AppendText("(-" + s + ")");
            }
        }
        private void delKuo()
        {
            if (juidgeNotSym(textBox1.Text))
            {
                string s = findNum();
                if (s != "")
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        inputStr.RemoveAt(inputStr.Count - 1);
                    }
                   
                    for (int i = 2; i < s.Length-1; i++)
                    {
                        inputStr.Add(s[i]);
                    }
                }
                textBox1.AppendText("" + s.Substring(2,s.Length-3) );
            }
        }

        public static List<char> inputStr2 = new List<char>(1000);
        private string countKuo(string s)
        {
            foreach (char c in inputStr)
            {
                inputStr2.Add(c);
            }
            while (inputStr2.Count != getLeft(s))
            {
                Console.WriteLine(getLeft(s));
                inputStr2.RemoveAt(inputStr2.Count - 1);
            }
            inputStr.Clear();
            string s1 = textBox1.Text;
            for (int i = getLeft(s1) + 1; i < s1.Length-1; i++)
            {
                inputStr.Add(textBox1.Text[i]);
            }
            string temp = DataOp.DataMain();
            if (temp[0] == '-') { temp = "(" + temp + ")"; }
            for (int i = 0; i < temp.Length; i++)
            {
                inputStr2.Add(temp[i]);
            }
            inputStr.Clear();
            textBox1.Text = "";
            foreach(char c in inputStr2)
            {
                inputStr.Add(c);
                textBox1.AppendText(c + "");
            }
            return temp;
        }
        private void button33_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            if(s[s.Length - 1] == ')')
            {
                countKuo(s);
            }
            s = textBox1.Text;
            if (s[s.Length - 1] == ')' && s[getLeft(s) + 1] == '-')
            {
                delKuo();
            }
            else
            {
                string s1 = findNum();
                if(s.Length == s1.Length + 1)
                {
                    textBox1.Text = "";
                    inputStr.Clear();
                    for (int i = 1; i < s.Length; i++)
                    {
                        textBox1.AppendText("" + s[i]);
                        inputStr.Add(s[i]);
                    }
                }
                else
                {
                    textBox1.Text += s1;
                    addKuo();
                }
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
