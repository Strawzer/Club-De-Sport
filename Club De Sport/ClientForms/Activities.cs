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

namespace Club_De_Sport.ClientForms
{
    public partial class Activities : Form
    {
        private User currentUser;
        public Activities(User user)
        {
            InitializeComponent();
            // To display title of cb
            ActivitiesCB.SelectedIndex = 0;
            CoachsCB.SelectedIndex = 0;
            // Default values of date time pickers set to current
            SeanceDate.Value = DateTime.Now.Date;
            SeanceTime.Value = DateTime.Now.Date + DateTime.Now.TimeOfDay;
            //
            this.currentUser = user;
        }

        private void Activities_Load(object sender, EventArgs e)
        {
            ActivityFormEnabled(false);
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
            }
            else if (AddActivityBtn.Text.Equals("Sauvegarder"))
            {
                // Perform Add Logic

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
        }

        private void ModifySeanceBtn_Click(object sender, EventArgs e)
        {
            // Perform Modify Logic
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
            ActivitiesCB.SelectedIndex = 0;
            CoachsCB.SelectedIndex = 0;
        }
    }
}
