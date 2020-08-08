namespace WinFormsServer
{
    partial class FrmServer
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
            this.btnStartServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpBroadcast = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.cmbClients = new System.Windows.Forms.ComboBox();
            this.cmbGroups = new System.Windows.Forms.ComboBox();
            this.rdToClient = new System.Windows.Forms.RadioButton();
            this.rdToGroup = new System.Windows.Forms.RadioButton();
            this.rdToAll = new System.Windows.Forms.RadioButton();
            this.btnSocketServer = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpBroadcast.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(59, 55);
            this.btnStartServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(144, 28);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Url";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(59, 23);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(321, 22);
            this.txtUrl.TabIndex = 2;
            this.txtUrl.Text = "http://localhost:8080";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(237, 55);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(144, 28);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(11, 36);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(556, 251);
            this.txtLog.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLog);
            this.groupBox1.Location = new System.Drawing.Point(13, 290);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(592, 316);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSocketServer);
            this.groupBox2.Controls.Add(this.txtUrl);
            this.groupBox2.Controls.Add(this.btnStartServer);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(592, 101);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server";
            // 
            // grpBroadcast
            // 
            this.grpBroadcast.Controls.Add(this.btnSend);
            this.grpBroadcast.Controls.Add(this.label2);
            this.grpBroadcast.Controls.Add(this.txtMessage);
            this.grpBroadcast.Controls.Add(this.cmbClients);
            this.grpBroadcast.Controls.Add(this.cmbGroups);
            this.grpBroadcast.Controls.Add(this.rdToClient);
            this.grpBroadcast.Controls.Add(this.rdToGroup);
            this.grpBroadcast.Controls.Add(this.rdToAll);
            this.grpBroadcast.Enabled = false;
            this.grpBroadcast.Location = new System.Drawing.Point(13, 123);
            this.grpBroadcast.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpBroadcast.Name = "grpBroadcast";
            this.grpBroadcast.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpBroadcast.Size = new System.Drawing.Size(592, 160);
            this.grpBroadcast.TabIndex = 7;
            this.grpBroadcast.TabStop = false;
            this.grpBroadcast.Text = "Broadcast Message";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(401, 52);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(175, 94);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Message";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(131, 121);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(249, 22);
            this.txtMessage.TabIndex = 7;
            // 
            // cmbClients
            // 
            this.cmbClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClients.FormattingEnabled = true;
            this.cmbClients.Location = new System.Drawing.Point(131, 87);
            this.cmbClients.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbClients.Name = "cmbClients";
            this.cmbClients.Size = new System.Drawing.Size(249, 24);
            this.cmbClients.TabIndex = 4;
            // 
            // cmbGroups
            // 
            this.cmbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroups.FormattingEnabled = true;
            this.cmbGroups.Location = new System.Drawing.Point(131, 54);
            this.cmbGroups.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbGroups.Name = "cmbGroups";
            this.cmbGroups.Size = new System.Drawing.Size(249, 24);
            this.cmbGroups.TabIndex = 3;
            // 
            // rdToClient
            // 
            this.rdToClient.AutoSize = true;
            this.rdToClient.Location = new System.Drawing.Point(16, 94);
            this.rdToClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdToClient.Name = "rdToClient";
            this.rdToClient.Size = new System.Drawing.Size(85, 21);
            this.rdToClient.TabIndex = 2;
            this.rdToClient.Text = "To Client";
            this.rdToClient.UseVisualStyleBackColor = true;
            // 
            // rdToGroup
            // 
            this.rdToGroup.AutoSize = true;
            this.rdToGroup.Location = new System.Drawing.Point(16, 62);
            this.rdToGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdToGroup.Name = "rdToGroup";
            this.rdToGroup.Size = new System.Drawing.Size(90, 21);
            this.rdToGroup.TabIndex = 1;
            this.rdToGroup.Text = "To Group";
            this.rdToGroup.UseVisualStyleBackColor = true;
            // 
            // rdToAll
            // 
            this.rdToAll.AutoSize = true;
            this.rdToAll.Checked = true;
            this.rdToAll.Location = new System.Drawing.Point(16, 27);
            this.rdToAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdToAll.Name = "rdToAll";
            this.rdToAll.Size = new System.Drawing.Size(65, 21);
            this.rdToAll.TabIndex = 0;
            this.rdToAll.TabStop = true;
            this.rdToAll.Text = "To All";
            this.rdToAll.UseVisualStyleBackColor = true;
            // 
            // btnSocketServer
            // 
            this.btnSocketServer.Location = new System.Drawing.Point(425, 55);
            this.btnSocketServer.Name = "btnSocketServer";
            this.btnSocketServer.Size = new System.Drawing.Size(129, 28);
            this.btnSocketServer.TabIndex = 4;
            this.btnSocketServer.Text = "Connect Socket";
            this.btnSocketServer.UseVisualStyleBackColor = true;
            this.btnSocketServer.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 625);
            this.Controls.Add(this.grpBroadcast);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmServer";
            this.Text = "Server";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpBroadcast.ResumeLayout(false);
            this.grpBroadcast.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpBroadcast;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ComboBox cmbClients;
        private System.Windows.Forms.ComboBox cmbGroups;
        private System.Windows.Forms.RadioButton rdToClient;
        private System.Windows.Forms.RadioButton rdToGroup;
        private System.Windows.Forms.RadioButton rdToAll;
        private System.Windows.Forms.Button btnSocketServer;
    }
}

