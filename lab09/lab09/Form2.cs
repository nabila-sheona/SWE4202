using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab09
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string rep;
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = (textBox2.Text);
            int c = a.Length;


            string b = (textBox4.Text);
            int d = b.Length;
            //string rep;

            if (c >= 6 && d >= 6)
            {
                string userName = textBox2.Text;
                string name = textBox1.Text;
                string pass = textBox4.Text;
                string path = $@"C:\Users\nitol\source\repos\lab_tasks\lab09\users.txt";
                
               // if (File.Exists(path))
                //{
                  //  MessageBox.Show("Username not available!");
                //}
                //else
                if (textBox4.Text != textBox3.Text)
                {
                    MessageBox.Show("Password didn't Match!");
                }
                else
                {
                    
                    MessageBox.Show("created!");
                    FileStream nFile = new FileStream($@"C:\Users\nitol\source\repos\lab_tasks\lab09\lab09\TextFile1.txt", FileMode.Create);

                    StreamWriter s1 = new StreamWriter(nFile);
                    // string s = $"p: {userName} n:{pass}";
                    string s = textBox1.Text+ " " + textBox2.Text + " " + textBox4.Text;

                  //  string s = $"p: {pass} n:{name}";
                   
                    string r=s;
                     rep = r + "\n" + s;
                    s1.WriteLine(rep);
                    s1.Close();

                    nFile.Close();

                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("minimum 6 characters");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
