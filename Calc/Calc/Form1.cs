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
        public string eded1="";
        public string eded2 = "";
        public string emeliyyat;
        public Form1()
        {
            InitializeComponent();
            Create();
            Emeliyyatlar();
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
                Controls.Add(btn);
                Toppos += 70;

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
                btn.Left = Leftpos;
                btn.Click += eded;
                Controls.Add(btn);
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

            label1.Text = Emeliyyat(Convert.ToInt32(eded1), Convert.ToInt32(eded2), emeliyyat).ToString();
        }
    }
}
