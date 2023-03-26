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
			Btn_Start = new Button();
			TextBox_Messages = new TextBox();
			TextBox_Message = new TextBox();
			label1 = new Label();
			SuspendLayout();
			// 
			// Btn_Start
			// 
			Btn_Start.Location = new Point(363, 247);
			Btn_Start.Name = "Btn_Start";
			Btn_Start.Size = new Size(75, 23);
			Btn_Start.TabIndex = 0;
			Btn_Start.Text = "Send";
			Btn_Start.UseVisualStyleBackColor = true;
			Btn_Start.Click += Btn_Start_Click;
			// 
			// TextBox_Messages
			// 
			TextBox_Messages.Location = new Point(12, 27);
			TextBox_Messages.Multiline = true;
			TextBox_Messages.Name = "TextBox_Messages";
			TextBox_Messages.ReadOnly = true;
			TextBox_Messages.Size = new Size(426, 214);
			TextBox_Messages.TabIndex = 1;
			// 
			// TextBox_Message
			// 
			TextBox_Message.Location = new Point(12, 247);
			TextBox_Message.Name = "TextBox_Message";
			TextBox_Message.Size = new Size(345, 23);
			TextBox_Message.TabIndex = 2;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(57, 15);
			label1.TabIndex = 3;
			label1.Text = "Greetings";
			// 
			// MainFormClient
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(450, 283);
			Controls.Add(label1);
			Controls.Add(TextBox_Message);
			Controls.Add(TextBox_Messages);
			Controls.Add(Btn_Start);
			Name = "MainFormClient";
			Text = "Application Greetings";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button Btn_Start;
		private TextBox TextBox_Messages;
		private TextBox TextBox_Message;
		private Label label1;
	}
}