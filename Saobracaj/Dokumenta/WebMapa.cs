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
    public partial class WebMapa : Form
    {
        public WebMapa()
        {
            InitializeComponent();
        }

        private void WebMapa_Load(object sender, EventArgs e)
        {
            Mapa.Navigate("http://87.106.181.103/sr/track");
            Mapa.ScriptErrorsSuppressed = true;
        }
    }
}
