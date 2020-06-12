using Club_De_Sport.Models;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Club_De_Sport.AdminForms
{
    public partial class Subscriptions : Form
    {
        // To display verify input data errors to the user
        private BindingList<string> UserErrors;
        public Subscriptions()
        {
            InitializeComponent();
            UserErrors = new BindingList<string>();
        }

        private void Subscribtions_Load(object sender, EventArgs e)
        {
            using (ClubDbContext context = new ClubDbContext())
            {
                var NonPayedAdherents = context.Users
                    .Where(u => u.Role == User.NonPayedClient || u.Role == User.NonRegisteredClient)
                    .Select(u => u.Adherent)
                    .ToList();

                var SubscriptionsExpiringThisMounth = new BindingList<Adherent>();
                var adherentsInDb = context.Adherents.ToList();
                foreach(Adherent adh in adherentsInDb)
                {
                    if (Expiration(adh.ExpirationDate))
                        SubscriptionsExpiringThisMounth.Add(adh);
                }
                  
                adherentBindingSource.DataSource = NonPayedAdherents;
                adherentBindingSource1.DataSource = SubscriptionsExpiringThisMounth;

                ExpirationDate.Value = DateTime.Now.Date;
                ExpirationTime.Value = DateTime.Now.Date + DateTime.Now.TimeOfDay;
            }
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            var excelApp = new Excel.Application();
            //Ouverture du fichier Excel, à vous de choisir l'emplacement ou est situé le fichier excel ainsi que son nom!!
            Excel._Workbook workbook = excelApp.Workbooks.Add(Type.Missing); //Open(@"C:\Users\lenovo 310\Desktop\users.xlsx");
            Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets[1]; // On sélectionne la Feuil1
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Clients non abonnées"; // on renomme la Feuil1 

            NonPayedDGV.RowHeadersVisible = false;
            for (int Rows = 1; Rows < NonPayedDGV.Columns.Count + 1; Rows++)
            {
                worksheet.Cells[1, Rows] = NonPayedDGV.Columns[Rows - 1].HeaderText;
            }

            // on recopie toutes les valeurs du DataGridView dans le fichier Excel
            for (int Rows = 0; Rows < NonPayedDGV.Rows.Count - 1; Rows++)
            {
                for (int Columns = 0; Columns < NonPayedDGV.Columns.Count; Columns++)
                {
                    worksheet.Cells[Rows + 2, Columns + 1] = NonPayedDGV.Rows[Rows].Cells[Columns].Value;
                }
            }

            workbook.Sheets.Add(After: workbook.Sheets[workbook.Sheets.Count]);
            Excel._Worksheet worksheet2 = null;
            worksheet2 = workbook.Sheets[2]; // On sélectionne la Feuil1
            worksheet2 = workbook.ActiveSheet;
            worksheet2.Name = "Abonnements expirants ce mois"; // on renomme la Feuil1 

            ExpiringDGV.RowHeadersVisible = false;
            for (int Rows = 1; Rows < ExpiringDGV.Columns.Count + 1; Rows++)
            {
                worksheet2.Cells[1, Rows] = ExpiringDGV.Columns[Rows - 1].HeaderText;
            }

            // on recopie toutes les valeurs du DataGridView dans le fichier Excel
            for (int Rows = 0; Rows < ExpiringDGV.Rows.Count - 1; Rows++)
            {
                for (int Columns = 0; Columns < ExpiringDGV.Columns.Count; Columns++)
                {
                    worksheet2.Cells[Rows + 2, Columns + 1] = ExpiringDGV.Rows[Rows].Cells[Columns].Value;
                }
            }

            // sauvegarde du fichier Excel 
            //puis dans ce dossier j'ai renommé Client.xlsx 
            var savefileDialoge = new SaveFileDialog();
            savefileDialoge.FileName = "RapportClubClients";
            savefileDialoge.DefaultExt = ".xlsx";
            if (savefileDialoge.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(savefileDialoge.FileName,
               Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
               Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
               Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            // Fermeture de l'application Excel
            excelApp.Visible = true;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(worksheet2);
            Marshal.FinalReleaseComObject(workbook);
            //excelApp.Quit();
        }

        private void PayementBtn_Click(object sender, EventArgs e)
        {
            var adherentToPay = adherentBindingSource.Current as Adherent;
            if (adherentToPay == null)
                UserErrors.Add("Veuillez séléctionner un adhérent pour éffectuer le payement!");
            if (ExpirationDate.Value.Date + ExpirationTime.Value.TimeOfDay < DateTime.Now)
                UserErrors.Add("Veuillez Entrer une date d'éxpiration valide !");
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
                var UserInDb = context.Users.SingleOrDefault(u => u.AdherentId == adherentToPay.CodeAdh);
                var CorrespondingAdherent = context.Adherents.SingleOrDefault(a => a.CodeAdh == adherentToPay.CodeAdh);
                UserInDb.Role = User.Client;
                CorrespondingAdherent.ExpirationDate = ExpirationDate.Value.Date + ExpirationTime.Value.TimeOfDay;
                context.SaveChanges();
            }
            Subscribtions_Load(sender, e);

        }

        private bool Expiration(DateTime? ExpirationDate)
        {
            if(ExpirationDate.HasValue)
            {
                DateTime expirateOn = (DateTime)ExpirationDate;
                TimeSpan aMounth = TimeSpan.FromDays(30);
                if ((expirateOn - DateTime.Today) < aMounth)
                    return true;
            }
            return false;
        }
    }
}
