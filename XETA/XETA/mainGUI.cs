﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XETA
{
    public partial class mainGUI : Form
    {
        private xetaSocket xSocket;

        public mainGUI()
        {
            InitializeComponent();
            deviceManager.onkyoController.ip = txtOnkyoIP.Text;
            deviceManager.onkyoController.port = txtOnkyoPort.Text;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (xSocket != null && xSocket.getClientState() == System.Net.WebSockets.WebSocketState.Open)
            {
                //Then we should probably be disconnecting
                xSocket.disconnect();

                //Various UI feedback
                btnConnect.Enabled = true;
                btnConnect.Text = "Connect";
                txtIP.Enabled = true;
                txtPort.Enabled = true;
            }
            else
            {
                //We should probably be connecting
                xSocket = new xetaSocket(txtIP.Text, txtPort.Text, this);

                //Various UI feedback
                btnConnect.Enabled = false;
                btnConnect.Text = "Connecting...";
                txtIP.Enabled = false;
                txtPort.Enabled = false;
            }
            
        }

        private void clientTick_Tick(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connecting..." && xSocket != null && xSocket.getClientState() == System.Net.WebSockets.WebSocketState.Closed)
            {
                //Failed?
                Console.WriteLine("XETAServer connection failed or closed.");
                //Renable stuff!
                btnConnect.Enabled = true;
                btnConnect.Text = "Connect";
                txtIP.Enabled = true;
                txtPort.Enabled = true;
            }
            else if (btnConnect.Enabled == false && xSocket != null && xSocket.getClientState() == System.Net.WebSockets.WebSocketState.Open)
            {
                btnConnect.Text = "Disconnect";
                btnConnect.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            deviceManager.onkyoController.askQuestion("PWRQSTN");
        }

        private void txtOnkyoIP_TextChanged(object sender, EventArgs e)
        {
            deviceManager.onkyoController.ip = txtOnkyoIP.Text;
        }

        private void txtOnkyoPort_TextChanged(object sender, EventArgs e)
        {
            deviceManager.onkyoController.port = txtOnkyoPort.Text;
        }
    }
}
