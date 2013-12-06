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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblConnectionPanel = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblNetworkAddress = new System.Windows.Forms.Label();
            this.lblNetworkPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.clientTick = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.lblNetworkPort);
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Controls.Add(this.lblNetworkAddress);
            this.panel1.Controls.Add(this.txtIP);
            this.panel1.Controls.Add(this.lblConnectionPanel);
            this.panel1.Location = new System.Drawing.Point(10, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 149);
            this.panel1.TabIndex = 0;
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
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(8, 41);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(203, 20);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "x2.ixeta.net";
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
            // clientTick
            // 
            this.clientTick.Enabled = true;
            this.clientTick.Tick += new System.EventHandler(this.clientTick_Tick);
            // 
            // mainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 170);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "mainGUI";
            this.Text = "XETA";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblNetworkPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblNetworkAddress;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblConnectionPanel;
        private System.Windows.Forms.Timer clientTick;
    }
}

