using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Procesamiento2
{
    public partial class Form1 : Form
    {
        private Bitmap ImagenOriginal, ImagenResultado;
        private bool seleccionando = false;
        private Point puntoInicialPB, puntoInicialImg;
        private Rectangle rectSeleccion;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "10";
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            pctLienzo.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void MostrarResultado()
        {
            pctLienzo.Image = ImagenResultado;
            pctLienzo.Refresh();
        }

        private void AplicarFiltro(Func<Color, Color> transformacion)
        {
            if (ImagenOriginal == null) return;

            int ancho = ImagenOriginal.Width;
            int alto = ImagenOriginal.Height;
            ImagenResultado = new Bitmap(ancho, alto);

            for (int x = 0; x < ancho; x++)
                for (int y = 0; y < alto; y++)
                    ImagenResultado.SetPixel(x, y, transformacion(ImagenOriginal.GetPixel(x, y)));

            MostrarResultado();
        }

        private void AplicarMosaico(Rectangle area)
        {
            if (ImagenOriginal == null || area.Width == 0 || area.Height == 0) return;

            if (!int.TryParse(textBox1.Text, out int tamBloque) || tamBloque <= 0) tamBloque = 10;

            Bitmap bmp = new Bitmap(ImagenOriginal);

            for (int y = area.Top; y < area.Bottom; y += tamBloque)
            {
                for (int x = area.Left; x < area.Right; x += tamBloque)
                {
                    int bloqueW = Math.Min(tamBloque, area.Right - x);
                    int bloqueH = Math.Min(tamBloque, area.Bottom - y);

                    int r = 0, g = 0, b = 0, count = 0;
                    for (int yy = 0; yy < bloqueH; yy++)
                        for (int xx = 0; xx < bloqueW; xx++)
                        {
                            Color pixel = bmp.GetPixel(x + xx, y + yy);
                            r += pixel.R; g += pixel.G; b += pixel.B; count++;
                        }

                    Color promedio = Color.FromArgb(r / count, g / count, b / count);

                    for (int yy = 0; yy < bloqueH; yy++)
                        for (int xx = 0; xx < bloqueW; xx++)
                            bmp.SetPixel(x + xx, y + yy, promedio);
                }
            }

            ImagenResultado = bmp;
            MostrarResultado();
        }

        private Point PictureBoxToImageCoords(Point pbPoint)
        {
            if (ImagenOriginal == null) return Point.Empty;
            int imgW = ImagenOriginal.Width, imgH = ImagenOriginal.Height;
            int pbW = pctLienzo.Width, pbH = pctLienzo.Height;

            if (pctLienzo.SizeMode == PictureBoxSizeMode.Zoom)
            {
                float ratio = Math.Min((float)pbW / imgW, (float)pbH / imgH);
                float dispW = imgW * ratio, dispH = imgH * ratio;
                float offsetX = (pbW - dispW) / 2f, offsetY = (pbH - dispH) / 2f;
                float xImg = (pbPoint.X - offsetX) / ratio;
                float yImg = (pbPoint.Y - offsetY) / ratio;
                return new Point((int)Math.Clamp(Math.Round(xImg), 0, imgW - 1),
                                 (int)Math.Clamp(Math.Round(yImg), 0, imgH - 1));
            }
            else
            {
                return new Point((int)Math.Clamp(pbPoint.X * (float)imgW / pbW, 0, imgW - 1),
                                 (int)Math.Clamp(pbPoint.Y * (float)imgH / pbH, 0, imgH - 1));
            }
        }

        // =====================
        // Eventos UI
        // =====================

        private void abrir_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog { Filter = "Archivos de imagen|*.jpg;*.png;*.bmp" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ImagenOriginal = new Bitmap(ofd.FileName);
                ImagenResultado = new Bitmap(ImagenOriginal);
                MostrarResultado();
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenResultado == null) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "BMP (*.bmp)|*.bmp|PNG (*.png)|*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|GIF (*.gif)|*.gif|TIFF (*.tif;*.tiff)|*.tif;*.tiff";
                sfd.DefaultExt = "png"; // extensión por defecto
                sfd.AddExtension = true; // añade extensión automáticamente si no la pones

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string ext = System.IO.Path.GetExtension(sfd.FileName).ToLower();
                    var formato = ext switch
                    {
                        ".bmp" => System.Drawing.Imaging.ImageFormat.Bmp,
                        ".png" => System.Drawing.Imaging.ImageFormat.Png,
                        ".gif" => System.Drawing.Imaging.ImageFormat.Gif,
                        ".tif" or ".tiff" => System.Drawing.Imaging.ImageFormat.Tiff,
                        ".jpg" or ".jpeg" => System.Drawing.Imaging.ImageFormat.Jpeg,
                        _ => System.Drawing.Imaging.ImageFormat.Png
                    };

                    ImagenResultado.Save(sfd.FileName, formato);
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e) => Close();
        private void imagenOriginalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            ImagenResultado = new Bitmap(ImagenOriginal);
            MostrarResultado();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            int brillo = trackBar1.Value;
            AplicarFiltro(c => Color.FromArgb(255,
                Math.Clamp(c.R + brillo, 0, 255),
                Math.Clamp(c.G + brillo, 0, 255),
                Math.Clamp(c.B + brillo, 0, 255)));
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            int intensidad = trackBar2.Value;
            Random rand = new Random();
            AplicarFiltro(c => Color.FromArgb(255,
                Math.Clamp(c.R + rand.Next(-intensidad, intensidad + 1), 0, 255),
                Math.Clamp(c.G + rand.Next(-intensidad, intensidad + 1), 0, 255),
                Math.Clamp(c.B + rand.Next(-intensidad, intensidad + 1), 0, 255)));
        }

        private void rojosincanalesToolStripMenuItem_Click(object sender, EventArgs e) =>
            AplicarFiltro(c => Filtros.RojoSinCanales(c, 50));

        private void cianToolStripMenuItem_Click(object sender, EventArgs e) => AplicarFiltro(Filtros.Cian);
        private void magentaToolStripMenuItem_Click(object sender, EventArgs e) => AplicarFiltro(Filtros.Magenta);
        private void rojoToolStripMenuItem_Click(object sender, EventArgs e) => AplicarFiltro(Filtros.Rojo);
        private void verdeToolStripMenuItem_Click(object sender, EventArgs e) => AplicarFiltro(Filtros.Verde);
        private void azulToolStripMenuItem_Click(object sender, EventArgs e) => AplicarFiltro(Filtros.Azul);
        private void escalaDeGrisesToolStripMenuItem_Click(object sender, EventArgs e) => AplicarFiltro(Filtros.EscalaGrises);
        private void BlancoYNegroToolStripMenuItem_Click(object sender, EventArgs e) => AplicarFiltro(Filtros.BlancoNegro);
        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e) => AplicarFiltro(Filtros.Sepia);
        private void negativoToolStripMenuItem_Click(object sender, EventArgs e) => AplicarFiltro(Filtros.Negativo);
        private void ejercicio2FranjasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;

            int ancho = ImagenOriginal.Width;
            int alto = ImagenOriginal.Height;
            ImagenResultado = new Bitmap(ancho, alto);

            for (int y = 0; y < alto; y++)
            {
                for (int x = 0; x < ancho; x++)
                {
                    Color c = ImagenOriginal.GetPixel(x, y);
                    ImagenResultado.SetPixel(x, y, Filtros.Ejercicio2_Franzas(c, y, alto));
                }
            }

            MostrarResultado();
        }
        private void ejercicio3DiagonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;

            int ancho = ImagenOriginal.Width;
            int alto = ImagenOriginal.Height;
            ImagenResultado = new Bitmap(ancho, alto);

            for (int y = 0; y < alto; y++)
            {
                for (int x = 0; x < ancho; x++)
                {
                    Color c = ImagenOriginal.GetPixel(x, y);
                    ImagenResultado.SetPixel(x, y, Filtros.Ejercicio3_Diagonal(c, x, y, ancho, alto));
                }
            }

            MostrarResultado();
        }

        private void mosaicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarMosaico(new Rectangle(0, 0, ImagenOriginal.Width, ImagenOriginal.Height));
        }
        private void pctLienzo_MouseDown(object sender, MouseEventArgs e)
        {
            if (ImagenOriginal == null) return;
            seleccionando = true;
            puntoInicialPB = e.Location;
            puntoInicialImg = PictureBoxToImageCoords(e.Location);
            rectSeleccion = new Rectangle(e.Location, Size.Empty);
        }

        private void pctLienzo_MouseMove(object sender, MouseEventArgs e)
        {
            if (!seleccionando) return;

            rectSeleccion = new Rectangle(
                Math.Min(e.X, puntoInicialPB.X),
                Math.Min(e.Y, puntoInicialPB.Y),
                Math.Abs(e.X - puntoInicialPB.X),
                Math.Abs(e.Y - puntoInicialPB.Y)
            );

            pctLienzo.Invalidate(); // repinta el PictureBox
        }

        private void pctLienzo_MouseUp(object sender, MouseEventArgs e)
        {
            if (!seleccionando) return;
            seleccionando = false;

            Point puntoFinalImg = PictureBoxToImageCoords(e.Location);
            Rectangle imgRect = new Rectangle(
                Math.Min(puntoInicialImg.X, puntoFinalImg.X),
                Math.Min(puntoInicialImg.Y, puntoFinalImg.Y),
                Math.Abs(puntoFinalImg.X - puntoInicialImg.X),
                Math.Abs(puntoFinalImg.Y - puntoInicialImg.Y)
            );

            AplicarMosaico(imgRect);
        }
        private void pctLienzo_Paint(object sender, PaintEventArgs e)
        {
            if (rectSeleccion != Rectangle.Empty)
            {
                using (Pen lapiz = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(lapiz, rectSeleccion);
                }
            }
        }
    }
}
