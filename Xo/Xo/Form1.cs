using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xo
{
    public partial class Form1 : Form
    {
        // public Button[] button = new Button[9];
        public List<Button> button = new List<Button>();
        public int Gedis = 1;
        public Form1()
        {
            InitializeComponent();
            Create();
        }
        private void Play(object sender, EventArgs e)
        {
            bool f = false;
            int j = 0;
            int a = 3;
            Button btn = sender as Button;
            if (Gedis ==1 && btn.Text == "")
            {
                btn.Text = "X";
                Gedis = Gedis * -1;
            }
            if (Gedis == -1 && btn.Text == "")
            {
                btn.Text = "O";
                Gedis = Gedis * -1;
            }

            // Setrleri yoxlamaq ucun 
            for (int i = 0; i < 9; i++)
            {
                if (button[i].Text == button[i+1].Text && button[i].Text == button[i+2].Text && button[i].Text != "")
                {
                    MessageBox.Show(button[i].Text + "  Qalibdir");
                    this.Close();
                }
                i += 2;
            }

            //sutunlari yoxlamaq ucun 
            for (int i = 0; i < 9; i++)
            {
                if (button[i].Text == button[i + 3].Text && button[i].Text == button[i + 6].Text && button[i].Text != "")
                {
                    MessageBox.Show(button[i].Text + "  Qalibdir");
                    this.Close();
                }
                if (i==2)
                {
                    break;
                }
            }

            // dioganallar
            for (int i = 0; i < 9; i++)
            {
                if (button[i].Text == button[i + 4].Text && button[i].Text == button[i + 8].Text && button[i].Text != "")
                {
                    MessageBox.Show(button[i].Text + "  Qalibdir");
                    this.Close();
                }
                if (button[i+2].Text == button[i + 4].Text && button[i+2].Text == button[i + 6].Text && button[i + 2].Text != "")
                {
                    MessageBox.Show(button[i].Text + "  Qalibdir");
                    this.Close();
                }
                break;
            }


        }
        void Create()
        {
            int Toppos = 70;
            int Leftpos = 70;
            for (int i = 1; i <= 9; i++)
            {
                Button btn = new Button();
                btn.Width = 70;
                btn.Height = 70;
                btn.Left = Leftpos;
                btn.Top = Toppos;
                btn.Click += Play;
                btn.Text = "";
                int newSize = 20;
                btn.Font = new Font(btn.Font.FontFamily, newSize);
                Controls.Add(btn);
                button.Add(btn);
                Leftpos += 70;
                if (i%3==0)
                {
                    Leftpos = 70;
                    Toppos += 70;
                }
                            
            }
        }  
    }

}
