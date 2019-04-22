using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {   public List<ImdbEntity> imbd = new List<ImdbEntity>();
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
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 6;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            button1.BackgroundImage = new Bitmap(@"C:\Users\wewewewe\Desktop\app art\login.png");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = new Bitmap(@"C:\Users\wewewewe\Desktop\app art\bg.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] str = System.IO.File.ReadAllLines(@"F:\secrets.txt");
            name = textBox1.Text;
            pass = textBox2.Text;
            for (int i = 0; i < str.Length; i++)
            {
               if(name.Equals(dename(str[i])))
                {
                    i++;
                    if (pass.Equals(depass(str[i])))
                    {
                        readall();
                        n = true;
                        this.Hide();
                    }
                }
                pass2 = "";
                name2 = "";
            }
        }
        public void readall()
        {
            string[] str = System.IO.File.ReadAllLines(@"F:\" + name + ".txt");
            for (int i = 0; i < str.Length/10; i++)
            {
                ImdbEntity obj = new ImdbEntity();
                obj.Title = str[0+i*10];
                obj.Year = str[1 + i * 10];
                obj.Rated = str[2 + i * 10];
                obj.Runtime = str[3 + i * 10];
                obj.Genre = str[4 + i * 10];
                obj.Director = str[5 + i * 10];
                obj.Writer = str[6 + i * 10];
                obj.Actors = str[7 + i * 10];
                obj.Plot = str[8 + i * 10];
                obj.Poster = str[9 + i * 10];
                imbd.Add(obj);
            }
        }
        public string depass(string pass3) {
            for (int i = 0; i < pass3.Length; i++)
            {

                int p;
                p = 10*(pass3[i] - 48);
                i++;
                p += pass3[i] - 48;
                p = p % 10;
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
