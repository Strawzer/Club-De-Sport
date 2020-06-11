namespace Club_De_Sport.ClientForms
{
    partial class Unsubscribe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Unsubscribe));
            this.UnsubscribeBtn = new FontAwesome.Sharp.IconButton();
            this.UnsubscribeTB = new MetroFramework.Controls.MetroTextBox();
            this.ProfileLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UnsubscribeBtn
            // 
            this.UnsubscribeBtn.AutoSize = true;
            this.UnsubscribeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(88)))), ((int)(((byte)(155)))));
            this.UnsubscribeBtn.FlatAppearance.BorderSize = 0;
            this.UnsubscribeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UnsubscribeBtn.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.UnsubscribeBtn.Font = new System.Drawing.Font("Lucida Fax", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.UnsubscribeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.UnsubscribeBtn.IconChar = FontAwesome.Sharp.IconChar.UserAltSlash;
            this.UnsubscribeBtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.UnsubscribeBtn.IconSize = 32;
            this.UnsubscribeBtn.Location = new System.Drawing.Point(758, 414);
            this.UnsubscribeBtn.Name = "UnsubscribeBtn";
            this.UnsubscribeBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.UnsubscribeBtn.Rotation = 0D;
            this.UnsubscribeBtn.Size = new System.Drawing.Size(229, 145);
            this.UnsubscribeBtn.TabIndex = 33;
            this.UnsubscribeBtn.Text = "Se Désabonner";
            this.UnsubscribeBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.UnsubscribeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.UnsubscribeBtn.UseVisualStyleBackColor = false;
            this.UnsubscribeBtn.Click += new System.EventHandler(this.UnsubscribeBtn_Click);
            // 
            // UnsubscribeTB
            // 
            // 
            // 
            // 
            this.UnsubscribeTB.CustomButton.Image = null;
            this.UnsubscribeTB.CustomButton.Location = new System.Drawing.Point(454, 1);
            this.UnsubscribeTB.CustomButton.Name = "";
            this.UnsubscribeTB.CustomButton.Size = new System.Drawing.Size(143, 143);
            this.UnsubscribeTB.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.UnsubscribeTB.CustomButton.TabIndex = 1;
            this.UnsubscribeTB.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.UnsubscribeTB.CustomButton.UseSelectable = true;
            this.UnsubscribeTB.CustomButton.Visible = false;
            this.UnsubscribeTB.Lines = new string[0];
            this.UnsubscribeTB.Location = new System.Drawing.Point(98, 414);
            this.UnsubscribeTB.MaxLength = 32767;
            this.UnsubscribeTB.Multiline = true;
            this.UnsubscribeTB.Name = "UnsubscribeTB";
            this.UnsubscribeTB.PasswordChar = '\0';
            this.UnsubscribeTB.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UnsubscribeTB.SelectedText = "";
            this.UnsubscribeTB.SelectionLength = 0;
            this.UnsubscribeTB.SelectionStart = 0;
            this.UnsubscribeTB.ShortcutsEnabled = true;
            this.UnsubscribeTB.Size = new System.Drawing.Size(598, 145);
            this.UnsubscribeTB.TabIndex = 32;
            this.UnsubscribeTB.Theme = MetroFramework.MetroThemeStyle.Light;
            this.UnsubscribeTB.UseSelectable = true;
            this.UnsubscribeTB.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.UnsubscribeTB.WaterMarkFont = new System.Drawing.Font("Microsoft Uighur", 24F, System.Drawing.FontStyle.Italic);
            // 
            // ProfileLabel
            // 
            this.ProfileLabel.AutoSize = true;
            this.ProfileLabel.Font = new System.Drawing.Font("Lucida Fax", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ProfileLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(88)))), ((int)(((byte)(155)))));
            this.ProfileLabel.Location = new System.Drawing.Point(95, 374);
            this.ProfileLabel.Name = "ProfileLabel";
            this.ProfileLabel.Size = new System.Drawing.Size(625, 18);
            this.ProfileLabel.TabIndex = 31;
            this.ProfileLabel.Text = "Quelle est la raison pour laquelle vous voullez vous désabonner du club?";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(303, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(507, 211);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Uighur", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(98, 234);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(889, 118);
            this.textBox1.TabIndex = 29;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Unsubscribe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1084, 577);
            this.Controls.Add(this.UnsubscribeBtn);
            this.Controls.Add(this.UnsubscribeTB);
            this.Controls.Add(this.ProfileLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Unsubscribe";
            this.Text = "Se Désabonner";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton UnsubscribeBtn;
        private MetroFramework.Controls.MetroTextBox UnsubscribeTB;
        private System.Windows.Forms.Label ProfileLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}