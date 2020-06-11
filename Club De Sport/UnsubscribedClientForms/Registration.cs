using Club_De_Sport.Models;
using Club_De_Sport.Validators.UnsubscribedValidators;
using FluentValidation.Results;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Club_De_Sport.UnsubscribedClientForms
{
    public partial class Registration : Form
    {
        // Handeler to Inform Menu if registered
        public delegate void SetRegistrationEventHandeler(object sender, EventArgs e);
        public event SetRegistrationEventHandeler SetRegistration;

        private User currentUser;

        // To display verify input data errors to the user
        private BindingList<string> UserErrors;

        public Registration(User user)
        {
            InitializeComponent();
            UserErrors = new BindingList<string>();
            this.currentUser = user;

            // Disable Code Adhérant
            CodeAdhTB.Enabled = false;
            CodeAdhIcon.Enabled = false;
            CodeAdhPanel.Enabled = false;
            // Initialize Sexe CB
            SexeCB.SelectedIndex = 0;
        }

        // checks if the current user already added this form informations
        private async void Registration_Load(object sender, EventArgs e)
        {
            using (ClubDbContext _context = new ClubDbContext())
            {
                var userInDb = await _context.Users.Include( u => u.Adherent).SingleOrDefaultAsync(u => u.Id == currentUser.Id);
                if (userInDb != null)
                    if (userInDb.Adherent != null)
                        OnSetRegistration();
            }
        }

        // Implements Registration of user informations (suivent) / modifying registered user informations (modifier)
        private async void NextModifyBtn_Click(object sender, EventArgs e)
        {
            /* Perform add user registration to db */

            // Get user data to a model
            Adherent newAdh = new Adherent
            {
                Nom = NameTB.Text,
                Prenom = PrenomTB.Text,
                Sexe = SexeCB.SelectedItem.ToString(),
                Cin = CinTB.Text,
                Tel = TelTB.Text,
                TelUrgence = TelUrgenceTB.Text,
                Adresse = AdresseTB.Text,
                Ville = VilleTB.Text,
                CNE = (CneTB.Text != "CNE Pour Bénificier d'une réduction étudiant") ? CneTB.Text : null
            };

            // Instanciating validators
            RegistrationValidator validator = new RegistrationValidator();
            ValidationResult results = await validator.ValidateAsync(newAdh);

            // User input data is not valid 
            if(!results.IsValid)
            {
                // Display Errors to user
                foreach (ValidationFailure failure in results.Errors)
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
            
            // All is valid let's attach adherent informations to the user
            using(ClubDbContext _context = new ClubDbContext())
            {
                var userInDb = await _context.Users.FirstOrDefaultAsync(u => u.Id == currentUser.Id);
                if(userInDb != null)
                {
                    userInDb.Adherent = newAdh;
                    
                }
                await _context.SaveChangesAsync();
                userInDb.AdherentId = userInDb.Adherent.CodeAdh;
                await _context.SaveChangesAsync();
            }

            // call the event to quit this shit
            OnSetRegistration();
        }
        // UI form behavior
        private void NameTB_Click(object sender, EventArgs e)
        {
            if (NameTB.Text.Equals("Nom"))
                NameTB.Clear();

            formColors(Color.WhiteSmoke);

            NameIcon.IconColor = Color.FromArgb(172, 126, 241);
            NamePanel.BackColor = Color.FromArgb(172, 126, 241);
        }

        private void PrenomTB_Click(object sender, EventArgs e)
        {
            if (PrenomTB.Text.Equals("Prénom"))
                PrenomTB.Clear();

            formColors(Color.WhiteSmoke);

            PrenomIcon.IconColor = Color.FromArgb(172, 126, 241);
            PrenomPanel.BackColor = Color.FromArgb(172, 126, 241);
        }

        private void CinTB_Click(object sender, EventArgs e)
        {
            if (CinTB.Text.Equals("Code D'identité National"))
                CinTB.Clear();

            formColors(Color.WhiteSmoke);

            CinIcon.IconColor = Color.FromArgb(172, 126, 241);
            CinPanel.BackColor = Color.FromArgb(172, 126, 241);
        }

        private void TelTB_Click(object sender, EventArgs e)
        {
            if (TelTB.Text.Equals("N° de Téléphone"))
                TelTB.Clear();

            formColors(Color.WhiteSmoke);

            TelIcon.IconColor = Color.FromArgb(172, 126, 241);
            TelPanel.BackColor = Color.FromArgb(172, 126, 241);
        }

        private void TelUrgenceTB_Click(object sender, EventArgs e)
        {
            if (TelUrgenceTB.Text.Equals("N° De Téléphone d'urgence"))
                TelUrgenceTB.Clear();

            formColors(Color.WhiteSmoke);

            TelUrgenceIcon.IconColor = Color.FromArgb(172, 126, 241);
            TelUrgencePanel.BackColor = Color.FromArgb(172, 126, 241);
        }

        private void AdresseTB_Click(object sender, EventArgs e)
        {
            if (AdresseTB.Text.Equals("Adresse"))
                AdresseTB.Clear();

            formColors(Color.WhiteSmoke);

            AdresseIcon.IconColor = Color.FromArgb(172, 126, 241);
            AdressePanel.BackColor = Color.FromArgb(172, 126, 241);
        }

        private void VilleTB_Click(object sender, EventArgs e)
        {
            if (VilleTB.Text.Equals("Ville"))
                VilleTB.Clear();

            formColors(Color.WhiteSmoke);

            VilleIcon.IconColor = Color.FromArgb(172, 126, 241);
            VillePanel.BackColor = Color.FromArgb(172, 126, 241);
        }

        private void CneTB_Click(object sender, EventArgs e)
        {
            if (CneTB.Text.Equals("CNE Pour Bénificier d'une réduction étudiant"))
                CneTB.Clear();

            formColors(Color.WhiteSmoke);

            CneIcon.IconColor = Color.FromArgb(172, 126, 241);
            CnePanel.BackColor = Color.FromArgb(172, 126, 241);
        }

        private void SexeCB_Click(object sender, EventArgs e)
        {
            formColors(Color.WhiteSmoke);

            SexeIcon.IconColor = Color.FromArgb(172, 126, 241);
            SexePanel.BackColor = Color.FromArgb(172, 126, 241);
        }

        // Set Registration Custom Event
        protected virtual void OnSetRegistration()
        {
            // Check for subscribers
            SetRegistration?.Invoke(this, EventArgs.Empty);
        }

        // Ui Helpers
        private void formColors(Color color)
        {
            NameIcon.IconColor = color;
            NamePanel.BackColor = color;

            PrenomIcon.IconColor = color;
            PrenomPanel.BackColor = color;

            SexeIcon.IconColor = color;
            SexePanel.BackColor = color;

            CinIcon.IconColor = color;
            CinPanel.BackColor = color;

            TelIcon.IconColor = color;
            TelPanel.BackColor = color;

            TelUrgenceIcon.IconColor = color;
            TelUrgencePanel.BackColor = color;

            AdresseIcon.IconColor = color;
            AdressePanel.BackColor = color;

            VilleIcon.IconColor = color;
            VillePanel.BackColor = color;

            CneIcon.IconColor = color;
            CnePanel.BackColor = color;
        }
    }
}
