using LibraryModels;
using MessagePack;

namespace ClientApp;

public partial class ClientAppForm : Form
{
	private readonly MyClient client = new();
	private List<int> numbers = new();

	public ClientAppForm()
	{
		InitializeComponent();
		FillTabItemTags();
	}

	private void FillTabItemTags()
	{
		TabPage_GetDate.Tag = Command.GetDate;
		TabPage_GetTime.Tag = Command.GetTime;
		TabPage_GetRandomArray.Tag = Command.GetRandomArray;
		TabPage_SortArray.Tag = Command.SortArray;
		TabPage_GetPictureByName.Tag = Command.GetPictureByName;
		TabPage_StartProcessByName.Tag = Command.StartProcessByName;
	}

	private void Btn_OrderCommand_Click(object sender, EventArgs e)
	{
		TabPage tabPage = TabControl_Commands.SelectedTab;

		Command? command = (Command?)tabPage.Tag;
		if (command is null) return;

		var data = CreateData((Command)command);

		var receivedData = client.OrderCommand(data);
		if (receivedData is null) return;

		ReceiveData(receivedData);
	}


	private MyData CreateData(Command command)
	{
		MyData data = new()
		{
			Command = command,
			Content = null
		};

		switch (data.Command)
		{
			case Command.SortArray: SetContent_SortArray(ref data); break;
			case Command.GetPictureByName: SetContent_GetPictureByName(ref data); break;
			case Command.StartProcessByName: SetContent_StartProcessByName(ref data); break;
		}

		return data;
	}


	private void SetContent_SortArray(ref MyData data)
	{
		data.Content = numbers.ToArray();
	}


	private void SetContent_GetPictureByName(ref MyData data)
	{
		if (string.IsNullOrEmpty(TextBox_PictureName.Text)) return;

		data.Content = TextBox_PictureName.Text;
	}


	private void SetContent_StartProcessByName(ref MyData data)
	{
		if (string.IsNullOrEmpty(TextBox_ProcessName.Text)) return;

		data.Content = TextBox_ProcessName.Text;
	}


	private void Btn_AddNumber_Click(object sender, EventArgs e)
	{
		if (!int.TryParse(TextBox_Number.Text, out int number)) return;

		numbers.Add(number);

		ListBox_YourArrayForSorting.DataSource = null;
		ListBox_YourArrayForSorting.DataSource = numbers;
	}


	private void Btn_RemoveNumber_Click(object sender, EventArgs e)
	{
		int n = ListBox_YourArrayForSorting.SelectedIndex;
		if (n >= 0)
		{
			numbers.RemoveAt(n);

			ListBox_YourArrayForSorting.DataSource = null;
			ListBox_YourArrayForSorting.DataSource = numbers;
		}
	}


	private void ReceiveData(MyData data)
	{
		switch (data.Command)
		{
			case Command.GetDate: GetDate(data); break;
			case Command.GetTime: GetTime(data); break;
			case Command.GetRandomArray: GetRandomArray(data); break;
			case Command.SortArray: SortArray(data); break;
			case Command.GetPictureByName: GetPictureByName(data); break;
			case Command.StartProcessByName: StartProcessByName(data); break;
		}
	}

	private void GetDate(MyData data)
	{
		TextBox_DateFromServer.Text = data.Content?.ToString();
	}


	private void GetTime(MyData data)
	{
		TextBox_TimeFromServer.Text = data.Content?.ToString();
	}

	private static int[] GetListOfInts(MyData data)
	{
		object[]? objects = data.Content as object[];
		if (objects is null) return Array.Empty<int>();

		int[] array = new int[objects.Length];

		for (int i = 0; i < objects.Length; i++)
		{
			array[i] = Convert.ToInt32(objects[i]);
		}

		return array;
	}

	private void GetRandomArray(MyData data)
	{
		int[] array = GetListOfInts(data);

		ListBox_RandomArrayFromServer.DataSource = null;
		ListBox_RandomArrayFromServer.DataSource = array;
	}


	private void SortArray(MyData data)
	{
		int[] array = GetListOfInts(data);

		ListBox_YourSortedArray.DataSource = null;
		ListBox_YourSortedArray.DataSource = array;
	}


	private void GetPictureByName(MyData data)
	{
		byte[]? messagePackBytes = data.Content as byte[];
		if (messagePackBytes is null) return;

		byte[] bytes = MessagePackSerializer.Deserialize<byte[]>(messagePackBytes);

		using var ms = new MemoryStream(bytes);
		Bitmap bitmap = new(ms);

		PictureBox_PictureByName.Image = null;
		PictureBox_PictureByName.Image = bitmap;
	}

	private void StartProcessByName(MyData data)
	{
		Label_IsExecuted.Text = data.Content?.ToString();
	}
}
