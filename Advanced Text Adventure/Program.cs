using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Advanced_Text_Adventure
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool finished = false;
            Canvas canvas = new();
            Snake snake = new();
            Food food = new();
            Upgrades upgrades = new();
            bool stupid = true;
            bool idiot = true;


            Console.WriteLine("           _________ _________ _________              __                    \r\n          /   _____//   _____//   _____/ ____ _____  |  | __ ____           \r\n  ______  \\_____  \\ \\_____  \\ \\_____  \\ /    \\\\__  \\ |  |/ // __ \\   ______ \r\n /_____/  /        \\/        \\/        \\   |  \\/ __ \\|    <\\  ___/  /_____/ \r\n         /_______  /_______  /_______  /___|  (____  /__|_ \\\\___  >         \r\n                 \\/        \\/        \\/     \\/     \\/     \\/    \\/          ");
            Console.WriteLine("\t\t\t      - WASD to move -");
            Console.WriteLine("\t\t       - Pick up food to gain score -");
            Console.WriteLine("\t\t\t  - Press enter to start -");
            Console.ReadLine();
            Console.Clear();
            canvas.DrawBorder();
            while (!finished)
            {
                try
                {
                    Console.SetCursorPosition(canvas.Width + 2, 1);
                    Console.Write($"Score : {snake.GetScore()}");
                    food.DrawFood();
                    snake.DrawSnake();
                    upgrades.DrawUpgrades();
                    while(idiot)
                    {
                        if (Console.ReadKey(true).Key != ConsoleKey.Escape)
                            idiot = false;
                    }
                    snake.Input();
                    snake.MoveSnake();
                    snake.SnakeGrow(food.FoodLocation(), food);
                    snake.IsDead();
                    snake.HitWall(canvas);
                    
                }
                catch (SnakeException e)
                {
                    stupid = true;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(e.Message);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($" {snake.GetScore()}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Restart (y/n)");

                    while (stupid)
                    {
                        try
                        {
                            char c = char.Parse(Console.ReadLine());
                            switch (c)
                            {
                                case 'y':
                                    Console.Clear();         
                                    canvas.DrawBorder();
                                    snake.SnakeReset();
                                    stupid = false;
                                    idiot = true;
                                    break;

                                case 'n':
                                    finished = true;
                                    Environment.Exit(0);
                                    break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a valid response");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }
        }
    }
}
