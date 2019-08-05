using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogEncDec;
using System.IO;

namespace Login_Portal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegForm rf = new RegForm();
            rf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (usrTxt.Text.Length < 3 || usrTxt.Text == " " || passTxt.Text.Length < 5)
            {
                MessageBox.Show("Please enter a longer username or password.");
            }
            else
            {
                string dir = usrTxt.Text;
                if (!Directory.Exists("data\\" + dir))
                    MessageBox.Show("Username or Password is Incorrrect.", dir);
                else
                {
                    var sr = new StreamReader("data\\" + dir + "\\data.ls");

                    string encusr = sr.ReadLine();
                    string encpass = sr.ReadLine();
                    sr.Close();

                    string decusr = LogCryp.Decrypt(encusr);
                    string decpass = LogCryp.Decrypt(encpass);

                    if (decusr == dir && decpass == passTxt.Text)
                    {
                        MessageBox.Show("Welcome. You have successfully loged in!", decusr);
                    }
                    else
                    {
                        MessageBox.Show("Error. Username or Password is incorrect.");
                    }
                }
            }

        }
    }
}
