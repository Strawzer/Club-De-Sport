using Club_De_Sport.AdminForms;
using Club_De_Sport.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Club_De_Sport.UnsubscribedClientForms
{
    public partial class Activities : Form
    {
        // Handeler to Inform Menu if Preffered activities set
        public delegate void SetPrefferedActivitiesEventHandeler(object sender, EventArgs e);
        public event SetPrefferedActivitiesEventHandeler SetPrefferedActivities;

        // Combo boxes binding data
        private BindingList<string> activities;
        private BindingList<string> coaches;

        private User currenUser;

        public Activities(User user)
        {
            InitializeComponent();
            coaches = new BindingList<string>();
            activities = new BindingList<string>();
            this.currenUser = user;
        }
        
        private void Activities_Load(object sender, EventArgs e)
        {
            formEnabled(false);
            
            // Bind the data source from db
            using(ClubDbContext context = new ClubDbContext())
            {
                var currentUserPrefferedActivities = context.Adherents
                    .Include(a => a.PreferredActivities)
                    .SingleOrDefault(a => a.CodeAdh == currenUser.AdherentId)
                    .PreferredActivities.ToList();

                activiteBindingSource.DataSource = currentUserPrefferedActivities;
            }
        }

        private void AddActivityBtn_Click(object sender, EventArgs e)
        {
            if (AddActivityBtn.Text.Equals("Ajouter Activitée"))
            {
                #region Just UI Logic
                // Enable form to user
                formEnabled(true);

                // Change UI
                formColors(Color.WhiteSmoke);

                // default text
                formTbInitializeText();

                // Change button text
                AddActivityBtn.Text = "Sauvegarder";

                // disable other buttons 
                DeleteActivityBtn.Enabled = false;
                #endregion

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
                if(ActivitiesCB.SelectedValue.ToString() != "Activités"
                    && ActivitiesCB.SelectedValue != null )
                {
                    var current = activiteBindingSource.Current as Activite;
                    using(ClubDbContext context = new ClubDbContext())
                    {
                        // Pick the activity object from db from cb selected activity name
                        current = context.Activites
                            .SingleOrDefault(a => a.Nom == ActivitiesCB.SelectedValue.ToString());

                        // add the activity to current adherent prefered activities
                        context.Adherents.SingleOrDefault(a => a.CodeAdh == currenUser.AdherentId)
                            .PreferredActivities.Add(current);

                        context.SaveChanges();
                    }
                }
                #region Just UI Logic

                // refresh Datagrid
                Activities_Load(sender, e);

                // Change Ui
                formColors(Color.FromArgb(95, 77, 221));

                // Change button text
                AddActivityBtn.Text = "Ajouter Activitée";

                // Enable other buttons
                DeleteActivityBtn.Enabled = true;
                formTbInitializeText();
                #endregion
            }
        }

        private void DeleteActivityBtn_Click(object sender, EventArgs e)
        {

            if(activiteBindingSource.Count != 0)
            {
                var activityToRemove = activiteBindingSource.Current as Activite;
                using (ClubDbContext context = new ClubDbContext())
                {
                    var activityInDb = context.Activites
                        .SingleOrDefault(a => a.CodeActivite == activityToRemove.CodeActivite);
                    context.Adherents.SingleOrDefault(a => a.CodeAdh == currenUser.AdherentId)
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

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            ICollection<Activite> preffered = new HashSet<Activite>();
            // Perform Submit Logic (set the role to Non Payed Client !) :)
            try
            {
                if(activiteBindingSource.Count != 0)
                {
                    using(ClubDbContext context = new ClubDbContext())
                    {
                        context.Users.SingleOrDefault(u => u.Id == currenUser.Id).Role = User.NonPayedClient;
                        context.SaveChanges();
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this,
                    "Veuillez" +
                    "remplire votre liste des Activités préfférés!",
                    "Données Non Valides",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // call the event 
            OnSetPrefferedActivities();
        }

        // Set PrefferedActivities Custom Event
        protected virtual void OnSetPrefferedActivities()
        {
            // Check for subscribers
            SetPrefferedActivities?.Invoke(this, EventArgs.Empty);
        }

        // Form Ui Behavior
        private void ActivitiesCB_Click(object sender, EventArgs e)
        {
            formColors(Color.WhiteSmoke);

            ActivitiesIcon.IconColor = Color.FromArgb(95, 77, 221);
            ActivitiesPanel.BackColor = Color.FromArgb(95, 77, 221);
        }

        private void CoachsCB_Click(object sender, EventArgs e)
        {
            formColors(Color.WhiteSmoke);

            CoachsIcon.IconColor = Color.FromArgb(95, 77, 221);
            CoachsPanel.BackColor = Color.FromArgb(95, 77, 221);
        }

        // Ui Helpers
        private void formEnabled(bool isEnabled)
        {
            InputPanel1.Enabled = isEnabled;
            InputPanel2.Enabled = isEnabled;
        }

        private void formColors(Color color)
        {
            ActivitiesIcon.IconColor = color;
            ActivitiesPanel.BackColor = color;

            CoachsIcon.IconColor = color;
            CoachsPanel.BackColor = color;
        }

        private void formTbInitializeText()
        {
            activities.Clear();
            coaches.Clear();
            activities.Add("Activités");
            coaches.Add("Coachs");
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
