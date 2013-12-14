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
            this.lblOnkyoPort = new System.Windows.Forms.Label();
            this.txtOnkyoPort = new System.Windows.Forms.TextBox();
            this.lblOnkyoIP = new System.Windows.Forms.Label();
            this.txtOnkyoIP = new System.Windows.Forms.TextBox();
            this.lblOnkyoPanel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panelNetwork.SuspendLayout();
            this.panelOnkyo.SuspendLayout();
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
            this.txtPort.Text = "47895";
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
            this.txtIP.Text = "x2.ixeta.net";
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
            this.clientTick.Tick += new System.EventHandler(this.clientTick_Tick);
            // 
            // panelOnkyo
            // 
            this.panelOnkyo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOnkyo.Controls.Add(this.lblOnkyoPort);
            this.panelOnkyo.Controls.Add(this.txtOnkyoPort);
            this.panelOnkyo.Controls.Add(this.lblOnkyoIP);
            this.panelOnkyo.Controls.Add(this.txtOnkyoIP);
            this.panelOnkyo.Controls.Add(this.lblOnkyoPanel);
            this.panelOnkyo.Location = new System.Drawing.Point(235, 9);
            this.panelOnkyo.Name = "panelOnkyo";
            this.panelOnkyo.Size = new System.Drawing.Size(219, 114);
            this.panelOnkyo.TabIndex = 1;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 170);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelOnkyo);
            this.Controls.Add(this.panelNetwork);
            this.MaximizeBox = false;
            this.Name = "mainGUI";
            this.Text = "XETA";
            this.panelNetwork.ResumeLayout(false);
            this.panelNetwork.PerformLayout();
            this.panelOnkyo.ResumeLayout(false);
            this.panelOnkyo.PerformLayout();
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
        private System.Windows.Forms.Button button1;
    }
}

