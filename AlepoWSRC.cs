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
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using RestSharp;
using static AlepoWSRC.Constants;
using Newtonsoft.Json;

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
            await scrapDataUsage();
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

            var dataUsage = await this.GetUserDataFromMyT();
          
            double usage = Double.Parse(dataUsage);
            lblDataUsage.Invoke((Action)delegate
            {
                lblDataUsage.Text = ByteSize.FromMegaBytes(usage).ToString();
                usageString = ByteSize.FromMegaBytes(usage).ToString();
                loadProgress.Invoke((Action)(() => loadProgress.Value = 100));

            });

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

        private async Task<string> Login()
        {

            var options = new RestClientOptions(AUTH_URL)
            {
                ThrowOnAnyError = true,
                Timeout = 1000
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            var client = new RestClient(options);

            var request = new RestRequest()
                .AddHeaders(headers)
                .AddJsonBody(
                new
                {
                    email = USERNAME,
                    password = PASSWORD,
                    otp = "",
                    rememberMe = "",
                    token = ""
                });

            var response = await client.PostAsync(request);
            var tokenResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);
            return "Bearer "+ tokenResponse.token;
        }

        private async Task<Dictionary<string, string>> GetUserIdentifier()
        {
            var options = new RestClientOptions(USER_IDENTIFIER_URL)
            {
                ThrowOnAnyError = true,
                Timeout = 1000
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", await this.Login());

            var client = new RestClient(options);
            var request = new RestRequest()
                .AddHeaders(headers);

            var response = await client.GetAsync(request);
            var userIdentifierResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);

            string identifierName = userIdentifierResponse[0].subscritionIdentifier;
            string identifierValue = userIdentifierResponse[0].subscritionIdentifierValue;

            Dictionary<string, string> identifiers = new Dictionary<string, string>();
            identifiers.Add("identifierName", identifierName.Substring(identifierName.LastIndexOf("-") + 1));
            identifiers.Add("identifierValue", identifierValue);

            return identifiers;
        }

        private async Task<string> GetUserDataFromMyT()
        {
            var options = new RestClientOptions(USER_DATA_URL)
            {
                ThrowOnAnyError = true,
                Timeout = 1000
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            headers.Add("Authorization", await this.Login());

            Dictionary<string, string> identifiers = await this.GetUserIdentifier();

            var client = new RestClient(options);

            var request = new RestRequest()
                .AddHeaders(headers)
                .AddJsonBody(new
                {
                    identifierName = identifiers["identifierName"],
                    identifierValue = identifiers["identifierValue"]
                });

            var response = await client.PostAsync(request);
            var userData = JsonConvert.DeserializeObject<dynamic>(response.Content);

            string usage = userData.response[1].convertedBalance;


            return usage.Substring(0, usage.IndexOf(":"));
        }


    }

}
