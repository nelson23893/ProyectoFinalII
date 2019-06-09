namespace ProyectoFinal3
{
    partial class formPrincipal
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
            this.btnDescarga = new System.Windows.Forms.Button();
            this.btnReproductor = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnListasReproduccion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDescarga
            // 
            this.btnDescarga.Location = new System.Drawing.Point(12, 29);
            this.btnDescarga.Name = "btnDescarga";
            this.btnDescarga.Size = new System.Drawing.Size(149, 35);
            this.btnDescarga.TabIndex = 0;
            this.btnDescarga.Text = "Descargar";
            this.btnDescarga.UseVisualStyleBackColor = true;
            this.btnDescarga.Click += new System.EventHandler(this.btnDescarga_Click);
            // 
            // btnReproductor
            // 
            this.btnReproductor.Location = new System.Drawing.Point(12, 84);
            this.btnReproductor.Name = "btnReproductor";
            this.btnReproductor.Size = new System.Drawing.Size(149, 35);
            this.btnReproductor.TabIndex = 1;
            this.btnReproductor.Text = "Reproductor";
            this.btnReproductor.UseVisualStyleBackColor = true;
            this.btnReproductor.Click += new System.EventHandler(this.btnReproductor_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Crear Favoritos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnListasReproduccion
            // 
            this.btnListasReproduccion.Location = new System.Drawing.Point(12, 190);
            this.btnListasReproduccion.Name = "btnListasReproduccion";
            this.btnListasReproduccion.Size = new System.Drawing.Size(149, 35);
            this.btnListasReproduccion.TabIndex = 3;
            this.btnListasReproduccion.Text = "Mis Listas";
            this.btnListasReproduccion.UseVisualStyleBackColor = true;
            this.btnListasReproduccion.Click += new System.EventHandler(this.btnListasReproduccion_Click);
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 249);
            this.Controls.Add(this.btnListasReproduccion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnReproductor);
            this.Controls.Add(this.btnDescarga);
            this.Name = "formPrincipal";
            this.Text = "formPrincipal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDescarga;
        private System.Windows.Forms.Button btnReproductor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnListasReproduccion;
    }
}