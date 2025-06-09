# Guide d'utilisation - Projet Blazor de Puzzles Logiques

## Introduction

Ce projet est une application Blazor WebAssembly qui permet de jouer à différents puzzles logiques sur une grille de taille variable. L'application prend en charge trois types de puzzles :

1. **Sudoku** : Remplir une grille avec des chiffres de 1 à 9 (ou de 1 à n pour une grille de taille n×n) de sorte que chaque ligne, chaque colonne et chaque région contienne tous les chiffres sans répétition.
2. **Star Battle** : Placer des étoiles dans une grille de sorte que chaque ligne et chaque colonne contienne exactement une étoile, et qu'aucune étoile ne soit adjacente à une autre (même en diagonale).
3. **Binairo** : Remplir une grille avec des 0 et des 1, de sorte que chaque ligne et chaque colonne contienne un nombre égal de 0 et de 1, et qu'il n'y ait pas plus de deux 0 ou 1 consécutifs.

## Fonctionnalités

- Grille de taille variable (de 2×2 à 12×12)
- Trois types de puzzles logiques
- Génération automatique de puzzles
- Validation des puzzles
- Interface utilisateur intuitive

## Comment jouer

1. **Choisir un type de puzzle** : Utilisez le menu déroulant "Type de puzzle" pour sélectionner le type de puzzle que vous souhaitez jouer (Sudoku, Star Battle ou Binairo), puis cliquez sur "Changer".
2. **Ajuster la taille de la grille** : Entrez la taille souhaitée dans le champ "Taille de la grille" (entre 2 et 12), puis cliquez sur "Redimensionner".
3. **Générer un nouveau puzzle** : Cliquez sur "Nouveau Puzzle" pour générer un nouveau puzzle du type sélectionné.
4. **Jouer** :
   - Cliquez sur une cellule vide pour la sélectionner.
   - Utilisez les boutons numériques (pour Sudoku), le bouton "Étoile" (pour Star Battle) ou les boutons "0" et "1" (pour Binairo) pour entrer une valeur.
   - Utilisez le bouton "Effacer" pour vider une cellule.
5. **Vérifier votre solution** : Cliquez sur "Vérifier" pour valider votre grille. Les cellules en conflit seront marquées en rouge.
6. **Terminer le puzzle** : Lorsque vous avez complété correctement le puzzle, un message de félicitations s'affiche.

## Navigation

- **Accueil** : Page d'accueil avec une présentation générale des puzzles.
- **Sudoku** : Page dédiée au puzzle Sudoku.
- **Star Battle** : Page dédiée au puzzle Star Battle.
- **Binairo** : Page dédiée au puzzle Binairo.

## Règles des puzzles

### Sudoku
- Remplir une grille n×n avec des chiffres de 1 à n.
- Chaque ligne, chaque colonne et chaque région doit contenir tous les chiffres de 1 à n sans répétition.
- Pour une grille 9×9, les régions sont des carrés 3×3.

### Star Battle
- Placer des étoiles (*) dans la grille.
- Chaque ligne et chaque colonne doit contenir exactement une étoile.
- Aucune étoile ne doit être adjacente à une autre, même en diagonale.

### Binairo
- Remplir la grille avec des 0 et des 1.
- Chaque ligne et chaque colonne doit contenir un nombre égal de 0 et de 1.
- Il ne peut pas y avoir plus de deux 0 ou 1 consécutifs.

## Détails techniques

- L'application est développée avec Blazor WebAssembly et .NET 9.
- L'interface utilisateur est responsive et fonctionne sur les appareils mobiles et de bureau.
- Les puzzles sont générés aléatoirement à chaque fois que vous cliquez sur "Nouveau Puzzle".

## Personnalisation

Vous pouvez personnaliser l'application en modifiant les fichiers suivants :

- `Components/Grid/GridComponent.razor` : Composant principal de la grille.
- `Components/Grid/GridCell.razor` : Composant pour les cellules individuelles.
- `Models/Grid.cs` : Modèle de données pour la grille.
- `Models/Cell.cs` : Modèle de données pour les cellules.
- `Services/PuzzleService.cs` : Service pour la logique des puzzles.
- `Pages/*.razor` : Pages de l'application.

## Conclusion

Cette application de puzzles logiques est un excellent moyen de tester vos compétences en résolution de problèmes et de passer du temps de manière ludique et éducative. Amusez-vous bien !

