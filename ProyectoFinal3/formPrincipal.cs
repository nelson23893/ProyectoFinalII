using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal3
{
    public partial class formPrincipal : Form
    {
        public formPrincipal()
        {
            InitializeComponent();
        }

        private void btnDescarga_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void btnReproductor_Click(object sender, EventArgs e)
        {
            frmMyReproductor frm = new frmMyReproductor();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmListasReproduccion frm = new frmListasReproduccion();
            frm.ShowDialog();
        }

        private void btnListasReproduccion_Click(object sender, EventArgs e)
        {
            
        }
    }
}
