using Saobracaj.Dokumenta;
using Saobracaj.Servis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Licensing;


namespace Saobracaj
{
    public partial class Main : Form
    {
        string Korisnik = "";

        public Main()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjgxNjY5QDMxMzkyZTM0MmUzMFVQcWRYSEJHSzU3b3kxb0xiYXhKbTR2WUQyZmhWTitWdFhjUEsvUXBPQ1E9");
            InitializeComponent();
        }

        public Main(string Logovan, int Lozinka)
        {
            InitializeComponent();
            Korisnik = Logovan;
        }

        private void staniceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmStanice stan = new Sifarnici.frmStanice();
            stan.Show();
        }

        private void mapaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.WebMapa mapa = new Dokumenta.WebMapa();
            mapa.Show();
        }

        private void traseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmTrase trase = new Sifarnici.frmTrase();
            trase.Show();
        }

        private void nHMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmNHM nhm = new Sifarnici.frmNHM();
            nhm.Show();
        }

        private void statusiVozovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmStatusVoza statvoz = new Sifarnici.frmStatusVoza();
            statvoz.Show();
        }

        private void najavaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmNajava frmNaj = new Dokumenta.frmNajava(Korisnik,0);
            frmNaj.Show();
        }

        private void najavaTablaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmNajava20 naj = new Dokumenta.frmNajava20();
            naj.Show();
        }

        private void partneriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmPartnerji part = new Sifarnici.frmPartnerji();
            part.Show();
        }

        private void razloziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmRazlozi raz = new Sifarnici.frmRazlozi();
            raz.Show();
        }

        private void prugeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmPruge prug = new Sifarnici.frmPruge();
            prug.Show();
        }

        private void radniNalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void osobljeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmOsoblje osob = new Sifarnici.frmOsoblje();
            osob.Show();
        }

        private void sendEMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSendEmailWithAttacment frmWAtt = new frmSendEmailWithAttacment();
            frmWAtt.Show();
        }

        private void prijemEamilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmReceiveMail frm = new Dokumenta.frmReceiveMail();
            frm.Show();
        }

        private void raznoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void teretniceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmTeretnicePregled frmTer = new Dokumenta.frmTeretnicePregled(Korisnik);
            frmTer.Show();

            // Dokumenta.frmTeretnica frmTer = new Dokumenta.frmTeretnica();
            // frmTer.Show();

        }

        private void isključeniVagoniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmIskljuceniVagoni iv = new Dokumenta.frmIskljuceniVagoni();
            iv.Show();
        }

        private void pregledRIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmPregledRID prid = new Dokumenta.frmPregledRID();
            prid.Show();
        }

        private void pronađiVagonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmPronadjiVagon fpv = new Dokumenta.frmPronadjiVagon();
            fpv.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void radniNaloziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmRadniNalogPregled frmRN = new Dokumenta.frmRadniNalogPregled();
            frmRN.Show();
        }

        private void najaveArhivToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmNajava frmNaj = new Dokumenta.frmNajava(Korisnik, 1);
            frmNaj.Show();
        }

        private void vagoniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPravljenjeVoza frmPV = new frmPravljenjeVoza();
            frmPV.Show();
        }

        private void formiranjeTeretnicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmRaspustiVagone frv = new Dokumenta.frmRaspustiVagone();
            frv.Show();
        }

        private void stavkeTeretnicaBezRIDaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmRIDTeretnice fridter = new Dokumenta.frmRIDTeretnice();
            fridter.Show();
        }

        private void najaveBezToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmNajaveBezTeretnice nbt = new Dokumenta.frmNajaveBezTeretnice();
            nbt.Show();
        }

        private void radniNaloziToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Dokumenta.frmRadniNaloziPregled2 frmp2 = new Dokumenta.frmRadniNaloziPregled2();
            frmp2.Show();
        }

        private void pronađiVagonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Dokumenta.frmPronadjiVagon pv = new Dokumenta.frmPronadjiVagon();
            pv.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Dokumenta.frmRIDPoNajavama rpn = new Dokumenta.frmRIDPoNajavama();
            rpn.Show();
        }

        private void vučneJediniceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmTimovi tim = new Sifarnici.frmTimovi();
            tim.Show();
        }

        private void osobljeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sifarnici.frmOsoblje osoblje = new Sifarnici.frmOsoblje();
            osoblje.Show();
        }

        private void štampaRNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmStampaRadnogNaloga srn = new Dokumenta.frmStampaRadnogNaloga();
            srn.Show();
        }

        private void kreirajPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMergePDF frmMPDF = new frmMergePDF();
            frmMPDF.Show();
        }

        private void tipTelegramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmTipTelegrama ttel = new Sifarnici.frmTipTelegrama();
            ttel.Show();
        }

        private void telegramiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmTelegrami tel = new Sifarnici.frmTelegrami();
            tel.Show();
        }

        private void dodelaLokomotivaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmDodelaLokomotive dodLok = new Sifarnici.frmDodelaLokomotive();
            dodLok.Show();
        }

        private void evidencijaRadaPregledačiMašinovođeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmEvidencijaRada erM = new Dokumenta.frmEvidencijaRada(Korisnik);
            erM.Show();

        }

        private void vrsteAktivnostiToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Sifarnici.frmVrsteAktivnosti vrakt = new Sifarnici.frmVrsteAktivnosti();
            if (Korisnik == "admin")
            {
                vrakt.Show();
            }
        }

        private void evidencijaRadaPregledPoStavkamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /*
            Dokumenta.frmEvidencijaRadaPregled erp = new Dokumenta.frmEvidencijaRadaPregled();
            erp.Show();
           */
        }

        private void evidencijaRadaPoZaglavljimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmEvidencijaRadaZaglavlje erz = new Dokumenta.frmEvidencijaRadaZaglavlje(Korisnik);
            erz.Show();
        }

        private void pregledZalihaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmPrikazSkladista frmPS = new Dokumenta.frmPrikazSkladista();
            frmPS.Show();
        }

        private void prijemniceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmPrijemnica frmPRIJ = new Dokumenta.frmPrijemnica();
            frmPRIJ.Show();
        }

        private void tipPrevozaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmTipPrevoza tipP = new Sifarnici.frmTipPrevoza();
            tipP.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Sifarnici.frmCenaPoRadniku cpr = new Sifarnici.frmCenaPoRadniku();
            if (Korisnik == "admin")
            {
                cpr.Show();
            }
        }

        private void izvestaZaradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmZarade zar = new Dokumenta.frmZarade();
            if (Korisnik == "admin")
            {
                zar.Show();
            }
            
            /*
            Dokumenta.frmZarade zar = new Dokumenta.frmZarade();
            zar.Show();
             * */
        }

        private void izvestajPoStavkamaAktivnostiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmStampaPoAktivnostimaStavke sPAs = new Dokumenta.frmStampaPoAktivnostimaStavke();
            sPAs.Show();
        }

        private void troškoviPoBankamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void izveštajPlaćenoNeplaćenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmPlacenoNeplaceno pln = new Dokumenta.frmPlacenoNeplaceno();
            pln.Show();
        }

        private void mašinovođeNovakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmZaradaMasinovodja zarmas = new Dokumenta.frmZaradaMasinovodja();
            zarmas.Show();
        }

        private void evidencijaRadaSmederevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmEvidencijaRadaSmederevo smed = new Dokumenta.frmEvidencijaRadaSmederevo();
            smed.Show();
        }

        private void standardanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmEvidencijaRada erM = new Dokumenta.frmEvidencijaRada(Korisnik);
            erM.Show();
        }

        private void smederevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmEvidencijaRadaSmederevo smed = new Dokumenta.frmEvidencijaRadaSmederevo();
            smed.Show();
        }

        private void kragujevacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmEvidencijaRadaKragujevac kged = new Dokumenta.frmEvidencijaRadaKragujevac();
            kged.Show();
        }

        private void cGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmEvidencijaRadaCG cged = new Dokumenta.frmEvidencijaRadaCG();
            cged.Show();
        }

        private void remontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmEvidencijaRadaRemont rmed = new Dokumenta.frmEvidencijaRadaRemont();
            rmed.Show();
        }

        private void milspedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmEvidencijaRadaMilsped mmed = new Dokumenta.frmEvidencijaRadaMilsped();
            mmed.Show();
        }

        private void godišnjiOdmoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmEvidencijaGodišnjihOdmora sed = new Dokumenta.frmEvidencijaGodišnjihOdmora();
            sed.Show();
        }

        private void pregledPutniNaloziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmPutniNaloziPregled fpn = new Dokumenta.frmPutniNaloziPregled();
            fpn.Show();
        }

        private void obračunZaradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmIzracunZarada fiz = new Dokumenta.frmIzracunZarada();
            fiz.Show();
        }

        private void neplaćenoSređivanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmEvidencijaRAdaNeplaceno nepl = new Dokumenta.frmEvidencijaRAdaNeplaceno();
            nepl.Show();
        }

        private void troškoviZaBankuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmFinansije novak = new Dokumenta.frmFinansije();
            novak.Show();
        }

        private void osnovnaZaradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmOsnovnaZarada osnzar = new Dokumenta.frmOsnovnaZarada();
            osnzar.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Dokumenta.frmPregledSmena smena = new Dokumenta.frmPregledSmena();
            smena.Show();
        }

        private void parametriObračunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmParametriObracuna parobr = new Dokumenta.frmParametriObracuna();
            parobr.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Dokumenta.frmPravoAktivnosti pravo = new Dokumenta.frmPravoAktivnosti();
            pravo.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Dokumenta.frmPravoAktivnostiViseRadnika pravovise = new Dokumenta.frmPravoAktivnostiViseRadnika();
            pravovise.Show();
        }

        private void mUPDOZVOLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmMUPDozvola Dozvola = new Dokumenta.frmMUPDozvola();
            Dozvola.Show();
        }

        private void automobiliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmAutomobili autom = new Dokumenta.frmAutomobili();
            autom.Show();
        }

        private void trenutneAdreseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumenta.frmMupMesto mesto = new Dokumenta.frmMupMesto();
            mesto.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Administracija.InsertAdministracije upd = new Administracija.InsertAdministracije();
            upd.UpdateNull();
            MessageBox.Show("Gotovo zatvori");
        }

        private void grupeKvarovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void kvaroviToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void korisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administracija.frmKorisnici kor = new Administracija.frmKorisnici();
            kor.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Dokumenta.frmPrijavaOdjava pr = new Dokumenta.frmPrijavaOdjava();
            pr.Show();
        }

        private void lokomotiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmLokomotive lok = new Sifarnici.frmLokomotive();
            lok.Show();
        }

        private void prijavaOdjavaMašinovođeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Servis.frmPrijavaMasinovodje mas = new Servis.frmPrijavaMasinovodje();
            mas.Show();
        }

        private void prijavljeniKvaroviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Servis.frmEvidencijaKvarova pkvar = new Servis.frmEvidencijaKvarova();
            pkvar.Show();
        }

        private void slobodniDaniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mobile.frmSlobodniDani slob = new Mobile.frmSlobodniDani(Korisnik);
            slob.Show();
        }

        private void tokoviDokumentacijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mobile.frmTokoviDokumentacije tokdok = new Mobile.frmTokoviDokumentacije();
            tokdok.Show();
        }

        private void prijavaOdjavaSmeneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mobile.frmPrijavaSmene prodj = new Mobile.frmPrijavaSmene();
            prodj.Show();
        }

        private void centralnaTablaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPregledRN prn = new frmPregledRN();
            prn.Show();
        }

        private void prijavaOdjavaMašinovođeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPrijavaMasinovodje mas = new frmPrijavaMasinovodje();
            mas.Show();
        }

        private void namirenjaGorivaIUljaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNamirenja namir = new frmNamirenja();
            namir.Show();
        }

        private void grupeSistematizacijaDincicToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void grupeRadnihMestaDinčićToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administracija.frmSistematizacija sistem = new Administracija.frmSistematizacija();
            sistem.Show();
        }

        private void vezaSistematizacijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administracija.frmSistematizacijaPovezivanje sist = new Administracija.frmSistematizacijaPovezivanje();
            sist.Show();
        }

        private void grupeKvarovaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Servis.frmGrupaKvarova gkv = new Servis.frmGrupaKvarova();
            gkv.Show();
        }

        private void kvaroviToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Servis.frmKvarovi kv = new Servis.frmKvarovi();
            kv.Show();
        }

        private void vrstePopisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Servis.frmVrstePopisa vrPopisa = new frmVrstePopisa();
            vrPopisa.Show();
        }

        private void lokomotivePopisneStavkeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLokomotivaVrstaPopisa lokvp = new frmLokomotivaVrstaPopisa();
            lokvp.Show();
        }

        private void registratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistator reg = new frmRegistator();
            reg.Show();
        }

        private void pregledOdlukaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistratorPregled regpre = new frmRegistratorPregled();
            regpre.Show();
        }

        private void radniNalogPoLokomotivamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRAdniNalogPregledPoLokomotivama rnpl = new frmRAdniNalogPregledPoLokomotivama();
            rnpl.Show();
        }

        private void markeriRNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTest test = new frmTest();
            test.Show();
        }

        private void evidencijaGodišnjihOdmoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEvidencijaGodišnjihOdmora evgo = new frmEvidencijaGodišnjihOdmora();
            evgo.Show();
        }

        private void završnaDokumentacijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mobile.frmZavrsnaDokumentacija zdok = new Mobile.frmZavrsnaDokumentacija();
            zdok.Show();
        }

        private void brojSmenaRasporedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrojSmena brsm = new frmBrojSmena();
            brsm.Show();
        }

        private void planiranjeZaposlenihToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SyncForm.frmPlanRada planrada = new SyncForm.frmPlanRada();
            planrada.Show();
        }

        private void namirenjaAnalizaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNamirenjaSumarno namSum = new frmNamirenjaSumarno();
            namSum.Show();
        }

        private void prijavaOdjavaMašinovođeAnalizaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SyncForm.frmPregledMasinovodje novi = new SyncForm.frmPregledMasinovodje();
            novi.Show();
        }

        private void prijavaOdjavaMobilniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SyncForm.frmPregledMobilni drugi = new SyncForm.frmPregledMobilni();
            drugi.Show();
        }

        private void evidencijaKvarovaAnaliayaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEvidencijaKvarovaAnaliza evkva = new frmEvidencijaKvarovaAnaliza();
            evkva.Show();
        }

        private void mainNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   frmMainNew nowi = new frmMainNew();
           // nowi.Show();
        }

        private void kašnjenjaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void planToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
