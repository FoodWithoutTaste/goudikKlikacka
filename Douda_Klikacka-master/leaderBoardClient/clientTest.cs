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
namespace leaderBoardClient
{
    public partial class clientTest : Form
    {
        private SimpleTcpClient client;
        public clientTest()
        {
            InitializeComponent();
        }

        private void clientTest_Load(object sender, EventArgs e)
        {

        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client != null && client.IsConnected)
            {
                string message = txtClient.Text;
                client.Send(message);
                txtClient.Text = string.Empty;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new SimpleTcpClient(txtServerAddress.Text);
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            client.Events.DataReceived += Events_DataReceived;

            try
            {
                client.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "bruhh");
            }
            client.Connect();
            txtClient.Enabled = true;
            btnSend.Enabled = true;
        }

        private void Events_Connected(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)(() => txtClient.Text += "Connected to server\r\n"));
        }

        private void Events_Disconnected(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)(() =>
            {
                txtClient.Text += "Disconnected from server\r\n";
                txtClient.Enabled = false;
                btnSend.Enabled = false;
            }));
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            Invoke((MethodInvoker)(() => txtClient.Text += $"Message from server: \r\n"));
        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            client = new SimpleTcpClient(txtServerAddress.Text);
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            client.Events.DataReceived += Events_DataReceived;

            try
            {
                client.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "bruhh");
            }
            client.Connect();
            txtClient.Enabled = true;
            btnSend.Enabled = true;
        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            if (client != null && client.IsConnected)
            {
                string message = txtClient.Text;
                client.Send(message);
                txtClient.Text = string.Empty;
            }
        }
    }
}

