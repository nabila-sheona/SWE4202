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

namespace lab09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> user = new List<string>();
        List<string> pass = new List<string>();


        private void button1_Click(object sender, EventArgs e)
        {
             if (user.Contains(textBox1.Text) && pass.Contains(textBox2.Text) && Array.IndexOf(user.ToArray(), textBox1.Text) == Array.IndexOf(pass.ToArray(), textBox2.Text))
            {
                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();
            }

            else
            {

                MessageBox.Show("The username/password is incorrect");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            StreamReader s1 = new StreamReader($@"C:\Users\nitol\source\repos\lab_tasks\lab09\lab09\TextFile1.txt");
            string line = "";
            while ((line = s1.ReadLine()) != null)
            {
                string[] components = line.Split(" ".ToCharArray());

                user.Add(components[1]);
                pass.Add(components[2]);
            }

            s1.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
