using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advanced_Text_Adventure
{
    internal class Snake
    {
        ConsoleKeyInfo keyInfo = new();
        char key = 'w';
        char dir = 'u';

        public List<Position> snakeBody { get; set; }

        public int x { get; set; }
        public int y { get; set; }
        public int score { get; set; }

        public Snake()
        {
            x = 20;
            y = 20;
            score = 0;

            snakeBody = new List<Position>();

            snakeBody.Add(new Position(x, y));
        }

        public void DrawSnake()
        {
            foreach (Position pos in snakeBody)
            {
                if (pos.x >= 0 && pos.x < Console.WindowWidth && pos.y >= 0 && pos.y < Console.WindowHeight)
                {
                    Console.SetCursorPosition(pos.x, pos.y);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("S");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }


        public void Input()
        {
            if(Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }

        private void Direction()
        {
            if(key == 'w' && dir != 'd')
                dir = 'u';
            else if(key == 's' && dir != 'u')
                dir = 'd';
            else if(key == 'd' && dir != 'l')
                dir = 'r';
            else if (key == 'a' && dir != 'r')
                dir = 'l';
        }

        public void MoveSnake()
        {
            Direction();

            Position tail = snakeBody[0];
            Console.SetCursorPosition(tail.x, tail.y);
            Console.Write(" ");

            switch (dir)
            {
                case 'u':
                    y--; break;
                case 'd':
                    y++; break;
                case 'r':
                    x++; break;
                case 'l':
                    x--; break;
            }

            snakeBody.Add(new Position(x, y));
            snakeBody.RemoveAt(0);  

            DrawSnake();  
            Thread.Sleep(100);
        }

        public void SnakeGrow(Position food, Food f)
        {
            Position head = snakeBody[snakeBody.Count - 1];

            if(head.x == food.x && head.y == food.y)
            {
                snakeBody.Add(new Position(x, y));
                f.FoodNewLocation(snakeBody);
                score++;
            }
        }

        public void IsDead()
        {
            Position head = snakeBody[snakeBody.Count - 1];

            for(int i =0; i < snakeBody.Count - 2; i++)
            {
                Position sb = snakeBody[i];

                if(head.x == sb.x && head.y == sb.y)
                {
                    throw new SnakeException($"You died, your score was");
                }
            }
        }

        public void HitWall(Canvas canvas)
        {
            Position head = snakeBody[snakeBody.Count - 1];

            if (head.x < 0 || head.x >= canvas.Width || head.y < 0 || head.y >= canvas.Height)
            {
                throw new SnakeException("You died, your score was");
            }
        }

    }
}
