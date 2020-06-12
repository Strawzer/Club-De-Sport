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

namespace Club_De_Sport.ClientForms
{
    public partial class Unsubscribe : Form
    {
        private User currentUser;
        public Unsubscribe(User user)
        {
            InitializeComponent();
            this.currentUser = user;
        }

        private void UnsubscribeBtn_Click(object sender, EventArgs e)
        {
            // Perform Unsubscribe Logic
            if(UnsubscribeTB.Text != string.Empty)
            {
                try
                {
                    using(ClubDbContext context = new ClubDbContext())
                    {
                        var userToDelete = context.Users
                            .Include(u => u.Adherent)
                            .SingleOrDefault(u => u.Id == currentUser.Id);
                        var correspondingAdherent = context.Adherents
                            .Include(u => u.PreferredActivities)
                            .Include(u => u.Seances)
                            .SingleOrDefault(u => u.CodeAdh == currentUser.AdherentId);
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
                        context.Users.Remove(userToDelete);
                        context.SaveChanges();
                    }
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
