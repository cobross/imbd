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
    public partial class Form2 : Form
    {
        string filename;
        string cypher = "XYZABCDEFGHIJKLMNOPQRSTUVW";
        string cypher3 = "xyzabcdefghijklmnopqrstuvw"; 
        string cypher2 = "";
        int c;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            incrypt();
            this.Close();
        }
        public void incrypt()
        {
            filename = textBox1.Text;
            string pass = textBox2.Text;
            string pass2="";
            int p;
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                    if (!string.IsNullOrWhiteSpace(textBox3.Text))
                        if(textBox2.Text.Equals(textBox3.Text))
                            if(check())
                        if (!System.IO.File.Exists(@"D:\" + filename + ".txt"))
            {
                System.IO.File.Create(@"D:\" + filename + ".txt");
                for(int i = 0; i < pass.Length; i++)
                {
                    p = pass[i] - 48;
                    p *= (i+1);
                    pass2 += p.ToString();
                }
                string name = textBox1.Text;
                for (int i = 0; i < name.Length; i++)
                {
                                        if (name[i] > 90)
                                        {
                                            c = name[i] - 96;
                                            cypher2 += cypher3[c - 1];
                                        }
                                        else
                                        {
                                            c = name[i] - 64;
                                            cypher2 += cypher[c - 1];
                                        }                    
                }
                using (System.IO.StreamWriter file =
              new System.IO.StreamWriter(@"D:\secrets.txt", true))
                {
                    file.WriteLine(cypher2);
                    file.WriteLine(pass2);
                }
            }
            else
                MessageBox.Show("Username Taken");
            else MessageBox.Show("your pass can contain only numbres");
            else MessageBox.Show("passwords dont match"); 
            else MessageBox.Show("you need to confirm your pass");
            else MessageBox.Show("you need to enter a pass");
            else MessageBox.Show("you need to enter username");
        }
        public bool check()
        {
            string pass3 = textBox2.Text;
            for (int i = 0; i < pass3.Length; i++)
                if (pass3[i] < 48 || pass3[i] > 57)
                    return false;
            return true;
        }
    }
}
