using System;
using System.Drawing;

namespace WinAppPixelcito
{
    class CuerdaV : Vector
    {
        public double tiempo;
        public CuerdaV() { }

        double fx(int x)
        {
            double f = (-x * (x - 8) / 3);
            return f;
        }
        int gx(int x)
        {
            int g = x;
            return g;
        }
        public void Fourier(double x, out double fou)
        {
            double an, bn, SumF, c = 1, g = 2, l = 8;
            double f = ((x * (8 - x)) / 3);
            //double f = 0.5;
            int n;
            SumF = 0;
            n = 0;
            do
            {
                n = n + 1;
                an = (1.33) * (0 + 4 * 5.33 * Math.Sin(n * 3.14 * 3) + 0 * Math.Sin(n * 3.14 * 7)); //0.5 en ves de 3, f(4 en ves de 3
                an = an * (0.25);
                bn = (1.33) * (0 + 4 * 4 * Math.Sin(n * 3.14 * 3) + 8 * Math.Sin(n * 3.14 * 7));
                bn = bn * 2 / (n * 3.14 * 1);
                SumF = SumF + (an * Math.Cos((n * 3.14 * c * tiempo) / l) + bn * Math.Sin((n * 3.14 * c * tiempo) / l)) * Math.Sin(n * 3.14 * x / l);
            }
            while (n <= 18);
            fou = SumF;
        }
        public void GraficoFourier(Bitmap pantalla)
        {
            double x = 0;
            Vector v = new Vector();
            Segmento s = new Segmento();
            do
            {
                v.x0 = x;
                Fourier(x, out double fou);

                //if (fou <= 10.77)
                //{
                v.y0 = fou;
                v.color0 = Color.DarkGreen;
                v.Encender(pantalla);

                //s.xf = x;
                //s.yf = fou;
                //s.color0 = Color.Blue;
                ////s.Encender(pantalla);
                //s.x0 = x;
                //s.y0 = fou;
                //}
                Console.WriteLine(fou);

                x = x + 0.00055;
            } while (x <= 8);
        }
    }
}