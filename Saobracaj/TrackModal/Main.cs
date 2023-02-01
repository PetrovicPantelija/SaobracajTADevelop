using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Configuration;

using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using TrackModal.Dokumeta;
using Saobracaj.TrackModal.Izvestaji;

namespace TrackModal
{
    public partial class Main : Form
    {
        string Korisnik = "";

        public Main()
        {
            InitializeComponent();
        }

        public Main(string Logovan, int Lozinka)
        {
            InitializeComponent();
            Korisnik = Logovan;
            
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void kOMITENTIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmTipCenovnika frmTC = new Sifarnici.frmTipCenovnika(Korisnik);
            frmTC.Show();
        }

        private void ceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmCene frmcen = new Sifarnici.frmCene(Korisnik);
            frmcen.Show();
        }

        private void nHMToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void komitentiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sifarnici.frmKomitent komitenti = new Sifarnici.frmKomitent(Korisnik);
            komitenti.Show();
        }

        private void načinDolaskaOdlaskaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmNacinDolaskaOdlaska nac = new Sifarnici.frmNacinDolaskaOdlaska(Korisnik);
            nac.Show();
        }

        private void statusRobeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmStatusRobe snac = new Sifarnici.frmStatusRobe(Korisnik);
            snac.Show();
        }

        private void zaposleniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmZaposleni zap = new Sifarnici.frmZaposleni(Korisnik);
            zap.Show();
        }

        private void vrstaRobeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmVrstaRobe vr = new Sifarnici.frmVrstaRobe(Korisnik);
            vr.Show();
        }

        private void kontejneriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmTipKontejnera tkr = new Sifarnici.frmTipKontejnera(Korisnik);
            tkr.Show();
        }

        private void skladištaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmSkladista sklad = new Sifarnici.frmSkladista(Korisnik);
            sklad.Show();
        }

        private void pozicijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrackModal.Sifarnici.frmPozicija poz = new Sifarnici.frmPozicija(Korisnik);
            poz.Show();
        }

        private void vozilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumeta.frmVozila vozila = new Dokumeta.frmVozila(Korisnik);
            vozila.Show();
        }

        private void vozoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumeta.frmVoz vozovi = new Dokumeta.frmVoz(Korisnik);
            vozovi.Show();
        }

        private void bukingVozaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumeta.frmBukingVoza buking = new Dokumeta.frmBukingVoza(Korisnik);
            buking.Show();
        }

        private void formeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmForme forme = new Sifarnici.frmForme(Korisnik);
            forme.Show();
        }

        private void prijemVozaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumeta.frmPrijemVozomPregled voz = new Dokumeta.frmPrijemVozomPregled(Korisnik);
            voz.Show();
        }

        private void prijemKamionomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumeta.frmPrijemKontejneraKamionom kamion = new Dokumeta.frmPrijemKontejneraKamionom(Korisnik);
            kamion.Show();
        }
 
        private void korisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Korisnik != "M.Jelisavčić" && Korisnik != "Kecman")
            { 
          
            }
            else
            {
                Sifarnici.frmKorisnici kor = new Sifarnici.frmKorisnici(Korisnik);
                kor.Show();
            }
        }

        private void dodeljivanjePravaPristupaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmPravoPristupaFormi ppf = new Sifarnici.frmPravoPristupaFormi(Korisnik);
            ppf.Show();
        }

        private void pristupFormiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rasporedManipulacijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumeta.frmManipulacije man = new Dokumeta.frmManipulacije(Korisnik);
            man.Show();
        }

        private void vrsteManipulacijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void otpremaVozomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumeta.frmPregledOtpreme otprema = new Dokumeta.frmPregledOtpreme(Korisnik);
            otprema.Show();
        }

        private void prijemRasporedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumeta.frmSkladistePrijem spr = new Dokumeta.frmSkladistePrijem(Korisnik);
            spr.Show();
        }

        private void međuskladišniPrenosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Promet.frmMedjuskladisniPrenos mpr = new Promet.frmMedjuskladisniPrenos(Korisnik);
            mpr.Show();
        }

        private void pregledStanjaZalihaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Promet.frmLager lager = new Promet.frmLager(Korisnik);
            lager.Show();
        }

        private void pregledPrometaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Promet.frmPrometKontejnera prometkon = new Promet.frmPrometKontejnera(Korisnik);
            prometkon.Show();
        }

        private void dodatniListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Izvestaji.frmDodatniList dodlist = new Izvestaji.frmDodatniList();
            dodlist.Show();
        }

        private void školskaSpremaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmSkolskaSprema skol = new Sifarnici.frmSkolskaSprema(Korisnik);
            skol.Show();
        }

        private void lekarskiPreglediToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmLekarskiPregledi lek = new Sifarnici.frmLekarskiPregledi(Korisnik);
            lek.Show();
        }

        private void organizacioneJediniceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmOrganizacionaJedinica orgJed = new Sifarnici.frmOrganizacionaJedinica(Korisnik);
            orgJed.Show();
        }

        private void licenceISertifikatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmLicenceISertifikati lic = new Sifarnici.frmLicenceISertifikati(Korisnik);
            lic.Show();
        }

        private void opremaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmZastitnaOdeca zast = new Sifarnici.frmZastitnaOdeca(Korisnik);
            zast.Show();
        }

        private void stručniIspitiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmStrucniIspiti sisp = new Sifarnici.frmStrucniIspiti(Korisnik);
            sisp.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Dokumeta.frmPrijemKontejneraKamionPregled prkamion = new Dokumeta.frmPrijemKontejneraKamionPregled(Korisnik);
            prkamion.Show();
        }

        private void staniceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmStanice stanice = new Sifarnici.frmStanice(Korisnik);
            stanice.Show();
        }

        private void vrsteManipulacijeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sifarnici.frmVrstaManipulacije frmvrman = new Sifarnici.frmVrstaManipulacije(Korisnik);
            frmvrman.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Dokumeta.frmPregledVozova pvoz = new Dokumeta.frmPregledVozova(Korisnik);
            pvoz.Show();
        }

        private void otpremaKontejneraKamionomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumeta.frmPregledOtpremeKamionom pkam = new Dokumeta.frmPregledOtpremeKamionom(Korisnik);
            pkam.Show();
        }

        private void pregledManipulacijaPoPrevozuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dokumeta.frmPregledNarucenihManipulacija pnman = new Dokumeta.frmPregledNarucenihManipulacija(Korisnik);
            pnman.Show();
        }

        private void pregledPrijemaRasporedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Promet.frmPregledSkladistePrijem ppr = new Promet.frmPregledSkladistePrijem(Korisnik);
            ppr.Show();
        }

        private void pregledMeđuskladišniPoPrijemuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Promet.frmPregledMedjuskladisniPrenos pprmp = new Promet.frmPregledMedjuskladisniPrenos(Korisnik);
            pprmp.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                string Putanja = @"\\192.168.100.2\mta\HELP\Korisničko upustvo- šifarnici.pdf";
                string configvalue1 = ConfigurationManager.AppSettings["ip"];
                string configvalue2 = ConfigurationManager.AppSettings["server"];
                configvalue2 = "192.168.100.2";
                Putanja = Putanja.Replace(configvalue1, configvalue2);
                System.Diagnostics.Process.Start(Putanja);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void prevozToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string Putanja = @"\\192.168.100.2\mta\HELP\Korisničko upustvo- prevoz.pdf";
                string configvalue1 = ConfigurationManager.AppSettings["ip"];
                string configvalue2 = ConfigurationManager.AppSettings["server"];
                configvalue2 = "192.168.100.2";
                Putanja = Putanja.Replace(configvalue1, configvalue2);
                System.Diagnostics.Process.Start(Putanja);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void skladištaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Sifarnici.frmSkladista sklad = new Sifarnici.frmSkladista(Korisnik);
            sklad.Show();
        }

        private void pozicijeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Sifarnici.frmPozicija poz = new Sifarnici.frmPozicija(Korisnik);
            poz.Show();
        }

        private void popisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Promet.frmPopis popis = new Promet.frmPopis(Korisnik);
            popis.Show();
        }

        private void manipulacijeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string Putanja = @"\\192.168.100.2\mta\HELP\Korisničko upustvo - manipulacije.pdf";
                string configvalue1 = ConfigurationManager.AppSettings["ip"];
                string configvalue2 = ConfigurationManager.AppSettings["server"];
                configvalue2 = "192.168.100.2";
                Putanja = Putanja.Replace(configvalue1, configvalue2);
                System.Diagnostics.Process.Start(Putanja);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Sifarnici.frmDelovi snac = new Sifarnici.frmDelovi(Korisnik);
            snac.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Sifarnici.frmGreske greske = new Sifarnici.frmGreske(Korisnik);
            greske.Show();
        }

        private void skladišnoPoslovanjeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string Putanja = @"\\192.168.100.2\mta\HELP\Korisničko upustvo - Skladišno poslovanje.pdf";
                string configvalue1 = ConfigurationManager.AppSettings["ip"];
                string configvalue2 = ConfigurationManager.AppSettings["server"];
                configvalue2 = "192.168.100.2";
                Putanja = Putanja.Replace(configvalue1, configvalue2);
                System.Diagnostics.Process.Start(Putanja);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void pregledNaloziZaPrevozToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPregledNaloziZaPrevoz preg = new frmPregledNaloziZaPrevoz();
            preg.Show();
        }

        private void pregledPutniNaloziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPutniNalog put = new frmPutniNalog(Korisnik);
            put.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            frmPregledNaloziZaPrevoz preg = new frmPregledNaloziZaPrevoz(Korisnik);
            preg.Show();
        }

        private void merskPregledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMersk mersk = new frmMersk();
            mersk.Show();
        }

        private void cMACGAPregledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCMACGA cma= new frmCMACGA();
            cma.Show();
        }

        private void pregledManipulacijaPoPartneruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPregledManipulacijaPoPartneru mpp = new frmPregledManipulacijaPoPartneru();
            mpp.Show();
        }

        private void izveštajiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string Putanja = @"\\192.168.100.2\mta\HELP\Korisničko upustvo – Izvestaji.pdf";
                string configvalue1 = ConfigurationManager.AppSettings["ip"];
                string configvalue2 = ConfigurationManager.AppSettings["server"];
                configvalue2 = "192.168.100.2";
                Putanja = Putanja.Replace(configvalue1, configvalue2);
                System.Diagnostics.Process.Start(Putanja);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cOSCOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCosco cosco = new frmCosco();
            cosco.Show();
        }

        private void pregledCIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCIRPregled frmCIRPregled = new frmCIRPregled();
            frmCIRPregled.Show();
        }

        private void menadžerVozoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenadadzerPoVozu mpv = new frmMenadadzerPoVozu();
            mpv.Show();
        }

        private void menadžerKamioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenadzerPoKamionima mpk = new frmMenadzerPoKamionima();
            mpk.Show();
        }

        private void menadžerSaManipulacijamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManipulacijeGrupno fmpm = new frmManipulacijeGrupno();
            fmpm.Show();
        }

        private void metadžerPretovarenoPoOrganizatoruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenadzerPretovar mpret = new frmMenadzerPretovar();
            mpret.Show();
        }

        private void otpremaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Promet.frmSkladisteOtprema sklOtp = new Promet.frmSkladisteOtprema(Korisnik);
            sklOtp.Show();
        }

        private void punoPraznoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenadzerPunoPrazno ppm = new frmMenadzerPunoPrazno();
            ppm.Show();
        }

        private void pregledPopisnihListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Promet.frmPopisPregled pl = new Promet.frmPopisPregled();
            pl.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            frmPutniNalog pn = new frmPutniNalog();
            pn.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            frmRadniNalogTransport rnt = new frmRadniNalogTransport();
            rnt.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            frmNalogZaPrevoz nzp = new frmNalogZaPrevoz(Korisnik);
            nzp.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            frmPregledPutnihNaloga ppn = new frmPregledPutnihNaloga();
            ppn.Show();
        }

        private void menadžerKamioniPoŠpediteruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenadzerPoKamionuSpediter pmpkm = new frmMenadzerPoKamionuSpediter();
            pmpkm.Show();
        }

        private void autoprevozničkiListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAutoprevozniList2 apl = new frmAutoprevozniList2();
            apl.Show();
        }

        private void pregledRadniNaloziTransportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPregledRadniNaloziTransport prnt = new frmPregledRadniNaloziTransport();
            prnt.Show();
        }

        private void pregledAutoprevoznihListovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPregledAutoPrevozniList pautp = new frmPregledAutoPrevozniList();
            pautp.Show();
        }

        private void tovarniListToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void kvaroviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSelectTransport6 kvarovi = new frmSelectTransport6();
            kvarovi.Show();
        }

        private void vozačiPoRutama5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSelectTransport5 trans = new frmSelectTransport5();
            trans.Show();
        }

        private void vozilaPoPN4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSelectTransport4 trans4 = new frmSelectTransport4();
            trans4.Show();
        }

        private void turePoRelaciji3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSelectTransport3 trans3 = new frmSelectTransport3();
            trans3.Show();
        }

        private void poTipuKontejnera2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSelectTransport2 trans2 = new frmSelectTransport2();
            trans2.Show();
        }

        private void kameniAgregat1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSelectTransport1 trans1 = new frmSelectTransport1();
            trans1.Show();
        }

        private void pregledTovarnihListovaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tovarniListoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTovarniList tovl = new frmTovarniList();
            tovl.Show();
        }

        private void pregledTovarniListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPregledTovarnihListova ptl = new frmPregledTovarnihListova();
            ptl.Show();
        }

        private void transportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string Putanja = @"\\192.168.100.2\mta\HELP\KorisnickoUpustvoTransport.pdf";
                string configvalue1 = ConfigurationManager.AppSettings["ip"];
                string configvalue2 = ConfigurationManager.AppSettings["server"];
                configvalue2 = "192.168.100.2";
                Putanja = Putanja.Replace(configvalue1, configvalue2);
                System.Diagnostics.Process.Start(Putanja);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void pregledStanjaZalihaMagacionerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Promet.frmLagerOperater lager = new Promet.frmLagerOperater();
            lager.Show();
        }

        private void predefinisanePorukeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifarnici.frmPredefinisanePoruke predefinisane = new Sifarnici.frmPredefinisanePoruke();
            predefinisane.Show();
        }

        private void fakturisanjeManipulacijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Izvestaji.frmFakturisanjeMan fakman = new Izvestaji.frmFakturisanjeMan();
            fakman.Show();
        }

        private void zadržavanjeKotejneraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Izvestaji.frmZadrzavanjeKotejnera zadkont = new Izvestaji.frmZadrzavanjeKotejnera();
            zadkont.Show();
        }

        private void zadržavanjeKotejneraPunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Izvestaji.frmZadrzavanjeKotejneraPun zadkonpun = new Izvestaji.frmZadrzavanjeKotejneraPun();
            zadkonpun.Show();
        }
    }
}
