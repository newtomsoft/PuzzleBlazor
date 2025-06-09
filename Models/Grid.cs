namespace PuzzleLogique.Models;

/// <summary>
/// Types de puzzles disponibles
/// </summary>
public enum PuzzleType
{
    Sudoku,
    StarBattle,
    Binairo
}

/// <summary>
/// Représente une grille de puzzle
/// </summary>
public class Grid
{
    /// <summary>
    /// Obtient ou définit la taille de la grille (n x n)
    /// </summary>
    public int Size { get; set; }
    
    /// <summary>
    /// Obtient ou définit le type de puzzle
    /// </summary>
    public PuzzleType PuzzleType { get; set; }
    
    /// <summary>
    /// Obtient ou définit les cellules de la grille
    /// </summary>
    public List<Cell> Cells { get; set; } = new List<Cell>();
    
    /// <summary>
    /// Initialise une nouvelle instance de la classe Grid
    /// </summary>
    public Grid()
    {
    }
    
    /// <summary>
    /// Initialise une nouvelle instance de la classe Grid avec une taille spécifiée
    /// </summary>
    /// <param name="size">Taille de la grille</param>
    /// <param name="puzzleType">Type de puzzle</param>
    public Grid(int size, PuzzleType puzzleType)
    {
        Size = size;
        PuzzleType = puzzleType;
        InitializeGrid();
    }
    
    /// <summary>
    /// Initialise la grille avec des cellules vides
    /// </summary>
    public void InitializeGrid()
    {
        Cells.Clear();
        
        for (int row = 0; row < Size; row++)
        {
            for (int col = 0; col < Size; col++)
            {
                Cells.Add(new Cell
                {
                    Row = row,
                    Column = col,
                    Value = null,
                    IsLocked = false,
                    IsSelected = false,
                    HasConflict = false
                });
            }
        }
    }
    
    /// <summary>
    /// Obtient une cellule à une position spécifique
    /// </summary>
    /// <param name="row">Ligne</param>
    /// <param name="column">Colonne</param>
    /// <returns>La cellule à la position spécifiée</returns>
    public Cell? GetCell(int row, int column)
    {
        return Cells.FirstOrDefault(c => c.Row == row && c.Column == column);
    }
    
    /// <summary>
    /// Définit la valeur d'une cellule
    /// </summary>
    /// <param name="row">Ligne</param>
    /// <param name="column">Colonne</param>
    /// <param name="value">Valeur</param>
    public void SetCellValue(int row, int column, string? value)
    {
        var cell = GetCell(row, column);
        if (cell != null && !cell.IsLocked)
        {
            cell.Value = value;
        }
    }
    
    /// <summary>
    /// Redimensionne la grille
    /// </summary>
    /// <param name="newSize">Nouvelle taille</param>
    public void Resize(int newSize)
    {
        Size = newSize;
        InitializeGrid();
    }
}

