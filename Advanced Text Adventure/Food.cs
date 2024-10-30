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
            Console.SetCursorPosition(foodPos.x, foodPos.y);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("F");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public Position FoodLocation()
        {
            return foodPos;
        }

        public void FoodNewLocation()
        {
            foodPos.x = rnd.Next(5, canvas.Width);
            foodPos.y = rnd.Next(5, canvas.Height);
        }
    }
}
