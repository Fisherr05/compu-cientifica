using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppPixelcito
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int tamanoX = 650;
        int tamanoY = 500;

        Bitmap lienzo = new Bitmap(650, 500);

        Color[] paleta1 = new[]
        {
            Color.Black,        //0
            Color.Navy,         //1
            Color.Green,        //2
            Color.Aqua,         //3
            Color.Red,          //4
            Color.Purple,       //5
            Color.Maroon,       //6 //ojo
            Color.LightGray,    //7
            Color.DarkGray,     //8
            Color.Blue,         //9
            Color.Lime,         //10
            Color.Silver,       //11
            Color.Teal,         //12
            Color.Fuchsia,      //13
            Color.Yellow,       //14
            Color.White         //15
        };

        private void PintaFondo(Color fondo)
        {
            for (int i = 0; i < tamanoX; i++)
            {
                for (int j = 0; j < tamanoY; j++)
                {
                    lienzo.SetPixel(i, j, fondo);
                }
            }
        }

        private void PintaFondoBlanco()
        {
            PintaFondo(Color.White);
        }
        private int InterpolaPlano(int y1, int y2, double x)
        {
            int x1 = 0;
            int x2 = 500;
            int y = 0;
            y = (int)((x - x1) * (y2 - y1) / (x2 - x1)) + y1;
            return y;
        }

        private int Interpola(int y1, int y2, double x, int x2)
        {
            int x1 = 0;
            int y = 0;
            y = (int)((x - x1) * (y2 - y1) / (x2 - x1)) + y1;
            return y;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PintaFondo(Color.White);
            Color color1 = Color.Red;
            Color color2 = Color.Blue;
            Color color3 = Color.Green;
            int i, j;
            for (i = 0; i < tamanoX; i++)
            {
                for (j = 0; j < tamanoY; j++)
                {
                    if (j < 200)
                    {
                        lienzo.SetPixel(i, j, color1);
                    }
                    else if (j >= 200 && j < 400)
                    {
                        lienzo.SetPixel(i, j, color2);
                    }
                    else
                    {
                        lienzo.SetPixel(i, j, color3);
                    }
                }
            }
            pictureBox1.Image = lienzo;
        }

        private void BTNDibuja2_Click(object sender, EventArgs e)
        {
            PintaFondo(Color.White);
            /*Vector TVector = new Vector();
            TVector.x0 = 4;
            TVector.y0 = 2.5;
            TVector.color0 = Color.Red;
            TVector.Encender(lienzo);*/
            Segmento segmento = new Segmento();
            segmento.x0 = -3; segmento.y0 = 1;//punto 1
            segmento.xf = 5; segmento.yf = 4;//punto 2
            segmento.color0 = Color.Red;
            segmento.Encender(lienzo);
            pictureBox1.Image = lienzo;
        }

        private void BTNLimpia_Click(object sender, EventArgs e)
        {
            PintaFondo(Color.White);
            pictureBox1.Image = lienzo;
        }

        private void BTNCircunferencia_Click(object sender, EventArgs e)
        {
            Circunferencia c = new Circunferencia();
            c.Radio = 1.0;
            c.x0 = 0;
            c.y0 = 0;
            /*do
            {
                c.color0 = Color.Blue;
                c.Encender(lienzo);
                c.x0 = c.x0 + 0.2;
            } while (c.x0 <= 8);*/
            //c.color0 = Color.FromArgb(255, 255, 255);
            c.color0 = Color.Blue;
            c.Encender(lienzo);
            pictureBox1.Image = lienzo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Circunferencia c = new Circunferencia();
            Segmento s = new Segmento();
            c.Radio = 2.0;
            c.x0 = 4;
            c.y0 = 2.5;
            c.color0 = Color.Black;
            c.Encender(lienzo);
            pictureBox1.Image = lienzo;
            c.Radio = 1.0;
            c.x0 = -4;
            c.y0 = -2.5;
            c.color0 = Color.Black;
            c.Encender(lienzo);
            pictureBox1.Image = lienzo;
            s.x0 = -5;
            s.xf = 5.5;
            s.y0 = -3;
            s.yf = 3.5;
            s.color0 = Color.Red;
            s.Encender(lienzo);
            pictureBox1.Image = lienzo;
            s.x0 = -1;
            s.xf = 1;
            s.y0 = 4;
            s.yf = -4;
            s.color0 = Color.Red;
            s.Encender(lienzo);
            pictureBox1.Image = lienzo;
            s.x0 = -5;
            s.xf = 5;
            s.y0 = 3;
            s.yf = 5;
            s.color0 = Color.Red;
            s.Encender(lienzo);
            pictureBox1.Image = lienzo;
        }

        private void BNTApaga_Click(object sender, EventArgs e)
        {
            Circunferencia c = new Circunferencia();
            c.Radio = 1.0;
            c.x0 = -8;
            c.y0 = 0;
            do
            {
                c.color0 = paleta1[6];
                c.Encender(lienzo);
                c.x0 = c.x0 + 0.3;
                pictureBox1.Refresh();
                Thread.Sleep(30);
                c.apagar(lienzo);
                pictureBox1.Image = lienzo;
            } while (c.x0 <= 8);
            /*Circunferencia c = new Circunferencia();
            double x = -8;
            c.Radio = 1.0;
            c.x0 = 0;
            c.y0 = 0;
            c.color0 = Color.Blue;
            c.Encender(lienzo);
            pictureBox1.Refresh();
            Thread.Sleep(2000);
            c.apagar(lienzo);
            pictureBox1.Image = lienzo;*/
            /*Circunferencia c = new Circunferencia();
            double x = -7;
            double y = 0.1;
            c.x0 = 0;
            c.y0 = 0;
            do
            {
                c.Radio = y;
                c.x0 = x;
                //c.y0 = Math.Sin(x);
                c.color0 = Color.Blue;
                c.Encender(lienzo);
                pictureBox1.Refresh();
                Thread.Sleep(13);
                x = x + 0.02;
                c.apagar(lienzo);
                pictureBox1.Image = lienzo;
                y += 0.02;
            } while (x <= 7);*/
        }

        private void BTNPaleta_Click(object sender, EventArgs e)
        {
            Color[] paleta2 = new Color[16];
            int c;
            for (int k = 0; k < 16; k++)
                paleta2[k] = Color.FromArgb(255, 17 * k, 0);
            for (int x = 0; x < tamanoX; x++)
            {
                for (int y = 0; y < tamanoY; y++)
                {
                    c = (int)(4 * Math.Pow(x, 2) + 9 * x * y) % 15;
                    lienzo.SetPixel(x, y, paleta2[c]);
                }
            }
            pictureBox1.Image = lienzo;
        }

        private void BTNOrbita_Click(object sender, EventArgs e)
        {
            Circunferencia c = new Circunferencia();
            c.Radio = 3.0;
            c.x0 = 0;
            c.y0 = 0;
            c.color0 = Color.Black;
            c.Encender(lienzo);

            c.Radio = 5.0;
            c.x0 = 0;
            c.y0 = 0;
            c.color0 = Color.Black;
            c.Encender(lienzo);

            c.Radio = 0.4;
            //c.x0 = 0;
            //c.y0 = -4;
            //c.color0 = Color.Green;
            double iterador = 0.05;
            double radio = 4;

            do
            {
                c.x0 = 0 + radio * Math.Sin(iterador);
                c.y0 = 0 + radio * Math.Cos(iterador);
                c.color0 = Color.Green;
                c.Encender(lienzo);
                pictureBox1.Refresh();
                Thread.Sleep(13);
                c.apagar(lienzo);
                pictureBox1.Image = lienzo;
                iterador += 0.1;
            } while (iterador <= (2 * Math.PI));

            pictureBox1.Image = lienzo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)//btnorbita
        {
            /*double t = -8;
            Circunferencia c = new Circunferencia();
            c.Radio = 0.3;
            do
            {
                c.x0 = t;
                c.y0 = ((64 - (Math.Pow(c.x0, 2))) / 11);
                c.color0 = Color.Brown;
                c.Encender(lienzo);
                pictureBox1.Refresh();
                Thread.Sleep(13);
                c.apagar(lienzo);
                pictureBox1.Image = lienzo;
                t += 0.2;
            } while (t <= 8);
            */

            Circunferencia c = new Circunferencia();
            Segmento s = new Segmento();
            c.x0 = 0;
            c.y0 = 0;
            c.Radio = 4;
            c.color0 = Color.Blue;
            c.Encender(lienzo);
            double t = 0.05;

            do
            {
                s.x0 = 0;
                s.y0 = 0;
                s.xf = (0 + 3.5 * Math.Sin(t));
                s.yf = (0 + 3.5 * Math.Cos(t));
                s.color0 = Color.Red;
                s.Encender(lienzo);
                pictureBox1.Image = lienzo;
                pictureBox1.Refresh();
                Thread.Sleep(13);
                t = t + 0.1;
                s.apagar(lienzo);
                pictureBox1.Image = lienzo;
            } while (t < 2 * Math.PI);

        }

        private void button2_Click_2(object sender, EventArgs e)//btnonda
        {
            Onda o = new Onda();
            double t = 0;
            //Sin animacion
            o.v = 9.3;
            o.w = 1.5;
            o.t = t;
            o.grafOnda(lienzo);
            //o.grafOnda(lienzo);
            pictureBox1.Image = lienzo;
        }

        private void BTNInterferencia_Click(object sender, EventArgs e)
        {
            Onda o = new Onda();
            double h = 0;

            do
            {
                o.v = 9.3;
                o.w = 1.5;
                o.grafOnda(lienzo);
                pictureBox1.Image = lienzo;
                pictureBox1.Refresh();
                h = h + 0.1;
                o.t = h;
            } while (h <= 3);
        }

        private void BTNHiperboloide_Click(object sender, EventArgs e)
        {
            SuperficieV s = new SuperficieV();
            int tipo = 2;
            s.color0 = Color.Red;
            s.tipo = tipo;
            s.Radio = 2;
            s.Encender(lienzo);
            pictureBox1.Image = lienzo;
        }

        private void BTNPractica_Click(object sender, EventArgs e)
        {
            Vector3D w = new Vector3D();
            double h = 0;
            w.color0 = Color.Red;
            /*do
            {
                w.x0 = 1 + (3 - (h / 5)) * Math.Sin(h);
                w.y0 = -1 + (4 - (h / 5)) * Math.Cos(h);
                w.z0 = (h / 3) - 2;
                w.Encender(lienzo);
                h = h + 0.005;
                pictureBox1.Image = lienzo;
            } while (h <= 15);*/

            do
            {
                double t = 0;
                do
                {
                    w.x0 = -2 + 3 * Math.Cos(t);
                    w.z0 = h - 3;
                    w.y0 = 1 + 3 * Math.Sin(t);
                    w.Encender(lienzo);
                    pictureBox1.Image = lienzo;
                    t = t + 0.1;


                } while (t <= 15);
                h = h + 0.1;
            } while (h <= 6.3);
        }

        private void BTNAOnda_Click(object sender, EventArgs e)
        {
            Onda o = new Onda();
            double t = 0;
            do
            {
                o.v = 9.3;
                o.w = 1.5;
                o.interferencia2(lienzo);
                pictureBox1.Image = lienzo;
                pictureBox1.Refresh();
                t = t + 0.1;
                o.t = t;
            } while (t <= 3);
        }

        private void BTNOnda3d_Click(object sender, EventArgs e)
        {
            Vector3D v3d = new Vector3D();
            double x, y, p, d, m, w, v, t, z1, z2;
            x = -7;
            m = 0.5;
            w = 2.5;//si se invrementa se unen mas las ondas si se disminuye se reduce (0,-3);(0,3)
            v = 9.3;
            t = 0.1;
            do
            {
                y = -6;
                do
                {
                    v3d.x0 = x;
                    v3d.y0 = y;
                    v3d.color0 = Color.Green;
                    d = (Math.Sqrt((x - 0) * (x - 0) + (y - 3) * (y - 3)));
                    p = w * (d - v * t);
                    z1 = m * Math.Sin(p);
                    d = (Math.Sqrt((x - 0) * (x - 0) + (y + 3) * (y + 3)));
                    p = w * (d - v * t);
                    z2 = m * Math.Sin(p);
                    v3d.z0 = z1 + z2;
                    v3d.Encender(lienzo);
                    pictureBox1.Image = lienzo;
                    pictureBox1.Refresh();
                    Thread.Sleep(13);
                    y = y + 0.05;

                } while (y <= 6);
                x = x + 0.05;
            } while (x <= 7);
        }

        private void BTNOndaAnima3d_Click(object sender, EventArgs e)
        {
            Onda o = new Onda();
            double t = 0;
            o.v = 9.3;
            o.w = 1.5;
            do
            {
                o.t = t;
                o.grafOnda3d(lienzo);
                pictureBox1.Image = lienzo;
                Refresh();
                lienzo = null;
                lienzo = new Bitmap(650, 500);
                Thread.Sleep(5);
                t = t + 0.01;
            } while (t <= 4);
        }

        private void BTNInterferencia3D_Click(object sender, EventArgs e)
        {
            Onda o = new Onda();
            double t = 0;
            o.v = 9.3;
            o.w = 1.5;
            do
            {
                o.t = t;
                o.ondaMoverx2(lienzo);
                pictureBox1.Image = lienzo;
                Refresh();
                lienzo = null;
                lienzo = new Bitmap(650, 500);
                Thread.Sleep(5);
                t = t + 0.02;
            } while (t <= 4);
        }

        private void BTNCurva_Click(object sender, EventArgs e)
        {
            Segmento s = new Segmento();
            s.x0 = -14;
            s.xf = 14;
            s.y0 = 0;
            s.yf = 0;
            s.color0 = Color.Red;
            s.Encender(lienzo);
            s.x0 = 0;
            s.xf = 0;
            s.y0 = -10.77;
            s.yf = 10.77;
            s.color0 = Color.Red;
            s.Encender(lienzo);

            double x;


            Vector v = new Vector();
            x = -14;

            v.color0 = Color.Blue;
            do
            {
                v.x0 = x;
                v.y0 = (-((x + 14) * (x - 14)) / 24.5);
                v.Encender(lienzo);
                pictureBox1.Image = lienzo;
                x += 0.01;
            } while (x <= 14);
        }

        private double Tangente(double cX, double limite)
        {
            double Y0 = (-(cX + 14) * (cX - 14) / 24.5);
            double m = (-2 * cX / 24.5);
            double Y1 = m * (limite - cX);
            double Y2 = Y1 + Y0;
            return Y2;
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //int pX, pY;
            //double cX, cY;
            //Circunferencia c = new Circunferencia();
            //pX = e.X;
            //pY = e.Y;
            //c.transforma(pX, pY, out cX, out cY);
            //c.Radio = 0.2;
            //c.x0 = cX;
            //c.y0 = cY;

            //int limite = 0;
            ////double Y0 = (-(cX + 14) * (cX - 14) / 24.5);
            ////double m = (-2 * cX / 24.5);
            ////double Y1 = m * (limite - cX);
            ////double Y2 = Y1 + Y0;

            ////double alfa = Math.Atan(m);

            //////double gamma = 90 + (2 * alfa);
            ////double mDeRefexlion = Math.Tan(gamma);

            //c.color0 = Color.Black;
            //c.Encender(lienzo);

            //Segmento s = new Segmento();
            //s.x0 = cX; s.y0 = cY;//punto inicial
            //s.xf = cX; s.yf = (-(cX + 14) * (cX - 14) / 24.5);//punto final
            //s.color0 = Color.Red;
            //s.Encender(lienzo);


            //limite = -14;
            //s.x0 = limite; s.y0 = Tangente(cX, limite); ; ;//punto inicial
            //limite = 14;
            //s.xf = limite; s.yf = Tangente(cX, limite); ;//punto final
            //s.color0 = Color.Green;
            //s.Encender(lienzo);

            ////double xp=;
            //double prX = cX < 0 ? 14 : -14;
            //s.xf = prX;
            //double alpha = Math.Atan(((-2 * cX) / 24.5));
            //double gamma = 90 + (2 * alpha);
            //double m = Math.Tan(gamma);
            //double prY = (m * (prX - cX)) + cY;
            //s.x0 = limite; s.y0 = Tangente(cX, limite);//punto inicial
            //s.xf = limite; s.yf = (-(cX + 14) * (cX - 14) / 24.5);//punto final
            //s.color0 = Color.Yellow;
            //s.Encender(lienzo);




            //pictureBox1.Image = lienzo;
            //Console.WriteLine("X=" + cX.ToString());
            //Console.WriteLine("Y=" + cY.ToString());
            double x, y;
            int i = e.X;
            int j = e.Y;

            Vector vec = new Vector();
            vec.transforma(i, j, out x, out y);
            //lblPosClick.Text = "X= " + Math.Round(x, 2) + " ; Y=" + Math.Round(y, 2);

            // point
            Circunferencia c = new Circunferencia();
            c.color0 = Color.Blue;
            c.x0 = x;
            c.y0 = y;
            c.Radio = 0.2;
            c.Encender(lienzo);
            pictureBox1.Image = lienzo;
            Thread.Sleep(20);

            // rayo
            Segmento s = new Segmento();
            s.color0 = Color.Red;
            s.x0 = x;
            s.y0 = y;
            double xp = x;
            double yp = -(((x + 14) * (x - 14)) / 24.5);
            s.xf = xp;
            s.yf = yp;
            s.Encender(lienzo);
            pictureBox1.Image = lienzo;

            // tangente
            Segmento tg = new Segmento();
            tg.color0 = Color.Green;
            tg.x0 = -14;
            tg.y0 = ((-2 * x) / (24.5)) * (-14 - xp) + yp;

            tg.xf = 14;
            tg.yf = ((-2 * x) / (24.5)) * (14 - xp) + yp;
            tg.Encender(lienzo);
            pictureBox1.Image = lienzo;

            // proyección
            Segmento pr = new Segmento();
            pr.color0 = Color.Orange;
            pr.x0 = xp;
            pr.y0 = yp;

            double prX = xp < 0 ? 14 : -14;
            pr.xf = prX;
            double alpha = Math.Atan(((-2 * x) / 24.5));
            double gamma = 90 + (2 * alpha);
            double m = Math.Tan(gamma);
            double prY = (m * (prX - xp)) + yp;

            pr.yf = prY;

            pr.Encender(lienzo);
            pictureBox1.Image = lienzo;

            Console.WriteLine("X=" + x.ToString());
            Console.WriteLine("Y=" + y.ToString());

        }

        private void BTNCuerda_Click(object sender, EventArgs e)
        {
            Segmento S = new Segmento();
            CuerdaV cv = new CuerdaV();

            //Sin Animacion
            //S.x0 = -14;
            //S.xf = 14;
            //S.y0 = 0;
            //S.yf = 0;
            //S.color0 = Color.Blue;
            //S.Encender(lienzo);
            //S.x0 = 0;
            //S.xf = 0;
            //S.y0 = -10.77;
            //S.yf = 10.77;
            //S.color0 = Color.Blue;
            //S.Encender(lienzo);
            //cv.tiempo = 3;
            //cv.GraficoFourier(lienzo);
            //pictureBox1.Image = lienzo;

            //Animacion
            double t = 0;
            do
            {
                S.x0 = -14;
                S.xf = 14;
                S.y0 = 0;
                S.yf = 0;
                S.color0 = Color.Red;
                S.Encender(lienzo);
                S.x0 = 0;
                S.xf = 0;
                S.y0 = -10.77;
                S.yf = 10.77;
                S.color0 = Color.Red;
                S.Encender(lienzo);
                cv.tiempo = t;
                cv.GraficoFourier(lienzo);
                pictureBox1.Image = lienzo;
                Refresh();
                lienzo = null;
                lienzo = new Bitmap(650, 500);
                Thread.Sleep(3);
                t = t + 0.5;
            } while (t <= 16);



            pictureBox1.Image = lienzo;
        }

        private void BTNPrueba_Click(object sender, EventArgs e)
        {
            Onda o = new Onda();
            o.v = 9.3;
            o.w = 1.5;
            o.interferencia3(lienzo);
            pictureBox1.Image = lienzo;
        }

        private void BTNRecu_Click(object sender, EventArgs e)
        {
            
            double x1 = -1, y1 = 2;//punto P
            double x2 = 3, y2 = 1;//punto Q
            double x3 = 4, y3 = Math.Sqrt(4.25 - Math.Pow(x3-2,2))+3;//punto R
            Segmento s = new Segmento();
            s.x0 = x1; s.y0 = y1;
            s.xf = x3;s.yf = y3;
            s.color0 = Color.Red;
            s.Encender(lienzo);
            s.xf = x2; s.yf = y2;
            s.color0 = Color.Blue;
            s.Encender(lienzo);
            s.x0 = x3; s.y0 = y3;
            s.color0 = Color.Black;
            s.Encender(lienzo);
            pictureBox1.Image = lienzo;
        }
    }
}
