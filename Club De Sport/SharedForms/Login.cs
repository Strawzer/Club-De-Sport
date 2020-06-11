using Club_De_Sport.Models;
using Club_De_Sport.CustomEventArgs;
using Club_De_Sport.Validators;
using FluentValidation.Results;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Web.Helpers;
using System.Windows.Forms;

namespace Club_De_Sport.SharedForms
{
    public partial class Login : Form
    {
        // If the user want to switch to register we must notify Main form
        public delegate void ClickRegisterEventHandeler(object sender, EventArgs e);
        public event ClickRegisterEventHandeler ClickRegister;

        // If the user is Logged In we must notify Main form to change all ui
        public delegate void UserLoggedInEventHandeler(object sender, LoginEventArgs e);
        public event UserLoggedInEventHandeler UserLoggedIn;

        // To display verify input data errors to the user
        private BindingList<string> UserErrors;

        // ctor just to instanciate
        public Login()
        {
            InitializeComponent();
            UserErrors = new BindingList<string>();
        }

        // Connect user
        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            // Get user data to a model
            User UserData = new User
            {
                Email = EmailTB.Text,
                Password = PasswordTB.Text
            };

            // Validate Model
            IdentificationValidator validator = new IdentificationValidator();
            ValidationResult result = await validator.ValidateAsync(UserData);

            if (!result.IsValid)
            {
                // Display Errors to user
                foreach (ValidationFailure failure in result.Errors)
                {
                    UserErrors.Add(failure.ErrorMessage);
                }
                MetroFramework.MetroMessageBox.Show(this,
                    string.Join("\n", UserErrors),
                    "Données Non Valides",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    400);

                // Clear errors for another use and quit
                UserErrors.Clear();
                return;
            }

            // All data is valid let's check database for the user 
            using(ClubDbContext _context = new ClubDbContext())
            {
                // Get user from db with email
                try
                {
                    User userInDb = await _context.Users.SingleOrDefaultAsync(u => u.Email == UserData.Email);
                    // Verify if the email exists and if the password matches the hashed one in Db
                    if (userInDb != null && Crypto.VerifyHashedPassword(userInDb.Password, UserData.Password))
                    {
                        // Password and email matches let's notify the main form (user connected)
                        OnUserLoggedIn(userInDb);
                    }
                    else
                    {
                        // User data incorrect, display error message
                        MetroFramework.MetroMessageBox.Show(this,
                        "L'email que vous avez rentrez et/ou le mot de passe" +
                        "ne sont pas valide, Veuillez Réssayer!",
                        "Données non valides",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Close the login form
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Switch to register form
        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            OnClickRegister();
        }

        /* UI/UX */
        private void EmailTB_Click(object sender, EventArgs e)
        {
            if (EmailTB.Text.Equals("E-mail"))
                EmailTB.Clear();

            EmailIcon.IconColor = Color.FromArgb(67, 174, 208);
            EmailPanel.BackColor = Color.FromArgb(67, 174, 208);

            PasswordIcon.IconColor = Color.WhiteSmoke;
            PassPanel.BackColor = Color.WhiteSmoke;
        }

        private void PasswordTB_Click(object sender, EventArgs e)
        {
            if (PasswordTB.Text.Equals("Password"))
            {
                PasswordTB.Clear();
                PasswordTB.PasswordChar = '*';
            }
            PasswordIcon.IconColor = Color.FromArgb(67, 174, 208);
            PassPanel.BackColor = Color.FromArgb(67, 174, 208);

            EmailIcon.IconColor = Color.WhiteSmoke;
            EmailPanel.BackColor = Color.WhiteSmoke;
        }

        /* Custom Events to manipulate Main form from child forms */
        protected virtual void OnUserLoggedIn(User user)
        {
            // Check for subscribers
            if (UserLoggedIn != null)
                UserLoggedIn(this, new LoginEventArgs { User = user });
        }

        protected virtual void OnClickRegister()
        {
            if (ClickRegister != null)
                ClickRegister(this, EventArgs.Empty);
        }
    }
}
