using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Conway.Constants;

namespace Conway
{
    class Tile
    {        
        public Point coordinates { get; }

        public bool alive { get; set; }

        public Tile(Point coordinates)
        {
            this.coordinates = coordinates;
            alive = true;
        }

        public Tile(int tileX, int tileY) : this(new Point(tileX, tileY)) { }
        
        public Tile(int tileX, int tileY, bool alive) : this(new Point(tileX, tileY)) 
        {
            this.alive = alive;
        }

        public void render(Graphics graphics)
        {
            if (alive)
            {
                graphics.FillRectangle(SQUARE_BRUSH, new Rectangle(coordinates.X * TILE_SIZE + LINE_SIZE, coordinates.Y * TILE_SIZE + LINE_SIZE, FILL_SIZE, FILL_SIZE));
            } else
            {
                graphics.FillRectangle(DEAD_BRUSH, new Rectangle(coordinates.X * TILE_SIZE + LINE_SIZE, coordinates.Y * TILE_SIZE + LINE_SIZE, FILL_SIZE, FILL_SIZE));
            }
        }
    }
}
