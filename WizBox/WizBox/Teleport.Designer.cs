
namespace WizBox
{
    partial class Teleport
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
            this.comBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.markBtn = new System.Windows.Forms.Button();
            this.tpMarkBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comBtn
            // 
            this.comBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.comBtn.ForeColor = System.Drawing.Color.GreenYellow;
            this.comBtn.Location = new System.Drawing.Point(3, 3);
            this.comBtn.Name = "comBtn";
            this.comBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comBtn.Size = new System.Drawing.Size(27, 25);
            this.comBtn.TabIndex = 23;
            this.comBtn.Text = "C";
            this.comBtn.UseVisualStyleBackColor = true;
            this.comBtn.Click += new System.EventHandler(this.comBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.homeBtn.ForeColor = System.Drawing.Color.GreenYellow;
            this.homeBtn.Location = new System.Drawing.Point(30, 3);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.homeBtn.Size = new System.Drawing.Size(27, 25);
            this.homeBtn.TabIndex = 22;
            this.homeBtn.Text = "H";
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // markBtn
            // 
            this.markBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.markBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.markBtn.ForeColor = System.Drawing.Color.GreenYellow;
            this.markBtn.Location = new System.Drawing.Point(57, 3);
            this.markBtn.Name = "markBtn";
            this.markBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.markBtn.Size = new System.Drawing.Size(27, 25);
            this.markBtn.TabIndex = 21;
            this.markBtn.Text = "M";
            this.markBtn.UseVisualStyleBackColor = true;
            this.markBtn.Click += new System.EventHandler(this.markBtn_Click);
            // 
            // tpMarkBtn
            // 
            this.tpMarkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tpMarkBtn.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tpMarkBtn.ForeColor = System.Drawing.Color.GreenYellow;
            this.tpMarkBtn.Location = new System.Drawing.Point(84, 3);
            this.tpMarkBtn.Name = "tpMarkBtn";
            this.tpMarkBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tpMarkBtn.Size = new System.Drawing.Size(27, 25);
            this.tpMarkBtn.TabIndex = 20;
            this.tpMarkBtn.Text = "T";
            this.tpMarkBtn.UseVisualStyleBackColor = true;
            this.tpMarkBtn.Click += new System.EventHandler(this.tpMarkBtn_Click);
            // 
            // Teleport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(114, 31);
            this.Controls.Add(this.comBtn);
            this.Controls.Add(this.homeBtn);
            this.Controls.Add(this.markBtn);
            this.Controls.Add(this.tpMarkBtn);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1, 1);
            this.Name = "Teleport";
            this.Opacity = 0.65D;
            this.Text = "WizBox - Teleport Tab";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button comBtn;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Button markBtn;
        private System.Windows.Forms.Button tpMarkBtn;
    }
}