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
    public partial class Topmost : Form
    {
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int LPAR);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        int width = Screen.PrimaryScreen.Bounds.Width;
        int height = Screen.PrimaryScreen.Bounds.Height;

        string commons = "{END}";
        string home = "{HOME}";
        string setMark = "{PGDN}";
        string telMark = "{PGUP}";

        Form1 form1;
        Overlay overlay;
        Topmost_Settings tmSettings;
        Teleport tp = new Teleport();

        Button[] btnList = new Button[4];
        Process[] procList;

        Color successColor = Color.LimeGreen;
        Color failColor = Color.Red;

        string winTitle = "";
        int procCount = 0;
        int curProcID = 0;
        int tempCurProcID = 0;

        bool foregroundBool = false;
        bool spacePressed = false;

        IntPtr fgHandle = IntPtr.Zero;
        Point centerTextPoint = new Point(0, 0);
        Point tpMenuPoint = new Point(0, 0);
        public Point nameTextPoint = new Point(0, 0);

        public Topmost()
        {
            InitializeComponent();

            ShowUI(false);
            ShowUI_FromList();

            SetPoints();

            timer1.Start();
            Console.WriteLine($"{this.Name} Loaded");
        }
        #region utils
        private void SetPoints()
        {
            centerTextPoint = new Point((width / 2), (height / 5) * (height / 250));
            nameTextPoint = new Point(centerTextPoint.X / 4, centerTextPoint.Y);
            tpMenuPoint = new Point(this.Location.X + tp.Size.Width, this.Location.Y - tp.Size.Height);
        }
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
            form1.WriteOutput($"[{this.Name}] Success: Finished teleporting to home.", successColor);
        }
        public void SetForms(Form1 f1, Overlay olay, Topmost_Settings tms)
        {
            form1 = f1;
            overlay = olay;
            tmSettings = tms;
            tmSettings.SetForm(this, overlay, f1, tp);
            tmSettings.GetConfigVars();
            tp.SetForm(f1);
        }
        public void SetProcInfo(int count, Process[] list)
        {
            procCount = count;
            procList = list;
            ShowUI_FromList();
            tp.SetProcList(list);
        }
        private int GetBtnCount()
        {
            int count = 0;

            foreach (Button btn in btnList)
            {
                if (btn.Visible == true)
                    count++;
            }
            Console.WriteLine($"Counted {count} visible buttons");
            return count;
        }
        public void ShowUI(bool tf)
        {
            button1.Visible = tf;//Button1
            btnList[0] = button1;

            button2.Visible = tf;//Button2
            btnList[1] = button2;

            button3.Visible = tf;//Button3
            btnList[2] = button3;

            button4.Visible = tf;//Button4
            btnList[3] = button4;
        }
        private void SetBtnColor(Button clickedBtn)
        {
            foreach (Button btn in btnList)
            {
                if (btn != clickedBtn)
                {
                    btn.ForeColor = Color.Red;
                }
                else 
                {
                    btn.ForeColor = Color.LimeGreen;
                }
            }
        }
        public void ShowUI_FromList()
        {
            ShowUI(false);
            for (int i = 0; i < procCount; i++)
            {
                btnList[i].Show();
            }
            if(GetBtnCount() <= 2) { this.Size = new Size(226, 90); }
            else { this.Size = new Size(226, 148); }
            //title.Text = $"WizBox - TopMost | {procCount}x Clients";
        }
        #endregion
        #region UI comps
        private void button1_Click(object sender, EventArgs e)
        {
            ButtonClick(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonClick(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonClick(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonClick(4);
        }

        private void ButtonClick(int i)
        {
            Process proc = procList[i - 1];
            SetForegroundWindow(proc.MainWindowHandle);
            SetBtnColor(btnList[i - 1]);

            winTitle = proc.MainWindowTitle.Replace("Wiz101: ", $"#{i} ");
            title.Text = $"WizBox | {winTitle}";

            overlay.DrawText("`&*42';"+winTitle, new Point(6969,6969));
            form1.WriteOutput($"[{this.Name}] Success: Set foreground window to '{proc.MainWindowTitle}'.", successColor);
        }
        private void TimerButtonClick(int i, string titleText)
        {
            winTitle = titleText.Replace("Wiz101: ", $"#{i+1} ");
            title.Text = $"WizBox | {winTitle}";
            overlay.DrawText("`&*42';" + winTitle, new Point(6969, 6969));
            SetBtnColor(btnList[i]);
        }

        private void xBtn_Click(object sender, EventArgs e)
        {
            if (!spacePressed)
            {
                this.Hide();
                overlay.Hide();
                tp.Hide();
                button5.ForeColor = Color.White;
                form1.WindowState = FormWindowState.Normal;
                form1.Focus();
            }else { spacePressed = false; }
        }

        private void Topmost_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void Topmost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '1' && GetBtnCount() >= 1)
            {
                ButtonClick(1);
            }
            if (e.KeyChar == '2' && GetBtnCount() >= 2)
            {
                ButtonClick(2);
            }
            if (e.KeyChar == '3' && GetBtnCount() >= 3)
            {
                ButtonClick(3);
            }
            if (e.KeyChar == '4' && GetBtnCount() >= 4)
            {
                ButtonClick(4);
            }
        }
        public void toggleTimer(bool tf)
        {
            if (tf)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (procList != null)
            {
                foregroundBool = false;
                fgHandle = GetForegroundWindow();
                for (int i = 0; i < procList.Length; i++)
                {
                    if (foregroundBool != true)
                    {
                        foregroundBool = DoesListContain(fgHandle);
                        if (foregroundBool && tempCurProcID != curProcID)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Switched Clients!");
                            TimerButtonClick(curProcID, procList[curProcID].MainWindowTitle);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red; 
                        }
                        //Console.WriteLine($"ProcHandle:{procList[i].MainWindowHandle} FGHandle: {fgHandle} Title: {procList[i].MainWindowTitle}");
                    }
                }
                tempCurProcID = curProcID;
                if (foregroundBool == true)
                { overlay.ColorLines(true); }
                else { overlay.ColorLines(false); }
            }
        }
        private bool DoesListContain(IntPtr fgHandle)
        {
            int i = 0;
            foreach (Process proc in procList)
            {
                if (proc.MainWindowHandle == fgHandle)
                {
                    curProcID = i;
                    //Console.WriteLine($"CurProcID: {i}/{tempCurProcID}");
                    return true;
                }
                i++;
            }
            return false;
        }
        private void title_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void optBtn_Click(object sender, EventArgs e)
        {
            if (!tmSettings.Visible)
            {
                tmSettings.Show();
                tmSettings.Location = new Point(this.Location.X - (359), this.Location.Y);
                form1.WriteOutput($"[{this.Name}] Success: Opened Top Most Settings", successColor);
            }
            else
            {
                tmSettings.Hide();
                form1.WriteOutput($"[{this.Name}] Success: Closed Top Most Settings", successColor);
            }
        }
        private void xBtn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                spacePressed = true;
            }
        }
        private void comBtn_Click(object sender, EventArgs e)
        { InputToEachClient(commons); }
        private void homeBtn_Click(object sender, EventArgs e)
        { InputToEachClient(home); }
        private void markBtn_Click(object sender, EventArgs e)
        { InputToEachClient(setMark); }
        private void tpMarkBtn_Click(object sender, EventArgs e)
        { InputToEachClient(telMark); }
        private void button5_Click(object sender, EventArgs e)//TeleportMenu-TopMost
        {
            if (tp.Visible)
            { 
                tp.Hide();
                button5.ForeColor = Color.White;
            }
            else
            {
                tp.Show();
                button5.ForeColor = Color.Red;
                tp.Location = new Point(this.Location.X+tp.Size.Width-2, this.Location.Y-tp.Size.Height);
            }
        }
        #endregion

        private void Topmost_Move(object sender, EventArgs e)
        {
            tp.Location = new Point(this.Location.X + tp.Size.Width-2, this.Location.Y - tp.Size.Height);
        }
    }
}
