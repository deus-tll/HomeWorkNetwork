namespace ServerApp
{
	partial class MainFormServer
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
			GroupBox_Connection = new GroupBox();
			label3 = new Label();
			label1 = new Label();
			NUD_Port = new NumericUpDown();
			TextBox_CountOfMaxClients = new TextBox();
			label2 = new Label();
			TextBox_IpAddres = new TextBox();
			Btn_Stop = new Button();
			Btn_Start = new Button();
			TabControl = new TabControl();
			tabPage1 = new TabPage();
			TextBox_ServerLogs = new TextBox();
			tabPage2 = new TabPage();
			Btn_AddClient = new Button();
			label7 = new Label();
			TextBox_MaxCountOfQueries = new TextBox();
			label5 = new Label();
			TextBox_Password = new TextBox();
			label6 = new Label();
			TextBox_Login = new TextBox();
			label4 = new Label();
			GroupBox_ClientsManaging = new GroupBox();
			GroupBox_Connection.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)NUD_Port).BeginInit();
			TabControl.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
			GroupBox_ClientsManaging.SuspendLayout();
			SuspendLayout();
			// 
			// GroupBox_Connection
			// 
			GroupBox_Connection.Controls.Add(label3);
			GroupBox_Connection.Controls.Add(label1);
			GroupBox_Connection.Controls.Add(NUD_Port);
			GroupBox_Connection.Controls.Add(TextBox_CountOfMaxClients);
			GroupBox_Connection.Controls.Add(label2);
			GroupBox_Connection.Controls.Add(TextBox_IpAddres);
			GroupBox_Connection.Location = new Point(6, 6);
			GroupBox_Connection.Name = "GroupBox_Connection";
			GroupBox_Connection.Size = new Size(346, 115);
			GroupBox_Connection.TabIndex = 20;
			GroupBox_Connection.TabStop = false;
			GroupBox_Connection.Text = "Connection";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(31, 81);
			label3.Name = "label3";
			label3.Size = new Size(120, 15);
			label3.TabIndex = 6;
			label3.Text = "Count of max clients:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(31, 25);
			label1.Name = "label1";
			label1.Size = new Size(83, 15);
			label1.TabIndex = 0;
			label1.Text = "Local Address:";
			// 
			// NUD_Port
			// 
			NUD_Port.Location = new Point(157, 49);
			NUD_Port.Maximum = new decimal(new int[] { 65000, 0, 0, 0 });
			NUD_Port.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
			NUD_Port.Name = "NUD_Port";
			NUD_Port.Size = new Size(146, 23);
			NUD_Port.TabIndex = 5;
			NUD_Port.Value = new decimal(new int[] { 1000, 0, 0, 0 });
			// 
			// TextBox_CountOfMaxClients
			// 
			TextBox_CountOfMaxClients.Location = new Point(157, 78);
			TextBox_CountOfMaxClients.Name = "TextBox_CountOfMaxClients";
			TextBox_CountOfMaxClients.Size = new Size(146, 23);
			TextBox_CountOfMaxClients.TabIndex = 7;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(31, 51);
			label2.Name = "label2";
			label2.Size = new Size(63, 15);
			label2.TabIndex = 2;
			label2.Text = "Local Port:";
			// 
			// TextBox_IpAddres
			// 
			TextBox_IpAddres.Location = new Point(157, 22);
			TextBox_IpAddres.Name = "TextBox_IpAddres";
			TextBox_IpAddres.Size = new Size(146, 23);
			TextBox_IpAddres.TabIndex = 1;
			TextBox_IpAddres.Text = "127.0.0.1";
			// 
			// Btn_Stop
			// 
			Btn_Stop.Location = new Point(390, 76);
			Btn_Stop.Name = "Btn_Stop";
			Btn_Stop.Size = new Size(87, 26);
			Btn_Stop.TabIndex = 19;
			Btn_Stop.Text = "Stop Server";
			Btn_Stop.UseVisualStyleBackColor = true;
			Btn_Stop.Click += Btn_Stop_Click;
			// 
			// Btn_Start
			// 
			Btn_Start.Location = new Point(390, 31);
			Btn_Start.Name = "Btn_Start";
			Btn_Start.Size = new Size(87, 26);
			Btn_Start.TabIndex = 18;
			Btn_Start.Text = "Start server";
			Btn_Start.UseVisualStyleBackColor = true;
			Btn_Start.Click += Btn_Start_Click;
			// 
			// TabControl
			// 
			TabControl.Controls.Add(tabPage1);
			TabControl.Controls.Add(tabPage2);
			TabControl.Location = new Point(12, 12);
			TabControl.Name = "TabControl";
			TabControl.SelectedIndex = 0;
			TabControl.Size = new Size(511, 479);
			TabControl.TabIndex = 21;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(TextBox_ServerLogs);
			tabPage1.Controls.Add(Btn_Stop);
			tabPage1.Controls.Add(GroupBox_Connection);
			tabPage1.Controls.Add(Btn_Start);
			tabPage1.Location = new Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(503, 451);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Server Work";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// TextBox_ServerLogs
			// 
			TextBox_ServerLogs.Location = new Point(6, 127);
			TextBox_ServerLogs.Multiline = true;
			TextBox_ServerLogs.Name = "TextBox_ServerLogs";
			TextBox_ServerLogs.ReadOnly = true;
			TextBox_ServerLogs.Size = new Size(491, 318);
			TextBox_ServerLogs.TabIndex = 21;
			// 
			// tabPage2
			// 
			tabPage2.Controls.Add(GroupBox_ClientsManaging);
			tabPage2.Location = new Point(4, 24);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(3);
			tabPage2.Size = new Size(503, 451);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Clients";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// Btn_AddClient
			// 
			Btn_AddClient.Location = new Point(213, 329);
			Btn_AddClient.Name = "Btn_AddClient";
			Btn_AddClient.Size = new Size(75, 23);
			Btn_AddClient.TabIndex = 16;
			Btn_AddClient.Text = "Add";
			Btn_AddClient.UseVisualStyleBackColor = true;
			Btn_AddClient.Click += Btn_AddClient_Click;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(191, 249);
			label7.Name = "label7";
			label7.Size = new Size(126, 15);
			label7.TabIndex = 14;
			label7.Text = "Max Count of Queries:";
			// 
			// TextBox_MaxCountOfQueries
			// 
			TextBox_MaxCountOfQueries.Location = new Point(181, 267);
			TextBox_MaxCountOfQueries.Name = "TextBox_MaxCountOfQueries";
			TextBox_MaxCountOfQueries.PasswordChar = '*';
			TextBox_MaxCountOfQueries.Size = new Size(146, 23);
			TextBox_MaxCountOfQueries.TabIndex = 15;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(228, 176);
			label5.Name = "label5";
			label5.Size = new Size(60, 15);
			label5.TabIndex = 12;
			label5.Text = "Password:";
			// 
			// TextBox_Password
			// 
			TextBox_Password.Location = new Point(181, 194);
			TextBox_Password.Name = "TextBox_Password";
			TextBox_Password.PasswordChar = '*';
			TextBox_Password.Size = new Size(146, 23);
			TextBox_Password.TabIndex = 13;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(232, 110);
			label6.Name = "label6";
			label6.Size = new Size(40, 15);
			label6.TabIndex = 10;
			label6.Text = "Login:";
			// 
			// TextBox_Login
			// 
			TextBox_Login.Location = new Point(181, 128);
			TextBox_Login.Name = "TextBox_Login";
			TextBox_Login.Size = new Size(146, 23);
			TextBox_Login.TabIndex = 11;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(200, 36);
			label4.Name = "label4";
			label4.Size = new Size(108, 15);
			label4.TabIndex = 0;
			label4.Text = "Add Client To Base:";
			// 
			// GroupBox_ClientsManaging
			// 
			GroupBox_ClientsManaging.Controls.Add(label4);
			GroupBox_ClientsManaging.Controls.Add(Btn_AddClient);
			GroupBox_ClientsManaging.Controls.Add(TextBox_Login);
			GroupBox_ClientsManaging.Controls.Add(label7);
			GroupBox_ClientsManaging.Controls.Add(label6);
			GroupBox_ClientsManaging.Controls.Add(TextBox_MaxCountOfQueries);
			GroupBox_ClientsManaging.Controls.Add(TextBox_Password);
			GroupBox_ClientsManaging.Controls.Add(label5);
			GroupBox_ClientsManaging.Location = new Point(6, 6);
			GroupBox_ClientsManaging.Name = "GroupBox_ClientsManaging";
			GroupBox_ClientsManaging.Size = new Size(491, 439);
			GroupBox_ClientsManaging.TabIndex = 17;
			GroupBox_ClientsManaging.TabStop = false;
			GroupBox_ClientsManaging.Text = "Clients Managing";
			// 
			// MainFormServer
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(535, 503);
			Controls.Add(TabControl);
			Name = "MainFormServer";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Exchange rates server";
			GroupBox_Connection.ResumeLayout(false);
			GroupBox_Connection.PerformLayout();
			((System.ComponentModel.ISupportInitialize)NUD_Port).EndInit();
			TabControl.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			GroupBox_ClientsManaging.ResumeLayout(false);
			GroupBox_ClientsManaging.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private GroupBox GroupBox_Connection;
		private Label label3;
		private Label label1;
		private NumericUpDown NUD_Port;
		private TextBox TextBox_CountOfMaxClients;
		private Label label2;
		private TextBox TextBox_IpAddres;
		private Button Btn_Stop;
		private Button Btn_Start;
		private TabControl TabControl;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private TextBox TextBox_ServerLogs;
		private Label label4;
		private Button Btn_AddClient;
		private Label label7;
		private TextBox TextBox_MaxCountOfQueries;
		private Label label5;
		private TextBox TextBox_Password;
		private Label label6;
		private TextBox TextBox_Login;
		private GroupBox GroupBox_ClientsManaging;
	}
}