namespace ClientApp
{
	partial class MainFormClient
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			GroupBox_Settings = new GroupBox();
			GroupBox_Connection = new GroupBox();
			label1 = new Label();
			NUD_Port = new NumericUpDown();
			label2 = new Label();
			TextBox_IpAddres = new TextBox();
			Btn_Disconnect = new Button();
			Btn_Connect = new Button();
			GroupBox_Mode = new GroupBox();
			RB_ComputerClient_ComputerServer = new RadioButton();
			RB_ComputerClient_PersonServer = new RadioButton();
			RB_PersonClient_ComputerServer = new RadioButton();
			RB_PersonClient_PersonServer = new RadioButton();
			ListBox_Messages = new ListBox();
			Btn_SendMessage = new Button();
			TextBox_Message = new TextBox();
			label3 = new Label();
			GroupBox_Settings.SuspendLayout();
			GroupBox_Connection.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)NUD_Port).BeginInit();
			GroupBox_Mode.SuspendLayout();
			SuspendLayout();
			// 
			// GroupBox_Settings
			// 
			GroupBox_Settings.Controls.Add(GroupBox_Connection);
			GroupBox_Settings.Controls.Add(Btn_Disconnect);
			GroupBox_Settings.Controls.Add(Btn_Connect);
			GroupBox_Settings.Controls.Add(GroupBox_Mode);
			GroupBox_Settings.Location = new Point(12, 12);
			GroupBox_Settings.Name = "GroupBox_Settings";
			GroupBox_Settings.Size = new Size(496, 190);
			GroupBox_Settings.TabIndex = 0;
			GroupBox_Settings.TabStop = false;
			GroupBox_Settings.Text = "Settings";
			// 
			// GroupBox_Connection
			// 
			GroupBox_Connection.Controls.Add(label1);
			GroupBox_Connection.Controls.Add(NUD_Port);
			GroupBox_Connection.Controls.Add(label2);
			GroupBox_Connection.Controls.Add(TextBox_IpAddres);
			GroupBox_Connection.Location = new Point(6, 101);
			GroupBox_Connection.Name = "GroupBox_Connection";
			GroupBox_Connection.Size = new Size(305, 83);
			GroupBox_Connection.TabIndex = 8;
			GroupBox_Connection.TabStop = false;
			GroupBox_Connection.Text = "Connection";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(6, 25);
			label1.Name = "label1";
			label1.Size = new Size(96, 15);
			label1.TabIndex = 0;
			label1.Text = "Remote Address:";
			// 
			// NUD_Port
			// 
			NUD_Port.Location = new Point(121, 51);
			NUD_Port.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
			NUD_Port.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
			NUD_Port.Name = "NUD_Port";
			NUD_Port.Size = new Size(152, 23);
			NUD_Port.TabIndex = 5;
			NUD_Port.Value = new decimal(new int[] { 1000, 0, 0, 0 });
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(6, 53);
			label2.Name = "label2";
			label2.Size = new Size(76, 15);
			label2.TabIndex = 2;
			label2.Text = "Remote Port:";
			// 
			// TextBox_IpAddres
			// 
			TextBox_IpAddres.Location = new Point(121, 22);
			TextBox_IpAddres.Name = "TextBox_IpAddres";
			TextBox_IpAddres.Size = new Size(152, 23);
			TextBox_IpAddres.TabIndex = 1;
			TextBox_IpAddres.Text = "127.0.0.1";
			// 
			// Btn_Disconnect
			// 
			Btn_Disconnect.Location = new Point(314, 158);
			Btn_Disconnect.Name = "Btn_Disconnect";
			Btn_Disconnect.Size = new Size(87, 26);
			Btn_Disconnect.TabIndex = 7;
			Btn_Disconnect.Text = "Disconnect";
			Btn_Disconnect.UseVisualStyleBackColor = true;
			Btn_Disconnect.Click += Btn_Disconnect_Click;
			// 
			// Btn_Connect
			// 
			Btn_Connect.Location = new Point(407, 158);
			Btn_Connect.Name = "Btn_Connect";
			Btn_Connect.Size = new Size(87, 26);
			Btn_Connect.TabIndex = 6;
			Btn_Connect.Text = "Connect";
			Btn_Connect.UseVisualStyleBackColor = true;
			Btn_Connect.Click += Btn_Connect_Click;
			// 
			// GroupBox_Mode
			// 
			GroupBox_Mode.Controls.Add(RB_ComputerClient_ComputerServer);
			GroupBox_Mode.Controls.Add(RB_ComputerClient_PersonServer);
			GroupBox_Mode.Controls.Add(RB_PersonClient_ComputerServer);
			GroupBox_Mode.Controls.Add(RB_PersonClient_PersonServer);
			GroupBox_Mode.Location = new Point(6, 22);
			GroupBox_Mode.Name = "GroupBox_Mode";
			GroupBox_Mode.Size = new Size(484, 75);
			GroupBox_Mode.TabIndex = 4;
			GroupBox_Mode.TabStop = false;
			GroupBox_Mode.Text = "Mode";
			// 
			// RB_ComputerClient_ComputerServer
			// 
			RB_ComputerClient_ComputerServer.AutoSize = true;
			RB_ComputerClient_ComputerServer.Location = new Point(237, 47);
			RB_ComputerClient_ComputerServer.Name = "RB_ComputerClient_ComputerServer";
			RB_ComputerClient_ComputerServer.Size = new Size(201, 19);
			RB_ComputerClient_ComputerServer.TabIndex = 3;
			RB_ComputerClient_ComputerServer.TabStop = true;
			RB_ComputerClient_ComputerServer.Text = "ComputerClient_ComputerServer";
			RB_ComputerClient_ComputerServer.UseVisualStyleBackColor = true;
			// 
			// RB_ComputerClient_PersonServer
			// 
			RB_ComputerClient_PersonServer.AutoSize = true;
			RB_ComputerClient_PersonServer.Location = new Point(237, 22);
			RB_ComputerClient_PersonServer.Name = "RB_ComputerClient_PersonServer";
			RB_ComputerClient_PersonServer.Size = new Size(183, 19);
			RB_ComputerClient_PersonServer.TabIndex = 2;
			RB_ComputerClient_PersonServer.TabStop = true;
			RB_ComputerClient_PersonServer.Text = "ComputerClient_PersonServer";
			RB_ComputerClient_PersonServer.UseVisualStyleBackColor = true;
			// 
			// RB_PersonClient_ComputerServer
			// 
			RB_PersonClient_ComputerServer.AutoSize = true;
			RB_PersonClient_ComputerServer.Location = new Point(6, 47);
			RB_PersonClient_ComputerServer.Name = "RB_PersonClient_ComputerServer";
			RB_PersonClient_ComputerServer.Size = new Size(183, 19);
			RB_PersonClient_ComputerServer.TabIndex = 1;
			RB_PersonClient_ComputerServer.TabStop = true;
			RB_PersonClient_ComputerServer.Text = "PersonClient_ComputerServer";
			RB_PersonClient_ComputerServer.UseVisualStyleBackColor = true;
			// 
			// RB_PersonClient_PersonServer
			// 
			RB_PersonClient_PersonServer.AutoSize = true;
			RB_PersonClient_PersonServer.Location = new Point(6, 22);
			RB_PersonClient_PersonServer.Name = "RB_PersonClient_PersonServer";
			RB_PersonClient_PersonServer.Size = new Size(165, 19);
			RB_PersonClient_PersonServer.TabIndex = 0;
			RB_PersonClient_PersonServer.TabStop = true;
			RB_PersonClient_PersonServer.Text = "PersonClient_PersonServer";
			RB_PersonClient_PersonServer.UseVisualStyleBackColor = true;
			// 
			// ListBox_Messages
			// 
			ListBox_Messages.FormattingEnabled = true;
			ListBox_Messages.ItemHeight = 15;
			ListBox_Messages.Location = new Point(12, 208);
			ListBox_Messages.Name = "ListBox_Messages";
			ListBox_Messages.Size = new Size(496, 274);
			ListBox_Messages.TabIndex = 1;
			// 
			// Btn_SendMessage
			// 
			Btn_SendMessage.Location = new Point(428, 494);
			Btn_SendMessage.Name = "Btn_SendMessage";
			Btn_SendMessage.Size = new Size(80, 24);
			Btn_SendMessage.TabIndex = 2;
			Btn_SendMessage.Text = "Send";
			Btn_SendMessage.UseVisualStyleBackColor = true;
			Btn_SendMessage.Click += Btn_SendMessage_Click;
			// 
			// TextBox_Message
			// 
			TextBox_Message.Location = new Point(71, 494);
			TextBox_Message.Name = "TextBox_Message";
			TextBox_Message.Size = new Size(351, 23);
			TextBox_Message.TabIndex = 3;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(12, 497);
			label3.Name = "label3";
			label3.Size = new Size(56, 15);
			label3.TabIndex = 4;
			label3.Text = "Message:";
			// 
			// MainFormClient
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(520, 528);
			Controls.Add(label3);
			Controls.Add(TextBox_Message);
			Controls.Add(Btn_SendMessage);
			Controls.Add(ListBox_Messages);
			Controls.Add(GroupBox_Settings);
			Name = "MainFormClient";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Client App";
			GroupBox_Settings.ResumeLayout(false);
			GroupBox_Connection.ResumeLayout(false);
			GroupBox_Connection.PerformLayout();
			((System.ComponentModel.ISupportInitialize)NUD_Port).EndInit();
			GroupBox_Mode.ResumeLayout(false);
			GroupBox_Mode.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private GroupBox GroupBox_Settings;
		private GroupBox GroupBox_Mode;
		private RadioButton RB_ComputerClient_PersonServer;
		private RadioButton RB_PersonClient_ComputerServer;
		private RadioButton RB_PersonClient_PersonServer;
		private TextBox textBox2;
		private Label label2;
		private TextBox TextBox_IpAddres;
		private Label label1;
		private RadioButton RB_ComputerClient_ComputerServer;
		private Button Btn_Connect;
		private NumericUpDown NUD_Port;
		private GroupBox GroupBox_Connection;
		private Button Btn_Disconnect;
		private ListBox ListBox_Messages;
		private Button Btn_SendMessage;
		private TextBox TextBox_Message;
		private Label label3;
	}
}