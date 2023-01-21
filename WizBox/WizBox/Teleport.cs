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
    public partial class Teleport : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        string commons = "{END}";
        string home = "{HOME}";
        string setMark = "{PGDN}";
        string telMark = "{PGUP}";

        Form1 f1;
        Process[] procList;

        Color successColor = Color.LimeGreen;
        Color failColor = Color.Red;

        public Teleport()
        {
            InitializeComponent();
            this.Size = new Size(115, 31);
        }

        public void SetForm(Form1 form1)
        {
            f1 = form1;
            Console.WriteLine("Finished setting forms for TP");
        }
        public void SetProcList(Process[] list)
        {
            procList = list;
            Console.WriteLine("Finished setting proclist for TP");
        }
        //Util
        private void InputToEachClient(string input)
        {
            for (int i = 0; i < procList.Length; i++)
            {
                Console.WriteLine($"Teleport To Client #{i}");
                SetForegroundWindow(procList[i].MainWindowHandle);

                Console.WriteLine($"Input: {input}");
                SendKeys.Send(input);
            }
            SetForegroundWindow(procList[0].MainWindowHandle);
            f1.WriteOutput($"[{this.Name}] Success: Finished teleporting to home.", successColor);
        }
        //Button Clicks
        private void comBtn_Click(object sender, EventArgs e)
        { InputToEachClient(commons); }
        private void homeBtn_Click(object sender, EventArgs e)
        { InputToEachClient(home); }
        private void markBtn_Click(object sender, EventArgs e)
        { InputToEachClient(setMark); }
        private void tpMarkBtn_Click(object sender, EventArgs e)
        { InputToEachClient(telMark); }
    }
}
