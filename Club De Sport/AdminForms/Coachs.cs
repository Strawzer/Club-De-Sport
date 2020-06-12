using Club_De_Sport.Models;
using Club_De_Sport.Validators.AdminValidators;
using FluentValidation.Results;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Club_De_Sport.AdminForms
{
    public partial class Coachs : Form
    {
        // Bind Diciplines Combo box
        private BindingList<string> activities;

        // To display verify input data errors to the user
        private BindingList<string> UserErrors;

        private Coach currentCoach;
        private Seance currentSeance;
        public Coachs()
        {
            InitializeComponent();
            UserErrors = new BindingList<string>();
            activities = new BindingList<string>();

            currentCoach = new Coach();
            currentSeance = new Seance();
            // Disable Code Adhérant
            CodeAdhTB.Enabled = false;
            CodeAdhIcon.Enabled = false;
            CodeAdhPanel.Enabled = false;
            // Initialize Sexe CB
            SexeCB.SelectedIndex = 0;
        }

        private void Coachs_Load(object sender, EventArgs e)
        {
            // bind data source to db
            using (ClubDbContext context = new ClubDbContext())
            {
                coachBindingSource.DataSource = context.Coaches.ToList();
                seanceBindingSource.DataSource = context.Seances.ToList();
                if(activities.Count == 0)
                {
                    var activityNamesInDb = context.Activites.ToList();
                    activities.Add("Choisir Votre Discipline");
                    foreach (var activity in activityNamesInDb)
                    {
                        activities.Add(activity.Nom);
                    }
                    // bind data to the cb collection of values
                    activitiesCB.DataSource = activities;
                }
                currentCoach = coachBindingSource.Current as Coach;
                currentSeance = seanceBindingSource.Current as Seance;
            }

            // disable form for input security control
            formEnabled(false);
            // disable affecter dicipline label
            AffecterDicipline.Enabled = false;
            AffecterDicipline.ForeColor = Color.White;
        }

        // Add New Coach to db
        private async void NextModifyBtn_Click(object sender, EventArgs e)
        {
            if (AjouterBtn.Text.Equals("Ajouter"))
            {
                // Enable form to user
                formEnabled(true);

                // Change UI
                formColors(Color.WhiteSmoke);

                // default text
                formTbInitializeText();

                // Change button text
                AjouterBtn.Text = "Sauvegarder";

                // add new field
                coachBindingSource.Add(new Coach());
                coachBindingSource.MoveLast();
            }
            else if (AjouterBtn.Text.Equals("Sauvegarder"))
            {
                /* Perform Add Logic */
                // get user input
                Coach newCoach = coachBindingSource.Current as Coach;

                // Instanciating validators
                CoachsValidator validator = new CoachsValidator();
                ValidationResult results = await validator.ValidateAsync(newCoach);

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

                // add new coach in db
                using (ClubDbContext context = new ClubDbContext())
                {
                    context.Coaches.Add(newCoach);
                    await context.SaveChangesAsync();
                }

                // refresh 
                Coachs_Load(sender, e);

                // Disable form to user
                formEnabled(false);

                // Change Ui
                formColors(Color.FromArgb(253, 138, 114));

                // Change button text
                AjouterBtn.Text = "Ajouter";
            }
        }

        // Affect Seance to coach logic
        private void AffecterSeanceBtn_Click(object sender, EventArgs e)
        {
            if (currentSeance != null && currentCoach != null)
            {
                try
                {
                    using (ClubDbContext context = new ClubDbContext())
                    {
                        var coachInDb = context.Coaches.SingleOrDefault(c => c.CodeCoach == currentCoach.CodeCoach);
                        var seanceInDb = context.Seances.SingleOrDefault(s => s.CodeSeance == currentSeance.CodeSeance);
                        if (coachInDb != null && seanceInDb != null)
                        {
                            coachInDb.Seances.Add(seanceInDb);
                            context.SaveChanges();
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox
                        .Show(ex.Message);
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

        // Perform dicipline affectation logic
        private void AffecterDicipline_Click(object sender, EventArgs e)
        {
            if(activitiesCB.SelectedItem.ToString() != "Choisir Votre Discipline"
                && activitiesCB.SelectedItem.ToString() != string.Empty)
            {
                var currentCoach = (coachBindingSource.Current != null)
                    ? coachBindingSource.Current as Coach
                    : null;
                if(currentCoach != null)
                {
                    using (ClubDbContext context = new ClubDbContext())
                    {
                        var coachToModify = context.Coaches
                            .SingleOrDefault(c => c.CodeCoach == currentCoach.CodeCoach);
                            
                        if(coachToModify.Activites.Count <= 2)
                        {
                            var activityToAdd = context.Activites
                                .SingleOrDefault(a => a.Nom == activitiesCB.SelectedItem.ToString());
                            coachToModify.Activites.Add(activityToAdd);
                            context.SaveChanges();
                            MetroFramework.MetroMessageBox.Show(this,
                            "La discipline " + activityToAdd.Nom + " a bien été afféctée " +
                            "au coach "+ coachToModify.Nom + " !" ,
                            "Discipline affécté avec succès",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this,
                            "Désolé vous ne pouvez pas affecter plus de 2 disciplines " +
                            "à un coach !",
                            "Erreur d'affectation de discipline",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        }
                    }
                }
            }


            // disable the label
                AffecterDicipline.Enabled = false;
            AffecterDicipline.ForeColor = Color.Gray;
            // set ddl to 0
            activitiesCB.SelectedIndex = 0;
        }

        // UI form behavior
        private void NameTB_Click(object sender, EventArgs e)
        {
            if (NameTB.Text.Equals("Nom"))
                NameTB.Clear();

            formColors(Color.WhiteSmoke);

            NameIcon.IconColor = Color.FromArgb(253, 138, 114);
            NamePanel.BackColor = Color.FromArgb(253, 138, 114);
        }

        private void PrenomTB_Click(object sender, EventArgs e)
        {
            if (PrenomTB.Text.Equals("Prénom"))
                PrenomTB.Clear();

            formColors(Color.WhiteSmoke);

            PrenomIcon.IconColor = Color.FromArgb(253, 138, 114);
            PrenomPanel.BackColor = Color.FromArgb(253, 138, 114);
        }

        private void CinTB_Click(object sender, EventArgs e)
        {
            if (CinTB.Text.Equals("Code D'identité National"))
                CinTB.Clear();

            formColors(Color.WhiteSmoke);

            CinIcon.IconColor = Color.FromArgb(253, 138, 114);
            CinPanel.BackColor = Color.FromArgb(253, 138, 114);
        }

        private void TelTB_Click(object sender, EventArgs e)
        {
            if (TelTB.Text.Equals("N° de Téléphone"))
                TelTB.Clear();

            formColors(Color.WhiteSmoke);

            TelIcon.IconColor = Color.FromArgb(253, 138, 114);
            TelPanel.BackColor = Color.FromArgb(253, 138, 114);
        }

        private void TelUrgenceTB_Click(object sender, EventArgs e)
        {
            if (TelUrgenceTB.Text.Equals("N° De Téléphone d'urgence"))
                TelUrgenceTB.Clear();

            formColors(Color.WhiteSmoke);

            TelUrgenceIcon.IconColor = Color.FromArgb(253, 138, 114);
            TelUrgencePanel.BackColor = Color.FromArgb(253, 138, 114);   
        }

        private void AdresseTB_Click(object sender, EventArgs e)
        {
            if (AdresseTB.Text.Equals("Adresse"))
                AdresseTB.Clear();

            formColors(Color.WhiteSmoke);

            AdresseIcon.IconColor = Color.FromArgb(253, 138, 114);
            AdressePanel.BackColor = Color.FromArgb(253, 138, 114);
        }

        private void VilleTB_Click(object sender, EventArgs e)
        {
            if (VilleTB.Text.Equals("Ville"))
                VilleTB.Clear();

            formColors(Color.WhiteSmoke);

            VilleIcon.IconColor = Color.FromArgb(253, 138, 114);
            VillePanel.BackColor = Color.FromArgb(253, 138, 114);
        }

        private void SexeCB_Click(object sender, EventArgs e)
        {
            formColors(Color.WhiteSmoke);

            SexeIcon.IconColor = Color.FromArgb(253, 138, 114);
            SexePanel.BackColor = Color.FromArgb(253, 138, 114);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (activitiesCB.SelectedIndex == 0)
                return;
            if (InputPanel2.Enabled == true)
            {
                activitiesCB.SelectedIndex = 0;
                return;
            }
            AffecterDicipline.Enabled = true;
            AffecterDicipline.ForeColor = Color.FromArgb(253, 138, 114);
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

        }

        private void CoachDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentCoach = coachBindingSource.Current as Coach;
        }

        private void SeancesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentSeance = seanceBindingSource.Current as Seance;
        }
    }
}
