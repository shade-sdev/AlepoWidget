using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using ByteSizeLib;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;


namespace AlepoWSRC
{
    public partial class AlepoWSRC : Form
    {
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        string usageString = "";
        public AlepoWSRC()
        {
    
            InitializeComponent();
        }

        private async void AlepoWSRC_Load(object sender, EventArgs e)
        {
          
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
            this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Right - (this.Width + 30), (Screen.PrimaryScreen.Bounds.Size.Height - this.Height - 80));
            checkUserCredentials();

           
            AlepoWSRCTray.ShowBalloonTip(3000, "Usage", await scrapDataUsage(), ToolTipIcon.Info);
        }

        private void AlepoWSRC_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }


        private async void getRemainingDataUsage()
        {
            await Task.Run(() => scrapDataUsage());
            closePhantomJS();


        }

        private async Task<string> scrapDataUsage()
        {
            loadProgress.Invoke((Action)(() => loadProgress.Value = 0));
            loadProgress.Invoke((Action)(() => loadProgress.Visible = true));
            loadProgress.Invoke((Action)(() => loadProgress.Value = 25));
            string dataUsage = "";
            var driverService = PhantomJSDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            var driver = new PhantomJSDriver(driverService);
            loadProgress.Invoke((Action)(() => loadProgress.Value = 50));
            driver.Navigate().GoToUrl("https://internetaccount.myt.mu/");
            driver.FindElement(By.Name("signInForm.username")).SendKeys(Constants.username);
            driver.FindElement(By.Name("signInForm.password")).SendKeys(Constants.password);
            driver.FindElement(By.Name("signInContainer:submit")).Click();
          
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(driver.PageSource);
            try
            {
              dataUsage = doc.DocumentNode.SelectSingleNode("//font[@class='tplus_text']//span//label[contains(text(),'Mb')]").InnerText;
            }catch(System.NullReferenceException e)
            {
                clearCredentials();
                Invoke((Action)delegate
                {
                    MessageBox.Show("Invalid Credentials, restart the application.");
                    Close();

                });
                
            }
          
            double usage = Double.Parse(dataUsage.Substring(0, dataUsage.IndexOf("Mb")));
            lblDataUsage.Invoke((Action)delegate
            {
                lblDataUsage.Text = ByteSize.FromMegaBytes(usage).ToString();
                usageString = ByteSize.FromMegaBytes(usage).ToString();
                loadProgress.Invoke((Action)(() => loadProgress.Value = 100));

            });
            await Task.Delay(TimeSpan.FromSeconds(2));
            loadProgress.Invoke((Action)(() => loadProgress.Visible = false));
            loadProgress.Invoke((Action)(() => loadProgress.Value = 0));

            return ByteSize.FromMegaBytes(usage).ToString();
        }

        private void checkUserCredentials()
        {
            if (ResourceHelper.CheckResource("username") == false)
            {
                string username = Microsoft.VisualBasic.Interaction.InputBox("Username", "Enter your username", "", -1, -1);
                if (username != string.Empty)
                {
                    ResourceHelper.AddOrUpdateResource("username", username);
                }
            }

            if (ResourceHelper.CheckResource("password") == false)
            {
                string password = Microsoft.VisualBasic.Interaction.InputBox("Password", "Enter your password", "", -1, -1);
                if (password != string.Empty)
                {
                    ResourceHelper.AddOrUpdateResource("password", password);
                }
            }
        }

        private void clearCredentials()
        {
            ResourceHelper.AddOrUpdateResource("username", string.Empty);
            ResourceHelper.AddOrUpdateResource("password", string.Empty);
        }

        private void iconPic_Click(object sender, EventArgs e)
        {
          
        
            getRemainingDataUsage();
        }

        private void closePhantomJS()
        {
            Process.Start("openkillphantom.vbs");


      

        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private void AlepoWSRCTray_DoubleClick(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Show();
            }
            else
            {
                this.Hide();
            }

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void showUsageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlepoWSRCTray.ShowBalloonTip(3000, "Usage", await scrapDataUsage(), ToolTipIcon.Info);
        }





    }
}
