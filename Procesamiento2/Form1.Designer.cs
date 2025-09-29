namespace Procesamiento2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pctLienzo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rojoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verdeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem azulToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rojosincanalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escalaDeGrisesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BlancoYNegroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negativoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagenOriginalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mosaicoToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1; // brillo
        private System.Windows.Forms.TrackBar trackBar2; // ruido
        private System.Windows.Forms.TextBox textBox1;   // tamaño mosaico
        private System.Windows.Forms.SaveFileDialog sfdGuardar;

        private void InitializeComponent()
        {
            pctLienzo = new PictureBox();
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            abrirToolStripMenuItem = new ToolStripMenuItem();
            guardarToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            filtrosToolStripMenuItem = new ToolStripMenuItem();
            rojoToolStripMenuItem = new ToolStripMenuItem();
            verdeToolStripMenuItem = new ToolStripMenuItem();
            azulToolStripMenuItem = new ToolStripMenuItem();
            rojosincanalesToolStripMenuItem = new ToolStripMenuItem();
            cianToolStripMenuItem = new ToolStripMenuItem();
            magentaToolStripMenuItem = new ToolStripMenuItem();
            escalaDeGrisesToolStripMenuItem = new ToolStripMenuItem();
            BlancoYNegroToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            negativoToolStripMenuItem = new ToolStripMenuItem();
            imagenOriginalToolStripMenuItem = new ToolStripMenuItem();
            mosaicoToolStripMenuItem = new ToolStripMenuItem();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            textBox1 = new TextBox();
            sfdGuardar = new SaveFileDialog();
            frangasToolStripMenuItem = new ToolStripMenuItem();
            diagonalToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pctLienzo).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // pctLienzo
            // 
            pctLienzo.BackColor = SystemColors.ActiveCaptionText;
            pctLienzo.Location = new Point(12, 40);
            pctLienzo.Name = "pctLienzo";
            pctLienzo.Size = new Size(800, 500);
            pctLienzo.TabIndex = 0;
            pctLienzo.TabStop = false;
            pctLienzo.Paint += pctLienzo_Paint;
            pctLienzo.MouseDown += pctLienzo_MouseDown;
            pctLienzo.MouseMove += pctLienzo_MouseMove;
            pctLienzo.MouseUp += pctLienzo_MouseUp;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, filtrosToolStripMenuItem, imagenOriginalToolStripMenuItem, mosaicoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1024, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { abrirToolStripMenuItem, guardarToolStripMenuItem, salirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(73, 24);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            abrirToolStripMenuItem.Size = new Size(145, 26);
            abrirToolStripMenuItem.Text = "Abrir";
            abrirToolStripMenuItem.Click += abrir_Click;
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
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // filtrosToolStripMenuItem
            // 
            filtrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rojoToolStripMenuItem, verdeToolStripMenuItem, azulToolStripMenuItem, rojosincanalesToolStripMenuItem, cianToolStripMenuItem, magentaToolStripMenuItem, escalaDeGrisesToolStripMenuItem, BlancoYNegroToolStripMenuItem, sepiaToolStripMenuItem, negativoToolStripMenuItem, frangasToolStripMenuItem, diagonalToolStripMenuItem });
            filtrosToolStripMenuItem.Name = "filtrosToolStripMenuItem";
            filtrosToolStripMenuItem.Size = new Size(63, 24);
            filtrosToolStripMenuItem.Text = "Filtros";
            filtrosToolStripMenuItem.Click += ejercicio2FranjasToolStripMenuItem_Click;
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
            rojosincanalesToolStripMenuItem.Text = "Rojo Sin Canales";
            rojosincanalesToolStripMenuItem.Click += rojosincanalesToolStripMenuItem_Click;
            // 
            // cianToolStripMenuItem
            // 
            cianToolStripMenuItem.Name = "cianToolStripMenuItem";
            cianToolStripMenuItem.Size = new Size(224, 26);
            cianToolStripMenuItem.Text = "Cian";
            cianToolStripMenuItem.Click += cianToolStripMenuItem_Click;
            // 
            // magentaToolStripMenuItem
            // 
            magentaToolStripMenuItem.Name = "magentaToolStripMenuItem";
            magentaToolStripMenuItem.Size = new Size(224, 26);
            magentaToolStripMenuItem.Text = "Magenta";
            magentaToolStripMenuItem.Click += magentaToolStripMenuItem_Click;
            // 
            // escalaDeGrisesToolStripMenuItem
            // 
            escalaDeGrisesToolStripMenuItem.Name = "escalaDeGrisesToolStripMenuItem";
            escalaDeGrisesToolStripMenuItem.Size = new Size(224, 26);
            escalaDeGrisesToolStripMenuItem.Text = "Escala de grises";
            escalaDeGrisesToolStripMenuItem.Click += escalaDeGrisesToolStripMenuItem_Click;
            // 
            // BlancoYNegroToolStripMenuItem
            // 
            BlancoYNegroToolStripMenuItem.Name = "BlancoYNegroToolStripMenuItem";
            BlancoYNegroToolStripMenuItem.Size = new Size(224, 26);
            BlancoYNegroToolStripMenuItem.Text = "Blanco y Negro";
            BlancoYNegroToolStripMenuItem.Click += BlancoYNegroToolStripMenuItem_Click;
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
            // imagenOriginalToolStripMenuItem
            // 
            imagenOriginalToolStripMenuItem.Name = "imagenOriginalToolStripMenuItem";
            imagenOriginalToolStripMenuItem.Size = new Size(126, 24);
            imagenOriginalToolStripMenuItem.Text = "ImagenOriginal";
            imagenOriginalToolStripMenuItem.Click += imagenOriginalToolStripMenuItem_Click;
            // 
            // mosaicoToolStripMenuItem
            // 
            mosaicoToolStripMenuItem.Name = "mosaicoToolStripMenuItem";
            mosaicoToolStripMenuItem.Size = new Size(79, 24);
            mosaicoToolStripMenuItem.Text = "Mosaico";
            mosaicoToolStripMenuItem.Click += mosaicoToolStripMenuItem_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(830, 40);
            trackBar1.Maximum = 255;
            trackBar1.Minimum = -255;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(182, 56);
            trackBar1.TabIndex = 2;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(830, 98);
            trackBar2.Maximum = 100;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(182, 56);
            trackBar2.TabIndex = 1;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(830, 160);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(50, 27);
            textBox1.TabIndex = 0;
            textBox1.Text = "10";
            // 
            // frangasToolStripMenuItem
            // 
            frangasToolStripMenuItem.Name = "frangasToolStripMenuItem";
            frangasToolStripMenuItem.Size = new Size(224, 26);
            frangasToolStripMenuItem.Text = "Frangas";
            // 
            // diagonalToolStripMenuItem
            // 
            diagonalToolStripMenuItem.Name = "diagonalToolStripMenuItem";
            diagonalToolStripMenuItem.Size = new Size(224, 26);
            diagonalToolStripMenuItem.Text = "Diagonal";
            diagonalToolStripMenuItem.Click += ejercicio3DiagonalToolStripMenuItem_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1024, 600);
            Controls.Add(textBox1);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(pctLienzo);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Procesamiento de Imagen";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pctLienzo).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private ToolStripMenuItem frangasToolStripMenuItem;
        private ToolStripMenuItem diagonalToolStripMenuItem;
    }
}
