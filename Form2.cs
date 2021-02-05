using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebView2Tester
{
    public partial class Form2 : Form
    {
        private Form2()
        {
            InitializeComponent();
            this.FormClosed += Form2_FormClosed;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Need to handle disposing the WebView2 on ShowDialog, otherwise the form closes but the browser pane seems to remain.
            // .Visible = false required, otherwise .Dispose throws an exception.
            webView.Visible = false;
            webView.Dispose();
        }

        public static async Task<Form2> CreateFormAsync()
        {
            var browser = new Form2();
            await browser.InitializeAsync();

            return browser;
        }

        Task InitializeAsync()
        {
            return webView.EnsureCoreWebView2Async(null);
        }

        public void Navigate(string url)
        {
            webView.CoreWebView2.Navigate(url);
        }
    }
}
