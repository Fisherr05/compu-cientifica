using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppPixelcito
{
    class Circunferencia : Vector
    {
        public Circunferencia()
        {
        }
        public double Radio;
        public override void Encender(Bitmap lienzo)
        {
            Vector objVector = new Vector();
            double t, dt;
            t = 0;
            dt = 0.001;
            do
            {
                objVector.x0 = x0 + (Radio * (Math.Cos(t)));
                objVector.y0 = y0 + (Radio * (Math.Sin(t)));
                objVector.color0 = color0;
                objVector.Encender(lienzo);
                t = t + dt;
            } while (t <= (2 * Math.PI));
        }
    }
}
