using Club_De_Sport.Models;
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
    public partial class Register : Form
    {
        // If the user want to switch to Login we must notify Main form
        public delegate void ClickLoginEventHandeler(object sender, EventArgs e);
        public event ClickLoginEventHandeler ClickLogin;

        // If the user is Registered In we must notify Main form to switch to login
        public delegate void UserLoggedInEventHandeler(object sender, EventArgs e);
        public event UserLoggedInEventHandeler UserRegistered;

        // To display verify input data errors to the user
        private BindingList<string> UserErrors;

        // Ctor just to instanciate
        public Register()
        {
            InitializeComponent();
            UserErrors = new BindingList<string>();
        }

        // Register user
        private async void RegisterBtn_Click(object sender, EventArgs e)
        {
            // Get user data to a model
            User newUser = new User
            {
                Email = EmailTB.Text,
                Password = PasswordTB.Text
            };

            // Validate Model
            IdentificationValidator validator = new IdentificationValidator();
            ValidationResult result = await validator.ValidateAsync(newUser);

            // Validate password confirmation
            if (!ConfirmPasswordTB.Text.Equals(newUser.Password))
            {
                result.Errors.Add(new ValidationFailure("Confirm Password",
                    "Les mots de passe ne sont pas identiques."));
            }

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
                    MessageBoxIcon.Error);

                // Clear errors for another use and quit
                UserErrors.Clear();
                return;
            }
            // Add Role information to the new user model
            newUser.Role = User.NonRegisteredClient;

            // Hash the password for security
            newUser.Password = Crypto.HashPassword(newUser.Password);

            // Input data is valid let's add to database
            using (ClubDbContext _context = new ClubDbContext())
            {
                // check for E-mail already used
                if(await _context.Users.SingleOrDefaultAsync(u => u.Email == newUser.Email) != null)
                {
                    MetroFramework.MetroMessageBox.Show(this,
                    "L'email que vous avez rentré est déjà utilisé par quelqu'un d'autre,\n" +
                    "Entrez en un nouveau ou connectez vous!",
                    "E-mail déjà utilisé",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }

                // All is valid now we need to add to db !
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                // Registered success, notify the Main form to switch to login
                OnUserRegistered();
            }
        }

        // Close Register form
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Switch to Login Form
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            OnClickLogin();
        }

        /* UI/UX */
        private void EmailTB_Click(object sender, EventArgs e)
        {
            if(EmailTB.Text.Equals("E-mail"))
                EmailTB.Clear();

            EmailIcon.IconColor = Color.FromArgb(67, 174, 208);
            EmailPanel.BackColor = Color.FromArgb(67, 174, 208);

            PasswordIcon.IconColor = Color.WhiteSmoke;
            PassPanel.BackColor = Color.WhiteSmoke;

            ConfirmIcon.IconColor = Color.WhiteSmoke;
            ConfirmPanel.BackColor = Color.WhiteSmoke;
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

            ConfirmIcon.IconColor = Color.WhiteSmoke;
            ConfirmPanel.BackColor = Color.WhiteSmoke;
        }

        private void ConfirmPasswordTB_Click(object sender, EventArgs e)
        {
            if(ConfirmPasswordTB.Text.Equals("Confirm Password"))
            {
                ConfirmPasswordTB.Clear();
                ConfirmPasswordTB.PasswordChar = '*';
            }
            ConfirmIcon.IconColor = Color.FromArgb(67, 174, 208);
            ConfirmPanel.BackColor = Color.FromArgb(67, 174, 208);

            EmailIcon.IconColor = Color.WhiteSmoke;
            EmailPanel.BackColor = Color.WhiteSmoke;

            PasswordIcon.IconColor = Color.WhiteSmoke;
            PassPanel.BackColor = Color.WhiteSmoke;
        }

        /* Custom Events to manipulate Main form from child forms */
        protected virtual void OnUserRegistered()
        {
            // Check for subscribers
            if (UserRegistered != null)
                UserRegistered(this, EventArgs.Empty);
        }

        protected virtual void OnClickLogin()
        {
            if (ClickLogin != null)
                ClickLogin(this, EventArgs.Empty);
        }
    }
}
