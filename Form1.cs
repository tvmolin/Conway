using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static Conway.Constants;

namespace Conway
{
    public partial class GameForm : Form
    {
        Game game;
        Thread gameThread;
        Graphics graphics;

        public GameForm()
        {
            InitializeComponent();

            graphics = pictureBox.CreateGraphics();
            game = new Game(graphics);
            game.render();
        }

        private void nextStepClick(object sender, EventArgs e)
        {
            game.advanceLogicStep();
        }
              
        private void pictureBox_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            int tileX = me.Location.X / TILE_SIZE;
            int tileY = me.Location.Y / TILE_SIZE;

            game.toggleTile(new Tile(tileX, tileY));
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            game.render();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if(gameThread != null)
            {
                gameThread.Abort();
            }
            game.reset();
            generationLabel.Text = game.generation.ToString();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.Gray);
            gameThread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                while (true)
                {
                    game.advanceLogicStep();
                    generationLabel.Invoke((Action) delegate
                    {
                        generationLabel.Text = game.generation.ToString();
                    });
                    Thread.Sleep(300);
                }

            });

            gameThread.Start();            
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if(gameThread != null)
            {
                gameThread.Abort();
            }
        }
    }
}
