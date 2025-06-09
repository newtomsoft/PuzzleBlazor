namespace PuzzleLogique.Server.Models;

/// <summary>
/// Représente une cellule dans la grille de puzzle
/// </summary>
public class Cell
{
    /// <summary>
    /// Obtient ou définit la ligne de la cellule
    /// </summary>
    public int Row { get; set; }

    /// <summary>
    /// Obtient ou définit la colonne de la cellule
    /// </summary>
    public int Column { get; set; }

    /// <summary>
    /// Obtient ou définit la valeur de la cellule
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// Indique si la cellule est verrouillée (valeur initiale du puzzle)
    /// </summary>
    public bool IsLocked { get; set; }

    /// <summary>
    /// Indique si la cellule est sélectionnée
    /// </summary>
    public bool IsSelected { get; set; }

    /// <summary>
    /// Indique si la valeur de la cellule est en conflit avec une autre cellule
    /// </summary>
    public bool HasConflict { get; set; }
}
