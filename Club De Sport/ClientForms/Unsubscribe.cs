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
            }

        }
    }
}
