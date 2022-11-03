using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppPixelcito
{
    class Procesos
    {
        public static int sx1 = 0;
        public static int sx2 = 650;
        public static int sy1 = 0;
        public static int sy2 = 500;
        public static double x1 = -14/2;
        public static double x2 = 14/2;
        public static double y1 = -10.77/2;
        public static double y2 = 10.77/2;
        //public static double x1 = -8;
        //public static double x2 = 8;
        //public static double y1 = -6.15;
        //public static double y2 = 6.15;
        public Procesos() { }
        public static void pantalla(double x, double y, out int sx, out int sy)
        {
            sx = (int)((((sx1 - sx2) / (x1 - x2)) * (x - x2)) + sx2);
            sy = (int)((((sy1 - sy2) / (y2 - y1)) * (y - y1)) + sy2);
        }

        public static void transforma(int sx, int sy, out double x, out double y)
        {
            x = (((sx - sx2) * (x2 - x1)) / (sx2 - sx1)) + x2;
            y = (((sy - sy1) * (y1 - y2)) / (sy2 - sy1)) + y2;     
        }

        public static void RealXY(int sx, int sy, out double x, out double y)
        {
            x = (((sx - sx2) * (x2 - x1)) / (sx2 - sx1)) + x2;
            y = (((sy - sy1) * (y1 - y2)) / (sy2 - sy1)) + y2;
        }
        public static void asonometria(double X0, double Y0, double Z0, out double AX, out double AY)
        {
            AX = X0 + (0.5) * Y0 * Math.Cos(0.8);
            AY = (0.5) * Y0 * Math.Sin(0.8) + Z0;
        }


    }
}
