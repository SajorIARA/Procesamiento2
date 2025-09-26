namespace Procesamiento2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pctLienzo = new PictureBox();
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            abrir = new ToolStripMenuItem();
            guardarToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            imagenOriginalToolStripMenuItem = new ToolStripMenuItem();
            filtrosToolStripMenuItem = new ToolStripMenuItem();
            rojoToolStripMenuItem = new ToolStripMenuItem();
            verdeToolStripMenuItem = new ToolStripMenuItem();
            azulToolStripMenuItem = new ToolStripMenuItem();
            rojosincanalesToolStripMenuItem = new ToolStripMenuItem();
            escalaDeGrisesToolStripMenuItem = new ToolStripMenuItem();
            imgenBlancoYNegroToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            negativoToolStripMenuItem = new ToolStripMenuItem();
            cianToolStripMenuItem = new ToolStripMenuItem();
            magentaToolStripMenuItem = new ToolStripMenuItem();
            ejercicio3ToolStripMenuItem = new ToolStripMenuItem();
            ofdAbrir = new OpenFileDialog();
            SFile = new SaveFileDialog();
            sfdGuardar = new SaveFileDialog();
            ejercicio3ToolStripMenuItem1 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pctLienzo).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pctLienzo
            // 
            pctLienzo.BackColor = SystemColors.ActiveCaptionText;
            pctLienzo.Location = new Point(24, 68);
            pctLienzo.Margin = new Padding(3, 4, 3, 4);
            pctLienzo.Name = "pctLienzo";
            pctLienzo.Size = new Size(685, 341);
            pctLienzo.SizeMode = PictureBoxSizeMode.StretchImage;
            pctLienzo.TabIndex = 0;
            pctLienzo.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, imagenOriginalToolStripMenuItem, filtrosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(914, 30);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { abrir, guardarToolStripMenuItem, salirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(73, 24);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrir
            // 
            abrir.Name = "abrir";
            abrir.Size = new Size(145, 26);
            abrir.Text = "Abrir";
            abrir.Click += abrir_Click;
            // 
            // guardarToolStripMenuItem
            // 
            guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            guardarToolStripMenuItem.Size = new Size(145, 26);
            guardarToolStripMenuItem.Text = "Guardar";
            guardarToolStripMenuItem.Click += guardarToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(145, 26);
            salirToolStripMenuItem.Text = "Salir";
            // 
            // imagenOriginalToolStripMenuItem
            // 
            imagenOriginalToolStripMenuItem.Name = "imagenOriginalToolStripMenuItem";
            imagenOriginalToolStripMenuItem.Size = new Size(130, 24);
            imagenOriginalToolStripMenuItem.Text = "Imagen Original";
            imagenOriginalToolStripMenuItem.Click += imagenOriginalToolStripMenuItem_Click;
            // 
            // filtrosToolStripMenuItem
            // 
            filtrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rojoToolStripMenuItem, verdeToolStripMenuItem, azulToolStripMenuItem, rojosincanalesToolStripMenuItem, escalaDeGrisesToolStripMenuItem, imgenBlancoYNegroToolStripMenuItem, sepiaToolStripMenuItem, negativoToolStripMenuItem, cianToolStripMenuItem, magentaToolStripMenuItem, ejercicio3ToolStripMenuItem, ejercicio3ToolStripMenuItem1 });
            filtrosToolStripMenuItem.Name = "filtrosToolStripMenuItem";
            filtrosToolStripMenuItem.Size = new Size(63, 24);
            filtrosToolStripMenuItem.Text = "Filtros";
            // 
            // rojoToolStripMenuItem
            // 
            rojoToolStripMenuItem.Name = "rojoToolStripMenuItem";
            rojoToolStripMenuItem.Size = new Size(224, 26);
            rojoToolStripMenuItem.Text = "Rojo";
            rojoToolStripMenuItem.Click += rojoToolStripMenuItem_Click;
            // 
            // verdeToolStripMenuItem
            // 
            verdeToolStripMenuItem.Name = "verdeToolStripMenuItem";
            verdeToolStripMenuItem.Size = new Size(224, 26);
            verdeToolStripMenuItem.Text = "Verde";
            verdeToolStripMenuItem.Click += verdeToolStripMenuItem_Click;
            // 
            // azulToolStripMenuItem
            // 
            azulToolStripMenuItem.Name = "azulToolStripMenuItem";
            azulToolStripMenuItem.Size = new Size(224, 26);
            azulToolStripMenuItem.Text = "Azul";
            azulToolStripMenuItem.Click += azulToolStripMenuItem_Click;
            // 
            // rojosincanalesToolStripMenuItem
            // 
            rojosincanalesToolStripMenuItem.Name = "rojosincanalesToolStripMenuItem";
            rojosincanalesToolStripMenuItem.Size = new Size(224, 26);
            rojosincanalesToolStripMenuItem.Text = "Rojo_sin_canales";
            rojosincanalesToolStripMenuItem.Click += rojosincanalesToolStripMenuItem_Click;
            // 
            // escalaDeGrisesToolStripMenuItem
            // 
            escalaDeGrisesToolStripMenuItem.Name = "escalaDeGrisesToolStripMenuItem";
            escalaDeGrisesToolStripMenuItem.Size = new Size(224, 26);
            escalaDeGrisesToolStripMenuItem.Text = "Escala de grises";
            escalaDeGrisesToolStripMenuItem.Click += escalaDeGrisesToolStripMenuItem_Click;
            // 
            // imgenBlancoYNegroToolStripMenuItem
            // 
            imgenBlancoYNegroToolStripMenuItem.Name = "imgenBlancoYNegroToolStripMenuItem";
            imgenBlancoYNegroToolStripMenuItem.Size = new Size(224, 26);
            imgenBlancoYNegroToolStripMenuItem.Text = "Blanco y Negro";
            imgenBlancoYNegroToolStripMenuItem.Click += BlancoYNegroToolStripMenuItem_Click;
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(224, 26);
            sepiaToolStripMenuItem.Text = "Sepia";
            sepiaToolStripMenuItem.Click += sepiaToolStripMenuItem_Click;
            // 
            // negativoToolStripMenuItem
            // 
            negativoToolStripMenuItem.Name = "negativoToolStripMenuItem";
            negativoToolStripMenuItem.Size = new Size(224, 26);
            negativoToolStripMenuItem.Text = "Negativo";
            negativoToolStripMenuItem.Click += negativoToolStripMenuItem_Click;
            // 
            // cianToolStripMenuItem
            // 
            cianToolStripMenuItem.Name = "cianToolStripMenuItem";
            cianToolStripMenuItem.Size = new Size(224, 26);
            cianToolStripMenuItem.Text = "Cian ";
            cianToolStripMenuItem.Click += cianToolStripMenuItem_Click;
            // 
            // magentaToolStripMenuItem
            // 
            magentaToolStripMenuItem.Name = "magentaToolStripMenuItem";
            magentaToolStripMenuItem.Size = new Size(224, 26);
            magentaToolStripMenuItem.Text = "Magenta";
            magentaToolStripMenuItem.Click += magentaToolStripMenuItem_Click;
            // 
            // ejercicio3ToolStripMenuItem
            // 
            ejercicio3ToolStripMenuItem.Name = "ejercicio3ToolStripMenuItem";
            ejercicio3ToolStripMenuItem.Size = new Size(224, 26);
            ejercicio3ToolStripMenuItem.Text = "ejercicio 2";
            ejercicio3ToolStripMenuItem.Click += ejercicio3ToolStripMenuItem_Click;
            // 
            // ofdAbrir
            // 
            ofdAbrir.FileName = "ofdAbrir";
            ofdAbrir.FileOk += ofdAbrir_FileOk;
            // 
            // SFile
            // 
            SFile.FileName = "SFile";
            // 
            // ejercicio3ToolStripMenuItem1
            // 
            ejercicio3ToolStripMenuItem1.Name = "ejercicio3ToolStripMenuItem1";
            ejercicio3ToolStripMenuItem1.Size = new Size(224, 26);
            ejercicio3ToolStripMenuItem1.Text = "ejercicio 3";
            ejercicio3ToolStripMenuItem1.Click += ejercicio3ToolStripMenuItem1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(pctLienzo);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pctLienzo).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pctLienzo;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem abrir;
        private ToolStripMenuItem guardarToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem imagenOriginalToolStripMenuItem;
        private ToolStripMenuItem filtrosToolStripMenuItem;
        private OpenFileDialog ofdAbrir;
        private SaveFileDialog SFile;
        private SaveFileDialog sfdGuardar;
        private ToolStripMenuItem rojoToolStripMenuItem;
        private ToolStripMenuItem verdeToolStripMenuItem;
        private ToolStripMenuItem azulToolStripMenuItem;
        private ToolStripMenuItem rojosincanalesToolStripMenuItem;
        private ToolStripMenuItem escalaDeGrisesToolStripMenuItem;
        private ToolStripMenuItem imgenBlancoYNegroToolStripMenuItem;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private ToolStripMenuItem negativoToolStripMenuItem;
        private ToolStripMenuItem cianToolStripMenuItem;
        private ToolStripMenuItem magentaToolStripMenuItem;
        private ToolStripMenuItem ejercicio3ToolStripMenuItem;
        private ToolStripMenuItem ejercicio3ToolStripMenuItem1;
    }
}
