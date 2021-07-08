using Fluje.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fluje
{
    public partial class PanelPrincipal : Form
    {
        private FNEModel fneModel;
        public PanelPrincipal()
        {
            InitializeComponent();
            fneModel = new FNEModel();
        }

        private void NuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 agregar = new Form1();
            agregar.fneModel = fneModel;
            agregar.MdiParent = this;
            agregar.Show();
        }
    }
}
