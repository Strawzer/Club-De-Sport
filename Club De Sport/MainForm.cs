using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Club_De_Sport.SharedForms;
using FontAwesome.Sharp;
using Club_De_Sport.Models;
using Club_De_Sport.AdminForms;
using Club_De_Sport.ClientForms;
using Club_De_Sport.UnsubscribedClientForms;
using Club_De_Sport.CustomEventArgs;
using System.Linq;

namespace Club_De_Sport
{
    public partial class MainForm : Form
    {
        // UI fields
        private Form currentChildForm;
        private Form currentSignForm;
        private Form currentMenuForm;

        // Current User Logged in
        private User currentUser;

        // Initialize default forms 
        public MainForm()
        {
            InitializeComponent();
            // Load Unlogged User Interface
            loadDefaultForms();
            // Form Ui 
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.CurrentChildFormTitle.Text = "Home";
            // Logged In user initialisation
            this.currentUser = new User();
        }

        #region Guest Role Main Form Logic 

        /*
         * Register and Login Logic 
         */

        // Cummon Register-Login switch helper method
        private void OpenSignForm(Form signForm)
        {
            if (currentSignForm != null)
            {
                currentSignForm.Close();
            }
            currentSignForm = signForm;
            signForm.TopLevel = false;
            signForm.Dock = DockStyle.Right;
            SignPanel.Controls.Add(signForm);
            SignPanel.Tag = signForm;
            signForm.BringToFront();
            signForm.Show();
            SignPanel.Visible = true;
        }

        // User Click Login in Register form
        public void OnClickLogin(object sender, EventArgs e)
        {
            SignInBtn.PerformClick();
        }

        // User Registered Successfully
        public void OnUserRegistered(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this,
                "Veuillez vous connecter à votre compte !",
                "Eregistré(e) avec succés",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                SignInBtn.PerformClick();
            
        }

        // Sign Up Button
        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            var thisBtn = (IconButton)sender;
            if (thisBtn.Text == "Sign Up")
            {
                Register RegisterForm = new Register();

                // subscribe to events
                RegisterForm.UserRegistered += OnUserRegistered;
                RegisterForm.ClickLogin += OnClickLogin;

                // Open the child form
                OpenSignForm(RegisterForm);
            }
            else if (thisBtn.Text == "Sign Out")
            {
                // Run the form from start ;)
                Application.Restart();
            }
        }

        /* ---------- */

        // User click Register in login form
        public void OnClickRegister(object sender, EventArgs e)
        {
            SignUpBtn.PerformClick();
        }

        // User Logged In Successfully Changes the hole interface according to user role
        public void OnUserLoggedIn(object sender, LoginEventArgs e) // I must add admin / client default form event handeler subscription when implemented
        {
            // Disable Logins
            SignInBtn.Enabled = false;
            SignInBtn.Visible = false;
            SignUpBtn.IconChar = IconChar.SignOutAlt;
            SignUpBtn.Text = "Sign Out";
            SignUpBtn.IconColor = RGBColors.color6;

            // Show the logged in panel
            LoggedPannel.Visible = true;
            LoggedLabel.Text = "Welcome " +  e.User.Email + " !";

            // Set user Informations to this login
            currentUser = e.User;

            // Close current child forms
            if (currentChildForm != null)
                currentChildForm.Close();
            if (currentMenuForm != null)
                currentMenuForm.Close();
            if (currentSignForm != null)
                currentSignForm.Close();

            // Disable loggin panel
            SignPanel.Enabled = false;
            SignPanel.Visible = false;
            SignPanel.Dispose();

            // check for user role and open corresponding child forms
            if(e.User.Role == User.Admin)
            {
                // set color for header
                CurrentChildFormIcon.IconColor = RGBColors.color2;
                CurrentChildFormTitle.ForeColor = RGBColors.color2;

                // Open admin forms
                AdminMenu adminMenu = new AdminMenu();
                adminMenu.SelectedMenu += OnSelectedMenu;
                // Here add other event handler subscription if needed in the future
                OpenMenuForm(adminMenu);

                Adherents adherents = new Adherents();
                /*
                 * Here Add your event handelers when implemented
                 */
                OpenChildForm(adherents);
            }
            
            else if(e.User.Role == User.NonPayedClient || e.User.Role == User.NonRegisteredClient)
            {
                // Create Unregistered Forms
                UnsubscribedClientMenu unsubscribedClientMenu = new UnsubscribedClientMenu(currentUser);
                unsubscribedClientMenu.SelectedMenu += OnSelectedMenu;
                OpenMenuForm(unsubscribedClientMenu);
            }

            else if(e.User.Role == User.Client)
            {
                // Open client forms
                ClientMenu clientMenu = new ClientMenu();
                clientMenu.SelectedMenu += OnSelectedMenu;
                // Here add other event handler subscription if needed in the future
                OpenMenuForm(clientMenu);

                UpdateCurrentUser();
                Profile profile = new Profile(currentUser);
                /*
                 * Here Add your event handelers when implemented
                 */
                OpenChildForm(profile);
            }
        } 

