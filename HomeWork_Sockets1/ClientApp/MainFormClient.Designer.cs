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
			TextBox_Exchanges = new TextBox();
			Btn_GetExchange = new Button();
			GroupBox_Connection = new GroupBox();
			label4 = new Label();
			TextBox_Password = new TextBox();
			label3 = new Label();
			label1 = new Label();
			NUD_Port = new NumericUpDown();
			TextBox_Login = new TextBox();
			label2 = new Label();
			TextBox_IpAddres = new TextBox();
			Btn_Disconnect = new Button();
			Btn_Connect = new Button();
			ComboBox_FromCurrency = new ComboBox();
			ComboBox_ToCurrency = new ComboBox();
			label5 = new Label();
			label6 = new Label();
			GroupBox_Connection.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)NUD_Port).BeginInit();
			SuspendLayout();
			// 
			// TextBox_Exchanges
			// 
			TextBox_Exchanges.Location = new Point(12, 133);
			TextBox_Exchanges.Multiline = true;
			TextBox_Exchanges.Name = "TextBox_Exchanges";
			TextBox_Exchanges.ReadOnly = true;
			TextBox_Exchanges.Size = new Size(503, 365);
			TextBox_Exchanges.TabIndex = 19;
			// 
			// Btn_GetExchange
			// 
			Btn_GetExchange.Location = new Point(427, 504);
			Btn_GetExchange.Name = "Btn_GetExchange";
			Btn_GetExchange.Size = new Size(88, 23);
			Btn_GetExchange.TabIndex = 18;
			Btn_GetExchange.Text = "Get Exchange";
			Btn_GetExchange.UseVisualStyleBackColor = true;
			Btn_GetExchange.Click += Btn_GetExchange_Click;
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
			GroupBox_Connection.TabIndex = 17;
			GroupBox_Connection.TabStop = false;
			GroupBox_Connection.Text = "Connection";
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
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(261, 25);
			label3.Name = "label3";
			label3.Size = new Size(40, 15);
			label3.TabIndex = 6;
			label3.Text = "Login:";
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
			// TextBox_Login
			// 
			TextBox_Login.Location = new Point(343, 22);
			TextBox_Login.Name = "TextBox_Login";
			TextBox_Login.Size = new Size(146, 23);
			TextBox_Login.TabIndex = 7;
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
			Btn_Disconnect.TabIndex = 16;
			Btn_Disconnect.Text = "Disconnect";
			Btn_Disconnect.UseVisualStyleBackColor = true;
			Btn_Disconnect.Click += Btn_Disconnect_Click;
			// 
			// Btn_Connect
			// 
			Btn_Connect.Location = new Point(335, 101);
			Btn_Connect.Name = "Btn_Connect";
			Btn_Connect.Size = new Size(87, 26);
			Btn_Connect.TabIndex = 15;
			Btn_Connect.Text = "Connect";
			Btn_Connect.UseVisualStyleBackColor = true;
			Btn_Connect.Click += Btn_Connect_Click;
			// 
			// ComboBox_FromCurrency
			// 
			ComboBox_FromCurrency.FormattingEnabled = true;
			ComboBox_FromCurrency.Location = new Point(133, 505);
			ComboBox_FromCurrency.Name = "ComboBox_FromCurrency";
			ComboBox_FromCurrency.Size = new Size(93, 23);
			ComboBox_FromCurrency.TabIndex = 20;
			// 
			// ComboBox_ToCurrency
			// 
			ComboBox_ToCurrency.FormattingEnabled = true;
			ComboBox_ToCurrency.Location = new Point(260, 505);
			ComboBox_ToCurrency.Name = "ComboBox_ToCurrency";
			ComboBox_ToCurrency.Size = new Size(93, 23);
			ComboBox_ToCurrency.TabIndex = 21;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(92, 508);
			label5.Name = "label5";
			label5.Size = new Size(35, 15);
			label5.TabIndex = 22;
			label5.Text = "From";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(235, 508);
			label6.Name = "label6";
			label6.Size = new Size(19, 15);
			label6.TabIndex = 23;
			label6.Text = "To";
			// 
			// MainFormClient
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(525, 536);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(ComboBox_ToCurrency);
			Controls.Add(ComboBox_FromCurrency);
			Controls.Add(TextBox_Exchanges);
			Controls.Add(Btn_GetExchange);
			Controls.Add(GroupBox_Connection);
			Controls.Add(Btn_Disconnect);
			Controls.Add(Btn_Connect);
			Name = "MainFormClient";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Exchange rates";
			GroupBox_Connection.ResumeLayout(false);
			GroupBox_Connection.PerformLayout();
			((System.ComponentModel.ISupportInitialize)NUD_Port).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox TextBox_Exchanges;
		private Button Btn_GetExchange;
		private GroupBox GroupBox_Connection;
		private Label label4;
		private TextBox TextBox_Password;
		private Label label3;
		private Label label1;
		private NumericUpDown NUD_Port;
		private TextBox TextBox_Login;
		private Label label2;
		private TextBox TextBox_IpAddres;
		private Button Btn_Disconnect;
		private Button Btn_Connect;
		private ComboBox ComboBox_FromCurrency;
		private ComboBox ComboBox_ToCurrency;
		private Label label5;
		private Label label6;
	}
}