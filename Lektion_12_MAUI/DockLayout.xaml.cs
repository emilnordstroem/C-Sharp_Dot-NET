using System.Collections.ObjectModel;

namespace Lektion_12_MAUI;

public partial class DockLayout : ContentPage
{
	public ObservableCollection<string> Items { get; set; } = new();

	public DockLayout()
	{
		InitializeComponent();
		BindingContext = this;
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		Items.Add(((Button)sender).Text);
	}

}