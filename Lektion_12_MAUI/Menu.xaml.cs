namespace Lektion_12_MAUI;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}

	private void MenuFlyoutItem_Clicked(object sender, EventArgs e)
	{
		SelectedMenuItem.Text = ((MenuFlyoutItem)sender).Text;
	}
}