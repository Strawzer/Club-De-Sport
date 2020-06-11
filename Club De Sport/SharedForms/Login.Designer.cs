namespace Club_De_Sport.SharedForms
{
    partial class Login
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
            this.PaperPlan = new FontAwesome.Sharp.IconButton();
            this.EmailIcon = new FontAwesome.Sharp.IconButton();
            this.EmailTB = new System.Windows.Forms.TextBox();
            this.EmailPanel = new System.Windows.Forms.Panel();
            this.PasswordIcon = new FontAwesome.Sharp.IconButton();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.PassPanel = new System.Windows.Forms.Panel();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.RegisterBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseBtn = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // PaperPlan
            // 
            this.PaperPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PaperPlan.FlatAppearance.BorderSize = 0;
            this.PaperPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PaperPlan.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.PaperPlan.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            this.PaperPlan.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(174)))), ((int)(((byte)(208)))));
            this.PaperPlan.IconSize = 50;
            this.PaperPlan.Location = new System.Drawing.Point(111, 66);
            this.PaperPlan.Name = "PaperPlan";
            this.PaperPlan.Rotation = 0D;
            this.PaperPlan.Size = new System.Drawing.Size(75, 61);
            this.PaperPlan.TabIndex = 0;
            this.PaperPlan.UseVisualStyleBackColor = true;
            // 
            // EmailIcon
            // 
            this.EmailIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EmailIcon.FlatAppearance.BorderSize = 0;
            this.EmailIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EmailIcon.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.EmailIcon.IconChar = FontAwesome.Sharp.IconChar.Envelope;
            this.EmailIcon.IconColor = System.Drawing.Color.WhiteSmoke;
            this.EmailIcon.IconSize = 30;
            this.EmailIcon.Location = new System.Drawing.Point(24, 194);
            this.EmailIcon.Name = "EmailIcon";
            this.EmailIcon.Rotation = 0D;
            this.EmailIcon.Size = new System.Drawing.Size(37, 30);
            this.EmailIcon.TabIndex = 0;
            this.EmailIcon.UseVisualStyleBackColor = true;
            // 
            // EmailTB
            // 
            this.EmailTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EmailTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.EmailTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailTB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTB.ForeColor = System.Drawing.Color.White;
            this.EmailTB.Location = new System.Drawing.Point(66, 199);
            this.EmailTB.Name = "EmailTB";
            this.EmailTB.Size = new System.Drawing.Size(215, 19);
            this.EmailTB.TabIndex = 1;
            this.EmailTB.Text = "E-mail";
            this.EmailTB.Click += new System.EventHandler(this.EmailTB_Click);
            // 
            // EmailPanel
            // 
            this.EmailPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EmailPanel.BackColor = System.Drawing.Color.White;
            this.EmailPanel.Location = new System.Drawing.Point(30, 221);
            this.EmailPanel.Name = "EmailPanel";
            this.EmailPanel.Size = new System.Drawing.Size(251, 1);
            this.EmailPanel.TabIndex = 2;
            // 
            // PasswordIcon
            // 
            this.PasswordIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordIcon.FlatAppearance.BorderSize = 0;
            this.PasswordIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordIcon.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.PasswordIcon.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.PasswordIcon.IconColor = System.Drawing.Color.WhiteSmoke;
            this.PasswordIcon.IconSize = 30;
            this.PasswordIcon.Location = new System.Drawing.Point(24, 238);
            this.PasswordIcon.Name = "PasswordIcon";
            this.PasswordIcon.Rotation = 0D;
            this.PasswordIcon.Size = new System.Drawing.Size(37, 30);
            this.PasswordIcon.TabIndex = 0;
            this.PasswordIcon.UseVisualStyleBackColor = true;
            // 
            // PasswordTB
            // 
            this.PasswordTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.PasswordTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTB.ForeColor = System.Drawing.Color.White;
            this.PasswordTB.Location = new System.Drawing.Point(66, 245);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(215, 19);
            this.PasswordTB.TabIndex = 1;
            this.PasswordTB.Text = "Password";
            this.PasswordTB.Click += new System.EventHandler(this.PasswordTB_Click);
            // 
            // PassPanel
            // 
            this.PassPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PassPanel.BackColor = System.Drawing.Color.White;
            this.PassPanel.Location = new System.Drawing.Point(30, 267);
            this.PassPanel.Name = "PassPanel";
            this.PassPanel.Size = new System.Drawing.Size(251, 1);
            this.PassPanel.TabIndex = 2;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginBtn.AutoSize = true;
            this.LoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(174)))), ((int)(((byte)(208)))));
            this.LoginBtn.FlatAppearance.BorderSize = 0;
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.LoginBtn.Location = new System.Drawing.Point(49, 344);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(0);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(202, 43);
            this.LoginBtn.TabIndex = 3;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // RegisterBtn
            // 
            this.RegisterBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RegisterBtn.AutoSize = true;
            this.RegisterBtn.BackColor = System.Drawing.Color.Transparent;
            this.RegisterBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.RegisterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RegisterBtn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterBtn.ForeColor = System.Drawing.Color.White;
            this.RegisterBtn.Location = new System.Drawing.Point(49, 461);
            this.RegisterBtn.Margin = new System.Windows.Forms.Padding(0);
            this.RegisterBtn.Name = "RegisterBtn";
            this.RegisterBtn.Size = new System.Drawing.Size(202, 43);
            this.RegisterBtn.TabIndex = 3;
            this.RegisterBtn.Text = "Register";
            this.RegisterBtn.UseVisualStyleBackColor = false;
            this.RegisterBtn.Click += new System.EventHandler(this.RegisterBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "OR";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.CloseBtn.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.CloseBtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(174)))), ((int)(((byte)(208)))));
            this.CloseBtn.IconSize = 32;
            this.CloseBtn.Location = new System.Drawing.Point(272, 1);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Rotation = 0D;
            this.CloseBtn.Size = new System.Drawing.Size(29, 30);
            this.CloseBtn.TabIndex = 15;
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(300, 577);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RegisterBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PassPanel);
            this.Controls.Add(this.EmailPanel);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.PasswordIcon);
            this.Controls.Add(this.EmailTB);
            this.Controls.Add(this.EmailIcon);
            this.Controls.Add(this.PaperPlan);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton PaperPlan;
        private FontAwesome.Sharp.IconButton EmailIcon;
        private System.Windows.Forms.TextBox EmailTB;
        private System.Windows.Forms.Panel EmailPanel;
        private FontAwesome.Sharp.IconButton PasswordIcon;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Panel PassPanel;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button RegisterBtn;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton CloseBtn;
    }
}