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
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usrTxt.Text.Length < 3 || usrTxt.Text == " " || passTxt.Text.Length < 5)
            {
                MessageBox.Show("Please enter a longer username or password.");
            }
            else
            {
                string dir = usrTxt.Text;
                Directory.CreateDirectory("data\\" + dir);

                var SW = new StreamWriter("data\\" + dir + "\\data.ls");

                string encusr = LogCryp.Encrypt(usrTxt.Text);
                string encpass = LogCryp.Encrypt(passTxt.Text);

                SW.WriteLine(encusr);
                SW.WriteLine(encpass);
                SW.Close();

                MessageBox.Show("User was successfully created.", usrTxt.Text);
                this.Close();

            }
        }
    }
}
