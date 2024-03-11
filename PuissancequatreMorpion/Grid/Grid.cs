using System;
using System.Threading.Tasks;

namespace MorpionApp
{    public class Grid
    {
        private char[,] grid;
        public Grid(int lines, int columns) {
            this.grid = new char[lines, columns];
        }

        public void PlaceElement(Position position, char element) {
            this.grid[position.Line, position.Column] = element;
        }

        public void DisplayGrid() {
            Console.Write("  |");
            for (int i = 0; i < this.grid.GetLength(0); i++)
            {
                Console.Write($" {i + 1} |");
            }
            Console.WriteLine();
            Console.Write("  |");
            for (int i = 0; i < this.grid.GetLength(0); i++)
            {
                Console.Write("___|");
            }
            Console.WriteLine();
            for (int i = 0; i < this.grid.Length; i++)
            {
                Console.Write($"{i + 1} |");
                for (int j = 0; j < this.grid.GetLength(i); j++)
                {
                    Console.Write($" {this.grid[i,j]} |");
                }
                Console.WriteLine();
            }
        }

        public int GetLineNbr() {
            return this.grid.Length;
        }

        public int GetColNbr() {
            return this.grid.GetLength(1);
        }

        public int TopLeftToBottomRightDiagonalContiguousCount(Position pos)
        {
            int line = pos.Line - 1;
            int column = pos.Column - 1;

            int count = 1;
            char elementToCheck = this.grid[line,column];

            int checkedLine = line - 1;
            int checkedColumn = column - 1;
            // Ascending
            while (checkedLine >= 0 && checkedColumn >= 0)
            {
                if (this.grid[checkedLine,checkedColumn] == elementToCheck)
                {
                    count++;
                }
                else
                {
                    break;
                }
                checkedLine--;
                checkedColumn--;
            }

            checkedLine = line + 1;
            checkedColumn = column + 1;
            // Descending
            while (checkedLine <= this.grid.Length - 1 && checkedColumn <= this.grid.GetLength(0) - 1)
            {
                if (this.grid[checkedLine,checkedColumn] == elementToCheck)
                {
                    count++;
                }
                else
                {
                    break;
                }
                checkedLine++;
                checkedColumn++;
            }

            return count;
        }

        public int BottomLeftToTopRightDiagonalContiguousCount(Position pos)
        {
            int line = pos.Line - 1;
            int column = pos.Column - 1;

            int count = 1;
            char elementToCheck = this.grid[line, column];

            int checkedLine = line - 1;
            int checkedColumn = column + 1;
            // Ascending
            while (checkedLine >= 0 && checkedColumn <= this.grid.GetLength(0) - 1)
            {
                if (this.grid[checkedLine, checkedColumn] == elementToCheck)
                {
                    count++;
                }
                else
                {
                    break;
                }
                checkedLine--;
                checkedColumn++;
            }

            checkedLine = line + 1;
            checkedColumn = column - 1;
            // Descending
            while (checkedLine <= this.grid.Length - 1 && checkedColumn >= 0)
            {
                if (this.grid[checkedLine, checkedColumn] == elementToCheck)
                {
                    count++;
                }
                else
                {
                    break;
                }
                checkedLine++;
                checkedColumn--;
            }

            return count;
        }

        public int VerticalContiguousCount(Position pos) {
            int line = pos.Line - 1;
            int column = pos.Column - 1;

            int count = 1;
            char elementToCheck = this.grid[line, column];

            // From element to bottom
            for(int i = line + 1; i < this.grid.GetLength(0); i++) {
                if(this.grid[i, column] == elementToCheck) {
                    count++;
                } else {
                    break;
                }
            }

            // From element to top
            for(int i = line - 1; i >= 0; i--) {
                if(this.grid[i, column] == elementToCheck) {
                    count++;
                } else {
                    break;
                }
            }

            return count;
        }

        public int HorizontalContiguousCount(Position pos)
        {
            int line = pos.Line - 1;
            int column = pos.Column - 1;

            int count = 1;

            char elementToCheck = this.grid[line, column];
            // From element to right
            for (int i = column + 1; i < this.grid.GetLength(line); i++)
            {
                if (this.grid[line, i] == elementToCheck)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            // From element to left
            for (int i = column - 1; i >= 0; i--)
            {
                if (this.grid[line, i] == elementToCheck)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }
    }


}