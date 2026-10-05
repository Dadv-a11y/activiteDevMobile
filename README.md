# CalculateurAge – TP1 Routing et MVVM (.NET MAUI)

Calculateur d'âge réalisé en trois phases, puis enrichi (Activité 6).

| Phase | Contenu |
|-------|---------|
| Étape 0 | Projet .NET MAUI vide (sans sample content) |
| A | Version code-behind |
| B | `ResultatPage`, routing Shell, `QueryProperty` |
| C | Réécriture MVVM : `BaseViewModel`, `RelayCommand`, `CalculateurViewModel` |
| Fonctionnalités | 1. Message Majeur/Mineur + validation de la date · 2. Commande Effacer · 3. Jours avant le prochain anniversaire · 4. Résultat transmis à `ResultatPage` par le ViewModel (`INavigationService`, `IQueryAttributable`) |

## Structure
```
Views/        ResultatPage
ViewModels/   BaseViewModel, RelayCommand, CalculateurViewModel, ResultatViewModel, INavigationService
Services/     ShellNavigationService
MainPage.xaml(.cs)  AppShell.xaml(.cs)  MauiProgram.cs
```
Règle MVVM : aucun `Label`, `Entry`, `Button` ni `DisplayAlert` dans les ViewModels ; aucun code-behind métier.

## Lancer
```
dotnet build -f net10.0-windows10.0.19041.0
dotnet run -f net10.0-windows10.0.19041.0
```
(ou émulateur Android : `net10.0-android`).
