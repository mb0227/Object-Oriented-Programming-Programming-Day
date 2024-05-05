using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;
using GameConversion.BL;

namespace GameConversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            char playerSymbol = 'P';
            Player player = new Player(playerSymbol, 15, 15);
            char enemySymbol = 'E';
            Enemy[] enemies = {
                new Enemy(enemySymbol, 9, 10),
                new Enemy(enemySymbol, 11, 15),
                new Enemy(enemySymbol, 12, 6)
            };
            char[,] maze = new char[20, 22]{
               {'$','$','$','$','$','$','$','$','$','$','$','$','$','$','$','$','$','$','$','$','$','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ','E',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','E',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ','E',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$'},
               {'$','$','$','$','$','$','$','$','$','$','$','$','$','$','$','$','$','$','$','$','$','$'} };
            printMaze(maze);
            Console.SetCursorPosition(player.Y, player.X);

            while (true)
            {
                Thread.Sleep(200);

                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    movePlayerUp(maze, player);
                    CheckCollisions(enemies, player, ref score);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    movePlayerDown(maze, player);
                    CheckCollisions(enemies, player, ref score);

                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    movePlayerRight(maze, player);
                    CheckCollisions(enemies, player, ref score);

                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    movePlayerLeft(maze, player);
                    CheckCollisions(enemies, player, ref score);

                }
            }
        }

        static void printMaze(char[,] maze)
        {
            int height = maze.GetLength(0);
            int width = maze.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void movePlayerUp(char[,] maze, Player player)
        {
            if (maze[player.X - 1, player.Y] == ' ' || maze[player.X - 1, player.Y] == 'E')
            {
                maze[player.X, player.Y] = ' ';
                Console.SetCursorPosition(player.Y, player.X);
                Console.Write(" ");
                player.X = player.X - 1;
                Console.SetCursorPosition(player.Y, player.X);
                Console.Write(player.DisplayCharacter);
            }
        }

        static void movePlayerDown(char[,] maze, Player player)
        {
            if (maze[player.X + 1, player.Y] == ' ' || maze[player.X + 1, player.Y] == 'E')
            {
                maze[player.X, player.Y] = ' ';
                Console.SetCursorPosition(player.Y, player.X);
                Console.Write(" ");
                player.X = player.X + 1;
                Console.SetCursorPosition(player.Y, player.X);
                Console.Write(player.DisplayCharacter);
            }
        }

        static void movePlayerLeft(char[,] maze, Player player)
        {
            if (maze[player.X, player.Y - 1] == ' ' || maze[player.X, player.Y - 1] == 'E')
            {
                maze[player.X, player.Y] = ' ';
                Console.SetCursorPosition(player.Y, player.X);
                Console.Write(" ");
                player.Y = player.Y - 1;
                Console.SetCursorPosition(player.Y, player.X);
                Console.Write(player.DisplayCharacter);
            }
        }

        static void movePlayerRight(char[,] maze, Player player)
        {
            if (maze[player.X, player.Y + 1] == ' ' || maze[player.X, player.Y + 1] == 'E')
            {
                maze[player.X, player.Y] = ' ';
                Console.SetCursorPosition(player.Y, player.X);
                Console.Write(" ");
                player.Y = player.Y + 1;
                Console.SetCursorPosition(player.Y, player.X);
                Console.Write(player.DisplayCharacter);
            }
        }

        static void CheckCollisions(Enemy[] enemies, Player player, ref int score)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].X == player.X && enemies[i].Y == player.Y)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    score++;
                    Console.SetCursorPosition(25, 5);
                    Console.WriteLine($"Score: {score}");
                    Console.ForegroundColor = ConsoleColor.White;
                    enemies[i].Collided = true;
                }
            }
        }
    }
}
