using PuzzleLogique.Web.Models;

namespace PuzzleLogique.Web.Services;

/// <summary>
/// Interface pour les services de puzzle
/// </summary>
public interface IPuzzleService
{
    /// <summary>
    /// Crée une nouvelle grille avec le type de puzzle spécifié
    /// </summary>
    /// <param name="size">Taille de la grille</param>
    /// <param name="puzzleType">Type de puzzle</param>
    /// <returns>Une nouvelle grille</returns>
    Grid CreateGrid(int size, PuzzleType puzzleType);
    
    /// <summary>
    /// Vérifie si la grille est valide
    /// </summary>
    /// <param name="grid">Grille à vérifier</param>
    /// <returns>True si la grille est valide, sinon False</returns>
    bool ValidateGrid(Grid grid);
    
    /// <summary>
    /// Vérifie si la grille est complète
    /// </summary>
    /// <param name="grid">Grille à vérifier</param>
    /// <returns>True si la grille est complète, sinon False</returns>
    bool IsGridComplete(Grid grid);
    
    /// <summary>
    /// Génère un nouveau puzzle
    /// </summary>
    /// <param name="grid">Grille à remplir</param>
    void GeneratePuzzle(Grid grid);
}

/// <summary>
/// Service pour gérer les puzzles
/// </summary>
public class PuzzleService : IPuzzleService
{
    /// <summary>
    /// Crée une nouvelle grille avec le type de puzzle spécifié
    /// </summary>
    /// <param name="size">Taille de la grille</param>
    /// <param name="puzzleType">Type de puzzle</param>
    /// <returns>Une nouvelle grille</returns>
    public Grid CreateGrid(int size, PuzzleType puzzleType)
    {
        return new Grid(size, puzzleType);
    }
    
    /// <summary>
    /// Vérifie si la grille est valide
    /// </summary>
    /// <param name="grid">Grille à vérifier</param>
    /// <returns>True si la grille est valide, sinon False</returns>
    public bool ValidateGrid(Grid grid)
    {
        // Réinitialiser les conflits
        foreach (var cell in grid.Cells)
        {
            cell.HasConflict = false;
        }
        
        switch (grid.PuzzleType)
        {
            case PuzzleType.Sudoku:
                return ValidateSudoku(grid);
            case PuzzleType.StarBattle:
                return ValidateStarBattle(grid);
            case PuzzleType.Binairo:
                return ValidateBinairo(grid);
            default:
                return false;
        }
    }
    
    /// <summary>
    /// Vérifie si la grille est complète
    /// </summary>
    /// <param name="grid">Grille à vérifier</param>
    /// <returns>True si la grille est complète, sinon False</returns>
    public bool IsGridComplete(Grid grid)
    {
        // Vérifier si toutes les cellules ont une valeur
        bool allCellsHaveValue = grid.Cells.All(c => !string.IsNullOrEmpty(c.Value));
        
        // Vérifier si la grille est valide
        bool isValid = ValidateGrid(grid);
        
        return allCellsHaveValue && isValid;
    }
    
    /// <summary>
    /// Génère un nouveau puzzle
    /// </summary>
    /// <param name="grid">Grille à remplir</param>
    public void GeneratePuzzle(Grid grid)
    {
        switch (grid.PuzzleType)
        {
            case PuzzleType.Sudoku:
                GenerateSudoku(grid);
                break;
            case PuzzleType.StarBattle:
                GenerateStarBattle(grid);
                break;
            case PuzzleType.Binairo:
                GenerateBinairo(grid);
                break;
        }
    }
    
    #region Validation des puzzles
    
