using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NReco.VideoConverter;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace ProyectoFinal3
{
    public partial class Form1 : Form
    {
        List<clsBiblioteca> listBiblioteca = new List<clsBiblioteca>();
        public Form1()
        {
            InitializeComponent();
        }
        string urlAudio;

        private async Task MainAsync()
        {

            clsBiblioteca biblioteca = new clsBiblioteca();
            //Nuevo Cliente de YouTube
            var client = new YoutubeClient();
            //Lee la URL de youtube que le escribimos en el textbox.
            var videoId = NormalizeVideoId(txtURL.Text);
            var video = await client.GetVideoAsync(videoId);
            var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(videoId);
            //Busca la mejor resolución en la que está disponible el video.
            var streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();
            //Compone el nombre que tendrá el video en base a su título y extensión.
            var fileExtension = streamInfo.Container.GetFileExtension();
            var fileName = $"{video.Title}.{fileExtension}";
            //TODO: Reemplazar los caractéres ilegales del nombre
            //fileName = RemoveIllegalFileNameChars(fileName);
            //Activa el timer para que el proceso funcione de forma asincrona
            ckbAudio.Enabled = true;
            // mensajes indicando que el video se está descargando
            label4.Text = "Descargando el video...";
            //TODO: se pude usar una barra de progreso para ver el avance
            //using (var progress = new ProgressBar());
            //Empieza la descarga.
            await client.DownloadMediaStreamAsync(streamInfo, fileName);
            //Ya descargado se inicia la conversión a MP3
            var Convert = new NReco.VideoConverter.FFMpegConverter();
            //Especificar la carpeta donde se van a guardar los archivos, recordar la \ del final
            String SaveMP3File = @"C:\Users\Ramirez\Documents\Visual Studio 2015\Projects\ProyectoFinal3\ProyectoFinal3\bin\Debug\Musica\" + fileName.Replace(".mp4", ".mp3");
            biblioteca.Url = SaveMP3File;
            biblioteca.Cancion = fileName;
            //Guarda el archivo convertido en la ubicación indicada
            Convert.ConvertMedia(fileName, SaveMP3File, "mp3");
            //Si el checkbox de solo audio está chequeado, borrar el mp4 despues de la conversión
            if (ckbAudio.Checked)
            {
                File.Delete(fileName);
            }
            //Indicar que se terminó la conversion
            MessageBox.Show("Vídeo convertido correctamente.");
            label4.Text = "";
            txtURL.Text = "";
            ckbAudio.Enabled = false;
            GuardarCancion(biblioteca);
            //TODO: Cargar el MP3 al reproductor o a la lista de reproducción
            //CargarMP3s();
            //Se puede incluir un checkbox para indicar que de una vez se reproduzca el MP3
            //if (ckbAutoPlay.Checked) 
            //  ReproducirMP3(SaveMP3File);
            return;
        }

        private static string NormalizeVideoId(string input)
        {
            string videoId = string.Empty;
            return YoutubeClient.TryParseVideoId(input, out videoId)
                ? videoId
                : input;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            MainAsync();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            reproductor.uiMode = "invisible";
            LeerBiblioteca();
        }
        private void LeerBiblioteca()
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

        private void btnPlay_Click(object sender, EventArgs e)
        {
            double time = reproductor.Ctlcontrols.currentPosition; //return always 0 for you, because you pause first and after get the value
            reproductor.Ctlcontrols.pause();
            if (time > 0)
            {
                reproductor.Ctlcontrols.currentPosition = time;
                reproductor.Ctlcontrols.play();
            }
            else
            {
                string ruta = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                reproductor.URL = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                urlAudio = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                reproductor.Ctlcontrols.play();
                Image f = Image.FromFile(ruta);
                picturebPortada.Image = f;
            }
        }

        private void btnAlto_Click(object sender, EventArgs e)
        {
            reproductor.Ctlcontrols.stop();
        }

        //DLL a utilizar para poder reproducir MP3
        [DllImport("winmm.dll")]

        //Método externo (esta definido en winmm.dll) tipo long que se encargara de enviar comandos al MCI
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);


        //Método para reproducir MP3 a través de MCI
        //Recibe: Nombre y ruta del archivo a reproducir
        public void PlayMP3(string rutaArchivo)
        {
            //Comandos multimedia de MCI http://msdn.microsoft.com/en-us/library/ms712587        

            //Abrir el dispositivo MCI
            //miMP3 es el alias con el que manejaremos el archivo MP3 recibido como parametro en rutaArchivo
            string comandoMCI = string.Format("open \"{0}\" type mpegvideo alias miMP3", rutaArchivo);

            
            //a traves de mciSendString, enviamos el comando anterior, para abrir el dispositivo MCO
            mciSendString(comandoMCI, null, 0, IntPtr.Zero);
            //Ahora en comandoMCI daremos la orden de reproducir el archivo, recordando que lo hacemos
            //a traves del alias que definimos anteriormente miMP3
            comandoMCI = "play miMP3";
            //enviamos a ejecutar el comando play
            mciSendString(comandoMCI, null, 0, IntPtr.Zero);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }




       private void leerBiblioteca()
        {
            List<clsBiblioteca> obj = new List<clsBiblioteca>();
            FileStream stream = new FileStream("biblioteca.json", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                string lectura = reader.ReadLine();
                clsBiblioteca libroLeido = JsonConvert.DeserializeObject<clsBiblioteca>(lectura);
                obj.Add(libroLeido);
            }
            reader.Close();
            //Mostrar la lista de libros en el gridview
            dataGridView1.DataSource = obj;
            dataGridView1.Refresh();

        }

        private void GuardarCancion(clsBiblioteca p)
        {
            string salida = JsonConvert.SerializeObject(p);
            FileStream stream = new FileStream("biblioteca.json", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(salida);
            writer.Close();

            MessageBox.Show("Ingresado");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            reproductor.Ctlcontrols.pause();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                int filaActual = dataGridView1.CurrentRow.Index;
                dataGridView1.CurrentCell = dataGridView1.Rows[filaActual + 1].Cells[0];
                string ruta = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                reproductor.URL = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                reproductor.Ctlcontrols.play();
                Image f = Image.FromFile(ruta);
                picturebPortada.Image = f;
            }
            catch
            {
                MessageBox.Show("No ha mas Canciones");
                DuracionActualTime.Stop();
            }
        }
    }
}
