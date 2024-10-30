using System;
using System.Security.Cryptography.X509Certificates;

namespace Advanced_Text_Adventure
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool finished = false;
            Canvas canvas = new Canvas();
            Snake snake = new();
            Food food = new();
            bool stupid = true;


            Console.WriteLine("           _________ _________ _________              __                    \r\n          /   _____//   _____//   _____/ ____ _____  |  | __ ____           \r\n  ______  \\_____  \\ \\_____  \\ \\_____  \\ /    \\\\__  \\ |  |/ // __ \\   ______ \r\n /_____/  /        \\/        \\/        \\   |  \\/ __ \\|    <\\  ___/  /_____/ \r\n         /_______  /_______  /_______  /___|  (____  /__|_ \\\\___  >         \r\n                 \\/        \\/        \\/     \\/     \\/     \\/    \\/          ");
            Console.WriteLine("\t\t\t  - Press enter to start -");
            Console.WriteLine("\t\t\t      - WASD to move -");
            Console.WriteLine("\t\t       - Pick up food to gain score -");
            Console.ReadLine();
            while(!finished)
            {
                try
                {
                    canvas.drawCanvas();
                    Console.SetCursorPosition(40, 1);
                    Console.Write($"Score : {snake.score}");
                    food.DrawFood();
                    snake.Input();
                    snake.DrawSnake();
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
                    Console.Write($" {snake.score}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Restart (y/n)");
                    while(stupid)
                    {
                        try
                        {
                            char c = char.Parse(Console.ReadLine());
                            switch (c)
                            {
                                case 'y':

                                    snake.x = 20;
                                    snake.y = 20;
                                    snake.score = 0;
                                    snake.snakeBody.RemoveRange(0, snake.snakeBody.Count - 1);
                                    stupid = false;
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
