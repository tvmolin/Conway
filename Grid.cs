using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static Conway.Constants;

namespace Conway
{
    class Grid
    {

        private Pen gridPen = new Pen(Color.Black);

        public void render(Graphics graphics)
        {
            for (int i = 0; i <= AREA_SIZE_X; i++)
            {
                int x = i * TILE_SIZE;
                graphics.DrawLine(gridPen, x, 0, x, AREA_SIZE_Y * TILE_SIZE);
            }

            for (int i = 0; i <= AREA_SIZE_Y; i++)
            {
                int y = i * TILE_SIZE;
                graphics.DrawLine(gridPen, 0, y, AREA_SIZE_X * TILE_SIZE, y);
            }
        }
    }
}
