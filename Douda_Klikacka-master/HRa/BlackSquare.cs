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
    public class BlackSquare : Square
    {
        public BlackSquare(Game game, Player player) : base(game, player)
        {
            gamePanel.BackColor = Color.Black;
        }

        protected override void changeColorOfgamePanels()
        {
            // Do nothing, as the color should remain black
        }

        protected override void gamePanel_Click(object sender, EventArgs e)
        {
            game.panel1.Controls.Remove(sender as Panel);
            game.RemoveFromList(this);
            player.TakeDamage();
        }

        protected override void descendCountdown(Game g)
        {
            countdown -= g.timer1.Interval;

            if (this.countdown <= 0)
            {
                gamePanel.Dispose();
            }
        }
    }
}