        // Sign In Button
        private void SignInBtn_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();

            // subscribe to events
            loginForm.UserLoggedIn += OnUserLoggedIn;
            loginForm.ClickRegister += OnClickRegister;

            // Open the child form
            OpenSignForm(loginForm);
        }

        #endregion

        #region UI For Main Form

        /* 
         * Windows External Methods
         * To perform drag & drop Form
         */

        // Color Pallet
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 116, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        // Event Handeler
        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // External Methods
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        /* 
         * Custom Close Minimize Maximize
         */
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void MaximizeBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        #endregion

        #region Common Helpers for all roles
        /*
         * Open Close childs forms helpers
         */
        
        // Update the current user if changed
        public void UpdateCurrentUser()
        {
            try
            {
                using(ClubDbContext context = new ClubDbContext())
                {
                    this.currentUser = context.Users.SingleOrDefault(u => u.Id == currentUser.Id);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Menu selection logic
        public void OnSelectedMenu(object sender, MenuEventArgs e)
        {
            try
            {
                // Try to instanciate form from it's name!
                Type typeName = Type.GetType(e.Namespace + "." + e.ClickedButtonIcon.Text);
                Form form;
                if (e.ClickedButtonIcon.Text == "Registration")
                {
                    form = Activator.CreateInstance(typeName, currentUser) as Registration;
                }
                else if (e.ClickedButtonIcon.Text == "Activities"
                        && e.Namespace == "Club_De_Sport.UnsubscribedClientForms")
                {
                    UpdateCurrentUser();
                    form = Activator.CreateInstance(typeName, currentUser) as UnsubscribedClientForms.Activities;
                }
                else if (e.ClickedButtonIcon.Text == "Subscribe"
                        && e.Namespace == "Club_De_Sport.UnsubscribedClientForms")
                {
                    UpdateCurrentUser();
                    form = Activator.CreateInstance(typeName, currentUser) as UnsubscribedClientForms.Subscribe;
                }
                else if( e.ClickedButtonIcon.Text == "Profile"
                    && e.Namespace == "Club_De_Sport.ClientForms")
                {
                    UpdateCurrentUser();
                    form = Activator.CreateInstance(typeName, currentUser) as ClientForms.Profile;
                }
                else if( e.ClickedButtonIcon.Text == "Activites"
                    && e.Namespace == "Club_De_Sport.ClientForms")
                {
                    UpdateCurrentUser();
                    form = Activator.CreateInstance(typeName, currentUser) as ClientForms.Activities;
                }
                else if( e.ClickedButtonIcon.Text == "Unsubscribe"
                    && e.Namespace == "Club_De_Sport.ClientForms")
                {
                    UpdateCurrentUser();
                    form = Activator.CreateInstance(typeName, currentUser) as ClientForms.Unsubscribe;
                }
                else
                {
                    form = Activator.CreateInstance(typeName) as Form;
                }
                if (form.Text == "Enregistrer vos données personels")
                {
                    var current = (Registration)form;
                    var currentUnsubMenu = (UnsubscribedClientMenu)currentMenuForm;
                    current.SetRegistration += currentUnsubMenu.OnSetRegistration;
                }
                if(form.Text == "Choisissez vos activités")
                {
                    var current = (UnsubscribedClientForms.Activities)form;
                    var currentUnsubMenu = (UnsubscribedClientMenu)currentMenuForm;
                    current.SetPrefferedActivities += currentUnsubMenu.OnSetPrefferedActivities;
                }
                OpenChildForm(form);

                // let's give the title bar icons
                CurrentChildFormIcon.IconChar = e.ClickedButtonIcon.IconChar;
                CurrentChildFormIcon.IconColor = e.ClickedButtonIcon.IconColor;
                CurrentChildFormTitle.ForeColor = e.ClickedButtonIcon.IconColor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Load Default forms as startup
        private void loadDefaultForms()
        {
            // Instanciate
            Home homeForm = new Home();
            SharedMenu sharedMenuForm = new SharedMenu();

            // Subscribe to events
            sharedMenuForm.SelectedMenu += this.OnSelectedMenu;

            // Open default forms
            OpenChildForm(homeForm);
            OpenMenuForm(sharedMenuForm);
        }

        // Open child form
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                // Open Only one form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ChildFormPanel.Controls.Add(childForm);
            ChildFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            CurrentChildFormTitle.Text = childForm.Text;
        }

        // Open menu form
        private void OpenMenuForm(Form menuForm)
        {
            if (currentMenuForm != null)
            {
                // Open Only one form
                currentMenuForm.Close();
            }
            currentMenuForm = menuForm;
            menuForm.TopLevel = false;
            menuForm.FormBorderStyle = FormBorderStyle.None;
            menuForm.Dock = DockStyle.Left;
            PanelMenu.Controls.Add(menuForm);
            PanelMenu.Tag = menuForm;
            menuForm.BringToFront();
            menuForm.Show();
            CurrentChildFormTitle.Text = menuForm.Text;
        }
        #endregion
    }
}
