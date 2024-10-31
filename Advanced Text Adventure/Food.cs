using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Text_Adventure
{
    internal class Food
    {
        public Position foodPos = new Position();
        Canvas canvas = new();
        Random rnd = new();

        public Food()
        {
            foodPos.x = rnd.Next(5, canvas.Width);
            foodPos.y = rnd.Next(5, canvas.Height);
        }

        public void DrawFood()
        {
            if (foodPos.x >= 0 && foodPos.x < Console.WindowWidth && foodPos.y >= 0 && foodPos.y < Console.WindowHeight)
            {
                Console.SetCursorPosition(foodPos.x, foodPos.y);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("F");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        public Position FoodLocation()
        {
            return foodPos;
        }

        public void FoodNewLocation(List<Position> snakeBody)
        {
            bool isOnSnake;

            do
            {
                isOnSnake = false;
                foodPos.x = rnd.Next(5, canvas.Width);
                foodPos.y = rnd.Next(5, canvas.Height);

                foreach (Position pos in snakeBody)
                {
                    if (foodPos.x == pos.x && foodPos.y == pos.y)
                    {
                        isOnSnake = true;
                        break;
                    }
                }
            } while (isOnSnake);
        }
    }

}
