namespace CalculateurAge.ViewModels;

// Abstraction de la navigation : le ViewModel demande d'aller
// quelque part sans connaître Shell ni aucun contrôle.
public interface INavigationService
{
	Task AllerAResultatAsync(string nom, int age, string message, string jours);
	Task RetourAsync();
}
