using CalculateurAge.Services;
using CalculateurAge.ViewModels;

namespace CalculateurAge.Views;

public partial class ResultatPage : ContentPage
{
	public ResultatPage()
	{
		InitializeComponent();
		BindingContext = new ResultatViewModel(new ShellNavigationService());
	}
}
