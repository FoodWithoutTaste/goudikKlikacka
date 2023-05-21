using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using SuperSimpleTcp;
namespace HRa
{
    public partial class GameOver : Form
    {
       
        private SimpleTcpClient client;
        List<string> leaderBoard = new List<string>();
        string username;
        int score;
        public GameOver(string name,Player player)
        {
            InitializeComponent();
          

            username = name;
            score = player.score;
        }



        private void GameOver_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient("127.0.0.1:9000");
            label2.Text = "Game : goudik_Klikacka-Martin";
            label3.Text = "Your name : " + username;
            label4.Text = "Your score : " + score;

            try
            {
                client.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "bruhh");
            }
            client.Connect();

            if (client != null && client.IsConnected)
            {
                string message = username + ",goudik_Klikacka-Martin," + score;
                client.Send(message);
            }

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
           
        }
    }
}
