using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WizBox
{
    public partial class TimerOverlay : Form
    {
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int LPAR);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        public TimerOverlay()
        {
            InitializeComponent();

            timer1.Start();
        }
        #region Utils
        #endregion
        #region UI
        private void drag_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void xBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string timeOfDay = DateTime.Now.ToString("hh:mm:ss tt");
            label1.Text = timeOfDay;
        }
        #endregion
    }
}
