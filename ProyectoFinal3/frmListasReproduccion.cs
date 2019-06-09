using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal3
{
    public partial class frmListasReproduccion : Form
    {
        bool pausa = false;
     
        List<clsBiblioteca> ListBiblioteca = new List<clsBiblioteca>();
        List<clsBiblioteca> ListaRep = new List<clsBiblioteca>();
        List<clsMyLista> Playlist = new List<clsMyLista>();
        List<clsBiblioteca> ListaActual = new List<clsBiblioteca>();
        public frmListasReproduccion()
        {
            InitializeComponent();
        }

        private void frmListasReproduccion_Load(object sender, EventArgs e)
        {
            leerBiblioteca();
            //comboBox1.DisplayMember = "Nombre1";
            //comboBox1.ValueMember = "Direccion1";
            //comboBox1.DataSource = Playlist;
            //comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
        }

        private void leerBiblioteca()
        {
            FileStream stream = new FileStream("Biblioteca.json", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                string lectura = reader.ReadLine();
                clsBiblioteca libroLeido = JsonConvert.DeserializeObject<clsBiblioteca>(lectura);
                ListBiblioteca.Add(libroLeido);
            }
            reader.Close();
            dataGridView1.DataSource = ListBiblioteca;
            dataGridView1.Refresh();
        }

        string NamePlayList;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsMyLista objLista = new clsMyLista();
            objLista.Cancion = txtNombreLista.Text;
            objLista.Url = NamePlayList;
            SaveMyPlayList(objLista);
            Playlist.Add(objLista);
            dataGridView2.DataSource = null;
            txtNombreLista.Text = "";
        }
        private void SaveMyPlayList(clsMyLista biblioteca)
        {
            string salida = JsonConvert.SerializeObject(biblioteca);
            FileStream stream = new FileStream("Listas.json", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(salida);
            writer.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            clsBiblioteca cancion = new clsBiblioteca();
            cancion.Id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cancion.Cancion = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cancion.Url = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cancion.Portada = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cancion.Letra = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            ListaRep.Add(cancion);
            SaveMyPlayLists(cancion);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = ListaRep;
            dataGridView2.Refresh();
        }

        private void SaveMyPlayLists(clsBiblioteca biblioteca)
        {

            if (txtNombreLista.Text == "")
            {
                MessageBox.Show("Ingresar nombre");
            }
            else
            {
                NamePlayList = "C:\\Users\\Ramirez\\Documents\\Visual Studio 2015\\Projects\\ProyectoFinal3\\ProyectoFinal3\\lyries\\" + txtNombreLista.Text + ".json";
                string salida = JsonConvert.SerializeObject(biblioteca);
                FileStream stream = new FileStream(NamePlayList, FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(salida);
                writer.Close();
            }

        }
    }

    
}
