namespace CalculateurAge.ViewModels;

// ViewModel de ResultatPage : reçoit les données du ViewModel précédent.
public class ResultatViewModel : BaseViewModel, IQueryAttributable
{
	private readonly INavigationService _navigation;
	private string _titre = "";
	private string _message = "";
	private string _jours = "";

	public string Titre
	{
		get => _titre;
		set => SetField(ref _titre, value);
	}

	public string Message
	{
		get => _message;
		set => SetField(ref _message, value);
	}

	public string Jours
	{
		get => _jours;
		set => SetField(ref _jours, value);
	}

	public RelayCommand RetourCommand { get; }

	public ResultatViewModel(INavigationService navigation)
	{
		_navigation = navigation;
		RetourCommand = new RelayCommand(() => _ = _navigation.RetourAsync());
	}

	// Appelée par Shell avec les paramètres de GoToAsync.
	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		Titre = $"{query["nom"]}, vous avez {query["age"]} ans";
		Message = (string)query["message"];
		Jours = (string)query["jours"];
	}
}
