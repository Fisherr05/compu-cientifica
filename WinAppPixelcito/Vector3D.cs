using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppPixelcito
{
    class Vector3D:Vector
    {
        public double z0;
        public override void Encender(Bitmap bitmap)
        {
            double ax, ay;
            int Sx, Sy;
            Procesos.asonometria(x0, y0, z0, out ax, out ay);
            Procesos.pantalla(ax, ay, out Sx, out Sy);

            if (Sx >= 0 && Sx < 650 && Sy >= 0 && Sy < 500)
            {
                bitmap.SetPixel(Sx, Sy, color0);
            }
        }
    }
}
