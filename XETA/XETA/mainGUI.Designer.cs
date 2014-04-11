namespace XETA
{
    partial class mainGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelNetwork = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblNetworkPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblNetworkAddress = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblConnectionPanel = new System.Windows.Forms.Label();
            this.clientTick = new System.Windows.Forms.Timer(this.components);
            this.panelOnkyo = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.onkyoStatus = new System.Windows.Forms.Label();
            this.tbarOnkyoVolume = new System.Windows.Forms.TrackBar();
            this.btnOnkyoGame = new System.Windows.Forms.Button();
            this.btnOnkyoMusic = new System.Windows.Forms.Button();
            this.btnOnkyoMovie = new System.Windows.Forms.Button();
            this.lblOnkyoPort = new System.Windows.Forms.Label();
            this.txtOnkyoPort = new System.Windows.Forms.TextBox();
            this.lblOnkyoIP = new System.Windows.Forms.Label();
            this.txtOnkyoIP = new System.Windows.Forms.TextBox();
            this.lblOnkyoPanel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPeakOutput = new System.Windows.Forms.Label();
            this.lblpeak = new System.Windows.Forms.Label();
            this.lblInputOutput = new System.Windows.Forms.Label();
            this.lblSSI = new System.Windows.Forms.Label();
            this.audioTick = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnbobConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbobPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbobIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.luminositySlider = new System.Windows.Forms.TrackBar();
            this.saturationSlider = new System.Windows.Forms.TrackBar();
            this.lblLuminosity = new System.Windows.Forms.Label();
            this.lblSaturation = new System.Windows.Forms.Label();
            this.panelNetwork.SuspendLayout();
            this.panelOnkyo.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarOnkyoVolume)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luminositySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNetwork
            // 
            this.panelNetwork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNetwork.Controls.Add(this.btnConnect);
            this.panelNetwork.Controls.Add(this.lblNetworkPort);
            this.panelNetwork.Controls.Add(this.txtPort);
            this.panelNetwork.Controls.Add(this.lblNetworkAddress);
            this.panelNetwork.Controls.Add(this.txtIP);
            this.panelNetwork.Controls.Add(this.lblConnectionPanel);
            this.panelNetwork.Location = new System.Drawing.Point(10, 9);
            this.panelNetwork.Name = "panelNetwork";
            this.panelNetwork.Size = new System.Drawing.Size(219, 149);
            this.panelNetwork.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(8, 110);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(203, 29);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblNetworkPort
            // 
            this.lblNetworkPort.AutoSize = true;
            this.lblNetworkPort.Location = new System.Drawing.Point(5, 66);
            this.lblNetworkPort.Name = "lblNetworkPort";
            this.lblNetworkPort.Size = new System.Drawing.Size(29, 13);
            this.lblNetworkPort.TabIndex = 4;
            this.lblNetworkPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(8, 82);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(203, 20);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "41414";
            // 
            // lblNetworkAddress
            // 
            this.lblNetworkAddress.AutoSize = true;
            this.lblNetworkAddress.Location = new System.Drawing.Point(5, 25);
            this.lblNetworkAddress.Name = "lblNetworkAddress";
            this.lblNetworkAddress.Size = new System.Drawing.Size(91, 13);
            this.lblNetworkAddress.TabIndex = 2;
            this.lblNetworkAddress.Text = "Network Address:";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(8, 41);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(203, 20);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "x1.ixeta.net";
            // 
            // lblConnectionPanel
            // 
            this.lblConnectionPanel.AutoSize = true;
            this.lblConnectionPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionPanel.Location = new System.Drawing.Point(5, 6);
            this.lblConnectionPanel.Name = "lblConnectionPanel";
            this.lblConnectionPanel.Size = new System.Drawing.Size(144, 13);
            this.lblConnectionPanel.TabIndex = 0;
            this.lblConnectionPanel.Text = "XETAServer Connection";
            // 
            // clientTick
            // 
            this.clientTick.Enabled = true;
            this.clientTick.Interval = 800;
            this.clientTick.Tick += new System.EventHandler(this.clientTick_Tick);
            // 
            // panelOnkyo
            // 
            this.panelOnkyo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOnkyo.Controls.Add(this.panel2);
            this.panelOnkyo.Controls.Add(this.tbarOnkyoVolume);
            this.panelOnkyo.Controls.Add(this.btnOnkyoGame);
            this.panelOnkyo.Controls.Add(this.btnOnkyoMusic);
            this.panelOnkyo.Controls.Add(this.btnOnkyoMovie);
            this.panelOnkyo.Controls.Add(this.lblOnkyoPort);
            this.panelOnkyo.Controls.Add(this.txtOnkyoPort);
            this.panelOnkyo.Controls.Add(this.lblOnkyoIP);
            this.panelOnkyo.Controls.Add(this.txtOnkyoIP);
            this.panelOnkyo.Controls.Add(this.lblOnkyoPanel);
            this.panelOnkyo.Location = new System.Drawing.Point(235, 9);
            this.panelOnkyo.Name = "panelOnkyo";
            this.panelOnkyo.Size = new System.Drawing.Size(219, 273);
            this.panelOnkyo.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.onkyoStatus);
            this.panel2.Location = new System.Drawing.Point(8, 246);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(203, 22);
            this.panel2.TabIndex = 9;
            // 
            // onkyoStatus
            // 
            this.onkyoStatus.AutoSize = true;
            this.onkyoStatus.Location = new System.Drawing.Point(5, 5);
            this.onkyoStatus.Name = "onkyoStatus";
            this.onkyoStatus.Size = new System.Drawing.Size(0, 13);
            this.onkyoStatus.TabIndex = 0;
            // 
            // tbarOnkyoVolume
            // 
            this.tbarOnkyoVolume.Location = new System.Drawing.Point(8, 210);
            this.tbarOnkyoVolume.Maximum = 100;
            this.tbarOnkyoVolume.Name = "tbarOnkyoVolume";
            this.tbarOnkyoVolume.Size = new System.Drawing.Size(203, 45);
            this.tbarOnkyoVolume.TabIndex = 8;
            this.tbarOnkyoVolume.TickFrequency = 5;
            this.tbarOnkyoVolume.ValueChanged += new System.EventHandler(this.tbarOnkyoVolume_ValueChanged);
            // 
            // btnOnkyoGame
            // 
            this.btnOnkyoGame.Location = new System.Drawing.Point(8, 176);
            this.btnOnkyoGame.Name = "btnOnkyoGame";
            this.btnOnkyoGame.Size = new System.Drawing.Size(203, 28);
            this.btnOnkyoGame.TabIndex = 7;
            this.btnOnkyoGame.Text = "Game Setup";
            this.btnOnkyoGame.UseVisualStyleBackColor = true;
            this.btnOnkyoGame.Click += new System.EventHandler(this.btnOnkyoGame_Click);
            // 
            // btnOnkyoMusic
            // 
            this.btnOnkyoMusic.Location = new System.Drawing.Point(8, 142);
            this.btnOnkyoMusic.Name = "btnOnkyoMusic";
            this.btnOnkyoMusic.Size = new System.Drawing.Size(203, 28);
            this.btnOnkyoMusic.TabIndex = 6;
            this.btnOnkyoMusic.Text = "Music Setup";
            this.btnOnkyoMusic.UseVisualStyleBackColor = true;
            this.btnOnkyoMusic.Click += new System.EventHandler(this.btnOnkyoMusic_Click);
            // 
            // btnOnkyoMovie
            // 
            this.btnOnkyoMovie.Location = new System.Drawing.Point(8, 108);
            this.btnOnkyoMovie.Name = "btnOnkyoMovie";
            this.btnOnkyoMovie.Size = new System.Drawing.Size(203, 28);
            this.btnOnkyoMovie.TabIndex = 5;
            this.btnOnkyoMovie.Text = "Movie Setup";
            this.btnOnkyoMovie.UseVisualStyleBackColor = true;
            this.btnOnkyoMovie.Click += new System.EventHandler(this.btnOnkyoMovie_Click);
            // 
            // lblOnkyoPort
            // 
            this.lblOnkyoPort.AutoSize = true;
            this.lblOnkyoPort.Location = new System.Drawing.Point(5, 66);
            this.lblOnkyoPort.Name = "lblOnkyoPort";
            this.lblOnkyoPort.Size = new System.Drawing.Size(29, 13);
            this.lblOnkyoPort.TabIndex = 4;
            this.lblOnkyoPort.Text = "Port:";
            // 
            // txtOnkyoPort
            // 
            this.txtOnkyoPort.Location = new System.Drawing.Point(8, 82);
            this.txtOnkyoPort.Name = "txtOnkyoPort";
            this.txtOnkyoPort.Size = new System.Drawing.Size(203, 20);
            this.txtOnkyoPort.TabIndex = 3;
            this.txtOnkyoPort.Text = "60128";
            this.txtOnkyoPort.TextChanged += new System.EventHandler(this.txtOnkyoPort_TextChanged);
            // 
            // lblOnkyoIP
            // 
            this.lblOnkyoIP.AutoSize = true;
            this.lblOnkyoIP.Location = new System.Drawing.Point(5, 25);
            this.lblOnkyoIP.Name = "lblOnkyoIP";
            this.lblOnkyoIP.Size = new System.Drawing.Size(91, 13);
            this.lblOnkyoIP.TabIndex = 2;
            this.lblOnkyoIP.Text = "Network Address:";
            // 
            // txtOnkyoIP
            // 
            this.txtOnkyoIP.Location = new System.Drawing.Point(8, 41);
            this.txtOnkyoIP.Name = "txtOnkyoIP";
            this.txtOnkyoIP.Size = new System.Drawing.Size(203, 20);
            this.txtOnkyoIP.TabIndex = 1;
            this.txtOnkyoIP.Text = "192.168.27.104";
            this.txtOnkyoIP.TextChanged += new System.EventHandler(this.txtOnkyoIP_TextChanged);
            // 
            // lblOnkyoPanel
            // 
            this.lblOnkyoPanel.AutoSize = true;
            this.lblOnkyoPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnkyoPanel.Location = new System.Drawing.Point(5, 6);
            this.lblOnkyoPanel.Name = "lblOnkyoPanel";
            this.lblOnkyoPanel.Size = new System.Drawing.Size(101, 13);
            this.lblOnkyoPanel.TabIndex = 0;
            this.lblOnkyoPanel.Text = "Onkyo Controller";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblPeakOutput);
            this.panel1.Controls.Add(this.lblpeak);
            this.panel1.Controls.Add(this.lblInputOutput);
            this.panel1.Controls.Add(this.lblSSI);
            this.panel1.Location = new System.Drawing.Point(235, 288);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 40);
            this.panel1.TabIndex = 2;
            // 
            // lblPeakOutput
            // 
            this.lblPeakOutput.AutoSize = true;
            this.lblPeakOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeakOutput.Location = new System.Drawing.Point(114, 21);
            this.lblPeakOutput.Name = "lblPeakOutput";
            this.lblPeakOutput.Size = new System.Drawing.Size(13, 13);
            this.lblPeakOutput.TabIndex = 3;
            this.lblPeakOutput.Text = "0";
            // 
            // lblpeak
            // 
            this.lblpeak.AutoSize = true;
            this.lblpeak.Location = new System.Drawing.Point(49, 21);
            this.lblpeak.Name = "lblpeak";
            this.lblpeak.Size = new System.Drawing.Size(65, 13);
            this.lblpeak.TabIndex = 2;
            this.lblpeak.Text = "Audio Peak:";
            // 
            // lblInputOutput
            // 
            this.lblInputOutput.AutoSize = true;
            this.lblInputOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputOutput.Location = new System.Drawing.Point(114, 4);
            this.lblInputOutput.Name = "lblInputOutput";
            this.lblInputOutput.Size = new System.Drawing.Size(13, 13);
            this.lblInputOutput.TabIndex = 1;
            this.lblInputOutput.Text = "0";
            // 
            // lblSSI
            // 
            this.lblSSI.AutoSize = true;
            this.lblSSI.Location = new System.Drawing.Point(5, 4);
            this.lblSSI.Name = "lblSSI";
            this.lblSSI.Size = new System.Drawing.Size(109, 13);
            this.lblSSI.TabIndex = 0;
            this.lblSSI.Text = "Seconds Since Input:";
            // 
            // audioTick
            // 
            this.audioTick.Enabled = true;
            this.audioTick.Interval = 50;
            this.audioTick.Tick += new System.EventHandler(this.audioTick_Tick);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblSaturation);
            this.panel3.Controls.Add(this.lblLuminosity);
            this.panel3.Controls.Add(this.saturationSlider);
            this.panel3.Controls.Add(this.luminositySlider);
            this.panel3.Controls.Add(this.btnbobConnect);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtbobPort);
            this.panel3.Controls.Add(this.txtbobIP);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(10, 164);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(219, 229);
            this.panel3.TabIndex = 3;
            // 
            // btnbobConnect
            // 
            this.btnbobConnect.Location = new System.Drawing.Point(8, 110);
            this.btnbobConnect.Name = "btnbobConnect";
            this.btnbobConnect.Size = new System.Drawing.Size(203, 29);
            this.btnbobConnect.TabIndex = 11;
            this.btnbobConnect.Text = "Start Ambilight";
            this.btnbobConnect.UseVisualStyleBackColor = true;
            this.btnbobConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Port:";
            // 
            // txtbobPort
            // 
            this.txtbobPort.Location = new System.Drawing.Point(8, 82);
            this.txtbobPort.Name = "txtbobPort";
            this.txtbobPort.Size = new System.Drawing.Size(203, 20);
            this.txtbobPort.TabIndex = 9;
            this.txtbobPort.Text = "19333";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Network Address:";
            // 
            // txtbobIP
            // 
            this.txtbobIP.Location = new System.Drawing.Point(8, 41);
            this.txtbobIP.Name = "txtbobIP";
            this.txtbobIP.Size = new System.Drawing.Size(203, 20);
            this.txtbobIP.TabIndex = 7;
            this.txtbobIP.Text = "10.73.50.47";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "boblight AmbiScreen";
            // 
            // luminositySlider
            // 
            this.luminositySlider.LargeChange = 10;
            this.luminositySlider.Location = new System.Drawing.Point(8, 161);
            this.luminositySlider.Maximum = 200;
            this.luminositySlider.Name = "luminositySlider";
            this.luminositySlider.Size = new System.Drawing.Size(201, 45);
            this.luminositySlider.TabIndex = 12;
            this.luminositySlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.luminositySlider.Value = 10;
            this.luminositySlider.ValueChanged += new System.EventHandler(this.luminositySlider_ValueChanged);
            // 
            // saturationSlider
            // 
            this.saturationSlider.LargeChange = 10;
            this.saturationSlider.Location = new System.Drawing.Point(8, 198);
            this.saturationSlider.Maximum = 200;
            this.saturationSlider.Name = "saturationSlider";
            this.saturationSlider.Size = new System.Drawing.Size(201, 45);
            this.saturationSlider.TabIndex = 13;
            this.saturationSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.saturationSlider.Value = 10;
            this.saturationSlider.ValueChanged += new System.EventHandler(this.saturationSlider_ValueChanged);
            // 
            // lblLuminosity
            // 
            this.lblLuminosity.AutoSize = true;
            this.lblLuminosity.Location = new System.Drawing.Point(5, 146);
            this.lblLuminosity.Name = "lblLuminosity";
            this.lblLuminosity.Size = new System.Drawing.Size(77, 13);
            this.lblLuminosity.TabIndex = 14;
            this.lblLuminosity.Text = "Luminosity: 1.0";
            // 
            // lblSaturation
            // 
            this.lblSaturation.AutoSize = true;
            this.lblSaturation.Location = new System.Drawing.Point(5, 185);
            this.lblSaturation.Name = "lblSaturation";
            this.lblSaturation.Size = new System.Drawing.Size(76, 13);
            this.lblSaturation.TabIndex = 15;
            this.lblSaturation.Text = "Saturation: 1.0";
            // 
            // mainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 409);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelOnkyo);
            this.Controls.Add(this.panelNetwork);
            this.MaximizeBox = false;
            this.Name = "mainGUI";
            this.Text = "XETA";
            this.panelNetwork.ResumeLayout(false);
            this.panelNetwork.PerformLayout();
            this.panelOnkyo.ResumeLayout(false);
            this.panelOnkyo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarOnkyoVolume)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luminositySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNetwork;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblNetworkPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblNetworkAddress;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblConnectionPanel;
        private System.Windows.Forms.Timer clientTick;
        private System.Windows.Forms.Panel panelOnkyo;
        private System.Windows.Forms.Label lblOnkyoPort;
        private System.Windows.Forms.TextBox txtOnkyoPort;
        private System.Windows.Forms.Label lblOnkyoIP;
        private System.Windows.Forms.TextBox txtOnkyoIP;
        private System.Windows.Forms.Label lblOnkyoPanel;
        private System.Windows.Forms.Button btnOnkyoGame;
        private System.Windows.Forms.Button btnOnkyoMusic;
        private System.Windows.Forms.Button btnOnkyoMovie;
        private System.Windows.Forms.TrackBar tbarOnkyoVolume;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInputOutput;
        private System.Windows.Forms.Label lblSSI;
        private System.Windows.Forms.Label lblPeakOutput;
        private System.Windows.Forms.Label lblpeak;
        private System.Windows.Forms.Timer audioTick;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label onkyoStatus;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSaturation;
        private System.Windows.Forms.Label lblLuminosity;
        private System.Windows.Forms.TrackBar saturationSlider;
        private System.Windows.Forms.TrackBar luminositySlider;
        private System.Windows.Forms.Button btnbobConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbobPort;
        private System.Windows.Forms.TextBox txtbobIP;
        private System.Windows.Forms.Label label2;
    }
}