    private bool ValidateSudoku(Grid grid)
    {
        bool isValid = true;
        
        // Vérifier les lignes
        for (int row = 0; row < grid.Size; row++)
        {
            var rowCells = grid.Cells.Where(c => c.Row == row && !string.IsNullOrEmpty(c.Value)).ToList();
            var duplicates = rowCells.GroupBy(c => c.Value)
                                    .Where(g => g.Count() > 1)
                                    .SelectMany(g => g)
                                    .ToList();
            
            foreach (var cell in duplicates)
            {
                cell.HasConflict = true;
                isValid = false;
            }
        }
        
        // Vérifier les colonnes
        for (int col = 0; col < grid.Size; col++)
        {
            var colCells = grid.Cells.Where(c => c.Column == col && !string.IsNullOrEmpty(c.Value)).ToList();
            var duplicates = colCells.GroupBy(c => c.Value)
                                    .Where(g => g.Count() > 1)
                                    .SelectMany(g => g)
                                    .ToList();
            
            foreach (var cell in duplicates)
            {
                cell.HasConflict = true;
                isValid = false;
            }
        }
        
        // Vérifier les régions (pour Sudoku)
        int regionSize = (int)Math.Sqrt(grid.Size);
        for (int regionRow = 0; regionRow < regionSize; regionRow++)
        {
            for (int regionCol = 0; regionCol < regionSize; regionCol++)
            {
                int startRow = regionRow * regionSize;
                int startCol = regionCol * regionSize;
                
                var regionCells = grid.Cells.Where(c => 
                    c.Row >= startRow && c.Row < startRow + regionSize &&
                    c.Column >= startCol && c.Column < startCol + regionSize &&
                    !string.IsNullOrEmpty(c.Value)).ToList();
                
                var duplicates = regionCells.GroupBy(c => c.Value)
                                          .Where(g => g.Count() > 1)
                                          .SelectMany(g => g)
                                          .ToList();
                
                foreach (var cell in duplicates)
                {
                    cell.HasConflict = true;
                    isValid = false;
                }
            }
        }
        
        return isValid;
    }
    
