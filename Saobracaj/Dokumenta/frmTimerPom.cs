using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saobracaj.Dokumenta
{
    public partial class frmTimerPom : Form
    {
        int StartnaForma = 1;
        frmNajava20 frm1 = new frmNajava20();
        frmNajava20 frm2 = new frmNajava20();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    
        
        public frmTimerPom()
        {
            InitializeComponent();
           
        }

        private void frmTimerPom_Load(object sender, EventArgs e)
        {

            timer.Interval = 10000;
            timer.Tick += new System.EventHandler(OnTimerEvent);
            timer.Start();
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
           // this.Hide();
           // frmNajava20 frmNaj20 = new frmNajava20();
            if (StartnaForma == 1)
            {

                frm1.Show();
                frm2.Hide();
                StartnaForma = 0;
                timer.Stop();
                timer.Start();
            }
            else if (StartnaForma == 0)
            {
                frm2.Show();
                frm1.Hide();
                StartnaForma = 1;
                timer.Stop();
                timer.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
