using Club_De_Sport.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Club_De_Sport.ClientForms
{
    public partial class Activities : Form
    {
        private User currentUser;
        // Combo boxes binding data
        private BindingList<string> activities;
        private BindingList<string> coaches;
        private BindingList<string> UserErrors;
        public Activities(User user)
        {
            InitializeComponent();
            // To display title of cb

            // Default values of date time pickers set to current
            SeanceDate.Value = DateTime.Now.Date;
            SeanceTime.Value = DateTime.Now.Date + DateTime.Now.TimeOfDay;
            //
            coaches = new BindingList<string>();
            activities = new BindingList<string>();
            UserErrors = new BindingList<string>();
            this.currentUser = user;
        }

        private void Activities_Load(object sender, EventArgs e)
        {
            ActivityFormEnabled(false);
            // Bind the data source from db
            using (ClubDbContext context = new ClubDbContext())
            {
                var currentUserPrefferedActivities = context.Adherents
                    .Include(a => a.PreferredActivities)
                    .SingleOrDefault(a => a.CodeAdh == currentUser.AdherentId)
                    .PreferredActivities.ToList();

                activiteBindingSource.DataSource = currentUserPrefferedActivities;

                var currentUserSeances = context.Adherents.Include(a => a.Seances)
                    .SingleOrDefault(a => a.CodeAdh == currentUser.AdherentId)
                    .Seances
                    .ToList();
                seanceBindingSource.DataSource = currentUserSeances;
            }
        }

        private void AddActivityBtn_Click(object sender, EventArgs e)
        {
            if (AddActivityBtn.Text.Equals("Ajouter Activitée"))
            {
                // Enable form to user
                ActivityFormEnabled(true);
                SeanceFormEnabled(false);

                // Change UI
                ActivityFormColors(Color.WhiteSmoke);

                // default text
                ActivityFormInitializeText();

                // Change button text
                AddActivityBtn.Text = "Sauvegarder";

                // disable other buttons 
                DeleteActivityBtn.Enabled = false;
                ModifySeanceBtn.Enabled = false;
                // Load Activities from db
                using (ClubDbContext context = new ClubDbContext())
                {
                    var activityNamesInDb = context.Activites.ToList();
                    foreach (var activity in activityNamesInDb)
                    {
                        activities.Add(activity.Nom);
                    }
                }
                // bind data to the cb collection of values
                ActivitiesCB.DataSource = activities;

                // Add a new field to the binding source
                activiteBindingSource.Add(new Activite());
                activiteBindingSource.MoveLast();
            }
            else if (AddActivityBtn.Text.Equals("Sauvegarder"))
            {
                // Perform Add Logic
                if (ActivitiesCB.SelectedValue.ToString() != "Activités"
                    && ActivitiesCB.SelectedValue != null)
                {
                    var current = activiteBindingSource.Current as Activite;
                    using (ClubDbContext context = new ClubDbContext())
                    {
                        // Pick the activity object from db from cb selected activity name
                        current = context.Activites
                            .SingleOrDefault(a => a.Nom == ActivitiesCB.SelectedValue.ToString());

                        // add the activity to current adherent prefered activities
                        context.Adherents.SingleOrDefault(a => a.CodeAdh == currentUser.AdherentId)
                            .PreferredActivities.Add(current);

                        context.SaveChanges();
                    }
                }
                Activities_Load(sender, e);
                // Disable form to user
                ActivityFormEnabled(false);
                SeanceFormEnabled(true);

                // Change Ui
                ActivityFormColors(Color.FromArgb(95, 77, 221));

                // Change button text
                AddActivityBtn.Text = "Ajouter Activitée";

                // Enable other buttons
                DeleteActivityBtn.Enabled = true;
                ModifySeanceBtn.Enabled = true;
            }
        }

        private void DeleteActivityBtn_Click(object sender, EventArgs e)
        {
            // Perform Delete Activity Logic
            if (activiteBindingSource.Count != 0)
            {
                var activityToRemove = activiteBindingSource.Current as Activite;
                using (ClubDbContext context = new ClubDbContext())
                {
                    var activityInDb = context.Activites
                        .SingleOrDefault(a => a.CodeActivite == activityToRemove.CodeActivite);
                    context.Adherents.SingleOrDefault(a => a.CodeAdh == currentUser.AdherentId)
                        .PreferredActivities.Remove(activityInDb);
                    context.SaveChanges();
                }
                Activities_Load(sender, e);
            }

            else
                MetroFramework.MetroMessageBox.Show(this,
                    "Veuillez Selectionner une ligne dans le tableau ou bien " +
                    "remplire votre liste des Activités préfférés si elle est vide!",
                    "Données Non Valides",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void ModifySeanceBtn_Click(object sender, EventArgs e)
        {
            // Perform Modify Logic
            var seanceToAdd = seanceBindingSource.Current as Seance;
            if(seanceToAdd != null)
            {
                seanceToAdd.DebutSeance = SeanceDate.Value.Date + SeanceTime.Value.TimeOfDay;

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
                    var seanceInDb = context.Adherents.Include(a => a.Seances)
                        .SingleOrDefault(a => a.CodeAdh == currentUser.AdherentId)
                        .Seances
                        .SingleOrDefault(s => s.CodeSeance == seanceToAdd.CodeSeance);
                    seanceInDb.DebutSeance = seanceToAdd.DebutSeance;
                    context.SaveChanges();
                }
                Activities_Load(sender, e);
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this,
                        "Vous n'avez pas séléctionné une séance ou bien aucune séance ne vous est afféctée!",
                        "Aucune séance n'est séléctionnée",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                // Clear errors for another use and quit
                UserErrors.Clear();
            }
        }

        // Form Ui Behavior
        private void ActivitiesCB_Click(object sender, EventArgs e)
        {
            ActivityFormColors(Color.WhiteSmoke);

            ActivitiesIcon.IconColor = Color.FromArgb(95, 77, 221);
            ActivitiesPanel.BackColor = Color.FromArgb(95, 77, 221);
        }

        private void CoachsCB_Click(object sender, EventArgs e)
        {
            ActivityFormColors(Color.WhiteSmoke);

            CoachsIcon.IconColor = Color.FromArgb(95, 77, 221);
            CoachsPanel.BackColor = Color.FromArgb(95, 77, 221);
        }

        private void SeanceDate_DropDown(object sender, EventArgs e)
        {
            SeanceFormColors(Color.WhiteSmoke);

            DateIcon.IconColor = Color.FromArgb(95, 77, 221);
            DatePanel.BackColor = Color.FromArgb(95, 77, 221);
        }

        private void SeanceTime_ValueChanged(object sender, EventArgs e)
        {
            SeanceFormColors(Color.WhiteSmoke);

            DateIcon.IconColor = Color.FromArgb(95, 77, 221);
            DatePanel.BackColor = Color.FromArgb(95, 77, 221);
        }

        // Ui Helpers
        private void ActivityFormEnabled(bool isEnabled)
        {
            InputPanel1.Enabled = isEnabled;
            InputPanel2.Enabled = isEnabled;
        }

        private void SeanceFormEnabled(bool isEnabled)
        {
            InputPanel3.Enabled = isEnabled;
        }

        private void ActivityFormColors(Color color)
        {
            ActivitiesIcon.IconColor = color;
            ActivitiesPanel.BackColor = color;
            CoachsIcon.IconColor = color;
            CoachsPanel.BackColor = color;
        }

        private void SeanceFormColors(Color color)
        {
            DateIcon.IconColor = color;
            DatePanel.BackColor = color;
        }

        private void ActivityFormInitializeText()
        {
            
        }

        // bind the second cb with coachs in db related to this activity
        private async void ActivitiesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ActivitiesCB.SelectedValue == null
                    || ActivitiesCB.SelectedValue.ToString() == "Activités")
                    return;
                coaches.Clear();
                coaches.Add("Coachs");
                using (ClubDbContext context = new ClubDbContext())
                {
                    var SelectedActivity = await context.Activites.Include(a => a.Coachs).SingleOrDefaultAsync(a => a.Nom == ActivitiesCB.SelectedValue.ToString());
                    foreach (var coach in SelectedActivity.Coachs)
                    {
                        coaches.Add(coach.Nom + " " + coach.Prenom);
                    }
                }
                // bind selected activity coachs to the scnd cb
                CoachsCB.DataSource = coaches;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
