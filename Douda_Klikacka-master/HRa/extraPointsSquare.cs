using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRa
{
    class extraPointsSquare : Square
    {
        public extraPointsSquare(Game game, Player player) : base(game, player)
        {
            gamePanel.BackColor = Color.Blue;
        }

        protected override void changeColorOfgamePanels()
        {
            // Do nothing, as the color should remain blue
        }
        protected override void gamePanel_Click(object sender, EventArgs e)
        {
            game.panel1.Controls.Remove(sender as Panel);
            game.RemoveFromList(this);
            player.AddScore(5);
        }
        protected override void descendCountdown(Game g)
        {
            countdown -= g.timer1.Interval * 4;

            if (this.countdown <= 0)
            {
                gamePanel.Dispose();
            }
        }
    }
}
