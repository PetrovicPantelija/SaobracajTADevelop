using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testiranje.Promet
{
    public partial class frmPopisUporedniPrikaz : Form
    {
        public frmPopisUporedniPrikaz()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertPopis ins = new InsertPopis();
            ins.InsertPopisStavkeUporedni(Convert.ToInt32(txtSifra.Text));
        }
    }
}
