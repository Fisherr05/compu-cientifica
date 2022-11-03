using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppPixelcito
{
    class Vector
    {
        public static int sx1 = 0;
        public static int sx2 = 650;
        public static int sy1 = 0;
        public static int sy2 = 500;
        //public static double x1 = -8;
        //public static double x2 = 8;
        //public static double y1 = -6.15;
        //public static double y2 = 6.15;
        public static double x1 = -14/2;
        public static double x2 = 14/2;
        public static double y1 = -10.77/2;
        public static double y2 = 10.77/2;
        public double x0 { get; set; }
        public double y0 { get; set; }
        public Color color0 { get; set; }
        public Vector() { }

        public Vector(double x0, double y0, Color color0)
        {
            this.x0 = x0;
            this.y0 = y0;
            this.color0 = color0;
        }

        public virtual void Encender(Bitmap lienzo)
        {
            int sx, sy;

            Procesos.pantalla(this.x0, this.y0, out sx, out sy);
            if (sx > 0 && sx < 650 && sy > 0 && sy < 500)
            {
                lienzo.SetPixel(sx, sy, color0);
            }

        }
        public virtual void apagar(Bitmap lienzo)
        {

            this.color0 = Color.White;
            Encender(lienzo);

        }
        public void transforma(int sx, int sy, out double x, out double y)
        {
            x = (((sx - sx2) * (x2 - x1)) / (sx2 - sx1)) + x2;
            y = (((sy - sy1) * (y1 - y2)) / (sy2 - sy1)) + y2;
        }
    }
}
