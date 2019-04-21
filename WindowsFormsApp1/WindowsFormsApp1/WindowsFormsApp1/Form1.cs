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
        int pagenumber = 0;
        string writer = "";
        string actors = "";
        Form3 log = new Form3(false);
        public Form1()
        {
           
            InitializeComponent();
            quarter1(0, 0);
            quarter2(0);
            quarter3(0);
            quarter4(0);
            button6.Hide();
            button7.Hide();
            this.button2.MouseHover += button2_MouseHover;
        }
        public void quarter1(int i,int j)
        {
            if(i==1)
            {
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Show();
                label7.Show();
                label8.Show();
                button2.Show();
                if(j==1)
                button9.Show();
            }
            if(i==0)
            {
                label1.Hide();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label7.Hide();
                label8.Hide();
                button2.Hide();
                button9.Hide();
            }
        }
        public void quarter2(int i)
        {
            if (i == 1)
            {
                label11.Show();
                label12.Show();
                label13.Show();
                label14.Show();
                label15.Show();
                label16.Show();
                button11.Show();
            }
            if (i == 0)
            {
                label11.Hide();
                label12.Hide();
                label13.Hide();
                label14.Hide();
                label15.Hide();
                label16.Hide();
                button11.Hide();
            }
        }
        public void quarter3(int i)
        {
            if (i == 1)
            {
                label19.Show();
                label20.Show();
                label21.Show();
                label22.Show();
                label23.Show();
                label24.Show();
                button13.Show();
            }
            if (i == 0)
            {
                label19.Hide();
                label20.Hide();
                label21.Hide();
                label22.Hide();
                label23.Hide();
                label24.Hide();
                button13.Hide();
            }
        }
        public void quarter4(int i)
        {
            if (i == 1)
            {
                label27.Show();
                label28.Show();
                label29.Show();
                label30.Show();
                label31.Show();
                label32.Show();
                button15.Show();
            }
            if (i == 0)
            {
                label27.Hide();
                label28.Hide();
                label29.Hide();
                label30.Hide();
                label31.Hide();
                label32.Hide();
                button15.Hide();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private int sortAZ(ImdbEntity a,ImdbEntity b)
        {

            return a.Title.CompareTo(b.Title);
        }
        private int sortZA(ImdbEntity a, ImdbEntity b)
        {

            return b.Title.CompareTo(a.Title);
        }
        private int sortYear1(ImdbEntity a, ImdbEntity b)
        {

            return a.Title.CompareTo(b.Year);
        }
        private int sortYear2(ImdbEntity a, ImdbEntity b)
        {

            return b.Title.CompareTo(a.Year);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (log.getn() == true)
            {
                button6.Show();
                button7.Show();
                pagenumber = 0;
                page();
            }
            else
                MessageBox.Show("You are not loged in!");

        }
        public void page()
        {
            int size = log.imbd.Count-pagenumber;
            if (size > 0)
            {
                quarter1(1, 0);
                label1.Text = log.imbd[pagenumber].Title;
                label2.Text = log.imbd[pagenumber].Year;
                label3.Text = log.imbd[pagenumber].Rated;
                label4.Text = log.imbd[pagenumber].Runtime;
                label7.Text = log.imbd[pagenumber].Genre;
                label8.Text = log.imbd[pagenumber].Director;
                pagenumber++;            size--;
            }
            if (size > 0)
            {
                quarter2(1);
                label11.Text = log.imbd[pagenumber].Director;
                label12.Text = log.imbd[pagenumber].Genre;
                label13.Text = log.imbd[pagenumber].Runtime;
                label14.Text = log.imbd[pagenumber].Rated;
                label15.Text = log.imbd[pagenumber].Year;
                label16.Text = log.imbd[pagenumber].Title;
                pagenumber++; size--;
            }
            else quarter2(0);
            if (size > 0)
            {
                quarter3(1);
                label19.Text = log.imbd[pagenumber].Director;
                label20.Text = log.imbd[pagenumber].Genre;
                label21.Text = log.imbd[pagenumber].Runtime;
                label22.Text = log.imbd[pagenumber].Rated;
                label23.Text = log.imbd[pagenumber].Year;
                label24.Text = log.imbd[pagenumber].Title;
                pagenumber++; size--;
            }
            else quarter3(0);       
            if (size > 0)
            {
                quarter4(1);
                label27.Text = log.imbd[pagenumber].Director;
                label28.Text = log.imbd[pagenumber].Genre;
                label29.Text = log.imbd[pagenumber].Runtime;
                label30.Text = log.imbd[pagenumber].Rated;
                label31.Text = log.imbd[pagenumber].Year;
                label32.Text = log.imbd[pagenumber].Title;
                pagenumber++;size--;
            }
            else quarter4(0);
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
                     writer = obj.Writer;
                     actors = obj.Actors;
                     plot = obj.Plot;
                }
                else
                {
                    MessageBox.Show("Movie not Found!!!");
                }

                quarter1(1, 1);
                quarter2(0);
                quarter3(0);
                quarter4(0);
            }
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.button2, plot);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int j=0;
            for(int i=pagenumber;i>4;i++){
                i=i-5;
                j++;
            }
            MessageBox.Show(log.imbd[0 + j * 4].Writer + "\n" +
                log.imbd[0 + j * 4].Actors + "\n" + log.imbd[0 + j * 4].Plot);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Reg = log.getn();
            name = log.getname();
            if (Reg == true)
            {
                using (System.IO.StreamWriter file =
              new System.IO.StreamWriter(@"F:\"+name+".txt", true))
                {
                    file.WriteLine(label1.Text);
                    file.WriteLine(label2.Text);
                    file.WriteLine(label3.Text);
                    file.WriteLine(label4.Text);
                    file.WriteLine(label7.Text);
                    file.WriteLine(label8.Text);
                    file.WriteLine(writer);
                    file.WriteLine(actors);
                    file.WriteLine(plot);
                }
            }
            else
                MessageBox.Show("You are not loged in!");
            quarter1(0, 0);
            ImdbEntity obj = new ImdbEntity();
            obj.Title = label1.Text;
            obj.Year = label2.Text;
            obj.Rated = label3.Text;
            obj.Runtime = label4.Text;
            obj.Genre = label7.Text;
            obj.Director = label8.Text;
            obj.Writer = writer;
            obj.Actors = actors;
            log.imbd.Add(obj);
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (log.getn() == true)
            {
                page();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (log.getn() == true)
            {
                if (pagenumber > 4)
                {
                    pagenumber = pagenumber - 5;
                    page();
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            log.imbd.Sort(sortAZ);
            pagenumber = 0;
            page();
            button6.Show();
            button7.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            log.imbd.Sort(sortZA);
            pagenumber = 0;
            page();
            button6.Show();
            button7.Show();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            log.imbd.Sort(sortYear1);
            pagenumber = 0;
            page();
            button6.Show();
            button7.Show();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            log.imbd.Sort(sortYear2);
            pagenumber = 0;
            page();
            button6.Show();
            button7.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = pagenumber; i > 4; i++)
            {
                i = i - 5;
                j++;
            }
            MessageBox.Show(log.imbd[1 + j * 4].Writer + "\n" +
                log.imbd[1 + j * 4].Actors + "\n" + log.imbd[1 + j * 4].Plot);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = pagenumber; i > 4; i++)
            {
                i = i - 5;
                j++;
            }
            MessageBox.Show(log.imbd[2 + j * 4].Writer + "\n" +
                log.imbd[2 + j * 4].Actors + "\n" + log.imbd[2 + j * 4].Plot);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = pagenumber; i > 4; i++)
            {
                i = i - 5;
                j++;
            }
            MessageBox.Show(log.imbd[3 + j * 4].Writer + "\n" +
                log.imbd[3 + j * 4].Actors + "\n" + log.imbd[3 + j * 4].Plot);
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
