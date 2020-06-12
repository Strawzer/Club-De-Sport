using Club_De_Sport.Models;
using Club_De_Sport.Validators.UnsubscribedValidators;
using FluentValidation.Results;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web.Helpers;
using System.Windows.Forms;
using System.Data.Entity;
     

namespace Club_De_Sport.AdminForms
{
    public partial class Adherents : Form
    {
        // To display verify input data errors to the user
        private BindingList<string> UserErrors;
        private Adherent currentAdh;
        private Seance currentSeance;
        public Adherents()
        {
            InitializeComponent();
            UserErrors = new BindingList<string>();
            currentSeance = new Seance();
            currentAdh = new Adherent();
            // Disable Code Adhérant
            CodeAdhTB.Enabled = false;
            CodeAdhIcon.Enabled = false;
            CodeAdhPanel.Enabled = false;
            // Initialize Sexe CB
            SexeCB.SelectedIndex = 0;
        }

        private void adherents_Load(object sender, EventArgs e)
        {
            // disable form for input security control
            formEnabled(false);

            // Get all adherent from the db and bind them to the data source
            using (ClubDbContext context = new ClubDbContext())
            {
                adherentBindingSource.DataSource = context.Adherents.ToList();
                seanceBindingSource.DataSource = context.Seances.ToList();
            }
            currentAdh = adherentBindingSource.Current as Adherent;
            currentSeance = seanceBindingSource.Current as Seance;
        }

        // Add New Adherent to db
        private async void NextModifyBtn_Click(object sender, EventArgs e)
        {
            if (AjouterBtn.Text.Equals("Ajouter"))
            {
                #region UI Logic
                // Enable form to user
                formEnabled(true);

                // Change UI
                formColors(Color.WhiteSmoke);

                // default text
                formTbInitializeText();

                // Change button text
                AjouterBtn.Text = "Sauvegarder";

                // Disable other buttons
                ModifierBtn.Enabled = false;
                SupprimerBtn.Enabled = false;
                AffecterSeanceBtn.Enabled = false;
                #endregion 

                adherentBindingSource.Add(new Adherent());
                adherentBindingSource.MoveLast();
            }
            else if (AjouterBtn.Text.Equals("Sauvegarder"))
            {
                /* Perform Add Logic */
                // get user input
                Adherent newAdh = adherentBindingSource.Current as Adherent;

                // Instanciating validators
                RegistrationValidator validator = new RegistrationValidator();
                ValidationResult results = await validator.ValidateAsync(newAdh);

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

                // Create new User logins
                var newUser = new User
                {
                    Email = newAdh.Nom + newAdh.Prenom + "@mail.com",
                    Password = Crypto.HashPassword("Client123"),
                    Role = User.NonPayedClient,
                };
                // All is valid let's attach adherent informations to the user
                using (ClubDbContext _context = new ClubDbContext())
                {
                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();
                    var userInDb = _context.Users.SingleOrDefault(u => u.Email.Equals(newUser.Email));
                    userInDb.Adherent = newAdh;
                    await _context.SaveChangesAsync();
                    userInDb.AdherentId = userInDb.Adherent.CodeAdh;
                    await _context.SaveChangesAsync();
                }
                // refresh the datagrid
                adherents_Load(sender, e);
                // show added message to display logins
                MetroFramework.MetroMessageBox.Show(this,
                        "Le client " + newAdh.Nom + " "
                        + newAdh.Prenom + " a été crée avec succés.\n" +
                        "Ses logins générés automatiquement sont: \n" +
                        "Login:\t" + newUser.Email +"\n" +
                        "Password:\t" + "Client123 \n",
                        "Client Ajouté avec succés",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                #region UI Logic
                // Disable form to user
                formEnabled(false);

                // Change Ui
                formColors(Color.FromArgb(249, 116, 176));

                // Change button text
                AjouterBtn.Text = "Ajouter";

                // Disable other buttons
                ModifierBtn.Enabled = true;
                SupprimerBtn.Enabled = true;
                AffecterSeanceBtn.Enabled = true;
                #endregion
            }
        }

        // Modify Existing adherent
        private async void ModifierBtn_Click(object sender, EventArgs e)
        {
            if (ModifierBtn.Text.Equals("Modifier"))
            {
                // Enable form to user
                formEnabled(true);

                // Change UI
                formColors(Color.WhiteSmoke);

                // Change button text
                ModifierBtn.Text = "Sauvegarder";

                // disable other buttons 
                AjouterBtn.Enabled = false;
                SupprimerBtn.Enabled = false;
                AffecterSeanceBtn.Enabled = false;
            }
            else if (ModifierBtn.Text.Equals("Sauvegarder"))
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
                adherents_Load(sender, e);

                // Disable form to user
                formEnabled(false);

                // Change Ui
                formColors(Color.FromArgb(249, 116, 176));

                // Change button text
                ModifierBtn.Text = "Modifier";

                // Enable other buttons
                AjouterBtn.Enabled = true;
                SupprimerBtn.Enabled = true;
                AffecterSeanceBtn.Enabled = true;
            }
        }

