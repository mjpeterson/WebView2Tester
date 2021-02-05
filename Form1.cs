using System;
using System.Windows.Forms;

namespace WebView2Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var frm = await Form2.CreateFormAsync();
            frm.Navigate("http://google.com");

            // lol wut. Without this the form is displayed as a blank.
            //await Task.Delay(1);

            // shows the form with the WebView2.
            frm.ShowDialog();
        }
    }
}
