using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppPixelcito
{
    class Onda : Vector
    {
        public double t;
        public int color;
        public Color c;
        public double v, w, w1, w2, x, y, z, z1, z2, z3, m = 0.5;
        public Color[] Paleta = new Color[16];
        public Onda()
        {
            Paleta[0] = Color.Black;
            Paleta[1] = Color.Navy;
            Paleta[2] = Color.Green;
            Paleta[3] = Color.Aqua;
            Paleta[4] = Color.Red;
            Paleta[5] = Color.Purple;
            Paleta[6] = Color.Maroon;
            Paleta[7] = Color.LightGray;
            Paleta[8] = Color.DarkGray;
            Paleta[9] = Color.Blue;
            Paleta[10] = Color.Lime;
            Paleta[11] = Color.Silver;
            Paleta[12] = Color.Teal;
            Paleta[13] = Color.Fuchsia;
            Paleta[14] = Color.Yellow;
            Paleta[15] = Color.White;

            /*for (int k = 0; k < 16; k++)
            {
                int r = Convert.ToInt32((14.8 * k + 2) + 10);
                int g = Convert.ToInt32((3.8 * k + 4) + 194);
                int b = Convert.ToInt32((3.4 * k + 4) + 190);
                Paleta[k] = Color.FromArgb(r, g, b);
            }*/
        }
        public int interpola(int y1, int y2, double x, int x2)
        {
            int x1 = 0;
            double y;
            y = ((x - x1) * (y2 - y1) / (x2 - x1)) + y1;
            return (int)y;
        }

        public double distancia(double x1, double y1, double x2, double y2)
        {
            double distancia = (Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)));
            return distancia;
        }
        public void grafOnda(Bitmap pantalla)
        {

            double aux;
            //Vector ov = new Vector();
            for (int i = 0; i < 650; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    transforma(i, j, out x, out y);
                    aux = w * (Math.Sqrt(x * x + y * y)) - v * t;
                    z = Math.Sin(aux) + 1;
                    color = (int)(z * 7.5);
                    c = Paleta[color];
                    pantalla.SetPixel(i, j, c);
                }
            }
        }

        public void grafOndaDegradado(Bitmap pantalla)
        {
            Color[] paleta2 = new Color[16];
            int maxX = 15;//dominio de las x para interpolar
            for (int k = 0; k < 16; k++)
            {
                paleta2[k] = Color.FromArgb(0, interpola(0, 255, k, maxX), interpola(100, 255, k, maxX));
            }
            double aux;
            //Vector ov = new Vector();
            for (int i = 0; i < 650; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    transforma(i, j, out x, out y);
                    aux = w * (Math.Sqrt(x * x + y * y)) - v * t;
                    z = Math.Sin(aux) + 1;
                    color = (int)Math.Truncate(z * 7.5);
                    c = paleta2[color];
                    pantalla.SetPixel(i, j, c);
                }
            }
        }

        //Interferencia 2 Ondas
        public void interferencia(Bitmap pantalla)
        {
            int i, j, colorO;

            for (i = 0; i < 650; i++)
            {
                for (j = 0; j < 500; j++)
                {
                    Procesos.transforma(i, j, out x, out y);
                    z1 = w * (Math.Sqrt((x - 0) * (x - 0) + (y - 3) * (y - 3))) - v * t;
                    z2 = w * (Math.Sqrt((x - 0) * (x - 0) + (y + 3) * (y + 3))) - v * t;
                    z3 = w * (Math.Sqrt((x - 0.5) * (x - 0.5) + (y + 0.5) * (y + 0.5))) - v * t;//tercera onda...

                    z1 = Math.Sin(z1) + 1;
                    z2 = Math.Sin(z2) + 1;
                    z3 = Math.Sin(z3) + 1;

                    z = z1 + z2 + z3;
                    colorO = (int)Math.Truncate(z * 1.75);
                    c = Paleta[colorO];
                    pantalla.SetPixel(i, j, c);

                }

            }
        }

        public void interferencia2(Bitmap pantalla)
        {
            Color[] paleta2 = new Color[16];
            int maxX = 15;//dominio de las x para interpolar
            for (int k = 0; k < 16; k++)
            {
                paleta2[k] = Color.FromArgb(0, interpola(0, 255, k, maxX), interpola(100, 255, k, maxX));
            }
            int i, j, colorO;
            z = 0;
            for (i = 0; i < 650; i++)
            {
                for (j = 0; j < 500; j++)
                {
                    z = 0;
                    Procesos.transforma(i, j, out x, out y);
                    //z1 = w * (Math.Sqrt((x - 0) * (x - 0) + (y - 3) * (y - 3))) - v * t;
                    //z2 = w * (Math.Sqrt((x - 0) * (x - 0) + (y + 3) * (y + 3))) - v * t;
                    //z3 = w * (Math.Sqrt((x - 0.5) * (x - 0.5) + (y + 0.5) * (y + 0.5))) - v * t;//tercera onda...

                    //z1 = Math.Sin(z1) + 1;
                    //z2 = Math.Sin(z2) + 1;
                    //z3 = Math.Sin(z3) + 1;

                    //z = z1 + z2 + z3;
                    for (int k = -10; k < 11; k++)
                    {
                        z1= w * (Math.Sqrt((x + k) * (x + k) + (y - 0) * (y - 0))) - v * t;
                        z1 = Math.Sin(z1) + 1;
                        z += z1;
                    }
                    colorO = (int)((11+z)%15);
                    c = Paleta[colorO];
                    pantalla.SetPixel(i, j,c );

                }

            }
        }

        public void interferencia3(Bitmap pantalla)
        {
            int i, j, colorO;

            for (i = 0; i < 650; i++)
            {
                for (j = 0; j < 500; j++)
                {
                    Procesos.transforma(i, j, out x, out y);
                    //z1 = w * (Math.Sqrt((x + 1) + (y + 5) * (y + 5))) - v * t;
                    //z2 = w * (Math.Sqrt((x - 3) * (x - 3) + (y + 5) * (y + 5))) - v * t;
                    //z3 = w * (Math.Sqrt((x + 1.2) * (x + 1.2) + (y - 4.46) * (y - 4.46))) - v * t;//tercera onda...
                    //puntos (-4.2,0.2);(1.2,-0.2);(-1.5,4.33)

                    double xt1 = -4;double yt1 = 0 ;//punto uno del triangulo. punto A
                    double xt2 = 1;double yt2 = yt1;//punto dos del triangulo. punto B
                    double distanciaAB = xt2 - xt1;
                    double xtm = (xt1 + xt2)/2;double ytm = (yt1 + yt2)/2;//punto medio entre los dos puntos
                    double xt3 = xtm;
                    double yt3 = Math.Sqrt(Math.Pow(distanciaAB, 2) - Math.Pow(xt3 - xt2, 2))+ytm;
                    if(i==0&&j==0)
                        Console.WriteLine("Punto 3: ("+xt3+";"+yt3+").");

                    double d1 = distancia(xt1, yt1, x, y);
                    double d2 = distancia(xt2, yt2, x, y);
                    double d3 = distancia(xt3, yt3, x, y);
                  

                    z1 = w * d1 - v * t;
                    z2 = w * d2 - v * t;
                    z3 = w * d3 - v * t;//
                    //z1 = w * (Math.Sqrt(Math.Pow(x + 4,2) + Math.Pow(y - 0,2))) - v * t;
                    //z2 = w * (Math.Sqrt(Math.Pow(x - 1,2) + Math.Pow(y + 0,2))) - v * t;
                    //z3 = w * (Math.Sqrt(Math.Pow(x + 1.5,2) + Math.Pow(y - 4.33,2))) - v * t;//

                    z1 = Math.Sin(z1) + 1;
                    z2 = Math.Sin(z2) + 1;
                    z3 = Math.Sin(z3) + 1;

                    z = z1 + z2 + z3; //
                    colorO = (int)(z * 1.75);
                    c = Paleta[colorO];
                    pantalla.SetPixel(i, j, c);


                }

            }
        }
        public void grafOnda3d(Bitmap pantalla)
         {
             Vector3D v3d = new Vector3D();
             x = -7;
             do
             {
                 y = -6;
                 do
                 {
                     v3d.x0 = x;
                     v3d.y0 = y;
                     z = w * (Math.Sqrt((x - 0) * (x - 0) + (y - 0) * (y - 0))) - v * t;
                     z = m * Math.Sin(z);
                     v3d.z0 = z;
                     v3d.color0 = Color.Red;
                     v3d.Encender(pantalla);
                     y = y + 0.05;
                 } while (y <= 6);
                 x = x + 0.1;
             } while (x <= 7);

         }

        public void ondaMoverx2(Bitmap bitmap)
        {
            Vector3D v3d = new Vector3D();
            double p, p2, z, z0;

            x = -10;
            do
            {
                y = -5;
                do
                {
                    v3d.x0 = x;
                    v3d.y0 = y;

                    p = w * (Math.Sqrt((x - 0) * (x - 0) + (y - 3) * (y - 3))) - v * t;
                    z = 0.2 * Math.Sin(p);
                   

                    p2 = w * (Math.Sqrt((x - 0) * (x - 0) + (y + 3) * (y + 3))) - v * t;
                    z0 = 0.2 * Math.Sin(p2);
                    v3d.z0 = z0+z;
                    v3d.color0 = Color.Black;
                    v3d.Encender(bitmap);

                    y = y + 0.1;
                } while (y <= 5);
                x = x + 0.1;
            } while (x <= 10);
        }
    }
}
