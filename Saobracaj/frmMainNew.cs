using Saobracaj.Dokumenta;
using Saobracaj.Servis;
using System;
using System.Windows.Forms;

namespace Saobracaj
{
    public partial class frmMainNew : Syncfusion.Windows.Forms.Tools.RibbonForm
    {
        string Korisnik = "";
        public frmMainNew()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzcwMDg5QDMxMzgyZTM0MmUzMFhQSmlDM0M2bGpxcXVtT1VScTg1a0dtVTFLcUZiK0tLRnpvRTYyRFpMc3M9");
            InitializeComponent();

        }

        public frmMainNew(string Logovan, int Lozinka)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzcwMDg5QDMxMzgyZTM0MmUzMFhQSmlDM0M2bGpxcXVtT1VScTg1a0dtVTFLcUZiK0tLRnpvRTYyRFpMc3M9");
            InitializeComponent();
            Korisnik = Logovan;
        }



      


        private void toolStripButton28_Click(object sender, EventArgs e)
        {
            frmPravljenjeVoza frmPV = new frmPravljenjeVoza();
            frmPV.Show();
        }

      


       

        private void toolStripButton67_Click(object sender, EventArgs e)
        {
/////Panta u osnovne zarade
            Dokumenta.frmIzracunZarada fiz = new Dokumenta.frmIzracunZarada();
            fiz.Show();
        }


     



     

      

     

        private void toolStripButton80_Click(object sender, EventArgs e)
        {
            Tehnologija.frmTehnologija teh = new Tehnologija.frmTehnologija();
            teh.Show();
        }

    }
}