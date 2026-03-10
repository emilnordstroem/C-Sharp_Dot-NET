namespace Lektion_12_MAUI;

public partial class BasicGridPage : ContentPage
{
	public BasicGridPage()
	{
		InitializeComponent();
	}

	private void SwichUpper_Clicked(object sender, EventArgs e)
	{
		string temp = Row0Column0.Text;
		Row0Column0.Text = Row0Column2.Text;
		Row0Column2.Text = temp;
	}

	private void SwitchLower_Clicked(object sender, EventArgs e)
	{
		string temp = Row1Column0.Text;
		Row1Column0.Text = Row1Column2.Text;
		Row1Column2.Text = temp;
	}
}