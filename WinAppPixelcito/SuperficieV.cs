using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppPixelcito
{
    class SuperficieV : Vector3D
    {
        public int tipo = 0;
        public double Radio = 0;

        public override void Encender(Bitmap lienzo)
        {
            Vector3D v3d = new Vector3D();
            v3d.color0 = color0;
            if (tipo == 0)
            {
                double t = 0; double dt = 0.05;
                do
                {
                    double h = 0; double dh = 0.05;
                    do
                    {
                        v3d.x0 = x0 + (Radio * Math.Cos(t));
                        v3d.y0 = y0 + (Radio * Math.Sin(t));
                        v3d.z0 = z0 + h;
                        v3d.Encender(lienzo);
                        h = h + dh;
                    } while (h <= 3);
                    t = t + dt;
                } while (t <= 2 * Math.PI);
            }
            else
            {
                if (tipo == 1)
                {
                    double t = (-Math.PI / 2); double dt = 0.05;
                    do
                    {
                        double h = 0; double dh = 0.03;
                        do
                        {
                            v3d.x0 = x0 + (Radio * Math.Cos(t) * Math.Cos(h));
                            v3d.y0 = y0 + (Radio * Math.Cos(t) * Math.Sin(h));
                            v3d.z0 = z0 + Math.Sin(t);
                            v3d.Encender(lienzo);
                            h = h + dh;
                        } while (h <= 2 * Math.PI);
                        t = t + dt;
                    } while (t <= (Math.PI / 2));
                }
                else
                {
                    double t = 0; double dt = 0.01;
                    do
                    {
                        double h = 0; double dh = 0.0125;
                        do
                        {
                            v3d.x0 = x0 + (Radio * (3 + Math.Cos(t)) * Math.Cos(h));
                            v3d.y0 = y0 + (Radio * (3 + Math.Cos(t)) * Math.Sin(h));
                            v3d.z0 = z0 + (Radio * Math.Sin(t));
                            v3d.Encender(lienzo);
                            h = h + dh;
                        } while (h <= 2 * Math.PI);
                        t = t + dt;
                    } while (t <= 2 * Math.PI);
                }
            }
        }
    }
}
