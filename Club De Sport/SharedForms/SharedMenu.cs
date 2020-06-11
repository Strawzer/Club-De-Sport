using Club_De_Sport.CustomEventArgs;
using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Club_De_Sport.SharedForms
{
    public partial class SharedMenu : Form
    {
        // Handeler to switch between Menu selections
        public delegate void SelectedMenuEventHandeler(object sender, MenuEventArgs e);
        public event SelectedMenuEventHandeler SelectedMenu;

        private IconButton currentBtn;
        private Panel leftBorderBtn;

        public SharedMenu()
        {
            InitializeComponent();
            // UI
            leftBorderBtn = new Panel();
            //PanelMenu.Controls.Add(leftBorderBtn);
            Controls.Add(leftBorderBtn);
            OnSelectedMenu(HomeBtn);

            ActivateButton(HomeBtn, RGBColors.color1);
            HomeBtn.PerformClick();
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 116, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            IconButton selectedIcon = (IconButton)sender;
            OnSelectedMenu(selectedIcon);
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            IconButton selectedIcon = (IconButton)sender;
            OnSelectedMenu(selectedIcon);
        }

        private void ContactBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            IconButton selectedIcon = (IconButton)sender;
            OnSelectedMenu(selectedIcon);
        }

        // UI Helpers
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                // Disable the previous Btn
                DisableButton();

                // Selected Btn
                currentBtn = (IconButton)senderBtn;

                // Btn appearence modification
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                // Left Border Button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(currentBtn.Location.X, currentBtn.Location.Y);
                leftBorderBtn.Size = new Size(10, currentBtn.Size.Height);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                // Btn appearence Reset to default
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.PapayaWhip;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.PapayaWhip;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        /* Custom Events to manipulate Main form from Menu buttons */
        protected virtual void OnSelectedMenu(IconButton clickedBtn)
        {
            // Check for subscribers
            if (SelectedMenu != null)
                SelectedMenu(this, new MenuEventArgs 
                { 
                    ClickedButtonIcon = clickedBtn,
                    Namespace = "Club_De_Sport.SharedForms"
                });
        }
    }
}
