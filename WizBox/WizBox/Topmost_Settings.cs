using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WizBox
{
    public partial class Topmost_Settings : Form
    {
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int LPAR);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        string gameDir = "";
        bool procOutline = true;
        int outlineThick = 10;
        double winOpacity = 0.65;
        int nameFontSize = 26;
        int moveAmt = 25;

        bool mouseDown = false;

        Form1 f1;
        Topmost tm;
        Overlay overlay;
        TimerOverlay timer = new TimerOverlay();
        Teleport tp;

        Color successColor = Color.LimeGreen;
        Color failColor = Color.Red;
        Color dialogColor = Color.White;

        public Topmost_Settings()
        {
            InitializeComponent();
            Console.WriteLine($"{this.Name} Loaded");
        }

        public void GetConfigVars()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            gameDir = f1.UnpackConfig(0);
            Console.WriteLine(gameDir);

            procOutline = Convert.ToBoolean(f1.UnpackConfig(1));
            Console.WriteLine(procOutline);

            winOpacity = double.Parse(f1.UnpackConfig(2));
            Console.WriteLine(winOpacity);

            outlineThick = int.Parse(f1.UnpackConfig(3));
            Console.WriteLine(outlineThick);

            nameFontSize = int.Parse(f1.UnpackConfig(4));
            Console.WriteLine(nameFontSize);
        }

        public void SetForm(Topmost top, Overlay olay, Form1 form1, Teleport teleport)
        {
            f1 = form1;
            Console.WriteLine($"Form1 Set: {f1.Text}");
            tm = top;
            Console.WriteLine($"TM Set: {tm.Text}");
            overlay = olay;
            Console.WriteLine($"olay Set: {overlay.Text}");
            tp = teleport;
            Console.WriteLine($"tp Set: {teleport.Text}");
        }

        #region UI comps
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            procOutline = checkBox1.Checked;
            tm.toggleTimer(procOutline);
            overlay.Clear();
            overlay.RewriteLastText();
            f1.WriteOutput($"[{this.Name}] Success: Draw line set to {procOutline.ToString().ToLower()}", successColor);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int lw = (int)numericUpDown1.Value;//lw = lineWidth
            outlineThick = lw;
            overlay.Clear();
            overlay.SetVar("lineWidth", lw);
            f1.WriteOutput($"[{this.Name}] Success: Line width changed to {lw}", successColor);
        }

        private void xBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void checkBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label2_Click(object sender, EventArgs e)//Change Name Color
        {
            colorDialog1.ShowDialog();
            dialogColor = colorDialog1.Color;

            overlay.SetVar("textColor", dialogColor);
            string RGB = $"R:'{dialogColor.R}' G:'{dialogColor.G}' B:'{dialogColor.B}'";

            f1.WriteOutput($"[{this.Name}] Success: Text color set to {dialogColor}.", successColor);
        }
        private void opacityUpDown_ValueChanged(object sender, EventArgs e)//opacityUpDown
        {
            double opacity = (double)opacityUpDown.Value;
            winOpacity = opacity;
            f1.Opacity = opacity;
            tm.Opacity = opacity;
            timer.Opacity = opacity;
            tp.Opacity = opacity;
            this.Opacity = opacity;
        }
        private void fontSizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            nameFontSize = (int)fontSizeUpDown.Value;
            overlay.SetVar("fontSize", nameFontSize);
        }
        private void resetName_Click(object sender, EventArgs e)
        {
            overlay.DrawText("`:`:'[]lwt(1001);", tm.nameTextPoint);
        }
        private void nameMoveUp_Click(object sender, EventArgs e)
        {
            overlay.ChangeTextPoint("y", -moveAmt);
        }
        private void moveNameRight_Click(object sender, EventArgs e)
        {
            overlay.ChangeTextPoint("x", moveAmt);
        }
        private void nameMoveDown_Click(object sender, EventArgs e)
        {
            overlay.ChangeTextPoint("y", moveAmt);
        }
        private void moveNameLeft_Click(object sender, EventArgs e)
        {
            overlay.ChangeTextPoint("x", -moveAmt);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            moveAmt = (int)numericUpDown2.Value;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            f1.SetGameDir(gameDir);
            f1.SaveConfig(procOutline, winOpacity, outlineThick, nameFontSize);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            string fileName = openFileDialog1.FileName;
            if (result.Equals(DialogResult.OK) && fileName.Contains("WizardGraphicalClient"))
            {
                gameDir = fileName;
                f1.WriteOutput($"[{this.Name}] Success: Found and set WizardGraphicalClient.exe!", successColor);
                MessageBox.Show("Success! Found WizardGraphicalClient.exe!", "WizBox");
            }
            else
            {
                f1.WriteOutput($"[{this.Name}] Error: Couldn't find WizardGraphicalClient.exe!", failColor);
                MessageBox.Show("Error: Couldn't find WizardGraphicalClient.exe!\n" +
                    $"This should be found in your Wizard101 installation folder, inside the Bin folder.\n\n" +
                    $" Default Directory> 'C:\\ProgramData\\KingsIsle Entertainment\\Wizard101\\Bin\\WizardGraphicalClient.exe'", "WizBox");
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                timer.Show();
            else timer.Hide();
        }
        #endregion
    }
}
