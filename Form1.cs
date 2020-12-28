using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conway
{
    public partial class Form1 : Form
    {

        Graphics graphics;
        Pen gridPen = new Pen(Color.Black);
        SolidBrush squareBrush = new SolidBrush(Color.Yellow);
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            graphics = pictureBox.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int areaSize = 30;
            int squarePixels = 15;
            int lineSize = 1;
            for (int i = 0; i <= areaSize; i++)
            {
                int x = i * squarePixels;
                graphics.DrawLine(gridPen, x, 0, x, areaSize * squarePixels);
            }

            for (int i = 0; i <= areaSize; i++)
            {
                int y = i * squarePixels;
                graphics.DrawLine(gridPen, 0, y, areaSize * squarePixels, y);
            }


            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(0, areaSize) * squarePixels + lineSize;
                int y = random.Next(0, areaSize) * squarePixels + lineSize;
                int fillSize = squarePixels - lineSize;
                graphics.FillRectangle(squareBrush, new Rectangle(x, y, fillSize, fillSize));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
