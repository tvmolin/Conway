using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway
{
    class Constants
    {

        public static int AREA_SIZE_X = 73;
        public static int AREA_SIZE_Y = 35;
        public static int TILE_SIZE = 15;
        public static int LINE_SIZE = 1;
        public static int FILL_SIZE = TILE_SIZE - LINE_SIZE;
        public static SolidBrush SQUARE_BRUSH = new SolidBrush(Color.Yellow);
        public static SolidBrush DEAD_BRUSH = new SolidBrush(Color.Gray);

    }
}
