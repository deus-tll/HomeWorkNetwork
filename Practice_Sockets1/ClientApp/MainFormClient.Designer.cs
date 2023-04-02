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
			GroupBox_Connection = new GroupBox();
			label1 = new Label();
			NUD_Port = new NumericUpDown();
			label2 = new Label();
			TextBox_IpAddres = new TextBox();
			Btn_Disconnect = new Button();
			Btn_Connect = new Button();
			Btn_GetQuote = new Button();
			TextBox_Quotes = new TextBox();
			label3 = new Label();
			TextBox_Login = new TextBox();
			label4 = new Label();
			TextBox_Password = new TextBox();
			GroupBox_Connection.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)NUD_Port).BeginInit();
			SuspendLayout();
			// 
			// GroupBox_Connection
			// 
			GroupBox_Connection.Controls.Add(label4);
			GroupBox_Connection.Controls.Add(TextBox_Password);
			GroupBox_Connection.Controls.Add(label3);
			GroupBox_Connection.Controls.Add(label1);
			GroupBox_Connection.Controls.Add(NUD_Port);
			GroupBox_Connection.Controls.Add(TextBox_Login);
			GroupBox_Connection.Controls.Add(label2);
			GroupBox_Connection.Controls.Add(TextBox_IpAddres);
			GroupBox_Connection.Location = new Point(12, 12);
			GroupBox_Connection.Name = "GroupBox_Connection";
			GroupBox_Connection.Size = new Size(503, 83);
			GroupBox_Connection.TabIndex = 11;
			GroupBox_Connection.TabStop = false;
			GroupBox_Connection.Text = "Connection";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(7, 25);
			label1.Name = "label1";
			label1.Size = new Size(96, 15);
			label1.TabIndex = 0;
			label1.Text = "Remote Address:";
			// 
			// NUD_Port
			// 
			NUD_Port.Location = new Point(109, 49);
			NUD_Port.Maximum = new decimal(new int[] { 65000, 0, 0, 0 });
			NUD_Port.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
			NUD_Port.Name = "NUD_Port";
			NUD_Port.Size = new Size(146, 23);
			NUD_Port.TabIndex = 5;
			NUD_Port.Value = new decimal(new int[] { 1000, 0, 0, 0 });
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(7, 51);
			label2.Name = "label2";
			label2.Size = new Size(76, 15);
			label2.TabIndex = 2;
			label2.Text = "Remote Port:";
			// 
			// TextBox_IpAddres
			// 
			TextBox_IpAddres.Location = new Point(109, 22);
			TextBox_IpAddres.Name = "TextBox_IpAddres";
			TextBox_IpAddres.Size = new Size(146, 23);
			TextBox_IpAddres.TabIndex = 1;
			TextBox_IpAddres.Text = "127.0.0.1";
			// 
			// Btn_Disconnect
			// 
			Btn_Disconnect.Location = new Point(428, 101);
			Btn_Disconnect.Name = "Btn_Disconnect";
			Btn_Disconnect.Size = new Size(87, 26);
			Btn_Disconnect.TabIndex = 10;
			Btn_Disconnect.Text = "Disconnect";
			Btn_Disconnect.UseVisualStyleBackColor = true;
			Btn_Disconnect.Click += Btn_Disconnect_Click;
			// 
			// Btn_Connect
			// 
			Btn_Connect.Location = new Point(335, 101);
			Btn_Connect.Name = "Btn_Connect";
			Btn_Connect.Size = new Size(87, 26);
			Btn_Connect.TabIndex = 9;
			Btn_Connect.Text = "Connect";
			Btn_Connect.UseVisualStyleBackColor = true;
			Btn_Connect.Click += Btn_Connect_Click;
			// 
			// Btn_GetQuote
			// 
			Btn_GetQuote.Location = new Point(427, 504);
			Btn_GetQuote.Name = "Btn_GetQuote";
			Btn_GetQuote.Size = new Size(88, 23);
			Btn_GetQuote.TabIndex = 13;
			Btn_GetQuote.Text = "Get Quote";
			Btn_GetQuote.UseVisualStyleBackColor = true;
			Btn_GetQuote.Click += Btn_GetQuote_Click;
			// 
			// TextBox_Quotes
			// 
			TextBox_Quotes.Location = new Point(12, 133);
			TextBox_Quotes.Multiline = true;
			TextBox_Quotes.Name = "TextBox_Quotes";
			TextBox_Quotes.ReadOnly = true;
			TextBox_Quotes.Size = new Size(503, 365);
			TextBox_Quotes.TabIndex = 14;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(261, 25);
			label3.Name = "label3";
			label3.Size = new Size(40, 15);
			label3.TabIndex = 6;
			label3.Text = "Login:";
			// 
			// TextBox_Login
			// 
			TextBox_Login.Location = new Point(343, 22);
			TextBox_Login.Name = "TextBox_Login";
			TextBox_Login.Size = new Size(146, 23);
			TextBox_Login.TabIndex = 7;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(261, 54);
			label4.Name = "label4";
			label4.Size = new Size(60, 15);
			label4.TabIndex = 8;
			label4.Text = "Password:";
			// 
			// TextBox_Password
			// 
			TextBox_Password.Location = new Point(343, 51);
			TextBox_Password.Name = "TextBox_Password";
			TextBox_Password.PasswordChar = '*';
			TextBox_Password.Size = new Size(146, 23);
			TextBox_Password.TabIndex = 9;
			// 
			// MainFormClient
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(527, 539);
			Controls.Add(TextBox_Quotes);
			Controls.Add(Btn_GetQuote);
			Controls.Add(GroupBox_Connection);
			Controls.Add(Btn_Disconnect);
			Controls.Add(Btn_Connect);
			Name = "MainFormClient";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Quote generator";
			GroupBox_Connection.ResumeLayout(false);
			GroupBox_Connection.PerformLayout();
			((System.ComponentModel.ISupportInitialize)NUD_Port).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private GroupBox GroupBox_Connection;
		private Label label1;
		private NumericUpDown NUD_Port;
		private Label label2;
		private TextBox TextBox_IpAddres;
		private Button Btn_Disconnect;
		private Button Btn_Connect;
		private Button Btn_GetQuote;
		private TextBox TextBox_Quotes;
		private Label label4;
		private TextBox TextBox_Password;
		private Label label3;
		private TextBox TextBox_Login;
	}
}