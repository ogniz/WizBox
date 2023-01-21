
namespace WizBox
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.xBtn = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.Label();
            this.minBtn = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.optBtn = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button11 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "Rename #1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(12, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 56);
            this.button2.TabIndex = 1;
            this.button2.Text = "Rename #2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(12, 231);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 56);
            this.button3.TabIndex = 2;
            this.button3.Text = "Rename #3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(12, 293);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 56);
            this.button4.TabIndex = 3;
            this.button4.Text = "Rename #4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(141, 122);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Window Title";
            this.textBox1.Size = new System.Drawing.Size(252, 28);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(141, 184);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "Window Title";
            this.textBox2.Size = new System.Drawing.Size(252, 28);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(141, 246);
            this.textBox3.Name = "textBox3";
            this.textBox3.PlaceholderText = "Window Title";
            this.textBox3.Size = new System.Drawing.Size(252, 28);
            this.textBox3.TabIndex = 6;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(141, 308);
            this.textBox4.Name = "textBox4";
            this.textBox4.PlaceholderText = "Window Title";
            this.textBox4.Size = new System.Drawing.Size(252, 28);
            this.textBox4.TabIndex = 7;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(12, 45);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(123, 56);
            this.button5.TabIndex = 8;
            this.button5.Text = "Top Most";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.title.Location = new System.Drawing.Point(12, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(411, 33);
            this.title.TabIndex = 9;
            this.title.Text = "WizBox";
            this.title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // xBtn
            // 
            this.xBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.xBtn.ForeColor = System.Drawing.Color.Red;
            this.xBtn.Location = new System.Drawing.Point(495, 12);
            this.xBtn.Name = "xBtn";
            this.xBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.xBtn.Size = new System.Drawing.Size(27, 26);
            this.xBtn.TabIndex = 10;
            this.xBtn.Text = "X";
            this.xBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.xBtn.UseVisualStyleBackColor = true;
            this.xBtn.Click += new System.EventHandler(this.xBtn_Click);
            // 
            // output
            // 
            this.output.AutoSize = true;
            this.output.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.output.Location = new System.Drawing.Point(141, 412);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(57, 17);
            this.output.TabIndex = 11;
            this.output.Text = "OUTPUT";
            this.output.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // minBtn
            // 
            this.minBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.minBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.minBtn.Location = new System.Drawing.Point(462, 12);
            this.minBtn.Name = "minBtn";
            this.minBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.minBtn.Size = new System.Drawing.Size(27, 26);
            this.minBtn.TabIndex = 12;
            this.minBtn.Text = "-";
            this.minBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.minBtn.UseVisualStyleBackColor = true;
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(141, 45);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(123, 56);
            this.button6.TabIndex = 13;
            this.button6.Text = "Open a Client";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.Red;
            this.button7.Location = new System.Drawing.Point(270, 45);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(123, 56);
            this.button7.TabIndex = 14;
            this.button7.Text = "Close Client(s)";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // optBtn
            // 
            this.optBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.optBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.optBtn.Location = new System.Drawing.Point(429, 12);
            this.optBtn.Name = "optBtn";
            this.optBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.optBtn.Size = new System.Drawing.Size(27, 26);
            this.optBtn.TabIndex = 15;
            this.optBtn.Text = "O";
            this.optBtn.UseVisualStyleBackColor = true;
            this.optBtn.Click += new System.EventHandler(this.optBtn_Click);
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(399, 45);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(123, 56);
            this.button8.TabIndex = 16;
            this.button8.Text = "Auto-Login";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(141, 370);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.PlaceholderText = "Chat on all clients";
            this.chatTextBox.Size = new System.Drawing.Size(252, 28);
            this.chatTextBox.TabIndex = 18;
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(12, 355);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(123, 56);
            this.button9.TabIndex = 17;
            this.button9.Text = "Send Chats";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(141, 432);
            this.textBox5.Name = "textBox5";
            this.textBox5.PlaceholderText = "Input to all clients";
            this.textBox5.Size = new System.Drawing.Size(252, 28);
            this.textBox5.TabIndex = 20;
            // 
            // button10
            // 
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(12, 417);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(123, 56);
            this.button10.TabIndex = 19;
            this.button10.Text = "Send Inputs";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(399, 432);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(123, 28);
            this.numericUpDown1.TabIndex = 21;
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button11
            // 
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(399, 355);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(123, 56);
            this.button11.TabIndex = 22;
            this.button11.Text = "Send Clicks";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(529, 483);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.optBtn);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.minBtn);
            this.Controls.Add(this.xBtn);
            this.Controls.Add(this.title);
            this.Controls.Add(this.output);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Opacity = 0.65D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button xBtn;
        private System.Windows.Forms.Label output;
        private System.Windows.Forms.Button minBtn;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button optBtn;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox chatTextBox;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button11;
    }
}

