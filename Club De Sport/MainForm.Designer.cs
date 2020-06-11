using MetroFramework;
using MetroFramework.Drawing;

namespace Club_De_Sport
{
    partial class MainForm
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
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.CurrentChildFormTitle = new System.Windows.Forms.Label();
            this.CurrentChildFormIcon = new FontAwesome.Sharp.IconButton();
            this.PanelTitleBar = new System.Windows.Forms.Panel();
            this.LoggedPannel = new System.Windows.Forms.Panel();
            this.LoggedLabel = new System.Windows.Forms.Label();
            this.SignUpBtn = new FontAwesome.Sharp.IconButton();
            this.SignInBtn = new FontAwesome.Sharp.IconButton();
            this.MinimizeBtn = new FontAwesome.Sharp.IconButton();
            this.MaximizeBtn = new FontAwesome.Sharp.IconButton();
            this.CloseBtn = new FontAwesome.Sharp.IconButton();
            this.ShadowPanel = new System.Windows.Forms.Panel();
            this.ChildFormPanel = new System.Windows.Forms.Panel();
            this.SignPanel = new System.Windows.Forms.Panel();
            this.PanelTitleBar.SuspendLayout();
            this.LoggedPannel.SuspendLayout();
            this.ChildFormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(200, 661);
            this.PanelMenu.TabIndex = 0;
            // 
            // CurrentChildFormTitle
            // 
            this.CurrentChildFormTitle.AutoSize = true;
            this.CurrentChildFormTitle.Font = new System.Drawing.Font("Lucida Fax", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.CurrentChildFormTitle.ForeColor = System.Drawing.Color.NavajoWhite;
            this.CurrentChildFormTitle.Location = new System.Drawing.Point(70, 34);
            this.CurrentChildFormTitle.Name = "CurrentChildFormTitle";
            this.CurrentChildFormTitle.Size = new System.Drawing.Size(56, 18);
            this.CurrentChildFormTitle.TabIndex = 1;
            this.CurrentChildFormTitle.Text = "Home";
            // 
            // CurrentChildFormIcon
            // 
            this.CurrentChildFormIcon.AutoSize = true;
            this.CurrentChildFormIcon.FlatAppearance.BorderSize = 0;
            this.CurrentChildFormIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CurrentChildFormIcon.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.CurrentChildFormIcon.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.CurrentChildFormIcon.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(126)))), ((int)(((byte)(241)))));
            this.CurrentChildFormIcon.IconSize = 32;
            this.CurrentChildFormIcon.Location = new System.Drawing.Point(26, 24);
            this.CurrentChildFormIcon.Name = "CurrentChildFormIcon";
            this.CurrentChildFormIcon.Rotation = 0D;
            this.CurrentChildFormIcon.Size = new System.Drawing.Size(38, 38);
            this.CurrentChildFormIcon.TabIndex = 0;
            this.CurrentChildFormIcon.UseVisualStyleBackColor = true;
            // 
            // PanelTitleBar
            // 
            this.PanelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.PanelTitleBar.Controls.Add(this.LoggedPannel);
            this.PanelTitleBar.Controls.Add(this.SignUpBtn);
            this.PanelTitleBar.Controls.Add(this.SignInBtn);
            this.PanelTitleBar.Controls.Add(this.MinimizeBtn);
            this.PanelTitleBar.Controls.Add(this.MaximizeBtn);
            this.PanelTitleBar.Controls.Add(this.CloseBtn);
            this.PanelTitleBar.Controls.Add(this.CurrentChildFormTitle);
            this.PanelTitleBar.Controls.Add(this.CurrentChildFormIcon);
            this.PanelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitleBar.ForeColor = System.Drawing.Color.White;
            this.PanelTitleBar.Location = new System.Drawing.Point(200, 0);
            this.PanelTitleBar.Name = "PanelTitleBar";
            this.PanelTitleBar.Size = new System.Drawing.Size(1084, 75);
            this.PanelTitleBar.TabIndex = 2;
            this.PanelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitleBar_MouseDown);
            // 
            // LoggedPannel
            // 
            this.LoggedPannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoggedPannel.Controls.Add(this.LoggedLabel);
            this.LoggedPannel.Font = new System.Drawing.Font("Lucida Fax", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.LoggedPannel.Location = new System.Drawing.Point(617, 24);
            this.LoggedPannel.Name = "LoggedPannel";
            this.LoggedPannel.Size = new System.Drawing.Size(332, 35);
            this.LoggedPannel.TabIndex = 0;
            this.LoggedPannel.Visible = false;
            // 
            // LoggedLabel
            // 
            this.LoggedLabel.AutoSize = true;
            this.LoggedLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.LoggedLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoggedLabel.Location = new System.Drawing.Point(77, 0);
            this.LoggedLabel.Name = "LoggedLabel";
            this.LoggedLabel.Padding = new System.Windows.Forms.Padding(7);
            this.LoggedLabel.Size = new System.Drawing.Size(255, 32);
            this.LoggedLabel.TabIndex = 0;
            this.LoggedLabel.Text = "Welcome Client@mail.com !";
            this.LoggedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SignUpBtn
            // 
            this.SignUpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SignUpBtn.FlatAppearance.BorderSize = 0;
            this.SignUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignUpBtn.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.SignUpBtn.Font = new System.Drawing.Font("Lucida Fax", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.SignUpBtn.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.SignUpBtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(161)))), ((int)(((byte)(251)))));
            this.SignUpBtn.IconSize = 32;
            this.SignUpBtn.Location = new System.Drawing.Point(951, 23);
            this.SignUpBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SignUpBtn.Name = "SignUpBtn";
            this.SignUpBtn.Rotation = 0D;
            this.SignUpBtn.Size = new System.Drawing.Size(140, 35);
            this.SignUpBtn.TabIndex = 5;
            this.SignUpBtn.Text = "Sign Up";
            this.SignUpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SignUpBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SignUpBtn.UseVisualStyleBackColor = true;
            this.SignUpBtn.Click += new System.EventHandler(this.SignUpBtn_Click);
            // 
            // SignInBtn
            // 
            this.SignInBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SignInBtn.FlatAppearance.BorderSize = 0;
            this.SignInBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignInBtn.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.SignInBtn.Font = new System.Drawing.Font("Lucida Fax", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.SignInBtn.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
            this.SignInBtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(88)))), ((int)(((byte)(155)))));
            this.SignInBtn.IconSize = 32;
            this.SignInBtn.Location = new System.Drawing.Point(838, 24);
            this.SignInBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SignInBtn.Name = "SignInBtn";
            this.SignInBtn.Rotation = 0D;
            this.SignInBtn.Size = new System.Drawing.Size(113, 35);
            this.SignInBtn.TabIndex = 5;
            this.SignInBtn.Text = "Sign In";
            this.SignInBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SignInBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SignInBtn.UseVisualStyleBackColor = true;
            this.SignInBtn.Click += new System.EventHandler(this.SignInBtn_Click);
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeBtn.FlatAppearance.BorderSize = 0;
            this.MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBtn.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.MinimizeBtn.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.MinimizeBtn.IconColor = System.Drawing.Color.SlateGray;
            this.MinimizeBtn.IconSize = 16;
            this.MinimizeBtn.Location = new System.Drawing.Point(991, 0);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Rotation = 0D;
            this.MinimizeBtn.Size = new System.Drawing.Size(30, 28);
            this.MinimizeBtn.TabIndex = 0;
            this.MinimizeBtn.UseVisualStyleBackColor = true;
            this.MinimizeBtn.Click += new System.EventHandler(this.MinimizeBtn_Click);
            // 
            // MaximizeBtn
            // 
            this.MaximizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaximizeBtn.FlatAppearance.BorderSize = 0;
            this.MaximizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeBtn.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.MaximizeBtn.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.MaximizeBtn.IconColor = System.Drawing.Color.SlateGray;
            this.MaximizeBtn.IconSize = 16;
            this.MaximizeBtn.Location = new System.Drawing.Point(1023, 0);
            this.MaximizeBtn.Name = "MaximizeBtn";
            this.MaximizeBtn.Rotation = 0D;
            this.MaximizeBtn.Size = new System.Drawing.Size(30, 28);
            this.MaximizeBtn.TabIndex = 0;
            this.MaximizeBtn.UseVisualStyleBackColor = true;
            this.MaximizeBtn.Click += new System.EventHandler(this.MaximizeBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.CloseBtn.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.CloseBtn.IconColor = System.Drawing.Color.SlateGray;
            this.CloseBtn.IconSize = 16;
            this.CloseBtn.Location = new System.Drawing.Point(1054, 0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Rotation = 0D;
            this.CloseBtn.Size = new System.Drawing.Size(30, 28);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // ShadowPanel
            // 
            this.ShadowPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.ShadowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ShadowPanel.Location = new System.Drawing.Point(200, 75);
            this.ShadowPanel.Name = "ShadowPanel";
            this.ShadowPanel.Size = new System.Drawing.Size(1084, 9);
            this.ShadowPanel.TabIndex = 3;
            // 
            // ChildFormPanel
            // 
            this.ChildFormPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ChildFormPanel.Controls.Add(this.SignPanel);
            this.ChildFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChildFormPanel.Location = new System.Drawing.Point(200, 84);
            this.ChildFormPanel.Name = "ChildFormPanel";
            this.ChildFormPanel.Size = new System.Drawing.Size(1084, 577);
            this.ChildFormPanel.TabIndex = 4;
            // 
            // SignPanel
            // 
            this.SignPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SignPanel.Location = new System.Drawing.Point(784, 0);
            this.SignPanel.MinimumSize = new System.Drawing.Size(300, 400);
            this.SignPanel.Name = "SignPanel";
            this.SignPanel.Size = new System.Drawing.Size(300, 577);
            this.SignPanel.TabIndex = 0;
            this.SignPanel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.ChildFormPanel);
            this.Controls.Add(this.ShadowPanel);
            this.Controls.Add(this.PanelTitleBar);
            this.Controls.Add(this.PanelMenu);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1300, 700);
            this.Name = "MainForm";
            this.PanelTitleBar.ResumeLayout(false);
            this.PanelTitleBar.PerformLayout();
            this.LoggedPannel.ResumeLayout(false);
            this.LoggedPannel.PerformLayout();
            this.ChildFormPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.Label CurrentChildFormTitle;
        private FontAwesome.Sharp.IconButton CurrentChildFormIcon;
        private System.Windows.Forms.Panel PanelTitleBar;
        private System.Windows.Forms.Panel ShadowPanel;
        private System.Windows.Forms.Panel ChildFormPanel;
        private FontAwesome.Sharp.IconButton CloseBtn;
        private FontAwesome.Sharp.IconButton MinimizeBtn;
        private FontAwesome.Sharp.IconButton MaximizeBtn;
        private FontAwesome.Sharp.IconButton SignInBtn;
        private FontAwesome.Sharp.IconButton SignUpBtn;
        private System.Windows.Forms.Panel SignPanel;
        private System.Windows.Forms.Panel LoggedPannel;
        private System.Windows.Forms.Label LoggedLabel;
    }
}

