using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {
        List<Button> BTN = new List<Button>();
        public string eded1="";
        public string eded2 = "";
        public string emeliyyat;
        public Form1()
        {
            InitializeComponent();
            Create();
            this.KeyPreview = true;
            Emeliyyatlar();
            this.KeyUp += btn_KeyDown;
        }

        static int count = 0;
        private void eded(object sender, EventArgs e)
        {
       
            if (1>=count)
            {
                if (count==0)
                {
                    Button btn = sender as Button;
                    textBox1.Text += btn.Text;
                    eded1 += btn.Text;
                }
                else
                {
                    Button btn = sender as Button;
                    textBox1.Text += btn.Text;
                    eded2 += btn.Text;
                }
            }

        }
        private void emelliyat(object sender, EventArgs e)
        {
            count++;
            Button btn = sender as Button;

            textBox1.Text += btn.Text;
            emeliyyat = btn.Text;
        }
        public int Emeliyyat(int a,int b,string e)
        {
            if (e=="+")
            {
               return a + b;
            }
            if (e == "-")
            {
                return a - b;
            }
            if (e == "*")
            {
                return a * b;
            }
            if (e == "/")
            {
                return a - b;
            }
            return a / b;
        }

        void Emeliyyatlar()
        {
            string[] str = new string[] {"+","-","*","/" };
            int Toppos = 90;
            int Leftpos = 280;
            for (int i = 0; i <4; i++)
            {
                Button btn = new Button();
                btn.Width = 60;
                btn.Height = 60;
                btn.Text = str[i];
                btn.Click += emelliyat;
                btn.Top = Toppos;
                btn.Left = Leftpos;
               
              //  btn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_KeyDown);
                Controls.Add(btn);
              
                Toppos += 70;

            }
        }

        private void btn_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (Button item in BTN)
            {
                item.BackColor = Color.White;
            }
            var a = e.KeyCode.ToString();
            MessageBox.Show(e.KeyCode.ToString());
            foreach (Button item in BTN)
            {
                if (item.Name ==a[a.Length-1].ToString())
                {
                    item.BackColor = Color.Green;
                }
            }

        }

        void Create()
        {
            int Toppos = 90;
            int Leftpos = 60;
            for (int i = 1; i <= 11; i++)
            {
                Button btn = new Button();
                btn.Width = 60;
                btn.Height = 60;
                btn.Text = (i - 1).ToString();
                btn.Top = Toppos;
                btn.Name = btn.Text;
                btn.Left = Leftpos;
                btn.Click += eded;
                Controls.Add(btn);
                BTN.Add(btn);
                btn.BackColor = Color.White;
                Leftpos += 70;
                if (i % 3 == 0)
                {
                    Leftpos = 60;
                    Toppos += 70;
                }
            }
        }

        private void Hesabla_Click(object sender, EventArgs e)
        {
            string a = "";
            string b = "";
            string emeliyyatt = "";
            if (eded1 != "" && eded2 !="")
            {
                label1.Text = Emeliyyat(Convert.ToInt32(eded1), Convert.ToInt32(eded2), emeliyyat).ToString();
            }
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i]=='+' || textBox1.Text[i] == '-' || textBox1.Text[i] == '*' || textBox1.Text[i] == '/')
                {
                    emeliyyatt = textBox1.Text[i].ToString();
                    for (int j = 0; j < textBox1.Text.Length; j++)
                    {
                        if (j<i)
                        {
                            a += textBox1.Text[j];
                        }
                        else if (j>i)
                        {
                            b += textBox1.Text[j];
                        }
                    }
                    label1.Text = Emeliyyat(Convert.ToInt32(a), Convert.ToInt32(b), emeliyyatt).ToString();
                }
            }
        }
    }
}
