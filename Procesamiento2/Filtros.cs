using System;
using System.Drawing;

namespace Procesamiento2
{
    public static class Filtros
    {
        public static Color Rojo(Color c) => Color.FromArgb(255, (c.R + c.G + c.B) / 3, 0, 0);
        public static Color Verde(Color c) => Color.FromArgb(255, 0, (c.R + c.G + c.B) / 3, 0);
        public static Color Azul(Color c) => Color.FromArgb(255, 0, 0, (c.R + c.G + c.B) / 3);
        public static Color RojoSinCanales(Color c, int aclarado = 50) =>
            Color.FromArgb(255, Math.Min(255, c.R + aclarado), 0, 0);
        public static Color Cian(Color c) => Color.FromArgb(255, 0, (c.R + c.G + c.B) / 3, (c.R + c.G + c.B) / 3);
        public static Color Magenta(Color c) => Color.FromArgb(255, (c.R + c.G + c.B) / 3, 0, (c.R + c.G + c.B) / 3);
        public static Color EscalaGrises(Color c)
        {
            int gris = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
            return Color.FromArgb(255, gris, gris, gris);
        }
        public static Color BlancoNegro(Color c)
        {
            int gris = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
            return gris >= 128 ? Color.White : Color.Black;
        }
        public static Color Sepia(Color c)
        {
            int tr = Math.Min(255, (int)(0.393 * c.R + 0.769 * c.G + 0.189 * c.B));
            int tg = Math.Min(255, (int)(0.349 * c.R + 0.686 * c.G + 0.168 * c.B));
            int tb = Math.Min(255, (int)(0.272 * c.R + 0.534 * c.G + 0.131 * c.B));
            return Color.FromArgb(255, tr, tg, tb);
        }
        public static Color Negativo(Color c) => Color.FromArgb(255, 255 - c.R, 255 - c.G, 255 - c.B);
        public static Color Ejercicio2_Franzas(Color c, int y, int alto)
        {
            int v = (c.R + c.G + c.B) / 3;
            if (y < alto / 3)
                return Color.FromArgb(255, v, 0, 0); // rojo
            else if (y < 2 * alto / 3)
                return Color.FromArgb(255, v, v, 0); // amarillo
            else
                return Color.FromArgb(255, 0, v, 0); // verde
        }

        // ==============================
        // Ejercicio 3 – Parte 2: Diagonal Blanco/Negro
        // ==============================
        public static Color Ejercicio3_Diagonal(Color c, int x, int y, int ancho, int alto)
        {
            int gris = (c.R + c.G + c.B) / 3;

            if (y < (-1.0 * alto / ancho) * x + alto)
                return Color.FromArgb(255, gris, gris, gris);
            else
                return gris > 128 ? Color.White : Color.Black;
        }
    }
}
