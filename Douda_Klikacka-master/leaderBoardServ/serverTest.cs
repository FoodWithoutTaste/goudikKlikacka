using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperSimpleTcp;
using MySql.Data.MySqlClient;
namespace leaderBoardServ.Properties
{
    public partial class serverTest : Form
    {
        MySqlConnection conn;
        string dtb;
        string selectedGame;
        SimpleTcpServer server;
        public serverTest()
        {
            InitializeComponent();
        }

        private void serverTest_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer("127.0.0.1:9000");
    
            server.Events.DataReceived += Events_DataReceived;
            try
            {
                server.Start(); // Specify the port number you want to use
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "bruhh");
            }
        }
     

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            byte[] byteArray = new byte[e.Data.Count];
            Array.Copy(e.Data.Array, e.Data.Offset, byteArray, 0, e.Data.Count);
           // Invoke((MethodInvoker)(() => listBox1.Items.Add($"Message from {e.IpPort}: {Encoding.UTF8.GetString(byteArray)}\r\n")));
            string[] clientMessage = Encoding.UTF8.GetString(byteArray).Split(',');
            //insertIntoDatabase

            //save Names into Database
            dtb = "server=127.0.0.1;uid=root;pwd=;database=csharp";
            conn = new MySqlConnection(dtb);
            try
            {
                conn.Open();
                //string quarry = $"INSERT INTO jsonsave(JSON) VALUES('" + item + "');";
                string quarry = $"INSERT INTO leaderboard(userName,gameName,score) VALUES('"+ clientMessage[0]+"','"+ clientMessage[1]+"',"+ clientMessage[2]+")";
                MySqlCommand cmd = new MySqlCommand(quarry, conn);
                    cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("ggg");
            }
            loadLeaderBoard("goudik_Klikacka-Martin");
        }

        

      

        private void button1_Click(object sender, EventArgs e)
        {
            loadLeaderBoard("goudik_Klikacka-Martin");
        }

        void loadLeaderBoard(string gameName)
        {
            //save Names into Database

            listBox1.Items.Clear();
            dtb = "server=127.0.0.1;uid=root;pwd=;database=csharp";
            conn = new MySqlConnection(dtb);

            try
            {
                conn.Open();

                string quarry = $"SELECT * FROM `leaderboard` WHERE gameName = '" + gameName + "' ORDER BY score DESC;";

                MySqlCommand cmd = new MySqlCommand(quarry, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string fullString = "Player Name : " + reader.GetString("userName") + " Score : " + reader.GetString("score");
                    listBox1.Items.Add(fullString);
                }
                conn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("ggg");
            }
        }
    }
}
