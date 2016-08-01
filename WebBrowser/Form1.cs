using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //when exit menu item is selected
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Shanklish");
        }


        //OnClick, the web control will display the page requested in the TextBox
        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToPage();
        }

        //Core Navigation Function.
        private void NavigateToPage()
        {
            webBrowser1.Navigate(textBox1.Text);
            toolStripStatusLabel1.Text = "Navigation in Progress";
            textBox1.Enabled = false;
            button1.Enabled = false;
        }

        //Allows the user to press Enter to execute
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)ConsoleKey.Enter)
            {
                NavigateToPage();
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Navigation Complete";
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if(e.CurrentProgress > 0 && e.MaximumProgress > 0)
            toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
        }
    }
}
