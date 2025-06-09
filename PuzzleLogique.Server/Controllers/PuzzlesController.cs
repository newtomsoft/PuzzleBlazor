using Microsoft.AspNetCore.Mvc;
using PuzzleLogique.Server.Models; // Models (Grid, Cell, PuzzleType)
using System; // For Random
using System.Linq; // For Linq methods if any are used in generation
using System.Collections.Generic; // For List

namespace PuzzleLogique.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuzzlesController : ControllerBase
    {
        // Generation methods will be placed here
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

        [HttpGet("binairo")]
        public ActionResult<Grid> GetBinairoPuzzle([FromQuery] int size = 6) // Default size 6 for Binairo
        {
            if (size % 2 != 0 || size < 4 || size > 14) // Binairo typically has even sizes, e.g., 4x4 to 14x14
            {
                return BadRequest("Invalid size for Binairo. Size must be an even number between 4 and 14.");
            }
            var grid = new Grid(size, PuzzleType.Binairo); // Uses PuzzleLogique.Server.Models.Grid and PuzzleType
            GenerateBinairo(grid); // Calls the copied private method
            return Ok(grid);
        }

        [HttpGet("starbattle")]
        public ActionResult<Grid> GetStarBattlePuzzle([FromQuery] int size = 6) // Default size for StarBattle
        {
            if (size < 5 || size > 10) // Example size constraints for StarBattle
            {
                return BadRequest("Invalid size for StarBattle. Size must be between 5 and 10.");
            }
            var grid = new Grid(size, PuzzleType.StarBattle);
            GenerateStarBattle(grid);
            return Ok(grid);
        }

        [HttpGet("sudoku")]
        public ActionResult<Grid> GetSudokuPuzzle([FromQuery] int size = 9) // Default size 9 for Sudoku
        {
            if (size != 4 && size != 6 && size != 9 && size != 12) // Common Sudoku sizes (must have integer sqrt)
            {
                return BadRequest("Invalid size for Sudoku. Common sizes are 4, 6, 9, 12.");
            }
            var grid = new Grid(size, PuzzleType.Sudoku);
            GenerateSudoku(grid);
            return Ok(grid);
        }
    }
}
