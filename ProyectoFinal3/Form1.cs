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

namespace ProyectoFinal3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private async Task MainAsync()
        {
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
    }
}
