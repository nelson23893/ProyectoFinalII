using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace ProyectoFinal3
{
    public partial class frmMyReproductor : Form
    {
        List<clsBiblioteca> listBiblioteca = new List<clsBiblioteca>();
        string urlAudio;
        public frmMyReproductor()
        {
            
            InitializeComponent();
        }
        private void GuardarBiblioteca(clsBiblioteca objBiblioteca)
        {
            string salida = JsonConvert.SerializeObject(objBiblioteca);
            FileStream stream = new FileStream("Biblioteca.json", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(salida);
            writer.Close();
        }
        private void leerBiblioteca()
        {
            FileStream stream = new FileStream("Biblioteca.json", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                string lectura = reader.ReadLine();
                clsBiblioteca libroLeido = JsonConvert.DeserializeObject<clsBiblioteca>(lectura);
                listBiblioteca.Add(libroLeido);
            }
            reader.Close();
            dataGridView1.DataSource = listBiblioteca;
            dataGridView1.Refresh();
            //Libro lib = Agregar.OrderBy(al => al.Anio1).First();
            //textBox5.Text = lib.Anio1.ToString();
        }
        private void frmMyReproductor_Load(object sender, EventArgs e)
        {
            MyRepro.uiMode = "invisible";
            leerBiblioteca();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            double time = MyRepro.Ctlcontrols.currentPosition; //return always 0 for you, because you pause first and after get the value
            MyRepro.Ctlcontrols.pause();
            if (time > 0)
            {
                MyRepro.Ctlcontrols.currentPosition = time;
                MyRepro.Ctlcontrols.play();
            }
            else
            {
                string ruta = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                MyRepro.URL = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                urlAudio = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                MyRepro.Ctlcontrols.play();
                Image f = Image.FromFile(ruta);
                picturebPortada.Image = f;
            }
        }

        private void btnAlto_Click(object sender, EventArgs e)
        {
            MyRepro.Ctlcontrols.stop();
        }
    }
}
