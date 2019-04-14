using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        string name = "";
        string pass = "";
        string cypher = "DEFGHIJKLMNOPQRSTUVWXYZABC";
        string cypher3 = "defghijklmnopqrstuvwxyzabc";
        string pass2 = "";
        string name2 = "";
        bool n;
        public Form3(bool i)
        {
            n = i;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] str = System.IO.File.ReadAllLines(@"D:\secrets.txt");
            name = textBox1.Text;
            pass = textBox2.Text;
            for (int i = 0; i < str.Length; i++)
            {
               if(name.Equals(dename(str[i])))
                {
                    i++;
                    if (pass.Equals(depass(str[i])))
                            {
                        n = true;
                        this.Hide();
                    }
                }
                pass2 = "";
                name2 = "";
            }
        }
        public string depass(string pass3) {
            for (int i = 0; i < pass3.Length; i++)
            {

                int p;
                p = pass3[i] - 48;
                p = p / (i + 1);
                pass2 += p.ToString();
            }

            return pass2;
        }
        public string dename(string name3)
        {
            for (int i = 0; i < name3.Length; i++)
            {
                int c;
                if (name3[i] > 90)
                {
                    c = name3[i] - 96;
                    name2 += cypher3[c - 1];
                }
                else
                {
                    c = name3[i] - 64;
                    name2 += cypher[c - 1];
                }
            }
            return name2;
        }
        public bool getn() { return n; }
        public string getname() { return name; }
    }
}