        // Delete Adherent
        private async void SupprimerBtn_Click(object sender, EventArgs e)
        {
            // Get current adherent
            Adherent adhToRemove = adherentBindingSource.Current as Adherent;
            // Get adherent to remove from db
            try
            {
                using (ClubDbContext context = new ClubDbContext())
                {
                    var userToDelete = context.Users
                                .Include(u => u.Adherent)
                                .SingleOrDefault(u => u.AdherentId == adhToRemove.CodeAdh);
                    var correspondingAdherent = context.Adherents
                        .Include(u => u.PreferredActivities)
                        .Include(u => u.Seances)
                        .SingleOrDefault(a => a.CodeAdh == adhToRemove.CodeAdh);
                    var prefActivities = correspondingAdherent.PreferredActivities.ToList();
                    foreach (var act in prefActivities)
                    {
                        correspondingAdherent.PreferredActivities.Remove(act);
                    }
                    var seances = correspondingAdherent.Seances.ToList();
                    foreach (var seance in seances)
                    {
                        correspondingAdherent.Seances.Remove(seance);
                    }
                    context.Adherents.Remove(correspondingAdherent);
                    context.SaveChanges();
                    context.Users.Remove(userToDelete);
                    context.SaveChanges();
                }
                adherents_Load(sender, e);
            }
            catch (ArgumentNullException ex)
            {
                MetroFramework.MetroMessageBox.Show(this,
                        "Aucun adhérent n'est séléctionnée ou bien la" +
                        " base de données est vide.",
                        "Pas d'adhérent séléctionné",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Affecter un emploi
        private void AffecterSeanceBtn_Click_1(object sender, EventArgs e)
        {
            if (currentSeance != null && currentAdh != null)
            {
                try
                {
                    using (ClubDbContext context = new ClubDbContext())
                    {
                        var UserInDb = context.Users.Include(u => u.Adherent)
                            .SingleOrDefault(u => u.AdherentId == currentAdh.CodeAdh)
                            .Adherent;
                        var adherentInDb = context.Adherents.Include(a => a.PreferredActivities)
                            .Include(a => a.Seances)
                            .SingleOrDefault(a => a.CodeAdh == UserInDb.CodeAdh);
                        var seanceInDb = context.Seances.Include(s => s.Activites)
                            .Include( s => s.Coach)
                            .Include( s=> s.Salle)
                            .SingleOrDefault(s => s.CodeSeance == currentSeance.CodeSeance);
                        if (seanceInDb != null && adherentInDb != null)
                        {
                            adherentInDb.Seances.Add(seanceInDb);
                            context.SaveChanges();
                        }
                        MetroFramework.MetroMessageBox.Show(this,
                        "La séance dont le code est " + seanceInDb.CodeSeance 
                        + " et qui a comme coach: " + seanceInDb.Coach.Nom
                        + " et qui a comme horaire: " + seanceInDb.DebutSeance
                        + " a bien été associée au client: "+ adherentInDb.Nom +
                        " " + adherentInDb.Prenom + " !",
                        "Séance afféctée avec succés",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                // show added message to display No Seance selected error
                MetroFramework.MetroMessageBox.Show(this,
                        "Vous n'avez séléctionné aucunne séance ou bien" +
                        "La base de donnée ne contiens aucunne séance !",
                        "Pas de Seance selectionnées",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }


        // UI form behavior
        private void NameTB_Click(object sender, EventArgs e)
        {
            if (NameTB.Text.Equals("Nom"))
                NameTB.Clear();

            formColors(Color.WhiteSmoke);

            NameIcon.IconColor = Color.FromArgb(249, 116, 176);
            NamePanel.BackColor = Color.FromArgb(249, 116, 176);
        }

        private void PrenomTB_Click(object sender, EventArgs e)
        {
            if (PrenomTB.Text.Equals("Prénom"))
                PrenomTB.Clear();

            formColors(Color.WhiteSmoke);

            PrenomIcon.IconColor = Color.FromArgb(249, 116, 176);
            PrenomPanel.BackColor = Color.FromArgb(249, 116, 176);
        }

        private void CinTB_Click(object sender, EventArgs e)
        {
            if (CinTB.Text.Equals("Code D'identité National"))
                CinTB.Clear();

            formColors(Color.WhiteSmoke);

            CinIcon.IconColor = Color.FromArgb(249, 116, 176);
            CinPanel.BackColor = Color.FromArgb(249, 116, 176);
        }

        private void TelTB_Click(object sender, EventArgs e)
        {
            if (TelTB.Text.Equals("N° de Téléphone"))
                TelTB.Clear();

            formColors(Color.WhiteSmoke);

            TelIcon.IconColor = Color.FromArgb(249, 116, 176);
            TelPanel.BackColor = Color.FromArgb(249, 116, 176);
        }

        private void TelUrgenceTB_Click(object sender, EventArgs e)
        {
            if (TelUrgenceTB.Text.Equals("N° De Téléphone d'urgence"))
                TelUrgenceTB.Clear();

            formColors(Color.WhiteSmoke);

            TelUrgenceIcon.IconColor = Color.FromArgb(249, 116, 176);
            TelUrgencePanel.BackColor = Color.FromArgb(249, 116, 176);
        }

        private void AdresseTB_Click(object sender, EventArgs e)
        {
            if (AdresseTB.Text.Equals("Adresse"))
                AdresseTB.Clear();

            formColors(Color.WhiteSmoke);

            AdresseIcon.IconColor = Color.FromArgb(249, 116, 176);
            AdressePanel.BackColor = Color.FromArgb(249, 116, 176);
        }

        private void VilleTB_Click(object sender, EventArgs e)
        {
            if (VilleTB.Text.Equals("Ville"))
                VilleTB.Clear();

            formColors(Color.WhiteSmoke);

            VilleIcon.IconColor = Color.FromArgb(249, 116, 176);
            VillePanel.BackColor = Color.FromArgb(249, 116, 176);

        }

        private void SexeCB_Click(object sender, EventArgs e)
        {
            formColors(Color.WhiteSmoke);

            SexeIcon.IconColor = Color.FromArgb(249, 116, 176);
            SexePanel.BackColor = Color.FromArgb(249, 116, 176);
        }

        private void CneTB_Click(object sender, EventArgs e)
        {
            if (CneTB.Text == "CNE Pour Bénificier d'une réduction étudiant")
                CneTB.Clear();

            NameIcon.IconColor = Color.WhiteSmoke;
            NamePanel.BackColor = Color.WhiteSmoke;

            PrenomIcon.IconColor = Color.WhiteSmoke;
            PrenomPanel.BackColor = Color.WhiteSmoke;

            SexeIcon.IconColor = Color.WhiteSmoke;
            SexePanel.BackColor = Color.WhiteSmoke;

            CinIcon.IconColor = Color.WhiteSmoke;
            CinPanel.BackColor = Color.WhiteSmoke;

            TelIcon.IconColor = Color.WhiteSmoke;
            TelPanel.BackColor = Color.WhiteSmoke;

            TelUrgenceIcon.IconColor = Color.WhiteSmoke;
            TelUrgencePanel.BackColor = Color.WhiteSmoke;

            AdresseIcon.IconColor = Color.WhiteSmoke;
            AdressePanel.BackColor = Color.WhiteSmoke;

            VilleIcon.IconColor = Color.WhiteSmoke;
            VillePanel.BackColor = Color.WhiteSmoke;

            CneIcon.IconColor = Color.FromArgb(249, 116, 176);
            CnePanel.ForeColor = Color.FromArgb(249, 116, 176);
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
            CnePanel.ForeColor = color;
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

        private void CoachDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentAdh = adherentBindingSource.Current as Adherent;
        }

        private void SeancesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentSeance = adherentBindingSource.Current as Seance;
        }
    }
}