    private bool ValidateStarBattle(Grid grid)
    {
        bool isValid = true;
        
        // Dans Star Battle, chaque ligne et colonne doit avoir exactement une étoile
        // Pour simplifier, nous considérons que les étoiles sont représentées par "*"
        
        // Vérifier les lignes
        for (int row = 0; row < grid.Size; row++)
        {
            var starCount = grid.Cells.Count(c => c.Row == row && c.Value == "*");
            if (starCount > 1)
            {
                var starCells = grid.Cells.Where(c => c.Row == row && c.Value == "*").ToList();
                foreach (var cell in starCells)
                {
                    cell.HasConflict = true;
                    isValid = false;
                }
            }
        }
        
        // Vérifier les colonnes
        for (int col = 0; col < grid.Size; col++)
        {
            var starCount = grid.Cells.Count(c => c.Column == col && c.Value == "*");
            if (starCount > 1)
            {
                var starCells = grid.Cells.Where(c => c.Column == col && c.Value == "*").ToList();
                foreach (var cell in starCells)
                {
                    cell.HasConflict = true;
                    isValid = false;
                }
            }
        }
        
        // Vérifier que les étoiles ne sont pas adjacentes (y compris en diagonale)
        foreach (var cell in grid.Cells.Where(c => c.Value == "*"))
        {
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0) continue; // Ignorer la cellule elle-même
                    
                    var neighbor = grid.GetCell(cell.Row + dr, cell.Column + dc);
                    if (neighbor != null && neighbor.Value == "*")
                    {
                        cell.HasConflict = true;
                        neighbor.HasConflict = true;
                        isValid = false;
                    }
                }
            }
        }
        
        return isValid;
    }
    
    private bool ValidateBinairo(Grid grid)
    {
        bool isValid = true;
        
        // Dans Binairo, chaque ligne et colonne doit avoir un nombre égal de 0 et 1
        // et il ne peut pas y avoir plus de deux 0 ou 1 consécutifs
        
        // Vérifier les lignes
        for (int row = 0; row < grid.Size; row++)
        {
            var rowCells = grid.Cells.Where(c => c.Row == row && !string.IsNullOrEmpty(c.Value)).ToList();
            
            // Vérifier les séquences consécutives
            for (int col = 0; col < grid.Size - 2; col++)
            {
                var cell1 = grid.GetCell(row, col);
                var cell2 = grid.GetCell(row, col + 1);
                var cell3 = grid.GetCell(row, col + 2);
                
                if (cell1?.Value != null && cell2?.Value != null && cell3?.Value != null &&
                    cell1.Value == cell2.Value && cell2.Value == cell3.Value)
                {
                    cell1.HasConflict = true;
                    cell2.HasConflict = true;
                    cell3.HasConflict = true;
                    isValid = false;
                }
            }
            
            // Vérifier l'équilibre des 0 et 1
            if (rowCells.Count == grid.Size) // Ligne complète
            {
                int zeroCount = rowCells.Count(c => c.Value == "0");
                int oneCount = rowCells.Count(c => c.Value == "1");
                
                if (zeroCount != oneCount)
                {
                    foreach (var cell in rowCells)
                    {
                        cell.HasConflict = true;
                    }
                    isValid = false;
                }
            }
        }
        
        // Vérifier les colonnes
        for (int col = 0; col < grid.Size; col++)
        {
            var colCells = grid.Cells.Where(c => c.Column == col && !string.IsNullOrEmpty(c.Value)).ToList();
            
            // Vérifier les séquences consécutives
            for (int row = 0; row < grid.Size - 2; row++)
            {
                var cell1 = grid.GetCell(row, col);
                var cell2 = grid.GetCell(row + 1, col);
                var cell3 = grid.GetCell(row + 2, col);
                
                if (cell1?.Value != null && cell2?.Value != null && cell3?.Value != null &&
                    cell1.Value == cell2.Value && cell2.Value == cell3.Value)
                {
                    cell1.HasConflict = true;
                    cell2.HasConflict = true;
                    cell3.HasConflict = true;
                    isValid = false;
                }
            }
            
            // Vérifier l'équilibre des 0 et 1
            if (colCells.Count == grid.Size) // Colonne complète
            {
                int zeroCount = colCells.Count(c => c.Value == "0");
                int oneCount = colCells.Count(c => c.Value == "1");
                
                if (zeroCount != oneCount)
                {
                    foreach (var cell in colCells)
                    {
                        cell.HasConflict = true;
                    }
                    isValid = false;
                }
            }
        }
        
        return isValid;
    }
    
    #endregion
    
    #region Génération des puzzles
    
    private void GenerateSudoku(Grid grid)
    {
        // Pour simplifier, nous allons juste créer un puzzle Sudoku basique
        // Dans une application réelle, vous voudriez utiliser un algorithme plus sophistiqué
        
        // Réinitialiser la grille
        grid.InitializeGrid();
        
        // Remplir quelques cellules pour créer un puzzle
        Random random = new Random();
        int cellsToFill = grid.Size * grid.Size / 4; // Remplir environ 25% des cellules
        
        for (int i = 0; i < cellsToFill; i++)
        {
            int row = random.Next(grid.Size);
            int col = random.Next(grid.Size);
            int value = random.Next(1, grid.Size + 1);
            
            var cell = grid.GetCell(row, col);
            if (cell != null && string.IsNullOrEmpty(cell.Value))
            {
                cell.Value = value.ToString();
                cell.IsLocked = true;
            }
        }
    }
    
    private void GenerateStarBattle(Grid grid)
    {
        // Réinitialiser la grille
        grid.InitializeGrid();
        
        // Pour Star Battle, nous allons simplement placer quelques étoiles
        // Dans une application réelle, vous voudriez générer un puzzle complet et solvable
        
        Random random = new Random();
        int starsToPlace = grid.Size / 2; // Placer quelques étoiles
        
        for (int i = 0; i < starsToPlace; i++)
        {
            int row = random.Next(grid.Size);
            int col = random.Next(grid.Size);
            
            var cell = grid.GetCell(row, col);
            if (cell != null && string.IsNullOrEmpty(cell.Value))
            {
                cell.Value = "*";
                cell.IsLocked = true;
            }
        }
    }
    
    private void GenerateBinairo(Grid grid)
    {
        // Réinitialiser la grille
        grid.InitializeGrid();
        
        // Pour Binairo, nous allons placer quelques 0 et 1
        // Dans une application réelle, vous voudriez générer un puzzle complet et solvable
        
        Random random = new Random();
        int cellsToFill = grid.Size * grid.Size / 3; // Remplir environ 33% des cellules
        
        for (int i = 0; i < cellsToFill; i++)
        {
            int row = random.Next(grid.Size);
            int col = random.Next(grid.Size);
            string value = random.Next(2).ToString(); // 0 ou 1
            
            var cell = grid.GetCell(row, col);
            if (cell != null && string.IsNullOrEmpty(cell.Value))
            {
                cell.Value = value;
                cell.IsLocked = true;
            }
        }
    }
    
    #endregion
}

