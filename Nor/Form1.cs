using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nor
{
    public partial class Form1 : Form
    {
        Cloud cloudDemo;
        MyGraphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cloudDemo = new Cloud();
            double[] x = cloudDemo.RndAngleDU(10, Math.PI * 2, 10, 0.2);
            foreach(double d in x)
            {
                listBox1.Items.Add(d.ToString("0.0000"));
            }
            g = new MyGraphics();
            g.InitGraph(pictureBox1);
            PointF[] crt = cloudDemo.PolygN(new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2), 20, 200, 100);
            cloudDemo.Draw(g.grp, crt);
            g.RefreshGraph();
        }
    }
}
