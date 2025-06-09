# Projet Blazor de Puzzles Logiques

Ce projet est une application Blazor WebAssembly qui permet de jouer à différents puzzles logiques (Sudoku, Star Battle, Binairo) sur une grille de taille variable.

## Prérequis

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Un navigateur web moderne

## Installation

1. Clonez ce dépôt :
   ```bash
   git clone https://github.com/votre-utilisateur/PuzzleLogique.git
   cd PuzzleLogique
   ```

2. Restaurez les dépendances :
   ```bash
   dotnet restore
   ```

3. Compilez le projet :
   ```bash
   dotnet build
   ```

4. Exécutez l'application :
   ```bash
   dotnet run
   ```

5. Ouvrez votre navigateur et accédez à l'URL suivante :
   ```
   http://localhost:5108
   ```

## Déploiement

### Déploiement sur GitHub Pages

1. Publiez l'application :
   ```bash
   dotnet publish -c Release -o publish
   ```

2. Créez un fichier `.nojekyll` dans le dossier `publish/wwwroot` :
   ```bash
   touch publish/wwwroot/.nojekyll
   ```

3. Déployez le contenu du dossier `publish/wwwroot` sur GitHub Pages.

### Déploiement sur Azure Static Web Apps

1. Créez une ressource Azure Static Web App dans le portail Azure.
2. Configurez le déploiement continu à partir de votre dépôt GitHub.
3. Configurez les paramètres de build comme suit :
   - App location: `/`
   - Api location: `api`
   - Output location: `wwwroot`

## Structure du projet

- `Components/` : Composants Blazor réutilisables
  - `Grid/` : Composants liés à la grille de jeu
- `Models/` : Classes de modèles de données
- `Services/` : Services pour la logique métier
- `Pages/` : Pages de l'application
- `wwwroot/` : Ressources statiques

## Fonctionnalités

- Grille de taille variable (de 2×2 à 12×12)
- Trois types de puzzles logiques :
  - Sudoku
  - Star Battle
  - Binairo
- Génération automatique de puzzles
- Validation des puzzles
- Interface utilisateur intuitive

## Captures d'écran

![Capture d'écran du Sudoku](screenshots/sudoku.png)
![Capture d'écran du Star Battle](screenshots/star_battle.png)
![Capture d'écran du Binairo](screenshots/binairo.png)

## Guide d'utilisation

Consultez le [Guide d'utilisation](guide_utilisation.md) pour plus d'informations sur l'utilisation de l'application.

## Licence

Ce projet est sous licence MIT. Voir le fichier [LICENSE](LICENSE) pour plus de détails.

## Auteur

Créé par [Votre Nom]

## Remerciements

- [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) - Framework web pour .NET
- [.NET](https://dotnet.microsoft.com/) - Plateforme de développement

