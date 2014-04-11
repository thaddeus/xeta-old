using System;
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
        public audioInterface audio;
        private string lastWindow;
        bobController ambiSocket = null;

        public mainGUI()
        {
            InitializeComponent();
            audio = new audioInterface();
            deviceManager.onkyoController.ip = txtOnkyoIP.Text;
            deviceManager.onkyoController.port = txtOnkyoPort.Text;
            //try
            //{
            //    Task<string> mVolumeTask = Task.Run<string>(() => deviceManager.onkyoController.askQuestion("MVLQSTN"));
            //    mVolumeTask.ContinueWith((volume) => { this.Invoke( new Action ( () => { tbarOnkyoVolume.Value = mVolumeTask.Result.Substring(5).ConvertHexValueToInt(); } ) ); } );
            //}
            //catch (Exception)
            //{
            //    onkyoStatus.Text = "Error connecting to Onkyo";
            //}
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
            if (xSocket != null && (xSocket.getClientState() == System.Net.WebSockets.WebSocketState.Closed || xSocket.getClientState() == System.Net.WebSockets.WebSocketState.Aborted))
            {
                //Failed?
                Console.WriteLine("XETAServer connection failed or closed.");
                //Try reconnecting
                xSocket.connect();
                //Renable stuff!
                btnConnect.Enabled = true;
                btnConnect.Text = "Connect";
                txtIP.Enabled = true;
                txtPort.Enabled = true;
            }
            else if (xSocket != null && xSocket.getClientState() == System.Net.WebSockets.WebSocketState.Open)
            {
                btnConnect.Text = "Disconnect";
                btnConnect.Enabled = true;
            }

            if(xSocket != null && xSocket.getClientState() == System.Net.WebSockets.WebSocketState.Open)
            {
                xSocket.queueMessage(Packets.outgoing.getPacket(new Packets.outgoing.IdlePacket()));
                Console.WriteLine("Sent idle packet");
                if(Input.GetActiveWindowTitle() != lastWindow)
                {
                    xSocket.queueMessage(Packets.outgoing.getPacket(new Packets.outgoing.WindowChangePacket()));
                    Console.WriteLine("Sent window change packet");
                }
            }
            lblInputOutput.Text = Input.SecondsSinceLastInput().ToString();
            lastWindow = Input.GetActiveWindowTitle();
            
        }

        private void txtOnkyoIP_TextChanged(object sender, EventArgs e)
        {
            deviceManager.onkyoController.ip = txtOnkyoIP.Text;
        }

        private void txtOnkyoPort_TextChanged(object sender, EventArgs e)
        {
            deviceManager.onkyoController.port = txtOnkyoPort.Text;
        }

        private void btnOnkyoMusic_Click(object sender, EventArgs e)
        {
            deviceManager.onkyoController.setMusicMode();
        }

        private void btnOnkyoMovie_Click(object sender, EventArgs e)
        {
            deviceManager.onkyoController.setMovieMode();
        }

        private void btnOnkyoGame_Click(object sender, EventArgs e)
        {
            deviceManager.onkyoController.setGameMode();
        }

        private void tbarOnkyoVolume_ValueChanged(object sender, EventArgs e)
        {
            deviceManager.onkyoController.sendMessage("MVL" + tbarOnkyoVolume.Value.ConverIntValueToHexString());
        }

        private void audioTick_Tick(object sender, EventArgs e)
        {
            if (xSocket != null && xSocket.getClientState() == System.Net.WebSockets.WebSocketState.Open)
            {
                xSocket.queueMessage(Packets.outgoing.getPacket(new Packets.outgoing.AudioLevelPacket(audio.getMasterPeak(), audio.getLeftPeak(), audio.getRightPeak())));
                Console.WriteLine("Sent audio packet");
            }
            lblPeakOutput.Text = audio.getMasterPeak().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnbobConnect.Text == "Stop Ambilight")
            {
                btnbobConnect.Text = "Start Ambilight";
                ambiSocket.killClient();
            }
            else
            {
                ambiSocket = new bobController(txtbobIP.Text, Convert.ToInt32(txtbobPort.Text));
                ambiSocket.startAmbilight();
                bobLight[] lights = ambiSocket.getLights();
                btnbobConnect.Text = "Stop Ambilight";
            }
        }

        private void luminositySlider_ValueChanged(object sender, EventArgs e)
        {
            ambiSocket.luminosityModifier = (double)luminositySlider.Value / 10;
            lblLuminosity.Text = "Luminosity: " + ((float)luminositySlider.Value / 10).ToString();
        }

        private void saturationSlider_ValueChanged(object sender, EventArgs e)
        {
            ambiSocket.saturationModifier = (double)saturationSlider.Value / 10;
            lblSaturation.Text = "Saturation: " + ((float)saturationSlider.Value / 10).ToString();
        }
    }
}
