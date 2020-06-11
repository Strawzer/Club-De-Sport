using Club_De_Sport.Models;
using Club_De_Sport.Validators.UnsubscribedValidators;
using FluentValidation.Results;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Club_De_Sport.ClientForms
{
    public partial class Profile : Form
    {
        private BindingList<string> UserErrors;
        private User currentUser;
        public Profile(User user)
        {
            InitializeComponent();
            UserErrors = new BindingList<string>();
            // Disable Code Adhérant
            CodeAdhTB.Enabled = false;
            CodeAdhIcon.Enabled = false;
            CodeAdhPanel.Enabled = false;
            // Initialize Sexe CB
            SexeCB.SelectedIndex = 0;
            // 
            this.currentUser = user;
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            formEnabled(false);
            using (ClubDbContext context = new ClubDbContext()) 
            {
                adherentBindingSource.DataSource = context.Adherents
                        .SingleOrDefault(a => a.CodeAdh == currentUser.AdherentId);
            }
        }

        // Implements Registration of user informations (suivent) / modifying registered user informations (modifier)
        private async void NextModifyBtn_Click(object sender, EventArgs e)
        {
            if (ModifyBtn.Text.Equals("Modifier"))
            {
                // Enable form to user
                formEnabled(true);

                // Change UI
                formColors(Color.WhiteSmoke);

                // Change button text
                ModifyBtn.Text = "Sauvegarder";
            }
            else if (ModifyBtn.Text.Equals("Sauvegarder"))
            {
                /* Perform Modify Logic */
                // Get current
                Adherent currentAdherent = adherentBindingSource.Current as Adherent;

                // Instanciating validators
                RegistrationValidator validator = new RegistrationValidator();
                ValidationResult results = await validator.ValidateAsync(currentAdherent);

                // User input data is not valid 
                if (!results.IsValid)
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
                // Get adherent from database
                using (ClubDbContext context = new ClubDbContext())
                {
                    var adherentInDB = context.Adherents
                        .SingleOrDefault(a => a.CodeAdh == currentAdherent.CodeAdh);
                    adherentInDB.Nom = currentAdherent.Nom;
                    adherentInDB.Prenom = currentAdherent.Prenom;
                    adherentInDB.Sexe = currentAdherent.Sexe;
                    adherentInDB.Cin = currentAdherent.Cin;
                    adherentInDB.Tel = currentAdherent.Tel;
                    adherentInDB.TelUrgence = currentAdherent.TelUrgence;
                    adherentInDB.Adresse = currentAdherent.Adresse;
                    adherentInDB.Ville = currentAdherent.Ville;
                    adherentInDB.CNE = currentAdherent.CNE;
                    await context.SaveChangesAsync();
                }
                // Refresh dataGrid
                Profile_Load(sender, e);

                // Disable form to user
                formEnabled(false);

                // Change Ui
                formColors(Color.FromArgb(172, 126, 241));

                // Change button text
                ModifyBtn.Text = "Modifier";
            }
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

        // Ui Helpers
        private void formEnabled(bool isEnabled)
        {
            InputPanel1.Enabled = isEnabled;
            InputPanel2.Enabled = isEnabled;
            InputPanel3.Enabled = isEnabled;
            InputPanel4.Enabled = isEnabled;
            InputPanel5.Enabled = isEnabled;
            InputPanel6.Enabled = isEnabled;
            InputPanel7.Enabled = isEnabled;
            InputPanel8.Enabled = isEnabled;
            InputPanel9.Enabled = isEnabled;
            InputPanel10.Enabled = isEnabled;
        }

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

        private void formTbInitializeText()
        {
            NameTB.Text = "Nom";
            PrenomTB.Text = "Prénom";
            SexeCB.SelectedIndex = 0;
            CinTB.Text = "Code D'identité National";
            TelTB.Text = "N° de Téléphone";
            TelUrgenceTB.Text = "N° De Téléphone d'urgence";
            AdresseTB.Text = "Adresse";
            VilleTB.Text = "Ville";
            CneTB.Text = "CNE Pour Bénificier d'une réduction étudiant";
        }
    }
}
