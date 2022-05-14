using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan_Game.BL;
using System.Threading;

namespace PacMan_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathMaze = "maze.txt";
            Grid mazeGrid = new Grid(24, 71, pathMaze);
            PacMan player = new PacMan(9, 32, mazeGrid);
            Ghost g1 = new Ghost(16, 39, 'G', "Left", 0.1F, ' ', mazeGrid);
            Ghost g2 = new Ghost(21, 57, 'O', "Up", 0.2F, ' ', mazeGrid);
            Ghost g3 = new Ghost(19, 7, 'S', "Up", 1F, ' ', mazeGrid);
            Ghost g4 = new Ghost(2, 66, 'T', "Up", 0.5F, ' ', mazeGrid);
            List<Ghost> enemies = new List<Ghost>();
            enemies.Add(g1);
            enemies.Add(g2);
            enemies.Add(g3);
            enemies.Add(g4);

            mazeGrid.draw();
            player.drawPacMan();

            bool gameRunning = true;

            while (gameRunning)
            {
                Thread.Sleep(90);
                player.printScore();
                player.removePacMan();
                player.movePacMan();
                player.drawPacMan();

                foreach (Ghost g in enemies)
                {
                    g.removeGhost();
                    g.moveGhosts();
                    g.drawGhost();
                }

                if (player.isStoppingCondition() == false)
                {
                    gameRunning = false;
                }
            }
           Console.ReadKey();
        }
    }
}
