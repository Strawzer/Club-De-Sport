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

namespace Club_De_Sport.UnsubscribedClientForms
{
    public partial class Subscribe : Form
    {
        private User currentUser;
        public Subscribe(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void Subscribe_Load(object sender, EventArgs e)
        {
            // Set the price to user
            using(ClubDbContext context = new ClubDbContext())
            {
                var adherent = context.Adherents
                                .SingleOrDefault(a => a.CodeAdh == currentUser.AdherentId);
                    
                var totalToPay = adherent.PreferredActivities
                                    .Sum(a => a.Prix);

                PriceTb.Text += (adherent.CNE == null || adherent.CNE == string.Empty)
                    ? totalToPay.ToString() + " DH!"
                    : Math.Truncate((decimal)0.8 * totalToPay).ToString() + " DH! " +
                    "avec réduction étudiant (20%) !";
            }
        }
    }
}
