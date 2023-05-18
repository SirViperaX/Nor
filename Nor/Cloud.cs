using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nor
{
    public class Cloud
    {
        int n, k;
        public static Random rnd = new Random();
        //cu distribuite neuniforma
        public double[] RndAngle(int n, double target)
        {
            double[] toR = new double[n];
            double suma = 0;
            for (int i = 0; i < n; i++)
            {
                toR[i] = rnd.NextDouble() * (target - suma);
                suma += toR[i];
            }
            return toR;
        }
        //cu distributie uniforma
        public double[] RndAngleDU(int n, double target, int steps, double minValue)
        {
            double[] toR = new double[n];
            for(int i = 0; i < n; i++)
            {
                toR[i] = minValue;
            }
            double k = (target - n * minValue) / steps;
            for(int i = 0;i < steps;i++)
            {
                toR[rnd.Next(n)] += k;
            }
            return toR;
        }
        public PointF[] PolygN(PointF c, int n, double dX, double dY)
        {
            PointF[] toR = new PointF[n];
            double[] a = RndAngleDU(n, Math.PI * 2, 10, 0.1);
            double sum = 0;
            for (int i = 0; i < n; i++) 
            {
                double k = rnd.NextDouble() * 0.5 + 0.5;
                float x = c.X + (float)(k * Math.Cos(sum) * dX);
                float y = c.Y + (float)(k * Math.Sin(sum) * dY);
                toR[i] = new PointF(x, y);
                sum += a[i];
            }
            return toR;
        }
        public void Draw(Graphics g, PointF[] points)
        {
            g.DrawPolygon(Pens.Blue, points);
        }
    }
}
