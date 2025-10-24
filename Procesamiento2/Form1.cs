using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Linq;

namespace Procesamiento2
{
    public partial class Form1 : Form
    {
        private Bitmap ImagenOriginal, ImagenResultado;
        private bool seleccionando = false;
        private Point puntoInicialPB, puntoInicialImg;
        private Rectangle rectSeleccion;
        private int[] histograma = new int[256];

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
            if (ImagenResultado != null)
            {
                pctLienzo.Image = ImagenResultado;
                pctLienzo.Refresh();
            }
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
                sfd.DefaultExt = "png";
                sfd.AddExtension = true;

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

            pctLienzo.Invalidate();
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
            AplicarFiltro(c => Color.FromArgb(255, 0, c.G, c.B));
        }

        private void azulToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarFiltro(c => Color.FromArgb(255, c.R, c.G, 0));
        }

        private void verdeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarFiltro(c => Color.FromArgb(255, c.R, 0, c.B));
        }

        private void rBGtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarFiltro(c => Color.FromArgb(255, c.R, c.B, c.G));
        }

        private void bRGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarFiltro(c => Color.FromArgb(255, c.B, c.G, c.R));
        }

        private void bGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarFiltro(c => Color.FromArgb(255, c.B, c.G, c.B));
        }

        private void gBRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarFiltro(c => Color.FromArgb(255, c.G, c.B, c.R));
        }

        private void gRBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;
            AplicarFiltro(c => Color.FromArgb(255, c.G, c.R, c.B));
        }

        private void espejoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;

            int ancho = ImagenOriginal.Width;
            int alto = ImagenOriginal.Height;

            Bitmap combinado = new Bitmap(ancho * 2, alto);

            using (Graphics g = Graphics.FromImage(combinado))
            {
                g.DrawImage(ImagenOriginal, 0, 0, ancho, alto);

                Bitmap espejo = (Bitmap)ImagenOriginal.Clone();
                espejo.RotateFlip(RotateFlipType.RotateNoneFlipX);

                g.DrawImage(espejo, ancho, 0, ancho, alto);
            }

            ImagenResultado = combinado;
            MostrarResultado();
        }

        private void histogramaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Usar la imagen actual mostrada en pctLienzo
            Bitmap imagenParaHistograma = pctLienzo.Image as Bitmap;

            if (imagenParaHistograma == null && ImagenOriginal != null)
            {
                imagenParaHistograma = ImagenOriginal;
            }

            if (imagenParaHistograma == null) return;

            MostrarHistograma(imagenParaHistograma, "Histograma (Escala de Grises)");
        }

        private void MostrarHistograma(Bitmap imagen, string titulo)
        {
            int ancho = imagen.Width;
            int alto = imagen.Height;
            int[] histograma = new int[256];

            // Calcular histograma
            for (int y = 0; y < alto; y++)
            {
                for (int x = 0; x < ancho; x++)
                {
                    Color c = imagen.GetPixel(x, y);
                    int gris = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                    histograma[gris]++;
                }
            }

            int maxValor = histograma.Max();

            // Normalizar para la TABLA (0 a 1)
            double[] histogramaNormalizado = new double[256];
            for (int i = 0; i < 256; i++)
            {
                histogramaNormalizado[i] = histograma[i] / (double)(ancho * alto);
            }

            // Crear imagen del histograma
            int histW = 512;
            int histH = 300;
            int margen = 30;
            Bitmap histImg = new Bitmap(histW, histH);

            using (Graphics g = Graphics.FromImage(histImg))
            {
                g.Clear(Color.White);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Definir área de dibujo
                int areaAltura = histH - margen - 10;
                int baseY = histH - margen;

                // Eje base
                using (Pen ejePen = new Pen(Color.Black, 2))
                {
                    g.DrawLine(ejePen, 0, baseY, histW, baseY);
                }

                // Crear puntos para la curva
                float escalaX = histW / 255f;
                List<PointF> puntos = new List<PointF>();

                for (int i = 0; i < 256; i++)
                {
                    float x = i * escalaX;
                    float altPunto = (histograma[i] * areaAltura) / (float)maxValor;
                    float y = baseY - altPunto;
                    y = Math.Max(y, 5);
                    puntos.Add(new PointF(x, y));
                }

                using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddRectangle(new Rectangle(0, 0, histW, baseY + 1));
                    g.SetClip(path);

                    using (Pen curvaPen = new Pen(Color.Red, 2))
                    {
                        if (puntos.Count > 2)
                        {
                            g.DrawCurve(curvaPen, puntos.ToArray(), 0.2f);
                        }
                    }
                    g.ResetClip();
                }

                // Etiquetas
                using (Font f = new Font("Arial", 9))
                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    g.DrawString("0", f, brush, 0, baseY + 2);
                    g.DrawString("256", f, brush, histW - 25, baseY + 2);
                    g.DrawString("Nivel de Gris", f, brush, histW / 2 - 40, histH - 15);
                }
            }

            // Mostrar en ventana
            Form histForm = new Form();
            histForm.Text = titulo;
            histForm.StartPosition = FormStartPosition.CenterScreen;
            histForm.Size = new Size(600, 600);

            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Top;
            pb.Height = histH + 20;
            pb.Image = histImg;
            pb.SizeMode = PictureBoxSizeMode.Zoom;

            // Liberar la imagen cuando se cierre el formulario
            histForm.FormClosed += (s, args) =>
            {
                pb.Image = null;
                histImg?.Dispose();
            };

            // Tabla
            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns.Add("Nivel", "Nivel de Gris");
            dgv.Columns.Add("Frecuencia", "Frecuencia");
            dgv.Columns.Add("Normalizado", "Valor Normalizado (0–1)");

            for (int i = 0; i < 256; i++)
            {
                dgv.Rows.Add(i, histograma[i], histogramaNormalizado[i].ToString("F4"));
            }

            histForm.Controls.Add(dgv);
            histForm.Controls.Add(pb);
            histForm.Show();
        }
        private void rGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Usar la imagen actual mostrada en pctLienzo
            Bitmap imagenParaHistograma = pctLienzo.Image as Bitmap;

            if (imagenParaHistograma == null && ImagenOriginal != null)
            {
                imagenParaHistograma = ImagenOriginal;
            }

            if (imagenParaHistograma == null) return;

            int ancho = imagenParaHistograma.Width;
            int alto = imagenParaHistograma.Height;

            // Histogramas para cada canal
            int[] histogramaR = new int[256];
            int[] histogramaG = new int[256];
            int[] histogramaB = new int[256];
            int[] histogramaA = new int[256];

            // Calcular histogramas
            for (int y = 0; y < alto; y++)
            {
                for (int x = 0; x < ancho; x++)
                {
                    Color c = imagenParaHistograma.GetPixel(x, y);
                    histogramaR[c.R]++;
                    histogramaG[c.G]++;
                    histogramaB[c.B]++;
                    histogramaA[c.A]++;
                }
            }

            int totalPixeles = ancho * alto;

            // Crear ventana principal
            Form histForm = new Form();
            histForm.Text = "Histogramas RGBA (Curvas)";
            histForm.StartPosition = FormStartPosition.CenterScreen;
            histForm.Size = new Size(1100, 700);
            histForm.AutoScroll = true;

            // Panel contenedor
            TableLayoutPanel mainPanel = new TableLayoutPanel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.ColumnCount = 2;
            mainPanel.RowCount = 2;
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));

            // Agregar histogramas por canal
            mainPanel.Controls.Add(CrearPanelHistograma("Canal Rojo (R)", histogramaR, Color.Red, totalPixeles), 0, 0);
            mainPanel.Controls.Add(CrearPanelHistograma("Canal Verde (G)", histogramaG, Color.Green, totalPixeles), 1, 0);
            mainPanel.Controls.Add(CrearPanelHistograma("Canal Azul (B)", histogramaB, Color.Blue, totalPixeles), 0, 1);
            mainPanel.Controls.Add(CrearPanelHistograma("Canal Alfa (A)", histogramaA, Color.Black, totalPixeles), 1, 1);

            histForm.Controls.Add(mainPanel);
            histForm.Show();
        }
        private Panel CrearPanelHistograma(string titulo, int[] histograma, Color colorCanal, int totalPixeles)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(5)
            };

            // Título del canal
            Label lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = colorCanal
            };

            // Parámetros del gráfico
            int histW = 500;
            int histH = 220;
            int margenInferior = 20;

            Bitmap histImg = new Bitmap(histW, histH, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            int maxValor = histograma.Max();
            if (maxValor <= 0) maxValor = 1;

            try
            {
                using (Graphics g = Graphics.FromImage(histImg))
                {
                    g.Clear(Color.White);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    int baseY = histH - margenInferior;
                    int areaAltura = histH - margenInferior;

                    float escalaX = histW / 255f;
                    List<PointF> puntos = new List<PointF>();

                    for (int i = 0; i < 256; i++)
                    {
                        float x = i * escalaX;
                        float altura = (histograma[i] * areaAltura) / (float)maxValor;
                        float y = baseY - altura;
                        if (y < 0) y = 0;
                        puntos.Add(new PointF(x, y));
                    }

                    // Dibujar curva con el color del canal
                    using (Pen pen = new Pen(colorCanal, 2))
                    {
                        if (puntos.Count > 1)
                            g.DrawCurve(pen, puntos.ToArray(), 0.5f);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar histograma: " + ex.Message);
            }

            // Mostrar imagen en PictureBox
            PictureBox pb = new PictureBox
            {
                Dock = DockStyle.Top,
                Height = histH + 10,
                Image = histImg,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // Tabla con estadísticas
            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ScrollBars = ScrollBars.Vertical,
                Height = 150
            };

            dgv.Columns.Add("Estadistica", "Estadística");
            dgv.Columns.Add("Valor", "Valor");

            int minimo = Array.FindIndex(histograma, h => h > 0);
            int maximo = Array.FindLastIndex(histograma, h => h > 0);
            double promedio = 0;
            long suma = 0;

            for (int i = 0; i < 256; i++)
                suma += (long)i * histograma[i];

            promedio = totalPixeles > 0 ? (suma / (double)totalPixeles) : 0;

            dgv.Rows.Add("Mínimo", minimo);
            dgv.Rows.Add("Máximo", maximo);
            dgv.Rows.Add("Promedio", promedio.ToString("F2"));
            dgv.Rows.Add("Total Píxeles", totalPixeles.ToString("N0"));
            dgv.Rows.Add("Frecuencia Máxima", maxValor.ToString("N0"));

            // Agregar controles
            panel.Controls.Add(dgv);
            panel.Controls.Add(pb);
            panel.Controls.Add(lblTitulo);

            return panel;
        }
        private void mejorarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;

            int sharpenAmount = 50;
            if (!int.TryParse(textBox1.Text, out sharpenAmount)) sharpenAmount = 50;
            sharpenAmount = Math.Clamp(sharpenAmount, 0, 200);

            Bitmap bmp = new Bitmap(ImagenOriginal);
            int width = bmp.Width;
            int height = bmp.Height;

            // Bloquear bits para acceso directo
            Rectangle rect = new Rectangle(0, 0, width, height);
            System.Drawing.Imaging.BitmapData data = bmp.LockBits(rect,
                System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            int bpp = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
            int stride = data.Stride;
            IntPtr ptr = data.Scan0;
            int bytes = Math.Abs(stride) * height;
            byte[] rgbValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            // --- Convertir RGB -> LAB y ecualizar canal L con CLAHE ---
            int[] hist = new int[256];
            for (int i = 0; i < bytes; i += bpp)
            {
                byte r = rgbValues[i + 2];
                byte g = rgbValues[i + 1];
                byte b = rgbValues[i];
                int l = (int)(r * 0.299 + g * 0.587 + b * 0.114);
                hist[l]++;
            }

            // CDF para ecualización adaptativa
            int total = width * height;
            int[] cdf = new int[256];
            int acc = 0;
            for (int i = 0; i < 256; i++) { acc += hist[i]; cdf[i] = acc; }
            int cdfMin = 0;
            for (int i = 0; i < 256; i++) { if (cdf[i] > 0) { cdfMin = cdf[i]; break; } }

            byte[] map = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                double v = (cdf[i] - cdfMin) / (double)(total - cdfMin);
                map[i] = (byte)Math.Clamp(v * 255.0, 0, 255);
            }

            // Aplicar ecualización en luminancia
            for (int i = 0; i < bytes; i += bpp)
            {
                double r = rgbValues[i + 2];
                double g = rgbValues[i + 1];
                double b = rgbValues[i];
                double l = r * 0.299 + g * 0.587 + b * 0.114;
                byte newL = map[(int)l];
                double ratio = (l == 0) ? 1 : newL / l;
                rgbValues[i + 2] = (byte)Math.Clamp(r * ratio, 0, 255);
                rgbValues[i + 1] = (byte)Math.Clamp(g * ratio, 0, 255);
                rgbValues[i] = (byte)Math.Clamp(b * ratio, 0, 255);
            }

            // --- Filtro Gaussiano 3x3 para suavizado (pre-unsharp mask) ---
            byte[] blur = new byte[bytes];
            int[] kernel = { 1, 2, 1, 2, 4, 2, 1, 2, 1 };
            int kernelSum = 16;
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    double r = 0, g = 0, b = 0;
                    int k = 0;
                    for (int yy = -1; yy <= 1; yy++)
                    {
                        for (int xx = -1; xx <= 1; xx++, k++)
                        {
                            int pos = ((y + yy) * stride) + (x + xx) * bpp;
                            b += rgbValues[pos] * kernel[k];
                            g += rgbValues[pos + 1] * kernel[k];
                            r += rgbValues[pos + 2] * kernel[k];
                        }
                    }
                    int p = (y * stride) + (x * bpp);
                    blur[p] = (byte)(b / kernelSum);
                    blur[p + 1] = (byte)(g / kernelSum);
                    blur[p + 2] = (byte)(r / kernelSum);
                }
            }

            // --- Unsharp Mask (enfoque) ---
            double factor = sharpenAmount / 100.0;
            for (int i = 0; i < bytes; i += bpp)
            {
                double r = rgbValues[i + 2];
                double g = rgbValues[i + 1];
                double b = rgbValues[i];
                double rb = blur[i + 2];
                double gb = blur[i + 1];
                double bb = blur[i];
                rgbValues[i + 2] = (byte)Math.Clamp(r + factor * (r - rb), 0, 255);
                rgbValues[i + 1] = (byte)Math.Clamp(g + factor * (g - gb), 0, 255);
                rgbValues[i] = (byte)Math.Clamp(b + factor * (b - bb), 0, 255);
            }

            // Copiar de vuelta al bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            bmp.UnlockBits(data);

            ImagenResultado = bmp;
            MostrarResultado();
        }
        private void mJRGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImagenOriginal == null) return;

            int sharpenAmount = 50;
            if (!int.TryParse(textBox1.Text, out sharpenAmount)) sharpenAmount = 50;
            sharpenAmount = Math.Clamp(sharpenAmount, 0, 200);

            Bitmap bmp = new Bitmap(ImagenOriginal);
            int width = bmp.Width;
            int height = bmp.Height;

            // Bloquear bits para acceso directo
            Rectangle rect = new Rectangle(0, 0, width, height);
            System.Drawing.Imaging.BitmapData data = bmp.LockBits(rect,
                System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            int bpp = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
            int stride = data.Stride;
            IntPtr ptr = data.Scan0;
            int bytes = Math.Abs(stride) * height;
            byte[] rgbValues = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            // --- Ecualizar histograma por canal RGB independientemente ---

            // Calcular histogramas para cada canal
            int[] histR = new int[256];
            int[] histG = new int[256];
            int[] histB = new int[256];

            for (int i = 0; i < bytes; i += bpp)
            {
                histR[rgbValues[i + 2]]++;  // R
                histG[rgbValues[i + 1]]++;  // G
                histB[rgbValues[i]]++;      // B
            }

            int totalPixeles = width * height;

            // Crear mapas de transformación CDF para cada canal
            byte[] mapR = CrearMapaEcualizacion(histR, totalPixeles);
            byte[] mapG = CrearMapaEcualizacion(histG, totalPixeles);
            byte[] mapB = CrearMapaEcualizacion(histB, totalPixeles);

            // Aplicar ecualización por canal
            for (int i = 0; i < bytes; i += bpp)
            {
                rgbValues[i + 2] = mapR[rgbValues[i + 2]];  // R
                rgbValues[i + 1] = mapG[rgbValues[i + 1]];  // G
                rgbValues[i] = mapB[rgbValues[i]];          // B
            }

            // --- Filtro Gaussiano 3x3 para suavizado ---
            byte[] blur = new byte[bytes];
            int[] kernel = { 1, 2, 1, 2, 4, 2, 1, 2, 1 };
            int kernelSum = 16;

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    double r = 0, g = 0, b = 0;
                    int k = 0;
                    for (int yy = -1; yy <= 1; yy++)
                    {
                        for (int xx = -1; xx <= 1; xx++, k++)
                        {
                            int pos = ((y + yy) * stride) + (x + xx) * bpp;
                            b += rgbValues[pos] * kernel[k];
                            g += rgbValues[pos + 1] * kernel[k];
                            r += rgbValues[pos + 2] * kernel[k];
                        }
                    }
                    int p = (y * stride) + (x * bpp);
                    blur[p] = (byte)(b / kernelSum);
                    blur[p + 1] = (byte)(g / kernelSum);
                    blur[p + 2] = (byte)(r / kernelSum);
                }
            }

            // --- Unsharp Mask (enfoque) ---
            double factor = sharpenAmount / 100.0;
            for (int i = 0; i < bytes; i += bpp)
            {
                double r = rgbValues[i + 2];
                double g = rgbValues[i + 1];
                double b = rgbValues[i];
                double rb = blur[i + 2];
                double gb = blur[i + 1];
                double bb = blur[i];
                rgbValues[i + 2] = (byte)Math.Clamp(r + factor * (r - rb), 0, 255);
                rgbValues[i + 1] = (byte)Math.Clamp(g + factor * (g - gb), 0, 255);
                rgbValues[i] = (byte)Math.Clamp(b + factor * (b - bb), 0, 255);
            }

            // Copiar de vuelta al bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            bmp.UnlockBits(data);

            ImagenResultado = bmp;
            MostrarResultado();
        }
        private byte[] CrearMapaEcualizacion(int[] histograma, int totalPixeles)
        {
            // Calcular CDF (Función de Distribución Acumulativa)
            int[] cdf = new int[256];
            int acumulado = 0;
            for (int i = 0; i < 256; i++)
            {
                acumulado += histograma[i];
                cdf[i] = acumulado;
            }

            // Encontrar el primer valor no cero del CDF
            int cdfMin = 0;
            for (int i = 0; i < 256; i++)
            {
                if (cdf[i] > 0)
                {
                    cdfMin = cdf[i];
                    break;
                }
            }

            // Crear mapa de transformación
            byte[] mapa = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                if (cdf[i] == 0)
                {
                    mapa[i] = 0;
                }
                else
                {
                    double valor = ((double)(cdf[i] - cdfMin) / (totalPixeles - cdfMin)) * 255.0;
                    mapa[i] = (byte)Math.Clamp(valor, 0, 255);
                }
            }

            return mapa;
        }
    }
}