# Structure du projet PuzzleLogique expliquée

Ce document explique la structure du projet Blazor PuzzleLogique et le rôle de chaque dossier et fichier principal.

## Structure générale

```
PuzzleLogique/
  ├── Components/          # Composants Blazor réutilisables
  │   └── Grid/            # Composants liés à la grille de jeu
  ├── Layout/              # Composants de mise en page
  ├── Models/              # Classes de modèles de données
  ├── Pages/               # Pages de l'application
  ├── Properties/          # Configuration du projet
  ├── Services/            # Services pour la logique métier
  ├── screenshots/         # Captures d'écran de l'application
  └── wwwroot/             # Ressources statiques
```

## Fichiers principaux

### Fichiers racine

- **PuzzleLogique.sln** : Fichier solution Visual Studio qui contient la référence au projet.
- **PuzzleLogique.csproj** : Fichier projet qui définit les dépendances et la configuration du projet.
- **Program.cs** : Point d'entrée de l'application Blazor WebAssembly.
- **App.razor** : Composant racine de l'application Blazor.
- **_Imports.razor** : Fichier qui définit les espaces de noms à importer dans tous les fichiers Razor.
- **README.md** : Documentation principale du projet.
- **guide_utilisation.md** : Guide d'utilisation détaillé de l'application.
- **structure_complete.md** : Structure complète du projet avec tous les fichiers.

### Dossiers et leur contenu

#### Components/Grid/

Contient les composants liés à la grille de jeu :

- **GridCell.razor** : Composant pour une cellule individuelle de la grille.
- **GridComponent.razor** : Composant principal de la grille qui gère l'affichage et les interactions.

#### Layout/

Contient les composants de mise en page :

- **MainLayout.razor** : Mise en page principale de l'application.
- **NavMenu.razor** : Menu de navigation de l'application.

#### Models/

Contient les classes de modèles de données :

- **Cell.cs** : Classe qui représente une cellule dans la grille.
- **Grid.cs** : Classe qui représente la grille de jeu et contient les cellules.

#### Pages/

Contient les pages de l'application :

- **Home.razor** : Page d'accueil de l'application.
- **Sudoku.razor** : Page dédiée au puzzle Sudoku.
- **StarBattle.razor** : Page dédiée au puzzle Star Battle.
- **Binairo.razor** : Page dédiée au puzzle Binairo.
- **Counter.razor** et **Weather.razor** : Pages d'exemple générées par le template Blazor.

#### Services/

Contient les services pour la logique métier :

- **PuzzleService.cs** : Service qui gère la logique des puzzles (génération, validation, etc.).

#### wwwroot/

Contient les ressources statiques de l'application :

- **index.html** : Page HTML principale qui charge l'application Blazor.
- **css/app.css** : Feuille de style principale de l'application.
- **lib/bootstrap/** : Bibliothèque Bootstrap pour le style de l'application.

## Fonctionnement de l'application

L'application est structurée selon le modèle Blazor WebAssembly, qui permet d'exécuter du code .NET directement dans le navigateur. Voici comment les différentes parties interagissent :

1. **Program.cs** initialise l'application et enregistre les services nécessaires.
2. **App.razor** définit le routage de l'application.
3. Les **Pages** définissent les différentes vues de l'application.
4. Les **Components** sont utilisés par les pages pour afficher les éléments d'interface utilisateur.
5. Les **Models** définissent la structure des données.
6. Les **Services** contiennent la logique métier.

## Personnalisation

Pour personnaliser l'application, vous pouvez :

- Modifier les composants dans le dossier **Components/Grid/** pour changer l'apparence et le comportement de la grille.
- Ajouter de nouveaux types de puzzles en étendant le service **PuzzleService.cs**.
- Modifier les pages existantes ou en ajouter de nouvelles dans le dossier **Pages/**.
- Personnaliser le style de l'application en modifiant les fichiers CSS dans le dossier **wwwroot/css/**.

## Compilation et exécution

Pour compiler et exécuter l'application :

```bash
dotnet build
dotnet run
```

L'application sera accessible à l'adresse http://localhost:5108 par défaut.

