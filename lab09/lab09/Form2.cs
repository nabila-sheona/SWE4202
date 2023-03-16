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
        // string file = @"C:\Users\nitol\source\repos\lab_tasks\lab09\lab09\TextFile1.txt";
        public Form2()
        {
            InitializeComponent();
        }

        List<string> user = new List<string>();

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = (textBox2.Text);
            int c = a.Length;


            string b = (textBox4.Text);
            int d = b.Length;


            if (c >= 4 && d >= 6)
            {
                string userName = textBox2.Text;
                string name = textBox1.Text;
                string pass = textBox4.Text;
                string path = @"C:\Users\nitol\source\repos\lab_tasks\lab09\lab09\TextFile1.txt";
                bool use = true;
                foreach (string u in user)
                {
                    if (u == userName)
                    {
                        MessageBox.Show("Username not available!");
                        use= false;
                        break;
                    }
                }
                if (use== true) {
                    if (textBox4.Text != textBox3.Text)
                    {
                        MessageBox.Show("Password didn't Match!");
                    }
                    else
                    {

                        MessageBox.Show("created!");

                        string s = textBox1.Text + " " + textBox2.Text + " " + textBox4.Text;

                        File.AppendAllText(path, name + " " + userName + " " + pass);

                        File.AppendAllText(path, "\n");

                        Form1 f1 = new Form1();
                        f1.Show();
                        this.Hide();

                    }
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

        private void Form2_Load(object sender, EventArgs e)
        {
            StreamReader s1 = new StreamReader(@"C:\Users\nitol\source\repos\lab_tasks\lab09\lab09\TextFile1.txt");
            string line = "";
            while ((line = s1.ReadLine()) != null)
            {
                string[] components = line.Split(" ".ToCharArray());

                user.Add(components[1]);
                
            }

            s1.Close();
        }
    }
}
