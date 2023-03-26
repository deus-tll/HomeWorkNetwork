namespace ClientApp;

partial class ClientAppForm
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
		TabControl_Commands = new TabControl();
		TabPage_GetDate = new TabPage();
		TextBox_DateFromServer = new TextBox();
		label1 = new Label();
		TabPage_GetTime = new TabPage();
		TextBox_TimeFromServer = new TextBox();
		label2 = new Label();
		TabPage_GetRandomArray = new TabPage();
		label3 = new Label();
		ListBox_RandomArrayFromServer = new ListBox();
		TabPage_SortArray = new TabPage();
		Btn_RemoveNumber = new Button();
		Btn_AddNumber = new Button();
		TextBox_Number = new TextBox();
		label5 = new Label();
		ListBox_YourSortedArray = new ListBox();
		label4 = new Label();
		ListBox_YourArrayForSorting = new ListBox();
		TabPage_GetPictureByName = new TabPage();
		PictureBox_PictureByName = new PictureBox();
		TextBox_PictureName = new TextBox();
		label6 = new Label();
		TabPage_StartProcessByName = new TabPage();
		Label_IsExecuted = new Label();
		TextBox_ProcessName = new TextBox();
		label7 = new Label();
		Btn_OrderCommand = new Button();
		Btn_Disconnect = new Button();
		Btn_Connect = new Button();
		TabControl_Commands.SuspendLayout();
		TabPage_GetDate.SuspendLayout();
		TabPage_GetTime.SuspendLayout();
		TabPage_GetRandomArray.SuspendLayout();
		TabPage_SortArray.SuspendLayout();
		TabPage_GetPictureByName.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)PictureBox_PictureByName).BeginInit();
		TabPage_StartProcessByName.SuspendLayout();
		SuspendLayout();
		// 
		// TabControl_Commands
		// 
		TabControl_Commands.Controls.Add(TabPage_GetDate);
		TabControl_Commands.Controls.Add(TabPage_GetTime);
		TabControl_Commands.Controls.Add(TabPage_GetRandomArray);
		TabControl_Commands.Controls.Add(TabPage_SortArray);
		TabControl_Commands.Controls.Add(TabPage_GetPictureByName);
		TabControl_Commands.Controls.Add(TabPage_StartProcessByName);
		TabControl_Commands.Location = new Point(12, 12);
		TabControl_Commands.Name = "TabControl_Commands";
		TabControl_Commands.SelectedIndex = 0;
		TabControl_Commands.Size = new Size(556, 429);
		TabControl_Commands.TabIndex = 0;
		// 
		// TabPage_GetDate
		// 
		TabPage_GetDate.Controls.Add(TextBox_DateFromServer);
		TabPage_GetDate.Controls.Add(label1);
		TabPage_GetDate.Location = new Point(4, 24);
		TabPage_GetDate.Name = "TabPage_GetDate";
		TabPage_GetDate.Padding = new Padding(3);
		TabPage_GetDate.Size = new Size(548, 401);
		TabPage_GetDate.TabIndex = 0;
		TabPage_GetDate.Text = "Get Date";
		TabPage_GetDate.UseVisualStyleBackColor = true;
		// 
		// TextBox_DateFromServer
		// 
		TextBox_DateFromServer.Location = new Point(6, 35);
		TextBox_DateFromServer.Name = "TextBox_DateFromServer";
		TextBox_DateFromServer.ReadOnly = true;
		TextBox_DateFromServer.Size = new Size(261, 23);
		TextBox_DateFromServer.TabIndex = 1;
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new Point(6, 17);
		label1.Name = "label1";
		label1.Size = new Size(117, 15);
		label1.TabIndex = 0;
		label1.Text = "Date from the server:";
		// 
		// TabPage_GetTime
		// 
		TabPage_GetTime.Controls.Add(TextBox_TimeFromServer);
		TabPage_GetTime.Controls.Add(label2);
		TabPage_GetTime.Location = new Point(4, 24);
		TabPage_GetTime.Name = "TabPage_GetTime";
		TabPage_GetTime.Size = new Size(548, 401);
		TabPage_GetTime.TabIndex = 5;
		TabPage_GetTime.Text = "Get Time";
		TabPage_GetTime.UseVisualStyleBackColor = true;
		// 
		// TextBox_TimeFromServer
		// 
		TextBox_TimeFromServer.Location = new Point(3, 38);
		TextBox_TimeFromServer.Name = "TextBox_TimeFromServer";
		TextBox_TimeFromServer.ReadOnly = true;
		TextBox_TimeFromServer.Size = new Size(261, 23);
		TextBox_TimeFromServer.TabIndex = 3;
		// 
		// label2
		// 
		label2.AutoSize = true;
		label2.Location = new Point(3, 20);
		label2.Name = "label2";
		label2.Size = new Size(119, 15);
		label2.TabIndex = 2;
		label2.Text = "Time from the server:";
		// 
		// TabPage_GetRandomArray
		// 
		TabPage_GetRandomArray.Controls.Add(label3);
		TabPage_GetRandomArray.Controls.Add(ListBox_RandomArrayFromServer);
		TabPage_GetRandomArray.Location = new Point(4, 24);
		TabPage_GetRandomArray.Name = "TabPage_GetRandomArray";
		TabPage_GetRandomArray.Padding = new Padding(3);
		TabPage_GetRandomArray.Size = new Size(548, 401);
		TabPage_GetRandomArray.TabIndex = 1;
		TabPage_GetRandomArray.Text = "Get Random Array";
		TabPage_GetRandomArray.UseVisualStyleBackColor = true;
		// 
		// label3
		// 
		label3.AutoSize = true;
		label3.Location = new Point(6, 12);
		label3.Name = "label3";
		label3.Size = new Size(147, 15);
		label3.TabIndex = 1;
		label3.Text = "Random array from server:";
		// 
		// ListBox_RandomArrayFromServer
		// 
		ListBox_RandomArrayFromServer.FormattingEnabled = true;
		ListBox_RandomArrayFromServer.ItemHeight = 15;
		ListBox_RandomArrayFromServer.Location = new Point(6, 30);
		ListBox_RandomArrayFromServer.Name = "ListBox_RandomArrayFromServer";
		ListBox_RandomArrayFromServer.Size = new Size(258, 364);
		ListBox_RandomArrayFromServer.TabIndex = 0;
		// 
		// TabPage_SortArray
		// 
		TabPage_SortArray.Controls.Add(Btn_RemoveNumber);
		TabPage_SortArray.Controls.Add(Btn_AddNumber);
		TabPage_SortArray.Controls.Add(TextBox_Number);
		TabPage_SortArray.Controls.Add(label5);
		TabPage_SortArray.Controls.Add(ListBox_YourSortedArray);
		TabPage_SortArray.Controls.Add(label4);
		TabPage_SortArray.Controls.Add(ListBox_YourArrayForSorting);
		TabPage_SortArray.Location = new Point(4, 24);
		TabPage_SortArray.Name = "TabPage_SortArray";
		TabPage_SortArray.Size = new Size(548, 401);
		TabPage_SortArray.TabIndex = 2;
		TabPage_SortArray.Text = "Sort Array";
		TabPage_SortArray.UseVisualStyleBackColor = true;
		// 
		// Btn_RemoveNumber
		// 
		Btn_RemoveNumber.Location = new Point(189, 354);
		Btn_RemoveNumber.Name = "Btn_RemoveNumber";
		Btn_RemoveNumber.Size = new Size(72, 23);
		Btn_RemoveNumber.TabIndex = 8;
		Btn_RemoveNumber.Text = "Remove";
		Btn_RemoveNumber.UseVisualStyleBackColor = true;
		Btn_RemoveNumber.Click += Btn_RemoveNumber_Click;
		// 
		// Btn_AddNumber
		// 
		Btn_AddNumber.Location = new Point(115, 355);
		Btn_AddNumber.Name = "Btn_AddNumber";
		Btn_AddNumber.Size = new Size(68, 23);
		Btn_AddNumber.TabIndex = 7;
		Btn_AddNumber.Text = "Add";
		Btn_AddNumber.UseVisualStyleBackColor = true;
		Btn_AddNumber.Click += Btn_AddNumber_Click;
		// 
		// TextBox_Number
		// 
		TextBox_Number.Location = new Point(9, 355);
		TextBox_Number.Name = "TextBox_Number";
		TextBox_Number.Size = new Size(100, 23);
		TextBox_Number.TabIndex = 6;
		// 
		// label5
		// 
		label5.AutoSize = true;
		label5.Location = new Point(267, 12);
		label5.Name = "label5";
		label5.Size = new Size(167, 15);
		label5.TabIndex = 5;
		label5.Text = "Your array but sorted in server:";
		// 
		// ListBox_YourSortedArray
		// 
		ListBox_YourSortedArray.FormattingEnabled = true;
		ListBox_YourSortedArray.ItemHeight = 15;
		ListBox_YourSortedArray.Location = new Point(267, 30);
		ListBox_YourSortedArray.Name = "ListBox_YourSortedArray";
		ListBox_YourSortedArray.Size = new Size(258, 319);
		ListBox_YourSortedArray.TabIndex = 4;
		// 
		// label4
		// 
		label4.AutoSize = true;
		label4.Location = new Point(3, 12);
		label4.Name = "label4";
		label4.Size = new Size(121, 15);
		label4.TabIndex = 3;
		label4.Text = "Your array for sorting:";
		// 
		// ListBox_YourArrayForSorting
		// 
		ListBox_YourArrayForSorting.FormattingEnabled = true;
		ListBox_YourArrayForSorting.ItemHeight = 15;
		ListBox_YourArrayForSorting.Location = new Point(3, 30);
		ListBox_YourArrayForSorting.Name = "ListBox_YourArrayForSorting";
		ListBox_YourArrayForSorting.Size = new Size(258, 319);
		ListBox_YourArrayForSorting.TabIndex = 2;
		// 
		// TabPage_GetPictureByName
		// 
		TabPage_GetPictureByName.Controls.Add(PictureBox_PictureByName);
		TabPage_GetPictureByName.Controls.Add(TextBox_PictureName);
		TabPage_GetPictureByName.Controls.Add(label6);
		TabPage_GetPictureByName.Location = new Point(4, 24);
		TabPage_GetPictureByName.Name = "TabPage_GetPictureByName";
		TabPage_GetPictureByName.Size = new Size(548, 401);
		TabPage_GetPictureByName.TabIndex = 3;
		TabPage_GetPictureByName.Text = "Get Picture by Name";
		TabPage_GetPictureByName.UseVisualStyleBackColor = true;
		// 
		// PictureBox_PictureByName
		// 
		PictureBox_PictureByName.Location = new Point(3, 77);
		PictureBox_PictureByName.Name = "PictureBox_PictureByName";
		PictureBox_PictureByName.Size = new Size(402, 296);
		PictureBox_PictureByName.SizeMode = PictureBoxSizeMode.StretchImage;
		PictureBox_PictureByName.TabIndex = 4;
		PictureBox_PictureByName.TabStop = false;
		// 
		// TextBox_PictureName
		// 
		TextBox_PictureName.Location = new Point(3, 39);
		TextBox_PictureName.Name = "TextBox_PictureName";
		TextBox_PictureName.Size = new Size(261, 23);
		TextBox_PictureName.TabIndex = 3;
		// 
		// label6
		// 
		label6.AutoSize = true;
		label6.Location = new Point(3, 21);
		label6.Name = "label6";
		label6.Size = new Size(144, 15);
		label6.TabIndex = 2;
		label6.Text = "Enter the name of picture:";
		// 
		// TabPage_StartProcessByName
		// 
		TabPage_StartProcessByName.Controls.Add(Label_IsExecuted);
		TabPage_StartProcessByName.Controls.Add(TextBox_ProcessName);
		TabPage_StartProcessByName.Controls.Add(label7);
		TabPage_StartProcessByName.Location = new Point(4, 24);
		TabPage_StartProcessByName.Name = "TabPage_StartProcessByName";
		TabPage_StartProcessByName.Size = new Size(548, 401);
		TabPage_StartProcessByName.TabIndex = 4;
		TabPage_StartProcessByName.Text = "Start Process by Name";
		TabPage_StartProcessByName.UseVisualStyleBackColor = true;
		// 
		// Label_IsExecuted
		// 
		Label_IsExecuted.AutoSize = true;
		Label_IsExecuted.Location = new Point(3, 84);
		Label_IsExecuted.Name = "Label_IsExecuted";
		Label_IsExecuted.Size = new Size(0, 15);
		Label_IsExecuted.TabIndex = 6;
		// 
		// TextBox_ProcessName
		// 
		TextBox_ProcessName.Location = new Point(3, 46);
		TextBox_ProcessName.Name = "TextBox_ProcessName";
		TextBox_ProcessName.Size = new Size(261, 23);
		TextBox_ProcessName.TabIndex = 5;
		// 
		// label7
		// 
		label7.AutoSize = true;
		label7.Location = new Point(3, 28);
		label7.Name = "label7";
		label7.Size = new Size(147, 15);
		label7.TabIndex = 4;
		label7.Text = "Enter the name of process:";
		// 
		// Btn_OrderCommand
		// 
		Btn_OrderCommand.Location = new Point(12, 447);
		Btn_OrderCommand.Name = "Btn_OrderCommand";
		Btn_OrderCommand.Size = new Size(113, 23);
		Btn_OrderCommand.TabIndex = 1;
		Btn_OrderCommand.Text = "Order Command";
		Btn_OrderCommand.UseVisualStyleBackColor = true;
		Btn_OrderCommand.Click += Btn_OrderCommand_Click;
		// 
		// Btn_Disconnect
		// 
		Btn_Disconnect.Location = new Point(238, 447);
		Btn_Disconnect.Name = "Btn_Disconnect";
		Btn_Disconnect.Size = new Size(101, 23);
		Btn_Disconnect.TabIndex = 2;
		Btn_Disconnect.Text = "Disconnect";
		Btn_Disconnect.UseVisualStyleBackColor = true;
		Btn_Disconnect.Click += Btn_Disconnect_Click;
		// 
		// Btn_Connect
		// 
		Btn_Connect.Location = new Point(131, 447);
		Btn_Connect.Name = "Btn_Connect";
		Btn_Connect.Size = new Size(101, 23);
		Btn_Connect.TabIndex = 3;
		Btn_Connect.Text = "Connect";
		Btn_Connect.UseVisualStyleBackColor = true;
		Btn_Connect.Click += Btn_Connect_Click;
		// 
		// ClientAppForm
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(580, 482);
		Controls.Add(Btn_Connect);
		Controls.Add(Btn_Disconnect);
		Controls.Add(Btn_OrderCommand);
		Controls.Add(TabControl_Commands);
		Name = "ClientAppForm";
		Text = "Client Application";
		TabControl_Commands.ResumeLayout(false);
		TabPage_GetDate.ResumeLayout(false);
		TabPage_GetDate.PerformLayout();
		TabPage_GetTime.ResumeLayout(false);
		TabPage_GetTime.PerformLayout();
		TabPage_GetRandomArray.ResumeLayout(false);
		TabPage_GetRandomArray.PerformLayout();
		TabPage_SortArray.ResumeLayout(false);
		TabPage_SortArray.PerformLayout();
		TabPage_GetPictureByName.ResumeLayout(false);
		TabPage_GetPictureByName.PerformLayout();
		((System.ComponentModel.ISupportInitialize)PictureBox_PictureByName).EndInit();
		TabPage_StartProcessByName.ResumeLayout(false);
		TabPage_StartProcessByName.PerformLayout();
		ResumeLayout(false);
	}

	#endregion

	private TabControl TabControl_Commands;
	private TabPage TabPage_GetDate;
	private TabPage TabPage_GetRandomArray;
	private TabPage TabPage_SortArray;
	private TabPage TabPage_GetPictureByName;
	private TabPage TabPage_StartProcessByName;
	private Button Btn_OrderCommand;
	private TabPage TabPage_GetTime;
	private TextBox TextBox_DateFromServer;
	private Label label1;
	private TextBox TextBox_TimeFromServer;
	private Label label2;
	private Label label3;
	private ListBox ListBox_RandomArrayFromServer;
	private Label label5;
	private ListBox ListBox_YourSortedArray;
	private Label label4;
	private ListBox ListBox_YourArrayForSorting;
	private TextBox TextBox_PictureName;
	private Label label6;
	private PictureBox PictureBox_PictureByName;
	private TextBox TextBox_ProcessName;
	private Label label7;
	private Button Btn_RemoveNumber;
	private Button Btn_AddNumber;
	private TextBox TextBox_Number;
	private Label Label_IsExecuted;
	private Button Btn_Disconnect;
	private Button Btn_Connect;
}
