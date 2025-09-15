namespace Procesamiento2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Variables
        int AnchoP = 200, AltoP = 200;
        int AnchoImagen, AltoImagen;
        Bitmap ImagenOriginal, ImagenResultado;
        Graphics Lienzo;
        int a = 20;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void abrir_Click(object sender, EventArgs e)
        {
            // Abrir
            if (ofdAbrir.ShowDialog() == DialogResult.OK)
            {
                ImagenOriginal = (Bitmap)(Bitmap.FromFile(ofdAbrir.FileName));
                AnchoImagen = ImagenOriginal.Width;
                AltoImagen = ImagenOriginal.Height;
                pctLienzo.Image = ImagenOriginal;
                ImagenResultado = ImagenOriginal;
            }
        }

        private void ofdAbrir_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdGuardar.ShowDialog() == DialogResult.OK)
            {
                // Detectar el formato de la imagen original para guardar con ese formato
                System.Drawing.Imaging.ImageFormat formato;

                string extension = System.IO.Path.GetExtension(sfdGuardar.FileName).ToLower();

                switch (extension)
                {
                    case ".bmp":
                        formato = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                    case ".png":
                        formato = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                    case ".gif":
                        formato = System.Drawing.Imaging.ImageFormat.Gif;
                        break;
                    case ".tiff":
                    case ".tif":
                        formato = System.Drawing.Imaging.ImageFormat.Tiff;
                        break;
                    case ".jpeg":
                    case ".jpg":
                        formato = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    default:
                        formato = System.Drawing.Imaging.ImageFormat.Png; // por defecto PNG
                        break;
                }

                ImagenResultado.Save(sfdGuardar.FileName, formato);

            }
        }

        private void imagenOriginalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImagenOriginal = (Bitmap)(Bitmap.FromFile(ofdAbrir.FileName));
            pctLienzo.Image = ImagenOriginal;
            pctLienzo.Refresh();
        }

        private void rojoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // rojo
            int i, j, rojo;
            Color miColor = new Color();
            Color nuevoColor = new Color();
            for (i = 0; i < AnchoImagen; i++)
            {
                for (j = 0; j < AltoImagen; j++)
                {
                    miColor = ImagenOriginal.GetPixel(i, j);
                    rojo = (miColor.R + miColor.B + miColor.G) / 3;
                    nuevoColor = Color.FromArgb(255, rojo, 0, 0);
                    ImagenResultado.SetPixel(i, j, nuevoColor);
                }
            }
            pctLienzo.Image = ImagenResultado;
            pctLienzo.Refresh();
        }

        private void verdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Filtro Verde con promedio
            int i, j, verde;
            Color miColor = new Color();
            Color nuevoColor = new Color();
            for (i = 0; i < AnchoImagen; i++)
            {
                for (j = 0; j < AltoImagen; j++)
                {
                    miColor = ImagenOriginal.GetPixel(i, j);
                    // Se hace promedio igual que en rojo
                    verde = (miColor.R + miColor.G + miColor.B) / 3;
                    nuevoColor = Color.FromArgb(255, 0, verde, 0);
                    ImagenResultado.SetPixel(i, j, nuevoColor);
                }
            }
            pctLienzo.Image = ImagenResultado;
            pctLienzo.Refresh();
        }

        private void azulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Filtro Azul con promedio
            int i, j, azul;
            Color miColor;
            Color nuevoColor;
            for (i = 0; i < AnchoImagen; i++)
            {
                for (j = 0; j < AltoImagen; j++)
                {
                    miColor = ImagenOriginal.GetPixel(i, j);
                    azul = (miColor.R + miColor.G + miColor.B) / 3;
                    nuevoColor = Color.FromArgb(255, 0, 0, azul);
                    ImagenResultado.SetPixel(i, j, nuevoColor);
                }
            }
            pctLienzo.Image = ImagenResultado;
            pctLienzo.Refresh();
            pctLienzo.Refresh();

        }

        private void rojosincanalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i, j;
            Color miColor;
            Color nuevoColor;
            int aclarado = 50; // cantidad para aclarar (puedes ajustar)

            for (i = 0; i < AnchoImagen; i++)
            {
                for (j = 0; j < AltoImagen; j++)
                {
                    miColor = ImagenOriginal.GetPixel(i, j);
                    // Aclarar canal rojo sumando aclarado pero sin pasar de 255
                    int rojoAclarado = miColor.R + aclarado;
                    if (rojoAclarado > 255)
                        rojoAclarado = 255;

                    nuevoColor = Color.FromArgb(255, rojoAclarado, 0, 0);
                    ImagenResultado.SetPixel(i, j, nuevoColor);
                }
            }
            pctLienzo.Image = ImagenResultado;
            pctLienzo.Refresh();
        }

    }
}
