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
    public partial class Overlay : Form
    {
        int width = Screen.PrimaryScreen.Bounds.Width-10;
        int height = Screen.PrimaryScreen.Bounds.Height-10;

        public bool lineBool = true;

        Bitmap bmp;
        Graphics g;

        Font shadow;
        Font normal;
        int fontSize = 26;
        int shdwOffset = 1;

        bool mouseDown = false;
        bool firstRun = true;

        Pen bPen = new Pen(Color.Black, 10);
        Pen gPen = new Pen(Color.LimeGreen, 10);
        Pen rPen = new Pen(Color.Red, 10);

        Color textColor = Color.White;

        Point TL = new Point(0, 0);
        Point TR = new Point(0, 0);
        Point BL = new Point(0, 0);
        Point BR = new Point(0, 0);
        Point nameTextPoint = new Point(0, 0);
        Point shadowTextPoint = new Point(0, 0);

        string lastWrittenText = "";
        Point lastPoint = new Point(0,0);

        public Overlay()
        {
            nameTextPoint = new Point((width / 9), (height / 5) * (height / 250));
            InitializeComponent();
            ResizeUI();

            SetFonts();

            SetPoints();
            CreateImage();
            DrawLine(rPen);
            CreateTestSquare();
            Console.WriteLine($"{this.Name} Loaded");
        }//X-Width / Y-Height
        #region Events
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            Console.WriteLine("[^ MouseUp] MouseDown = 'false'");
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            Console.WriteLine("[V MouseDown] MouseDown = 'true'");
            //while (mouseDown)
            //{
            //    DragTextPoint(new Point(e.X, e.Y));
            //    Console.WriteLine("[V MouseUp] >> DragTextPoint()");
            //}
        }
        #endregion
        public void MoveX(int x, int y)
        {
            label1.Location = new Point(x,y);
        }
        public void DrawTestDot(int x, int y)
        {
            DateTime n1 = DateTime.Now;

            int t = 2;
            int tt = t+2;

            g.DrawRectangle(bPen, new Rectangle(x - tt, y - tt, tt, tt));
            g.DrawRectangle(gPen, new Rectangle(x - t, y - t, t, t));
            Console.WriteLine($"X:{x} Y:{y} W:{t} H:{t}");

            DateTime n2 = DateTime.Now;

            Console.WriteLine($"Draw took {n2.Subtract(n1)}");
        }
        public void CreateTestSquare()
        {
            DateTime n1 = DateTime.Now;

            int t = 1;

            int x = (width / 2) - t;
            int y = ((height / 2) - t);
            int offset = y-((y/11)*10);
            y-=offset;

            g.DrawRectangle(gPen, new Rectangle(x, y, t, t));
            Console.WriteLine($"X:{x} Y:{y} W:{t} H:{t}");

            DateTime n2 = DateTime.Now;

            Console.WriteLine($"Draw took {n2.Subtract(n1)}");
        }
        private void ResizeUI()
        {
            this.Size = new Size(width, height);
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Size = new Size(width, height);
        }
        private void SetPoints()
        {
            TL = new Point(0, 0);
            TR = new Point(width, 0);
            BL = new Point(0, height);
            BR = new Point(width, height);
        }
        private void CreateImage()
        {
            bmp = new Bitmap(width, height);
            g = Graphics.FromImage(bmp);
        }
        private void DrawLine(Pen pen)
        {
            g.DrawLine(pen, TL, TR);
            g.DrawLine(pen, TL, BL);
            g.DrawLine(pen, BL, BR);
            g.DrawLine(pen, BR, TR);
            SetImage();
        }
        private void SetImage()
        {
            pictureBox1.Image = bmp;
        }
        private void SetFonts()
        {
            shadow = new Font(this.Font.FontFamily, this.Font.Size + (fontSize+shdwOffset), this.Font.Style, this.Font.Unit);
            normal = new Font(this.Font.FontFamily, this.Font.Size + fontSize, this.Font.Style, this.Font.Unit);
        }
        public void RewriteLastText()
        {
            DrawText(lastWrittenText, lastPoint);
        }
        public void ColorLines(bool tf)
        {
            if (tf)
            {
                DrawLine(gPen);
            }
            else
            {
                DrawLine(rPen);
            }
        }
        public void Clear()
        {
            g.Clear(Color.Transparent);
            SetImage();
        }
        public void SetVar(string varName, object i)
        {
            if (varName.Equals("lineWidth"))
            {
                gPen = new Pen(Color.LimeGreen, (int)i);
                rPen = new Pen(Color.Red, (int)i);
                SetImage();
            }
            if (varName.Equals("textColor"))
            {
                textColor = (Color)i;
                RewriteLastText();
            }
            if (varName.Equals("fontSize"))
            {
                fontSize = (int)i;
                SetFonts();
                RewriteLastText();
            }
        }
        public void DrawText(string text, Point point)
        {
            Clear();
            if (text == "`:`:'[]lwt(1001);")
                text = lastWrittenText;
            if (point == new Point(6969,6969))
                point = nameTextPoint;
            if(text.Contains("`&*42';"))
            {
                text = text.Replace("`&*42';", "");
                if (firstRun != true)
                    point = lastPoint;
            }

            lastWrittenText = text;
            lastPoint = point;
            firstRun = false;

            shadowTextPoint = new Point(point.X-2, point.Y);

            g.DrawString(text, shadow, new SolidBrush(Color.Black), shadowTextPoint);
            g.DrawString(text, normal, new SolidBrush(textColor), point);

            SetImage();
        }
        public void ChangeTextPoint(string xy, int i)
        {
            Point newPoint = new Point(lastPoint.X, lastPoint.Y);

            if (xy == "x")
            {
                newPoint = new Point(lastPoint.X + i, lastPoint.Y);
            }
            if (xy == "y")
            {
                newPoint = new Point(lastPoint.X, lastPoint.Y + i);
            }

            DrawText(lastWrittenText, newPoint);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"[CUR POS] X:{e.X} Y:{e.Y}");
        }
    }
}
