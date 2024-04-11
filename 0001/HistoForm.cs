using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0001
{
    public partial class HistoForm : Form
    {
        private byte[] bits;
        private byte mayor;

        public HistoForm(byte[] pHistograma)
        {
            InitializeComponent();
            bits = pHistograma;
            int n = 0;

            //Encontramos el mayor;
            for (n = 0; n < 256; n++)
            {
                if (bits[n] > mayor)
                    mayor = bits[n];
            }

            for (n = 0; n < 256; n++)
            {
                bits[n] = (byte)((float)bits[n] / (float)mayor * (256.0f));
            }



        }

        private void HistoForm_Paint(object sender, PaintEventArgs e)
        {
            int n = 0;
            int altura = 0;
            Graphics g = e.Graphics;
            Pen penH = new Pen(Color.Black);
            Pen penAxis = new Pen(Color.Coral);

            g.DrawLine(penAxis, 19, 271, 277, 271);
            g.DrawLine(penAxis, 19, 270, 19, 14);

            for (n = 0; n < 256; n++)
            {
                g.DrawLine(penH, n + 20, 270, n + 20, 270 - bits[n]);
            }
        }
    }
}
