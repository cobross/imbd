using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Net;


namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        String plot;
        Boolean Reg=false;
        string name;
        Form3 log = new Form3(false);
        public Form1()
        {
            InitializeComponent();
            this.button2.MouseHover += button2_MouseHover;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string url = "http://www.omdbapi.com/?t="+textBox1.Text.Trim()+"&apikey=3cedb535";
            using (System.Net.WebClient wc = new WebClient())
            {
                wc.UseDefaultCredentials = true;
                var json = wc.DownloadString(url);
                JavaScriptSerializer oJS = new JavaScriptSerializer();
                ImdbEntity obj = new ImdbEntity();
                obj = oJS.Deserialize<ImdbEntity>(json);
                if (obj.Response == "True")
                {
                     label1.Text = obj.Title;
                     label2.Text = obj.Year;
                     label3.Text = obj.Rated;
                     label4.Text = obj.Runtime;
                     label7.Text = obj.Genre;
                     label8.Text = obj.Director;
                     label9.Text = obj.Writer;
                     label10.Text = obj.Actors;
                     plot = obj.Plot;
                }
                else
                {
                    MessageBox.Show("Movie not Found!!!");
                }


            }
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.button2, plot);
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Reg = log.getn();
            name = log.getname();
            if (Reg == true)
            {
                using (System.IO.StreamWriter file =
              new System.IO.StreamWriter(@"D:\"+name+".txt", true))
                {
                    file.WriteLine(label1.Text);
                    file.WriteLine(label2.Text);
                    file.WriteLine(label3.Text);
                    file.WriteLine(label4.Text);
                    file.WriteLine(label7.Text);
                    file.WriteLine(label8.Text);
                    file.WriteLine(label9.Text);
                    file.WriteLine(label10.Text);
                    file.WriteLine(plot);
                }
            }
            else
                MessageBox.Show("You are not loged in!");
        }

        private void button4_Click(object sender, EventArgs e)
        {          
            log.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 settingsForm = new Form2();
            settingsForm.Show();
        }
    }
    public class ImdbEntity
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Released { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public string Metascore { get; set; }
        public string imdbRating { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Response { get; set; }
    }

}
