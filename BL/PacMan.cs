using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using System.Threading;
namespace PacMan_Game.BL
{
    internal class PacMan
    {
        private int x;
        private int y;
        private int score;
        private Grid mazeGrid;
        private int life=3;
        public PacMan(int x, int y, Grid mazeGrid)
        {
            this.x = x;
            this.y = y;
            this.mazeGrid = mazeGrid;
        }
        public void drawPacMan()
        {
           Console.SetCursorPosition(y, x);
           Console.Write("P");
           mazeGrid.maze[x, y].setValue('P');
        }

        public void removePacMan()
        {
            Console.SetCursorPosition(y, x);
            Console.Write(" ");
            mazeGrid.maze[x, y].setValue(' ');
        }
        public void Leftside()
        {
            removePacMan();
            y -= 1;
        }

        public void rightSide()
        {
            removePacMan();
            y += 1;
        }

        public void upSide()
        {
            removePacMan();
            x -=1;
        }

        public void downSide()
        {
            removePacMan();
             x += 1;
        }

        public void moveLeftDirection(Ghost g)
        {
            if (mazeGrid.maze[x, y - 1].getValue() == ' '|| mazeGrid.maze[x, y - 1].getValue()=='.')
            {
                Leftside();
                if (mazeGrid.maze[x, y].getValue() == g.getCharacter())
                {
                    life -= 1;
                }
                else if (mazeGrid.maze[x, y].getValue() == '.')
                {
                    score+=1;
                }
            }
        }

        public void moveRightDirection(Ghost g)
        {
            if (mazeGrid.maze[x, y + 1].getValue() == ' '|| mazeGrid.maze[x, y + 1].getValue() == '.')
            {
                rightSide();
                if (mazeGrid.maze[x, y].getValue() == g.getCharacter())
                {
                    life -= 1;
                }
                if (mazeGrid.maze[x, y].getValue() == '.')
                {
                    score+=1;
                }
            }
        }

        public void moveUpDirection(Ghost g)
        {
            if (mazeGrid.maze[x - 1, y].getValue() == ' '|| mazeGrid.maze[x - 1, y].getValue() == '.')
            {
                upSide();
                if (mazeGrid.maze[x, y].getValue() == g.getCharacter())
                {
                    life -= 1;
                }
                else if (mazeGrid.maze[x, y].getValue() == '.')
                {
                    score+=1;
                }
            }
        }
        public void moveDownDirection(Ghost g)
        {
            if (mazeGrid.maze[x + 1, y].getValue() == ' '|| mazeGrid.maze[x + 1, y].getValue() == '.')
            {
                downSide();
                if (mazeGrid.maze[x, y].getValue() == g.getCharacter())
                {
                    life -= 1;
                }
                else if (mazeGrid.maze[x, y].getValue() == '.')
                {
                    score+=1;
                }
            }
        }
        public bool isStoppingCondition()
        {
            if (life == 0)
            {
                return false;
            }
            return true;
        }
        public void printScore()
        {
            Console.SetCursorPosition(80, 5);
            Console.WriteLine("Score = {0}",score);
        }
        public void movePacMan()
        {
            Ghost g = new Ghost();
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                moveUpDirection(g);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                moveDownDirection(g);
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                moveLeftDirection(g);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                moveRightDirection(g);
            }
            if (Keyboard.IsKeyPressed(Key.Escape))
            {
                Thread.ResetAbort();
            }
        }
    }
}
