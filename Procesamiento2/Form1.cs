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
            textBox1.Text = "50";
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
            puntoInicialImg = PictureBoxToImageCoords(e.Location);
            rectSeleccion = new Rectangle(puntoInicialImg, Size.Empty);
        }
        private void pctLienzo_MouseMove(object sender, MouseEventArgs e)
        {
            if (!seleccionando) return;

            Point puntoActualImg = PictureBoxToImageCoords(e.Location);

            rectSeleccion = new Rectangle(
                Math.Min(puntoInicialImg.X, puntoActualImg.X),
                Math.Min(puntoInicialImg.Y, puntoActualImg.Y),
                Math.Abs(puntoActualImg.X - puntoInicialImg.X),
                Math.Abs(puntoActualImg.Y - puntoInicialImg.Y)
            );

            pctLienzo.Invalidate(); // repinta el PictureBox
        }
        private void pctLienzo_MouseUp(object sender, MouseEventArgs e)
        {
            if (!seleccionando) return;
            seleccionando = false;

            Point puntoFinalImg = PictureBoxToImageCoords(e.Location);

            rectSeleccion = new Rectangle(
                Math.Min(puntoInicialImg.X, puntoFinalImg.X),
                Math.Min(puntoInicialImg.Y, puntoFinalImg.Y),
                Math.Abs(puntoFinalImg.X - puntoInicialImg.X),
                Math.Abs(puntoFinalImg.Y - puntoInicialImg.Y)
            );

            pctLienzo.Invalidate();
        }
        private Rectangle ImageToPictureBoxRect(Rectangle imgRect)
        {
            if (ImagenOriginal == null) return Rectangle.Empty;

            int imgW = ImagenOriginal.Width;
            int imgH = ImagenOriginal.Height;
            int pbW = pctLienzo.Width;
            int pbH = pctLienzo.Height;

            if (pctLienzo.SizeMode == PictureBoxSizeMode.Zoom)
            {
                float ratio = Math.Min((float)pbW / imgW, (float)pbH / imgH);
                float dispW = imgW * ratio;
                float dispH = imgH * ratio;
                float offsetX = (pbW - dispW) / 2f;
                float offsetY = (pbH - dispH) / 2f;

                return new Rectangle(
                    (int)(imgRect.X * ratio + offsetX),
                    (int)(imgRect.Y * ratio + offsetY),
                    (int)(imgRect.Width * ratio),
                    (int)(imgRect.Height * ratio)
                );
            }
            else
            {
                return new Rectangle(
                    imgRect.X * pbW / imgW,
                    imgRect.Y * pbH / imgH,
                    imgRect.Width * pbW / imgW,
                    imgRect.Height * pbH / imgH
                );
            }
        }
        private void pctLienzo_Paint(object sender, PaintEventArgs e)
        {
            if (rectSeleccion != Rectangle.Empty)
            {
                using (Pen lapiz = new Pen(Color.Red, 2))
                {
                    Rectangle pbRect = ImageToPictureBoxRect(rectSeleccion);
                    e.Graphics.DrawRectangle(lapiz, pbRect);
                }
            }
        }
        private void AplicarDistorsionDiagonal(Rectangle area)
        {
            if (ImagenOriginal == null || area.Width == 0 || area.Height == 0) return;

            if (!int.TryParse(textBox1.Text, out int Maximo) || Maximo <= 0)
                Maximo = 10;

            Bitmap bmp = new Bitmap(ImagenOriginal);
            Random rand = new Random();

            for (int y = area.Top; y < area.Bottom; y++)
            {
                for (int x = area.Left; x < area.Right; x++)
                {
                    int desplazamiento = rand.Next(0, Maximo + 1);

                    int nx = Math.Min(x + desplazamiento, ImagenOriginal.Width - 1);
                    int ny = Math.Min(y + desplazamiento, ImagenOriginal.Height - 1);

                    Color color = ImagenOriginal.GetPixel(nx, ny);
                    bmp.SetPixel(x, y, color);
                }
            }

            ImagenResultado = bmp;
            MostrarResultado();
        }
        private void distorsionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AplicarDistorsionDiagonal(new Rectangle(0, 0, ImagenOriginal.Width, ImagenOriginal.Height));
        }
        private void aplicarMosaicoButton_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null || rectSeleccion == Rectangle.Empty) return;
            AplicarMosaico(rectSeleccion);
        }
        private void aplicarDistorsionButton_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null || rectSeleccion == Rectangle.Empty) return;
            AplicarDistorsionDiagonal(rectSeleccion);
        }
        private void AplicarFiltroAvanzado(Func<int, int, Color, Color> transformacion)
        {
            if (ImagenOriginal == null) return;

            int ancho = ImagenOriginal.Width;
            int alto = ImagenOriginal.Height;
            ImagenResultado = new Bitmap(ancho, alto);

            for (int x = 0; x < ancho; x++)
            {
                for (int y = 0; y < alto; y++)
                {
                    Color c = ImagenOriginal.GetPixel(x, y);
                    Color modificado = transformacion(x, y, c);
                    ImagenResultado.SetPixel(x, y, modificado);
                }
            }

            MostrarResultado();
        }
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;

            int intensidad = trackBar4.Value;
            int tamanoPatron = 10;

            Random rand = new Random();

            AplicarFiltroAvanzado((x, y, c) =>
            {
                bool aplicarRuido = ((x / tamanoPatron) + (y / tamanoPatron)) % 2 == 0;

                int ruido = aplicarRuido ? rand.Next(-intensidad, intensidad + 1) : 0;

                int r = Math.Clamp(c.R + ruido, 0, 255);
                int g = Math.Clamp(c.G + ruido, 0, 255);
                int b = Math.Clamp(c.B + ruido, 0, 255);

                return Color.FromArgb(255, r, g, b);
            });
        }
        private void AplicarMosaicoRectangular(Rectangle area)
        {
            if (ImagenOriginal == null || area.Width == 0 || area.Height == 0) return;

            // Puedes usar dos TextBox separados o valores fijos aquí
            if (!int.TryParse(textBoxAncho.Text, out int anchoBloque) || anchoBloque <= 0) anchoBloque = 10;
            if (!int.TryParse(textBoxAlto.Text, out int altoBloque) || altoBloque <= 0) altoBloque = 10;

            Bitmap bmp = new Bitmap(ImagenOriginal);

            for (int y = area.Top; y < area.Bottom; y += altoBloque)
            {
                for (int x = area.Left; x < area.Right; x += anchoBloque)
                {
                    int bloqueW = Math.Min(anchoBloque, area.Right - x);
                    int bloqueH = Math.Min(altoBloque, area.Bottom - y);

                    int r = 0, g = 0, b = 0, count = 0;

                    // Calcular promedio de color dentro del bloque rectangular
                    for (int yy = 0; yy < bloqueH; yy++)
                    {
                        for (int xx = 0; xx < bloqueW; xx++)
                        {
                            Color pixel = bmp.GetPixel(x + xx, y + yy);
                            r += pixel.R;
                            g += pixel.G;
                            b += pixel.B;
                            count++;
                        }
                    }

                    Color promedio = Color.FromArgb(r / count, g / count, b / count);

                    // Asignar el color promedio a todos los píxeles del bloque
                    for (int yy = 0; yy < bloqueH; yy++)
                    {
                        for (int xx = 0; xx < bloqueW; xx++)
                        {
                            bmp.SetPixel(x + xx, y + yy, promedio);
                        }
                    }
                }
            }

            ImagenResultado = bmp;
            MostrarResultado();
        }
        private void mosaicoRectangularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarMosaicoRectangular(new Rectangle(0, 0, ImagenOriginal.Width, ImagenOriginal.Height));
        }
        private void AplicarDistorsionHorizaontal(Rectangle area)
        {
            if (ImagenOriginal == null || area.Width == 0 || area.Height == 0) return;

            if (!int.TryParse(textBox1.Text, out int Maximo) || Maximo <= 0)
                Maximo = 10;

            Bitmap bmp = new Bitmap(ImagenOriginal);
            Random rand = new Random();

            for (int y = area.Top; y < area.Bottom; y++)
            {
                for (int x = area.Left; x < area.Right; x++)
                {
                    int desplazamiento = rand.Next(0, Maximo + 1);

                    int nx = Math.Min(x + desplazamiento, ImagenOriginal.Width - 1);
                    int ny = y;

                    Color color = ImagenOriginal.GetPixel(nx, ny);
                    bmp.SetPixel(x, y, color);
                }
            }

            ImagenResultado = bmp;
            MostrarResultado();
        }
        private void distorcionHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AplicarDistorsionHorizaontal(new Rectangle(0, 0, ImagenOriginal.Width, ImagenOriginal.Height));
        }

        private void rojoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarFiltro(c =>
            {
                int g = c.G;
                int b = c.B;
                return Color.FromArgb(255, 0, g, b);
            });
        }

        private void azulToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarFiltro(c =>
            {
                int r = c.R;
                int g = c.G;
                return Color.FromArgb(255, r, g, 0);
            });
        }

        private void verdeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarFiltro(c =>
            {
                int r = c.R;
                int b = c.B;
                return Color.FromArgb(255, r, 0, b);
            });
        }
        private void rBGtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarFiltro(c =>
            {
                return Color.FromArgb(255, c.R, c.B, c.G);
            });
        }
        private void bRGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarFiltro(c =>
            {
                return Color.FromArgb(255, c.B, c.G, c.R);
            });
        }

        private void bGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarFiltro(c =>
            {
                return Color.FromArgb(255, c.B, c.G, c.B);
            });
        }

        private void gBRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarFiltro(c =>
            {
                return Color.FromArgb(255, c.G, c.B, c.R);
            });
        }

        private void gRBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarFiltro(c =>
            {
                return Color.FromArgb(255, c.G, c.R, c.B);
            });
        }

        private void espejoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;

            int ancho = ImagenOriginal.Width;
            int alto = ImagenOriginal.Height;

            // Crear bitmap más grande para contener ambas imágenes lado a lado
            Bitmap combinado = new Bitmap(ancho * 2, alto);

            using (Graphics g = Graphics.FromImage(combinado))
            {
                // Dibujar la imagen original a la izquierda
                g.DrawImage(ImagenOriginal, 0, 0, ancho, alto);

                // Crear la imagen espejo
                Bitmap espejo = (Bitmap)ImagenOriginal.Clone();
                espejo.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Dibujar la imagen espejo a la derecha
                g.DrawImage(espejo, ancho, 0, ancho, alto);
            }

            // Guardar resultado en ImagenResultado y mostrarlo
            ImagenResultado = combinado;
            MostrarResultado();

        }
    }
}