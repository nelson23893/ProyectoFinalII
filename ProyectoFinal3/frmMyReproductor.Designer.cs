namespace ProyectoFinal3
{
    partial class frmMyReproductor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMyReproductor));
            this.button1 = new System.Windows.Forms.Button();
            this.picturebPortada = new System.Windows.Forms.PictureBox();
            this.btnAlto = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.MyRepro = new AxWMPLib.AxWindowsMediaPlayer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.picturebPortada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyRepro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(331, 450);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 29);
            this.button1.TabIndex = 23;
            this.button1.Text = "II";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // picturebPortada
            // 
            this.picturebPortada.Location = new System.Drawing.Point(516, 429);
            this.picturebPortada.Name = "picturebPortada";
            this.picturebPortada.Size = new System.Drawing.Size(130, 98);
            this.picturebPortada.TabIndex = 22;
            this.picturebPortada.TabStop = false;
            // 
            // btnAlto
            // 
            this.btnAlto.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlto.Location = new System.Drawing.Point(434, 450);
            this.btnAlto.Name = "btnAlto";
            this.btnAlto.Size = new System.Drawing.Size(76, 29);
            this.btnAlto.TabIndex = 21;
            this.btnAlto.Text = "◙ ";
            this.btnAlto.UseVisualStyleBackColor = true;
            this.btnAlto.Click += new System.EventHandler(this.btnAlto_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.Location = new System.Drawing.Point(228, 450);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(76, 29);
            this.btnSiguiente.TabIndex = 20;
            this.btnSiguiente.Text = "» » ";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Location = new System.Drawing.Point(14, 450);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(76, 29);
            this.btnAtras.TabIndex = 19;
            this.btnAtras.Text = "««";
            this.btnAtras.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.Location = new System.Drawing.Point(109, 450);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(76, 29);
            this.btnPlay.TabIndex = 18;
            this.btnPlay.Text = "►";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // MyRepro
            // 
            this.MyRepro.Enabled = true;
            this.MyRepro.Location = new System.Drawing.Point(652, 429);
            this.MyRepro.Name = "MyRepro";
            this.MyRepro.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MyRepro.OcxState")));
            this.MyRepro.Size = new System.Drawing.Size(115, 153);
            this.MyRepro.TabIndex = 17;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(755, 387);
            this.dataGridView1.TabIndex = 24;
            // 
            // frmMyReproductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 592);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picturebPortada);
            this.Controls.Add(this.btnAlto);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.MyRepro);
            this.Name = "frmMyReproductor";
            this.Text = "frmMyReproductor";
            this.Load += new System.EventHandler(this.frmMyReproductor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picturebPortada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyRepro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picturebPortada;
        private System.Windows.Forms.Button btnAlto;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnPlay;
        private AxWMPLib.AxWindowsMediaPlayer MyRepro;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}