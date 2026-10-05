using CalculateurAge.ViewModels;
using CalculateurAge.Views;

namespace CalculateurAge.Services;

// Implémentation de la navigation avec Shell.
public class ShellNavigationService : INavigationService
{
	// Les données voyagent sous forme d'objets (pas dans l'URL).
	public Task AllerAResultatAsync(string nom, int age, string message, string jours)
		=> Shell.Current.GoToAsync(nameof(ResultatPage),
			new Dictionary<string, object>
			{
				["nom"] = nom,
				["age"] = age,
				["message"] = message,
				["jours"] = jours
			});

	public Task RetourAsync() => Shell.Current.GoToAsync("..");
}
