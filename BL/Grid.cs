using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PacMan_Game.BL
{
    internal class Grid
    {
        public Cell[,] maze;
        private int rowSize;
        private int colSize;

        public Grid(int rowSize, int colSize, string path)
        {
            this.rowSize = rowSize;
            this.colSize = colSize;
            maze =Read(rowSize,colSize,path);
          
        }
        public  Cell[,] Read(int rowSize, int colSize, string path)
        {
            Cell[,] maze = new Cell[rowSize, colSize];
            if (File.Exists(path))
            {
                StreamReader fp = new StreamReader(path);
                string record;
                int row = 0;
                while ((record = fp.ReadLine()) != null)
                {
                    if (row < rowSize)
                    {
                        for (int col = 0; col < colSize; col++)
                        {
                            maze[row, col] = new Cell(record[col], row, col);
                        }
                        row++;
                    }
                }
                fp.Close();
            }
            return maze;
        }
        public void draw()
        {
            for (int x = 0; x < rowSize; x++)
            {
                for (int y = 0; y < colSize; y++)
                {
                    Console.Write(maze[x, y].getValue());
                }
                Console.WriteLine();
            }
        }
        public Cell getLeftCell(Cell c)
        {
            return maze[c.getX(), c.getY() - 1];
        }
        public Cell getRightCell(Cell c)
        {
            return maze[c.getX(), c.getY() + 1];
        }
        public Cell getUpCell(Cell c)
        {
            return maze[c.getX() - 1, c.getY()];
        }
        public Cell getDownCell(Cell c)
        {
            return maze[c.getX() + 1, c.getY()];
        }
        public Cell findPacman()
        {
            for (int x = 0; x < rowSize; x++)
            {
                for (int y = 0; y < colSize; y++)
                {
                    if (maze[x, y].getValue() == 'P')
                    {
                        return maze[x, y];
                    }
                }
            }
            return null;
        }
        public Cell findGost(char ghostCharacter)
        {
            for (int x = 0; x < rowSize; x++)
            {
                for (int y = 0; y < colSize; y++)
                {
                    if (maze[x, y].getValue() == ghostCharacter)
                    {
                        return maze[x, y];
                    }
                }
            }
            return null;
        }
      

    }
}
