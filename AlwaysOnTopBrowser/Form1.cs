using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlwaysOnTopBrowser
{
    public partial class Form1 : Form
    {
        bool loading = false;

        public Form1()
        {
            InitializeComponent();

            webBrowser1.Navigating += new WebBrowserNavigatingEventHandler(webBrowser1_Navigating);
            webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
        }

        void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            tbxAddress.Text = webBrowser1.Url.ToString();
        }

        void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            btnReloadCancel.Image = (Image)Properties.Resources.cross;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = (Image)Properties.Resources.loadingAnimation;
            loading = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            btnReloadCancel.Image = (Image)Properties.Resources.arrow_refresh;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.Image = (Image)Properties.Resources.tick;
            loading = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void btnReloadCancel_Click(object sender, EventArgs e)
        {
            if (loading)
            {
                webBrowser1.Stop();
            }
            else
            {
                webBrowser1.Refresh();
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(tbxAddress.Text);
        }
    }
}
