using Club_De_Sport.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Club_De_Sport.AdminForms
{
    public partial class Activities : Form
    {
        // Bind Combo boxes
        private BindingList<string> activities;
        private BindingList<string> salles;
        private BindingList<string> coachs;

        // To display verify input data errors to the user
        private BindingList<string> UserErrors;

        public Activities()
        {
            InitializeComponent();
            // Initialize binding lists
            activities = new BindingList<string>();
            salles = new BindingList<string>();
            coachs = new BindingList<string>();
            UserErrors = new BindingList<string>();

            
            // Default values of date time pickers set to current
            SeanceDate.Value = DateTime.Now.Date;
            SeanceTime.Value = DateTime.Now.Date + DateTime.Now.TimeOfDay;
        }

        private void Activities_Load(object sender, EventArgs e)
        {
            // bind data source to db
            using (ClubDbContext context = new ClubDbContext())
            {
                adherentBindingSource.DataSource = context.Adherents.ToList();
                seanceBindingSource.DataSource = context.Seances.ToList();
                // Bind combobox datasource to db 
                if (activities.Count == 0)
                {
                    var activityNamesInDb = context.Activites.ToList();
                    activities.Add("Choisir Votre Discipline");
                    foreach (var activity in activityNamesInDb)
                    {
                        activities.Add(activity.Nom);
                    }
                    // bind data to the cb collection of values
                    ActivitiesCB.DataSource = activities;
                }
            }
            // To display title of cb
            ActivitiesCB.SelectedIndex = 0;
            formEnabled(false);
            formTbInitializeText();
        }

        private void AddSeanceBtn_Click(object sender, EventArgs e)
        {
            if(AddSeanceBtn.Text.Equals("Ajouter Une Seance"))
            {
                // Enable form to user
                formEnabled(true);

                // Change UI
                formColors(Color.WhiteSmoke);

                // default text
                formTbInitializeText();

                // Change button text
                AddSeanceBtn.Text = "Sauvegarder";

                seanceBindingSource.Add(new Seance());
                seanceBindingSource.MoveLast();
            }
            else if (AddSeanceBtn.Text.Equals("Sauvegarder"))
            {
                // Perform Add Logic
                var seanceToAdd = seanceBindingSource.Current as Seance;
                seanceToAdd.Activites = new List<Activite>();
                seanceToAdd.DebutSeance = SeanceDate.Value.Date + SeanceTime.Value.TimeOfDay;
                if (MinAdhTB.Text == string.Empty
                    || MaxAdhTB.Text == string.Empty
                    || ActivitiesCB.SelectedIndex == 0
                    || CoachsCB.SelectedIndex == 0
                    || SallesCB.SelectedIndex == 0)
                {
                    UserErrors.Add("Veuillez remplire tous les champs du formulaire !");
                }
                if (seanceToAdd.MinAdh <= 0)
                    UserErrors.Add("Le nombre minimal d'adhérents doit etre supérieur à 0");
                if (seanceToAdd.MaxAdh > 10)
                {
                    if (ActivitiesCB.SelectedItem.ToString() != "Musculation")
                    {
                        UserErrors.Add("Le nombre maximal d'adhérents doit etre inférieur ou égal à 10" +
                        "Sauf pour la musculation.");
                    }
                    else if(ActivitiesCB.SelectedItem.ToString() == "Musculation" && seanceToAdd.MaxAdh >30)
                    {
                        UserErrors.Add("Le nombre maximal d'adhérents doit etre inférieur ou égal à 30" +
                        "pour la musculation.");
                    }
                }
                DateTime min = new DateTime(seanceToAdd.DebutSeance.Year
                    , seanceToAdd.DebutSeance.Month
                    , seanceToAdd.DebutSeance.Day
                    , 7
                    , 0
                    , 0);
                DateTime max = new DateTime(seanceToAdd.DebutSeance.Year
                    , seanceToAdd.DebutSeance.Month
                    , seanceToAdd.DebutSeance.Day
                    , 21
                    , 0
                    , 0);

                if (seanceToAdd.DebutSeance < min || seanceToAdd.DebutSeance > max)
                {
                    UserErrors.Add("Les Seances doivent respecter les horaires du club: \n" +
                        "Ouverture: 7h00\n" +
                        "Fermeture: 21h00.");
                }
                if(UserErrors.Count > 0)
                {
                    MetroFramework.MetroMessageBox.Show(this,
                        string.Join("\n", UserErrors),
                        "Données Non Valides",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    // Clear errors for another use and quit
                    UserErrors.Clear();
                    return;
                }

                using (ClubDbContext context = new ClubDbContext())
                {
                    var activityToAdd = context.Activites
                        .SingleOrDefault(a => a.Nom == ActivitiesCB.SelectedItem.ToString());
                    var coachToAdd = context.Coaches
                        .SingleOrDefault(c => c.Nom == CoachsCB.SelectedItem.ToString());
                    var salleToAdd = context.Salles
                        .SingleOrDefault(s => s.Discipline == SallesCB.SelectedItem.ToString());
                    seanceToAdd.Salle = salleToAdd;
                    seanceToAdd.Coach = coachToAdd;
                    seanceToAdd.Activites.Add(activityToAdd);
                    context.Seances.Add(seanceToAdd);
                    context.SaveChanges();
                }
                Activities_Load(sender, e);

                // Disable form to user
                formEnabled(false);

                // Change Ui
                formColors(Color.FromArgb(95, 77, 221));

                // Change button text
                AddSeanceBtn.Text = "Ajouter Une Seance";

                // Enable other buttons
                ModifySeanceBtn.Enabled = true;
                DeleteSeanceBtn.Enabled = true;
            }
        }

        private void DeleteSeanceBtn_Click(object sender, EventArgs e)
        {
            // Perform Delete Logic
            var seanceToDelete = seanceBindingSource.Current as Seance;
            try
            {
                if (seanceToDelete != null)
                {
                    using (ClubDbContext context = new ClubDbContext())
                    {
                        var seanceInDb = context.Seances
                            .Include(s => s.Activites)
                            .Include(s => s.Adherents)
                            .SingleOrDefault(s => s.CodeSeance == seanceToDelete.CodeSeance);
                        var adherents = seanceInDb.Adherents.ToList();
                        var activites = seanceInDb.Activites.ToList();
                        foreach (var activity in activites)
                        {
                            seanceInDb.Activites.Remove(activity);
                        }
                        foreach (var adherent in adherents)
                        {
                            seanceInDb.Adherents.Remove(adherent);
                        }
                        context.Seances.Remove(seanceInDb);
                        context.SaveChanges();
                    }
                    Activities_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ModifySeanceBtn_Click(object sender, EventArgs e)
        {
            if (ModifySeanceBtn.Text.Equals("Modifier Une Seance"))
            {
                // Enable form to user
                formEnabled(true);

                // Change UI
                formColors(Color.WhiteSmoke);

                // Change button text
                ModifySeanceBtn.Text = "Sauvegarder";

                // disable other buttons 
                AddSeanceBtn.Enabled = false;
                DeleteSeanceBtn.Enabled = false;
            }
            else if (ModifySeanceBtn.Text.Equals("Sauvegarder"))
            {
                // Perform Modify Logic
                var seanceToAdd = seanceBindingSource.Current as Seance;
                seanceToAdd.Activites = new List<Activite>();
                seanceToAdd.DebutSeance = SeanceDate.Value.Date + SeanceTime.Value.TimeOfDay;
                if (MinAdhTB.Text == string.Empty
                    || MaxAdhTB.Text == string.Empty
                    || ActivitiesCB.SelectedIndex == 0
                    || CoachsCB.SelectedIndex == 0
                    || SallesCB.SelectedIndex == 0)
                {
                    UserErrors.Add("Veuillez remplire tous les champs du formulaire !");
                }
                if (seanceToAdd.MinAdh <= 0)
                    UserErrors.Add("Le nombre minimal d'adhérents doit etre supérieur à 0");
                if (seanceToAdd.MaxAdh > 10)
                {
                    if (ActivitiesCB.SelectedItem.ToString() != "Musculation")
                    {
                        UserErrors.Add("Le nombre maximal d'adhérents doit etre inférieur ou égal à 10" +
                        "Sauf pour la musculation.");
                    }
                    else if (ActivitiesCB.SelectedItem.ToString() == "Musculation" && seanceToAdd.MaxAdh > 30)
                    {
                        UserErrors.Add("Le nombre maximal d'adhérents doit etre inférieur ou égal à 30" +
                        "pour la musculation.");
                    }
                }
                DateTime min = new DateTime(seanceToAdd.DebutSeance.Year
                    , seanceToAdd.DebutSeance.Month
                    , seanceToAdd.DebutSeance.Day
                    , 7
                    , 0
                    , 0);
                DateTime max = new DateTime(seanceToAdd.DebutSeance.Year
                    , seanceToAdd.DebutSeance.Month
                    , seanceToAdd.DebutSeance.Day
                    , 21
                    , 0
                    , 0);

                if (seanceToAdd.DebutSeance < min || seanceToAdd.DebutSeance > max)
                {
                    UserErrors.Add("Les Seances doivent respecter les horaires du club: \n" +
                        "Ouverture: 7h00\n" +
                        "Fermeture: 21h00.");
                }
                if (UserErrors.Count > 0)
                {
                    MetroFramework.MetroMessageBox.Show(this,
                        string.Join("\n", UserErrors),
                        "Données Non Valides",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    // Clear errors for another use and quit
                    UserErrors.Clear();
                    return;
                }
                using (ClubDbContext context = new ClubDbContext())
                {
                    var activityToAdd = context.Activites
                        .SingleOrDefault(a => a.Nom == ActivitiesCB.SelectedItem.ToString());
                    var coachToAdd = context.Coaches
                        .SingleOrDefault(c => c.Nom == CoachsCB.SelectedItem.ToString());
                    var salleToAdd = context.Salles
                        .SingleOrDefault(s => s.Discipline == SallesCB.SelectedItem.ToString());
                    seanceToAdd.Salle = salleToAdd;
                    seanceToAdd.Coach = coachToAdd;
                    seanceToAdd.Activites.Add(activityToAdd);

                    var seanceInDb = context.Seances.SingleOrDefault(s => s.CodeSeance == seanceToAdd.CodeSeance);
                    seanceInDb.MinAdh = seanceToAdd.MinAdh;
                    seanceInDb.MaxAdh = seanceToAdd.MaxAdh;
                    seanceInDb.Activites = seanceToAdd.Activites;
                    seanceInDb.Coach = seanceToAdd.Coach;
                    seanceInDb.Salle = seanceToAdd.Salle;
                    seanceInDb.DebutSeance = seanceToAdd.DebutSeance;
                    context.SaveChanges();
                }
                Activities_Load(sender, e);

                // Disable form to user
                formEnabled(false);

                // Change Ui
                formColors(Color.FromArgb(95, 77, 221));

                // Change button text
                ModifySeanceBtn.Text = "Modifier Une Seance";

                // Enable other buttons
                AddSeanceBtn.Enabled = true;
                DeleteSeanceBtn.Enabled = true;
            }
        }

        // Form Ui Behavior
        private void MaxAdhTB_Click(object sender, EventArgs e)
        {
            if (MaxAdhTB.Text.Equals("Nombre Maximal D'adhérents"))
                MaxAdhTB.Clear();

            formColors(Color.WhiteSmoke);

            MaxAdhIcon.IconColor = Color.FromArgb(95, 77, 221);
            MaxAdhPanel.BackColor = Color.FromArgb(95, 77, 221);
        }

        private void MinAdhTB_Click(object sender, EventArgs e)
        {
            if (MinAdhTB.Text.Equals("Nombre Minimal D'adhérents"))
                MinAdhTB.Clear();

            formColors(Color.WhiteSmoke);

            MinAdhIcon.IconColor = Color.FromArgb(95, 77, 221);
            MinAdhPanel.BackColor = Color.FromArgb(95, 77, 221);
        }

        private void ActivitiesCB_Click(object sender, EventArgs e)
        {
            formColors(Color.WhiteSmoke);

            ActivitiesIcon.IconColor = Color.FromArgb(95, 77, 221);
            ActivitiesPanel.BackColor = Color.FromArgb(95, 77, 221);
        }

        private void SallesCB_Click(object sender, EventArgs e)
        {
            formColors(Color.WhiteSmoke);

            SallesIcon.IconColor = Color.FromArgb(95, 77, 221);
            SallesPanel.BackColor = Color.FromArgb(95, 77, 221);
        }

        private void CoachsCB_Click(object sender, EventArgs e)
        {
            formColors(Color.WhiteSmoke);

            CoachsIcon.IconColor = Color.FromArgb(95, 77, 221);
            CoachsPanel.BackColor = Color.FromArgb(95, 77, 221);
        }

        private void SeanceDate_DropDown(object sender, EventArgs e)
        {
            formColors(Color.WhiteSmoke);

            DateIcon.IconColor = Color.FromArgb(95, 77, 221);
            DatePanel.BackColor = Color.FromArgb(95, 77, 221);
        }

        private void SeanceTime_ValueChanged(object sender, EventArgs e)
        {
            formColors(Color.WhiteSmoke);

            DateIcon.IconColor = Color.FromArgb(95, 77, 221);
            DatePanel.BackColor = Color.FromArgb(95, 77, 221);
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
        }

        private void formColors(Color color)
        {
            MaxAdhIcon.IconColor = color;
            MaxAdhPanel.BackColor = color;

            MinAdhIcon.IconColor = color;
            MinAdhPanel.BackColor = color;

            ActivitiesIcon.IconColor = color;
            ActivitiesPanel.BackColor = color;

            SallesIcon.IconColor = color;
            SallesPanel.BackColor = color;

            CoachsIcon.IconColor = color;
            CoachsPanel.BackColor = color;

            DateIcon.IconColor = color;
            DatePanel.BackColor = color;
        }

        private void formTbInitializeText()
        {
            MinAdhTB.Text = "Nombre Maximal D'adhérents";
            MaxAdhTB.Text = "Nombre Minimal D'adhérents";
            ActivitiesCB.SelectedIndex = 0;
            SeanceDate.Value = DateTime.Now.Date;
            SeanceTime.Value = DateTime.Now.Date + DateTime.Now.TimeOfDay;
        }

        private void ActivitiesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActivitiesCB.SelectedIndex == 0)
                return;
            using (ClubDbContext context = new ClubDbContext())
            {
                coachs.Clear();
                salles.Clear();
                var selectedActivity = context.Activites
                    .SingleOrDefault(a => a.Nom == ActivitiesCB.SelectedItem.ToString());

                // Salle Binding
                var salleNameInDb = context.Salles
                    .SingleOrDefault(s => s.CodeSalle == selectedActivity.SalleId);
                salles.Add("Choisir Votre Salle");
                salles.Add(salleNameInDb.Discipline);
                // bind data to the cb collection of values
                SallesCB.DataSource = salles;

                // Coach Binding
                var activityInDb = context.Activites
                    .SingleOrDefault(a => a.CodeActivite == selectedActivity.CodeActivite);
                coachs.Add("Choisir Votre Coach");
                if(activityInDb.Coachs.Count != 0)
                {
                    foreach (var coach in activityInDb.Coachs)
                        coachs.Add(coach.Nom);
                }
                else
                {
                    coachs.Add("Aucun cauch n'est enregistré avec cette discipline!");
                }
                CoachsCB.DataSource = coachs;
            }
            SallesCB.SelectedIndex = 0;
        }
    }
}
