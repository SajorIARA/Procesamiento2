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
            frangasToolStripMenuItem = new ToolStripMenuItem();
            diagonalToolStripMenuItem = new ToolStripMenuItem();
            quitarToolStripMenuItem = new ToolStripMenuItem();
            rojoToolStripMenuItem1 = new ToolStripMenuItem();
            azulToolStripMenuItem1 = new ToolStripMenuItem();
            verdeToolStripMenuItem1 = new ToolStripMenuItem();
            invertirRGBToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            bRGToolStripMenuItem = new ToolStripMenuItem();
            bGRToolStripMenuItem = new ToolStripMenuItem();
            gRBToolStripMenuItem = new ToolStripMenuItem();
            gRBToolStripMenuItem1 = new ToolStripMenuItem();
            imagenOriginalToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            brilloToolStripMenuItem = new ToolStripMenuItem();
            mosaicoToolStripMenuItem1 = new ToolStripMenuItem();
            distorcionToolStripMenuItem = new ToolStripMenuItem();
            mosaicoRectangularToolStripMenuItem = new ToolStripMenuItem();
            distorcionHorizontalToolStripMenuItem = new ToolStripMenuItem();
            espejoToolStripMenuItem = new ToolStripMenuItem();
            histogramaToolStripMenuItem = new ToolStripMenuItem();
            escalaDeGricesToolStripMenuItem = new ToolStripMenuItem();
            rGBToolStripMenuItem = new ToolStripMenuItem();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            textBox1 = new TextBox();
            sfdGuardar = new SaveFileDialog();
            button1 = new Button();
            button2 = new Button();
            trackBar4 = new TrackBar();
            textBoxAncho = new TextBox();
            textBoxAlto = new TextBox();
            ecualizarToolStripMenuItem = new ToolStripMenuItem();
            mejorarImagenToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pctLienzo).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, filtrosToolStripMenuItem, imagenOriginalToolStripMenuItem, toolStripMenuItem3, histogramaToolStripMenuItem, ecualizarToolStripMenuItem });
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
            filtrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rojoToolStripMenuItem, verdeToolStripMenuItem, azulToolStripMenuItem, rojosincanalesToolStripMenuItem, cianToolStripMenuItem, magentaToolStripMenuItem, escalaDeGrisesToolStripMenuItem, BlancoYNegroToolStripMenuItem, sepiaToolStripMenuItem, negativoToolStripMenuItem, frangasToolStripMenuItem, diagonalToolStripMenuItem, quitarToolStripMenuItem, invertirRGBToolStripMenuItem });
            filtrosToolStripMenuItem.Name = "filtrosToolStripMenuItem";
            filtrosToolStripMenuItem.Size = new Size(63, 24);
            filtrosToolStripMenuItem.Text = "Filtros";
            // 
            // rojoToolStripMenuItem
            // 
            rojoToolStripMenuItem.Name = "rojoToolStripMenuItem";
            rojoToolStripMenuItem.Size = new Size(202, 26);
            rojoToolStripMenuItem.Text = "Rojo";
            rojoToolStripMenuItem.Click += rojoToolStripMenuItem_Click;
            // 
            // verdeToolStripMenuItem
            // 
            verdeToolStripMenuItem.Name = "verdeToolStripMenuItem";
            verdeToolStripMenuItem.Size = new Size(202, 26);
            verdeToolStripMenuItem.Text = "Verde";
            verdeToolStripMenuItem.Click += verdeToolStripMenuItem_Click;
            // 
            // azulToolStripMenuItem
            // 
            azulToolStripMenuItem.Name = "azulToolStripMenuItem";
            azulToolStripMenuItem.Size = new Size(202, 26);
            azulToolStripMenuItem.Text = "Azul";
            azulToolStripMenuItem.Click += azulToolStripMenuItem_Click;
            // 
            // rojosincanalesToolStripMenuItem
            // 
            rojosincanalesToolStripMenuItem.Name = "rojosincanalesToolStripMenuItem";
            rojosincanalesToolStripMenuItem.Size = new Size(202, 26);
            rojosincanalesToolStripMenuItem.Text = "Rojo Sin Canales";
            rojosincanalesToolStripMenuItem.Click += rojosincanalesToolStripMenuItem_Click;
            // 
            // cianToolStripMenuItem
            // 
            cianToolStripMenuItem.Name = "cianToolStripMenuItem";
            cianToolStripMenuItem.Size = new Size(202, 26);
            cianToolStripMenuItem.Text = "Cian";
            cianToolStripMenuItem.Click += cianToolStripMenuItem_Click;
            // 
            // magentaToolStripMenuItem
            // 
            magentaToolStripMenuItem.Name = "magentaToolStripMenuItem";
            magentaToolStripMenuItem.Size = new Size(202, 26);
            magentaToolStripMenuItem.Text = "Magenta";
            magentaToolStripMenuItem.Click += magentaToolStripMenuItem_Click;
            // 
            // escalaDeGrisesToolStripMenuItem
            // 
            escalaDeGrisesToolStripMenuItem.Name = "escalaDeGrisesToolStripMenuItem";
            escalaDeGrisesToolStripMenuItem.Size = new Size(202, 26);
            escalaDeGrisesToolStripMenuItem.Text = "Escala de grises";
            escalaDeGrisesToolStripMenuItem.Click += escalaDeGrisesToolStripMenuItem_Click;
            // 
            // BlancoYNegroToolStripMenuItem
            // 
            BlancoYNegroToolStripMenuItem.Name = "BlancoYNegroToolStripMenuItem";
            BlancoYNegroToolStripMenuItem.Size = new Size(202, 26);
            BlancoYNegroToolStripMenuItem.Text = "Blanco y Negro";
            BlancoYNegroToolStripMenuItem.Click += BlancoYNegroToolStripMenuItem_Click;
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(202, 26);
            sepiaToolStripMenuItem.Text = "Sepia";
            sepiaToolStripMenuItem.Click += sepiaToolStripMenuItem_Click;
            // 
            // negativoToolStripMenuItem
            // 
            negativoToolStripMenuItem.Name = "negativoToolStripMenuItem";
            negativoToolStripMenuItem.Size = new Size(202, 26);
            negativoToolStripMenuItem.Text = "Negativo";
            negativoToolStripMenuItem.Click += negativoToolStripMenuItem_Click;
            // 
            // frangasToolStripMenuItem
            // 
            frangasToolStripMenuItem.Name = "frangasToolStripMenuItem";
            frangasToolStripMenuItem.Size = new Size(202, 26);
            frangasToolStripMenuItem.Text = "Frangas";
            frangasToolStripMenuItem.Click += ejercicio2FranjasToolStripMenuItem_Click;
            // 
            // diagonalToolStripMenuItem
            // 
            diagonalToolStripMenuItem.Name = "diagonalToolStripMenuItem";
            diagonalToolStripMenuItem.Size = new Size(202, 26);
            diagonalToolStripMenuItem.Text = "Diagonal";
            diagonalToolStripMenuItem.Click += ejercicio3DiagonalToolStripMenuItem_Click;
            // 
            // quitarToolStripMenuItem
            // 
            quitarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rojoToolStripMenuItem1, azulToolStripMenuItem1, verdeToolStripMenuItem1 });
            quitarToolStripMenuItem.Name = "quitarToolStripMenuItem";
            quitarToolStripMenuItem.Size = new Size(202, 26);
            quitarToolStripMenuItem.Text = "Quitar";
            // 
            // rojoToolStripMenuItem1
            // 
            rojoToolStripMenuItem1.Name = "rojoToolStripMenuItem1";
            rojoToolStripMenuItem1.Size = new Size(130, 26);
            rojoToolStripMenuItem1.Text = "Rojo";
            rojoToolStripMenuItem1.Click += rojoToolStripMenuItem1_Click;
            // 
            // azulToolStripMenuItem1
            // 
            azulToolStripMenuItem1.Name = "azulToolStripMenuItem1";
            azulToolStripMenuItem1.Size = new Size(130, 26);
            azulToolStripMenuItem1.Text = "Azul";
            azulToolStripMenuItem1.Click += azulToolStripMenuItem1_Click;
            // 
            // verdeToolStripMenuItem1
            // 
            verdeToolStripMenuItem1.Name = "verdeToolStripMenuItem1";
            verdeToolStripMenuItem1.Size = new Size(130, 26);
            verdeToolStripMenuItem1.Text = "Verde";
            verdeToolStripMenuItem1.Click += verdeToolStripMenuItem1_Click;
            // 
            // invertirRGBToolStripMenuItem
            // 
            invertirRGBToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, bRGToolStripMenuItem, bGRToolStripMenuItem, gRBToolStripMenuItem, gRBToolStripMenuItem1 });
            invertirRGBToolStripMenuItem.Name = "invertirRGBToolStripMenuItem";
            invertirRGBToolStripMenuItem.Size = new Size(202, 26);
            invertirRGBToolStripMenuItem.Text = "Invertir RGB";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(120, 26);
            toolStripMenuItem1.Text = "RBG";
            toolStripMenuItem1.Click += rBGtoolStripMenuItem1_Click;
            // 
            // bRGToolStripMenuItem
            // 
            bRGToolStripMenuItem.Name = "bRGToolStripMenuItem";
            bRGToolStripMenuItem.Size = new Size(120, 26);
            bRGToolStripMenuItem.Text = "BRG";
            bRGToolStripMenuItem.Click += bRGToolStripMenuItem_Click;
            // 
            // bGRToolStripMenuItem
            // 
            bGRToolStripMenuItem.Name = "bGRToolStripMenuItem";
            bGRToolStripMenuItem.Size = new Size(120, 26);
            bGRToolStripMenuItem.Text = "BGR";
            bGRToolStripMenuItem.Click += bGBToolStripMenuItem_Click;
            // 
            // gRBToolStripMenuItem
            // 
            gRBToolStripMenuItem.Name = "gRBToolStripMenuItem";
            gRBToolStripMenuItem.Size = new Size(120, 26);
            gRBToolStripMenuItem.Text = "GBR";
            gRBToolStripMenuItem.Click += gBRToolStripMenuItem_Click;
            // 
            // gRBToolStripMenuItem1
            // 
            gRBToolStripMenuItem1.Name = "gRBToolStripMenuItem1";
            gRBToolStripMenuItem1.Size = new Size(120, 26);
            gRBToolStripMenuItem1.Text = "GRB";
            gRBToolStripMenuItem1.Click += gRBToolStripMenuItem1_Click;
            // 
            // imagenOriginalToolStripMenuItem
            // 
            imagenOriginalToolStripMenuItem.Name = "imagenOriginalToolStripMenuItem";
            imagenOriginalToolStripMenuItem.Size = new Size(126, 24);
            imagenOriginalToolStripMenuItem.Text = "ImagenOriginal";
            imagenOriginalToolStripMenuItem.Click += imagenOriginalToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { brilloToolStripMenuItem, mosaicoToolStripMenuItem1, distorcionToolStripMenuItem, mosaicoRectangularToolStripMenuItem, distorcionHorizontalToolStripMenuItem, espejoToolStripMenuItem });
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(71, 24);
            toolStripMenuItem3.Text = "Efectos";
            // 
            // brilloToolStripMenuItem
            // 
            brilloToolStripMenuItem.Name = "brilloToolStripMenuItem";
            brilloToolStripMenuItem.Size = new Size(230, 26);
            brilloToolStripMenuItem.Text = "Brillo";
            // 
            // mosaicoToolStripMenuItem1
            // 
            mosaicoToolStripMenuItem1.Name = "mosaicoToolStripMenuItem1";
            mosaicoToolStripMenuItem1.Size = new Size(230, 26);
            mosaicoToolStripMenuItem1.Text = "Mosaico";
            mosaicoToolStripMenuItem1.Click += mosaicoToolStripMenuItem_Click;
            // 
            // distorcionToolStripMenuItem
            // 
            distorcionToolStripMenuItem.Name = "distorcionToolStripMenuItem";
            distorcionToolStripMenuItem.Size = new Size(230, 26);
            distorcionToolStripMenuItem.Text = "Distorcion";
            distorcionToolStripMenuItem.Click += distorsionToolStripMenuItem_Click;
            // 
            // mosaicoRectangularToolStripMenuItem
            // 
            mosaicoRectangularToolStripMenuItem.Name = "mosaicoRectangularToolStripMenuItem";
            mosaicoRectangularToolStripMenuItem.Size = new Size(230, 26);
            mosaicoRectangularToolStripMenuItem.Text = "MosaicoRectangular";
            mosaicoRectangularToolStripMenuItem.Click += mosaicoRectangularToolStripMenuItem_Click;
            // 
            // distorcionHorizontalToolStripMenuItem
            // 
            distorcionHorizontalToolStripMenuItem.Name = "distorcionHorizontalToolStripMenuItem";
            distorcionHorizontalToolStripMenuItem.Size = new Size(230, 26);
            distorcionHorizontalToolStripMenuItem.Text = "DistorcionHorizontal";
            distorcionHorizontalToolStripMenuItem.Click += distorcionHorizontalToolStripMenuItem_Click;
            // 
            // espejoToolStripMenuItem
            // 
            espejoToolStripMenuItem.Name = "espejoToolStripMenuItem";
            espejoToolStripMenuItem.Size = new Size(230, 26);
            espejoToolStripMenuItem.Text = "Espejo";
            espejoToolStripMenuItem.Click += espejoToolStripMenuItem_Click;
            // 
            // histogramaToolStripMenuItem
            // 
            histogramaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { escalaDeGricesToolStripMenuItem, rGBToolStripMenuItem });
            histogramaToolStripMenuItem.Name = "histogramaToolStripMenuItem";
            histogramaToolStripMenuItem.Size = new Size(101, 24);
            histogramaToolStripMenuItem.Text = "Histograma";
            // 
            // escalaDeGricesToolStripMenuItem
            // 
            escalaDeGricesToolStripMenuItem.Name = "escalaDeGricesToolStripMenuItem";
            escalaDeGricesToolStripMenuItem.Size = new Size(197, 26);
            escalaDeGricesToolStripMenuItem.Text = "Escala de grices";
            escalaDeGricesToolStripMenuItem.Click += histogramaToolStripMenuItem_Click_1;
            // 
            // rGBToolStripMenuItem
            // 
            rGBToolStripMenuItem.Name = "rGBToolStripMenuItem";
            rGBToolStripMenuItem.Size = new Size(197, 26);
            rGBToolStripMenuItem.Text = "RGB";
            rGBToolStripMenuItem.Click += rGBToolStripMenuItem_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(830, 40);
            trackBar1.Maximum = 255;
            trackBar1.Minimum = -255;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(182, 56);
            trackBar1.TabIndex = 2;
            trackBar1.TickFrequency = 10;
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
            // button1
            // 
            button1.Location = new Point(818, 208);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Mosaico";
            button1.UseVisualStyleBackColor = true;
            button1.Click += aplicarMosaicoButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(918, 208);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Distorcion";
            button2.UseVisualStyleBackColor = true;
            button2.Click += aplicarDistorsionButton_Click;
            // 
            // trackBar4
            // 
            trackBar4.Location = new Point(830, 311);
            trackBar4.Maximum = 100;
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(182, 56);
            trackBar4.TabIndex = 7;
            trackBar4.TickFrequency = 10;
            trackBar4.Scroll += trackBar4_Scroll;
            // 
            // textBoxAncho
            // 
            textBoxAncho.Location = new Point(918, 389);
            textBoxAncho.Name = "textBoxAncho";
            textBoxAncho.Size = new Size(77, 27);
            textBoxAncho.TabIndex = 8;
            textBoxAncho.Text = "10";
            // 
            // textBoxAlto
            // 
            textBoxAlto.Location = new Point(835, 389);
            textBoxAlto.Name = "textBoxAlto";
            textBoxAlto.Size = new Size(77, 27);
            textBoxAlto.TabIndex = 9;
            textBoxAlto.Text = "10";
            // 
            // ecualizarToolStripMenuItem
            // 
            ecualizarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mejorarImagenToolStripMenuItem });
            ecualizarToolStripMenuItem.Name = "ecualizarToolStripMenuItem";
            ecualizarToolStripMenuItem.Size = new Size(82, 24);
            ecualizarToolStripMenuItem.Text = "Ecualizar";
            // 
            // mejorarImagenToolStripMenuItem
            // 
            mejorarImagenToolStripMenuItem.Name = "mejorarImagenToolStripMenuItem";
            mejorarImagenToolStripMenuItem.Size = new Size(224, 26);
            mejorarImagenToolStripMenuItem.Text = "Mejorar Imagen";
            mejorarImagenToolStripMenuItem.Click += mejorarImagenToolStripMenuItem_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1024, 600);
            Controls.Add(textBoxAlto);
            Controls.Add(textBoxAncho);
            Controls.Add(trackBar4);
            Controls.Add(button2);
            Controls.Add(button1);
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
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private ToolStripMenuItem frangasToolStripMenuItem;
        private ToolStripMenuItem diagonalToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem mosaicoToolStripMenuItem1;
        private ToolStripMenuItem distorcionToolStripMenuItem;
        private Button button1;
        private Button button2;
        private TrackBar trackBar4;
        private TextBox textBoxAncho;
        private TextBox textBoxAlto;
        private ToolStripMenuItem mosaicoRectangularToolStripMenuItem;
        private ToolStripMenuItem distorcionHorizontalToolStripMenuItem;
        private ToolStripMenuItem quitarToolStripMenuItem;
        private ToolStripMenuItem rojoToolStripMenuItem1;
        private ToolStripMenuItem azulToolStripMenuItem1;
        private ToolStripMenuItem verdeToolStripMenuItem1;
        private ToolStripMenuItem invertirRGBToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem bRGToolStripMenuItem;
        private ToolStripMenuItem bGRToolStripMenuItem;
        private ToolStripMenuItem gRBToolStripMenuItem;
        private ToolStripMenuItem gRBToolStripMenuItem1;
        private ToolStripMenuItem espejoToolStripMenuItem;
        private ToolStripMenuItem brilloToolStripMenuItem;
        private ToolStripMenuItem histogramaToolStripMenuItem;
        private ToolStripMenuItem escalaDeGricesToolStripMenuItem;
        private ToolStripMenuItem rGBToolStripMenuItem;
        private ToolStripMenuItem ecualizarToolStripMenuItem;
        private ToolStripMenuItem mejorarImagenToolStripMenuItem;
    }
}
