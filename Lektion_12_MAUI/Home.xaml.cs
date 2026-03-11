namespace Lektion_12_MAUI;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
	}

	private void AddLeftInputToLeftPicker(object sender, EventArgs e)
	{
		if (!string.IsNullOrWhiteSpace(LeftSideEntry.Text))
		{
			LeftSidePicker.Items.Add(LeftSideEntry.Text);
			LeftSideEntry.Text = "";
		}
	}

	private void AddRightInputToRightPicker(object sender, EventArgs e)
	{
		if (!string.IsNullOrWhiteSpace(RightSideEntry.Text))
		{
			RightSidePicker.Items.Add(RightSideEntry.Text);
			RightSideEntry.Text = "";
		}
	}

	private void LeftSideClear(object sender, EventArgs e)
	{
		LeftSidePicker.Items.Clear();
	}

	private void RightSideClear(object sender, EventArgs e)
	{
		RightSidePicker.Items.Clear();
	}

	private void MoveLeftToRight(object sender, EventArgs e)
	{
		foreach (var item in LeftSidePicker.Items)
		{
			RightSidePicker.Items.Add(item);
		}
		LeftSidePicker.Items.Clear();
	}

	private void MoveRightToLeft(object sender, EventArgs e)
	{
		foreach (var item in RightSidePicker.Items)
		{
			LeftSidePicker.Items.Add(item);
		}
		RightSidePicker.Items.Clear();
	}
}