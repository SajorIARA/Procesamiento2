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
            ofdAbrir = new OpenFileDialog();
            SFile = new SaveFileDialog();
            sfdGuardar = new SaveFileDialog();
            rojosincanalesToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pctLienzo).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pctLienzo
            // 
            pctLienzo.BackColor = SystemColors.ActiveCaptionText;
            pctLienzo.Location = new Point(21, 51);
            pctLienzo.Name = "pctLienzo";
            pctLienzo.Size = new Size(400, 200);
            pctLienzo.SizeMode = PictureBoxSizeMode.StretchImage;
            pctLienzo.TabIndex = 0;
            pctLienzo.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, imagenOriginalToolStripMenuItem, filtrosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { abrir, guardarToolStripMenuItem, salirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrir
            // 
            abrir.Name = "abrir";
            abrir.Size = new Size(116, 22);
            abrir.Text = "Abrir";
            abrir.Click += abrir_Click;
            // 
            // guardarToolStripMenuItem
            // 
            guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            guardarToolStripMenuItem.Size = new Size(116, 22);
            guardarToolStripMenuItem.Text = "Guardar";
            guardarToolStripMenuItem.Click += guardarToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(116, 22);
            salirToolStripMenuItem.Text = "Salir";
            // 
            // imagenOriginalToolStripMenuItem
            // 
            imagenOriginalToolStripMenuItem.Name = "imagenOriginalToolStripMenuItem";
            imagenOriginalToolStripMenuItem.Size = new Size(104, 20);
            imagenOriginalToolStripMenuItem.Text = "Imagen Original";
            imagenOriginalToolStripMenuItem.Click += imagenOriginalToolStripMenuItem_Click;
            // 
            // filtrosToolStripMenuItem
            // 
            filtrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rojoToolStripMenuItem, verdeToolStripMenuItem, azulToolStripMenuItem, rojosincanalesToolStripMenuItem });
            filtrosToolStripMenuItem.Name = "filtrosToolStripMenuItem";
            filtrosToolStripMenuItem.Size = new Size(51, 20);
            filtrosToolStripMenuItem.Text = "Filtros";
            // 
            // rojoToolStripMenuItem
            // 
            rojoToolStripMenuItem.Name = "rojoToolStripMenuItem";
            rojoToolStripMenuItem.Size = new Size(180, 22);
            rojoToolStripMenuItem.Text = "Rojo";
            rojoToolStripMenuItem.Click += rojoToolStripMenuItem_Click;
            // 
            // verdeToolStripMenuItem
            // 
            verdeToolStripMenuItem.Name = "verdeToolStripMenuItem";
            verdeToolStripMenuItem.Size = new Size(180, 22);
            verdeToolStripMenuItem.Text = "Verde";
            verdeToolStripMenuItem.Click += verdeToolStripMenuItem_Click;
            // 
            // azulToolStripMenuItem
            // 
            azulToolStripMenuItem.Name = "azulToolStripMenuItem";
            azulToolStripMenuItem.Size = new Size(180, 22);
            azulToolStripMenuItem.Text = "Azul";
            azulToolStripMenuItem.Click += azulToolStripMenuItem_Click;
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
            // rojosincanalesToolStripMenuItem
            // 
            rojosincanalesToolStripMenuItem.Name = "rojosincanalesToolStripMenuItem";
            rojosincanalesToolStripMenuItem.Size = new Size(180, 22);
            rojosincanalesToolStripMenuItem.Text = "Rojo_sin_canales";
            rojosincanalesToolStripMenuItem.Click += rojosincanalesToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pctLienzo);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
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
    }
}
