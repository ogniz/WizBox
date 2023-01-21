using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections;
using System.Threading;

namespace WizBox
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int LPAR);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        int width = Screen.PrimaryScreen.Bounds.Width;
        int height = Screen.PrimaryScreen.Bounds.Height;

        Process[] procList;
        ArrayList wizList = new ArrayList();
        Button[] btnList = new Button[4];
        TextBox[] txtList = new TextBox[4];

        Topmost tmost = new Topmost();
        Overlay overlay = new Overlay();
        Topmost_Settings tmSettings = new Topmost_Settings();

        Random rand = new Random();

        Color successColor = Color.LimeGreen;
        Color loadingColor = Color.Yellow;
        Color failColor = Color.Red;

        Point centerTextPoint = new Point(0, 0);

        string titleName = "WizBox ";
        string procName = "WizardGraphicalClient";
        string baseDir = Directory.GetCurrentDirectory();
        string gameDir = "";
        string configDir = "";
        string loginDir = "";
        /*string configContents = $"[Game Directory]=:" +
                        $"[Process Outline Lines]=:" +
                        $"[Outline Thickness]=:" +
                        $"[Window Transparency]=:" +
                        $"[Name Font Size]=:" +
                        $"[Name Text Position]=:";*/
        string[] configContents = {$"[Game Directory]=:",
                        $"[Process Outline Lines]=true",
                        $"[Outline Thickness]=10",
                        $"[Window Transparency]=0.65",
                        $"[Name Font Size]=26",
                        $"[Name Text Position]=:"};

        string[] loginContents = { "" };

        string cfg_gameDir = "[Game Directory]=";
        string cfg_procOutline = "[Process Outline Lines]=";
        string cfg_outlineThick = "[Outline Thickness]=";
        string cfg_winOpacity = "[Window Transparency]=";
        string cfg_nameFontSize = "[Name Font Size]=";
         
        int procCount = 0;
        int timeout = 50;

        string charName1 = "N/A";
        string charName2 = "N/A";
        string charName3 = "N/A";
        string charName4 = "N/A";

        public Form1()
        {
            InitializeComponent();

            configDir = baseDir + "\\config.ini";
            loginDir = baseDir + "\\login.ini";
            GetConfigFile();
            GetLoginFile();

            centerTextPoint = new Point((width / 2) + 15, (height / 5) * 4);
            ShowUI(false);

            tmost.SetForms(this, overlay, tmSettings);

            FindProcesses();

            timer1.Start();
            ShowUI_FromList();
            Console.WriteLine($"{this.Name} Loaded");
        }

        #region file stuff
        private void GetConfigFile()
        {
            if (!File.Exists(configDir))
            {
                File.WriteAllLines(configDir, configContents);
            }
            else
            {
                configContents = File.ReadAllLines(configDir);
            }
            GetConfigVars();
        }
        private void GetLoginFile()
        {
            if (!File.Exists(loginDir))
            {
                File.Create(loginDir);
                Console.WriteLine("Login Created: ");
            }
            else
            {
                loginContents = File.ReadAllLines(loginDir);
                Console.WriteLine("Login Contents Count: " +loginContents.Length);
            }
            GetConfigVars();
        }
        public string UnpackConfig(int configLine)
        {
            string content = configContents[configLine];
            content = content.Substring(content.IndexOf('=')+1);
            Console.WriteLine(content);
            return content;
        }
        private void RepackConfig(int i, object o)
        {
            configContents[i] = o.ToString();
        }
        public void SetGameDir(string dir)
        {
            gameDir = dir;
        }
        public void SaveConfig(bool procOutline, double winOpacity, int outlineThick, int nameFontSize)
        {
            if (gameDir != "")
            {
                RepackConfig(0, cfg_gameDir+gameDir);
                Console.WriteLine("Saved game dir " + cfg_gameDir + gameDir);
            }

            RepackConfig(1, cfg_procOutline+procOutline);
            Console.WriteLine("Saved procOutline " + cfg_procOutline + procOutline);

            RepackConfig(2, cfg_winOpacity+winOpacity);
            Console.WriteLine("Saved winOpacity " + cfg_winOpacity + winOpacity);

            RepackConfig(3, cfg_outlineThick+outlineThick);
            Console.WriteLine("Saved outlineThick " + cfg_outlineThick + outlineThick);

            RepackConfig(4, cfg_nameFontSize+nameFontSize);
            Console.WriteLine("Saved nameFontSize " + cfg_nameFontSize + nameFontSize);

            Console.WriteLine(configContents);

            File.WriteAllLines(configDir, configContents);
        }
        private void GetConfigVars()
        {
            gameDir = UnpackConfig(0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"GameDir:'{ConfigToString(gameDir)}'");         
        }
        private string ConfigToString(string input)
        {
            string output = input.Substring(input.IndexOf("=") + 1);
            return output;
        }
        #endregion
        #region proc stuff
        private void FindProcesses()
        {
            procList = Process.GetProcessesByName(procName);

            tmost.SetProcInfo(procCount, procList);

            if (procCount != procList.Length)
            {
                procCount = procList.Length;
                ShowUI_FromList();
                tmost.SetProcInfo(procCount, procList);

                Console.WriteLine("DIFFERENT COUNT!"); 
            }
            Console.WriteLine($"[{DateTime.Now}] +ProcList updated. ProcCount = {procCount} || ProcLength = {procList.Length}");
            procCount = procList.Length;
        }
        #endregion
        #region utils
        public void WriteOutput(string text, Color color)
        {
            string now = DateTime.Now.TimeOfDay.ToString();
            output.ForeColor = color;
            output.Text = $"[{now.Remove(now.IndexOf('.')+3)}]"+text;
        }
        private bool CheckProcListLength()
        {
            if (procList.Length != 0)
                return true;
            else return false;
        }
        private void ShowUI(bool tf)
        {
            button1.Visible = tf;//Button1
            btnList[0] = button1;

            button2.Visible = tf;//Button2
            btnList[1] = button2;

            button3.Visible = tf;//Button3
            btnList[2] = button3;

            button4.Visible = tf;//Button4
            btnList[3] = button4;

            textBox1.Visible = tf;//TextBox1
            txtList[0] = textBox1;

            textBox2.Visible = tf;//TextBox2
            txtList[1] = textBox2;

            textBox3.Visible = tf;//TextBox3
            txtList[2] = textBox3;

            textBox4.Visible = tf;//TextBox4
            txtList[3] = textBox4;
        }
        private void ShowUI_FromList()
        {
            ShowUI(false);
            for (int i = 0; i < procCount; i++)
            {
                btnList[i].Show();
                txtList[i].Show();
            }
            title.Text = titleName + $"| {procCount}x Clients";
        }
        #endregion
        #region UI comps
        private void timer1_Tick(object sender, EventArgs e)
        {
            FindProcesses();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BtnRename(0, charName1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BtnRename(1, charName2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BtnRename(2, charName3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BtnRename(3, charName4);
        }

        private void BtnRename(int btnNum, string charName)
        {
            try
            {
                SetWindowText(procList[btnNum].MainWindowHandle, $"Wiz101: {charName}");
                tmost.SetProcInfo(procCount, procList);
                WriteOutput($"[{this.Name}] Success: Client#{btnNum} renamed to 'Wiz101: {charName}'", successColor);
            } catch (Exception e)
            {
                WriteOutput($"[{this.Name}] Error: {e.Message}", failColor);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            charName1 = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            charName2 = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            charName3 = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            charName4 = textBox4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!tmost.Visible)
            {
                overlay.Show();

                tmost.Show();
                tmost.Location = new Point(this.Location.X, this.Location.Y-tmost.Size.Height);
                tmost.SetProcInfo(procCount, procList);
                tmost.ShowUI_FromList();
                WriteOutput($"[{this.Name}] Success: Opened Top Most", successColor);
            }
            else
            {
                overlay.Hide();

                tmost.Hide();
                tmost.SetProcInfo(procCount, procList);
                tmost.ShowUI_FromList();
                WriteOutput($"[{this.Name}] Success: Closed Top Most", successColor);
            }
        }
        private void xBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to exit WizBox?", "WizBox", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void button6_Click(object sender, EventArgs e)//Open a client
        {
            if (gameDir != "" && wizList.Count < 4)
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = gameDir;
                Console.WriteLine($"[PSI] FileName = '{gameDir}'");

                psi.WorkingDirectory = gameDir.Replace("WizardGraphicalClient.exe",""); ;
                Console.WriteLine($"[PSI] WorkingDirectory = '{gameDir.Replace("WizardGraphicalClient.exe", "")}'");

                psi.Arguments = "-L login.us.wizard101.com 12000";
                Console.WriteLine($"[PSI] Arguments = '{psi.Arguments}'");

                //psi.WindowStyle = ProcessWindowStyle.Maximized;
                //Console.WriteLine($"[PSI] WindowStyle = Maximized");
                //psi.CreateNoWindow = true;
                
                Process wizProc = new Process();

                wizProc.StartInfo = psi;
                Console.WriteLine($"[WizProc] Proc Start Info Set");

                wizProc.Start();
                Console.WriteLine($"[WizProc] Proc Started");

                wizList.Add(wizProc);
                Console.WriteLine($"[WizProc] Count++ " + wizList.Count);
            }
            else { Console.WriteLine(" >> Failed! GameDir not set!"); }
        }

        private void button7_Click(object sender, EventArgs e)//Close all clients
        {
            foreach(Process proc in wizList)
            {
                proc.Kill();
            }
            wizList.Clear();
        }

        private void optBtn_Click(object sender, EventArgs e)
        {
            if (!tmSettings.Visible)
            {
                tmSettings.Show();
                tmSettings.Location = new Point(this.Location.X-(359), this.Location.Y);
                WriteOutput($"[{this.Name}] Success: Opened Top Most Settings", successColor);
            }
            else
            {
                tmSettings.Hide();
                WriteOutput($"[{this.Name}] Success: Closed Top Most Settings", successColor);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to auto-login to Wiz101?", "WizBox", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (procCount > 0)
                {
                    for (int i = 0; i < procList.Length; i++)
                    {//instead of i++ use i+2 for ever other number. 
                     //Then +1 from the second loginContents[i+1]; to get 1
                     //(0 1), (2 3), (4 5), (6 7)
                     //procList[i] would need some looking into
                        if (i == 0)
                        {
                            string u = loginContents[0];
                            string p = loginContents[1];
                            Console.WriteLine($"Logining Into Client #{i}");
                            SetForegroundWindow(procList[i].MainWindowHandle);

                            Console.WriteLine($"Username: {u}");
                            SendKeys.SendWait(u + "{TAB}");

                            Console.WriteLine($"Password: {p}");
                            SendKeys.SendWait(p + "~");
                        }
                        if (i == 1)
                        {
                            string u = loginContents[2];
                            string p = loginContents[3];
                            Console.WriteLine($"Logining Into Client #{i}");
                            SetForegroundWindow(procList[i].MainWindowHandle);

                            Console.WriteLine($"Username: {u}");
                            SendKeys.SendWait(u + "{TAB}");

                            Console.WriteLine($"Password: {p}");
                            SendKeys.SendWait(p + "~");
                        }
                        if (i == 2)
                        {
                            string u = loginContents[4];
                            string p = loginContents[5];
                            Console.WriteLine($"Logining Into Client #{i}");
                            SetForegroundWindow(procList[i].MainWindowHandle);

                            Console.WriteLine($"Username: {u}");
                            SendKeys.SendWait(u + "{TAB}");

                            Console.WriteLine($"Password: {p}");
                            SendKeys.SendWait(p + "~");
                        }
                        if (i == 3)
                        {
                            string u = loginContents[6];
                            string p = loginContents[7];
                            Console.WriteLine($"Logining Into Client #{i}");
                            SetForegroundWindow(procList[i].MainWindowHandle);

                            Console.WriteLine($"Username: {u}");
                            SendKeys.SendWait(u + "{TAB}");

                            Console.WriteLine($"Password: {p}");
                            SendKeys.SendWait(p + "~");
                        }
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)//Sending Multiple InGame Chat Messages
        {
            if (CheckProcListLength() && chatTextBox.Text.Length != 0)
            {
                for (int i = 0; i < procList.Length; i++)
                {
                    Console.WriteLine($"Sending Message To Client #{i}");
                    SetForegroundWindow(procList[i].MainWindowHandle);

                    Console.WriteLine($"MSG: {chatTextBox.Text}");
                    SendKeys.SendWait("{ENTER}" + chatTextBox.Text + "{ENTER}");
                }
                SetForegroundWindow(procList[0].MainWindowHandle);
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (CheckProcListLength() && textBox5.Text.Length != 0)
            {
                for (int i = 0; i < procList.Length; i++)
                {
                    Console.WriteLine($"Sending Input To Client #{i}");
                    SetForegroundWindow(procList[i].MainWindowHandle);

                    Console.WriteLine($"Input: {textBox5.Text}");
                    //SendKeys.Send(textBox5.Text);
                    SendKeys_Timed(textBox5.Text);
                    //SendKey(procList[0].MainWindowHandle, Keys.W);
                }
                SetForegroundWindow(procList[0].MainWindowHandle);
                WriteOutput($"[{this.Name}] Success: Finished sending inputs", successColor);
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timeout = (int)numericUpDown1.Value;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            InviteClientsThroughGroup();
        }
        #endregion

        #region MouseClicks

        private void InviteClientsThroughGroup()
        {
            // X Button to close menus
            double x_btn_double = (width / 1.5);
            double y_btn_double = ((height / 1.5));
            int x_btn = (int)x_btn_double;
            int y_btn = (int)y_btn_double;
            int offset_btn = 0;
            // Group menu icon
            int x_gm = (width / 3);
            int y_gm = ((height / 3));
            int offset_gm = x_gm / 15;
            x_gm += offset_gm;
            // 2nd char in group menu
            int x_char = (width / 2);
            int y_char = ((height / 2));
            int offset_char = y_char - (y_char / 10) * 9;
            y_char -= offset_char;

            if (CheckProcListLength()) //Make sure there are clients open
            {
                this.Hide();
                for (int i = 1; i < procList.Length; i++) // Start looping through clients
                {
                    Console.WriteLine($"Sending Clicks To Client #{i}");
                    SetForegroundWindow(procList[i].MainWindowHandle); // Set the client to the foreground

                    Console.WriteLine($"========================'#1 | About to pause | Set client {i} to foreground'========================");
                    Thread.Sleep(1000);
                    /*
                    SendMouseClicks(rand.Next(4, 9), x_btn, y_btn);

                    Console.WriteLine("========================'#2 | About to pause | Open group menu'========================");
                    Thread.Sleep(1000);*/

                    SendKeys.SendWait("^a"); ; // Step3: Open group menu.

                    Console.WriteLine("========================'#3 | About to pause | Open group menu'========================");
                    Thread.Sleep(1000);

                    //SendMouseClicks(rand.Next(4, 9), x_char, y_char); // Step4: Click the group icon.
                    SendMouseClicks(rand.Next(3, 5), x_gm, y_gm);

                    Console.WriteLine("========================'#4 | About to pause | Click the group icon'========================");
                    Thread.Sleep(1000);

                    SendMouseClicks(rand.Next(3, 5), x_char, y_char); // Step5: Click on the 2nd char, and teleport.

                    Console.WriteLine("========================'#5 | About to pause | Click on the 2nd char, and teleport'========================");
                    Thread.Sleep(1000);
                }
                SetForegroundWindow(procList[0].MainWindowHandle);
                this.Show();
            }
        }

        private void SendMouseClicks(int amt, int x, int y)
        {
            for (int i = 0; i < amt; i++)
            {
                SetCursorPos(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                Console.WriteLine($"Sent {i} clicks to X:{x} Y:{y}!");
            }
            Thread.Sleep(10);
        }
        private void DebugMouseClicks(int amt, int x, int y)
        {
            for (int i = 0; i < amt; i++)
            {
                SetCursorPos(x, y);
                overlay.DrawTestDot(x, y);
                overlay.MoveX(x, y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                Console.WriteLine($"Sent {i} dbg clicks to X:{x} Y:{y}!");
            }
            Thread.Sleep(10);
        }
        #endregion 
        private void SendKeys_Timed(string input)
        {
            for (int i = 0; i < timeout; i++)
            {
                SendKeys.SendWait(input);
                WriteOutput($"[{this.Name}] {i}/{timeout}", loadingColor);
            }
        }
    }
}
