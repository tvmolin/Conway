using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway
{
    class Game
    {
        private Graphics graphics;
        public int generation { get; set; }

        private Dictionary<Point, Tile> tileList = new Dictionary<Point, Tile>();
        Grid grid = new Grid();

        public Game(Graphics graphics)
        {
            this.graphics = graphics;
            generation = 0;
            render();
        }

        public void advanceLogicStep()
        {

            List<Tile> markedForDeath = new List<Tile>();
            List<Tile> markedForLife = new List<Tile>();

            foreach (var item in tileList)
            {
                Tile tile = item.Value;
                int numberOfNeighbours = countNeighbours(tile);

                if ((numberOfNeighbours < 2 || numberOfNeighbours > 3) && tile.alive)
                {
                    markedForDeath.Add(tile);

                } else if (!tile.alive && numberOfNeighbours == 3)
                {
                    markedForLife.Add(tile);
                }
            }

            foreach (var item in markedForDeath)
            {
                tileList[item.coordinates].alive = false;
            }

            foreach (var item in markedForLife)
            {
                tileList[item.coordinates].alive = true;
                addSurroudingDeadTiles(item);
            }

            generation++;

            render();
        }

        private int countNeighbours(Tile tile)
        {
            int numberOfNeighbours = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {

                    Point coordinateToCheck = tile.coordinates;
                    coordinateToCheck.X += x;
                    coordinateToCheck.Y += y;

                    if (coordinateToCheck.X == tile.coordinates.X && coordinateToCheck.Y == tile.coordinates.Y)
                    {
                        continue;
                    }

                    if (tileList.ContainsKey(coordinateToCheck) && tileList[coordinateToCheck].alive)
                    {
                        numberOfNeighbours++;
                    }
                }
            }

            return numberOfNeighbours;
        }

        internal void reset()
        {
            graphics.Clear(Color.Gray);
            tileList.Clear();
            generation = 0;
            render();
        }

        private void addTile(Tile tile)
        {
            tileList.Add(tile.coordinates, tile);

            addSurroudingDeadTiles(tile);
        }

        private void addSurroudingDeadTiles(Tile tile)
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    Point coordinateToCheck = tile.coordinates;
                    coordinateToCheck.X += x;
                    coordinateToCheck.Y += y;

                    if (coordinateToCheck.X == tile.coordinates.X && coordinateToCheck.Y == tile.coordinates.Y)
                    {
                        continue;
                    }

                    if (!tileList.ContainsKey(coordinateToCheck))
                    {
                        Tile newDeadTile = new Tile(coordinateToCheck.X, coordinateToCheck.Y, false);
                        tileList.Add(newDeadTile.coordinates, newDeadTile);
                    }
                }
            }
        }

        public void toggleTile(Tile tile)
        {
            if(!tileList.ContainsKey(tile.coordinates))
            {
                addTile(tile);
            } else if (!tileList[tile.coordinates].alive)
            {
                tileList[tile.coordinates].alive = true;
                addSurroudingDeadTiles(tile);
            }
            else
            {
                tileList[tile.coordinates].alive = false;
            }

            render();
        }

        public void render()
        {
            foreach (var item in tileList)
            {
                item.Value.render(graphics);
            }

            grid.render(graphics);
        }
    }
}
