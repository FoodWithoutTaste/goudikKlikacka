using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRa
{
    public partial class Form1 : Form
    {
        Game game;
        public Form1()
        {
            InitializeComponent();

            this.Hide();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            if (nameInput.Text != "")
            {
                this.Hide();
                game = new Game(nameInput.Text, this);
                game.Show();
            }
            else
            {
                MessageBox.Show("zadej jmeno");
            }


        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
