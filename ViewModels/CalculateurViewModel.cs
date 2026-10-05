namespace CalculateurAge.ViewModels;

public class CalculateurViewModel : BaseViewModel
{
	// Contient l'ÉTAT de l'écran et les ACTIONS possibles.
	// Champs privés : la vraie donnée.
	private string _nom = "";
	private DateTime _dateNaissance =
		DateTime.Today.AddYears(-20);
	private string _resultat = "";
	private bool _resultatVisible;
	private string _message = "";

	// Propriétés publiques : ce que le XAML voit.
	public string Nom
	{
		get => _nom;
		set { if (SetField(ref _nom, value))
				  CalculerCommand.Rafraichir(); }
	}

	public DateTime DateNaissance
	{
		get => _dateNaissance;
		set { if (SetField(ref _dateNaissance, value))
				  CalculerCommand.Rafraichir(); }
	}

	// Fonctionnalité 1 : statut "Majeur" / "Mineur".
	public string Message
	{
		get => _message;
		set => SetField(ref _message, value);
	}

	// Le Calculer n'est possible que pour un nom saisi
	// et une date de naissance qui n'est pas dans le futur.
	public bool PeutCalculer
		=> !string.IsNullOrWhiteSpace(Nom)
		   && DateNaissance.Date <= DateTime.Today;

	public string Resultat
	{
		get => _resultat;
		set => SetField(ref _resultat, value);
	}

	public bool ResultatVisible
	{
		get => _resultatVisible;
		set => SetField(ref _resultatVisible, value);
	}

	// Lié à Button.Command dans le XAML.
	public RelayCommand CalculerCommand { get; }

	// Fonctionnalité 2 : remet tous les champs à zéro.
	public RelayCommand EffacerCommand { get; }

	public CalculateurViewModel()
	{
		CalculerCommand = new RelayCommand(
			Calculer,
			() => PeutCalculer);
		EffacerCommand = new RelayCommand(Effacer);
	}

	// La logique métier : aucun contrôle d'interface ici.
	private void Calculer()
	{
		int age = DateTime.Today.Year - DateNaissance.Year;
		if (DateNaissance.Date >
			DateTime.Today.AddYears(-age)) age--;

		Resultat = $"{Nom}, vous avez {age} ans";
		Message = age >= 18 ? "Majeur" : "Mineur";
		ResultatVisible = true;
	}

	private void Effacer()
	{
		Nom = "";
		DateNaissance = DateTime.Today.AddYears(-20);
		Resultat = "";
		Message = "";
		ResultatVisible = false;
	}
}
