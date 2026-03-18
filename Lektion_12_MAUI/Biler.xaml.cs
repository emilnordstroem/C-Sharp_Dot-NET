using System.Collections.ObjectModel;
using Lektion_12_MAUI.Models;
using Microsoft.Maui.Controls.Platform;

namespace Lektion_12_MAUI;

public partial class Biler : ContentPage
{
	public ObservableCollection<Bil> BilerListe { get; set; } = new();

	// bil bliver behandlet som en property og ikke et data felt
	public Bil bil { get; set; } = new Bil
	{
		Model = "Porsche",
		Hestekrafter = 300,
		Eldreven = true
	};

	public Biler()
	{
		InitializeComponent();

		BilerListe.Add(new Bil { Model = "Mercedes", Hestekrafter = 450, Eldreven = true });
		BilerListe.Add(new Bil { Model = "Opel", Hestekrafter = 120, Eldreven = false });

		BindingContext = this;
	}

	private void SeBilDetaljer(object sender, EventArgs e)
	{
		DisplayAlertAsync("Bil", $"{bil.Model} {bil.Hestekrafter} {bil.Eldreven}", "OK");
	}

	private void GendanBilDetaljer(object sender, EventArgs e)
	{
		bil.Model = "Porsche";
		bil.Hestekrafter = 300;
		bil.Eldreven = true;
	}
}