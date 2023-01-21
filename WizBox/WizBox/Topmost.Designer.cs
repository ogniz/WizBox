
namespace WizBox
{
    partial class Topmost
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.xBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.optBtn = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.markBtn = new System.Windows.Forms.Button();
            this.tpMarkBtn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlText;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(3, 30);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "Client #1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Topmost_KeyPress);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlText;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(113, 30);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 58);
            this.button2.TabIndex = 1;
            this.button2.Text = "Client #2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Topmost_KeyPress);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlText;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(3, 87);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 58);
            this.button3.TabIndex = 2;
            this.button3.Text = "Client #3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Topmost_KeyPress);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ControlText;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(113, 87);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(110, 58);
            this.button4.TabIndex = 3;
            this.button4.Text = "Client #4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Topmost_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "**Brings a client to the top**";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title_MouseDown);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.title.Location = new System.Drawing.Point(4, 7);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(128, 20);
            this.title.TabIndex = 5;
            this.title.Text = "WizBox";
            this.title.Click += new System.EventHandler(this.title_Click);
            this.title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title_MouseDown);
            // 
            // xBtn
            // 
            this.xBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.xBtn.ForeColor = System.Drawing.Color.Red;
            this.xBtn.Location = new System.Drawing.Point(196, 3);
            this.xBtn.Name = "xBtn";
            this.xBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.xBtn.Size = new System.Drawing.Size(27, 27);
            this.xBtn.TabIndex = 6;
            this.xBtn.Text = "X";
            this.xBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.xBtn.UseVisualStyleBackColor = true;
            this.xBtn.Click += new System.EventHandler(this.xBtn_Click);
            this.xBtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.xBtn_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // optBtn
            // 
            this.optBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.optBtn.ForeColor = System.Drawing.Color.White;
            this.optBtn.Location = new System.Drawing.Point(169, 3);
            this.optBtn.Name = "optBtn";
            this.optBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.optBtn.Size = new System.Drawing.Size(27, 27);
            this.optBtn.TabIndex = 7;
            this.optBtn.Text = "O";
            this.optBtn.UseVisualStyleBackColor = true;
            this.optBtn.Click += new System.EventHandler(this.optBtn_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 200;
            // 
            // comBtn
            // 
            this.comBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.comBtn.ForeColor = System.Drawing.Color.GreenYellow;
            this.comBtn.Location = new System.Drawing.Point(268, 36);
            this.comBtn.Name = "comBtn";
            this.comBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comBtn.Size = new System.Drawing.Size(27, 25);
            this.comBtn.TabIndex = 19;
            this.comBtn.Text = "C";
            this.comBtn.UseVisualStyleBackColor = true;
            this.comBtn.Click += new System.EventHandler(this.comBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.homeBtn.ForeColor = System.Drawing.Color.GreenYellow;
            this.homeBtn.Location = new System.Drawing.Point(295, 36);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.homeBtn.Size = new System.Drawing.Size(27, 25);
            this.homeBtn.TabIndex = 18;
            this.homeBtn.Text = "H";
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // markBtn
            // 
            this.markBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.markBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.markBtn.ForeColor = System.Drawing.Color.GreenYellow;
            this.markBtn.Location = new System.Drawing.Point(322, 36);
            this.markBtn.Name = "markBtn";
            this.markBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.markBtn.Size = new System.Drawing.Size(27, 25);
            this.markBtn.TabIndex = 17;
            this.markBtn.Text = "M";
            this.markBtn.UseVisualStyleBackColor = true;
            this.markBtn.Click += new System.EventHandler(this.markBtn_Click);
            // 
            // tpMarkBtn
            // 
            this.tpMarkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tpMarkBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tpMarkBtn.ForeColor = System.Drawing.Color.GreenYellow;
            this.tpMarkBtn.Location = new System.Drawing.Point(349, 36);
            this.tpMarkBtn.Name = "tpMarkBtn";
            this.tpMarkBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tpMarkBtn.Size = new System.Drawing.Size(27, 25);
            this.tpMarkBtn.TabIndex = 16;
            this.tpMarkBtn.Text = "T";
            this.tpMarkBtn.UseVisualStyleBackColor = true;
            this.tpMarkBtn.Click += new System.EventHandler(this.tpMarkBtn_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(142, 3);
            this.button5.Name = "button5";
            this.button5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button5.Size = new System.Drawing.Size(27, 27);
            this.button5.TabIndex = 20;
            this.button5.Text = "T";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Topmost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(226, 90);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.comBtn);
            this.Controls.Add(this.homeBtn);
            this.Controls.Add(this.markBtn);
            this.Controls.Add(this.tpMarkBtn);
            this.Controls.Add(this.optBtn);
            this.Controls.Add(this.xBtn);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Topmost";
            this.Opacity = 0.65D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WizBox - ClientHelper";
            this.TopMost = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Topmost_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Topmost_MouseDown);
            this.Move += new System.EventHandler(this.Topmost_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button xBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button optBtn;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button comBtn;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Button markBtn;
        private System.Windows.Forms.Button tpMarkBtn;
        private System.Windows.Forms.Button button5;
    }
}