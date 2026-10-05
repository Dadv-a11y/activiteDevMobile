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
	private string _joursAnniversaire = "";

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

	// Fonctionnalité 3 : jours restants avant le prochain anniversaire.
	public string JoursAnniversaire
	{
		get => _joursAnniversaire;
		set => SetField(ref _joursAnniversaire, value);
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

		int jours = JoursAvantAnniversaire(DateNaissance, DateTime.Today);
		JoursAnniversaire = jours == 0
			? "Joyeux anniversaire !"
			: $"Prochain anniversaire dans {jours} jour(s)";
		ResultatVisible = true;
	}

	private void Effacer()
	{
		Nom = "";
		DateNaissance = DateTime.Today.AddYears(-20);
		Resultat = "";
		Message = "";
		JoursAnniversaire = "";
		ResultatVisible = false;
	}

	// Nombre de jours entre aujourd'hui et la prochaine date anniversaire
	// (0 si c'est aujourd'hui). Le 29 février tombe le 28 les années non bissextiles.
	private static int JoursAvantAnniversaire(DateTime naissance, DateTime aujourdhui)
	{
		DateTime Anniversaire(int annee)
		{
			int jour = (naissance.Month == 2 && naissance.Day == 29
						&& !DateTime.IsLeapYear(annee)) ? 28 : naissance.Day;
			return new DateTime(annee, naissance.Month, jour);
		}

		DateTime prochain = Anniversaire(aujourdhui.Year);
		if (prochain < aujourdhui.Date)
			prochain = Anniversaire(aujourdhui.Year + 1);
		return (prochain - aujourdhui.Date).Days;
	}
}
