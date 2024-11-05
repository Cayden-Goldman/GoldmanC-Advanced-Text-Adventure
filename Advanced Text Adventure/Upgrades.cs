using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Text_Adventure
{
    internal class Upgrades
    {
        public Canvas canvas = new();
        public List<Upgrade> upgradeList = new();

        //Upgrades
        public static Upgrade food = new Upgrade("Food", 1, 10, 1.76f);
        public static Upgrade canvasSize = new Upgrade("Canvas Size", 2, 200, 1.21f);
        public static Upgrade color = new Upgrade("Color", 1, 100, 10);

        public Upgrades()
        {
            upgradeList.Add(food);
            upgradeList.Add(canvasSize);
            upgradeList.Add(color);
        }

        public void DrawUpgrades()
        {
            List<string> outputList = new();
            Console.SetCursorPosition(canvas.Width + 2, 3);
            Console.WriteLine("Upgrades:");
            Console.SetCursorPosition(canvas.Width + 2, 4);
            Console.WriteLine("NAME | MODIFIER | PRICE");
            int i = 0;
            foreach (var upgrade in upgradeList)
            {
                i++;
                Console.SetCursorPosition(canvas.Width + 2, 4 + i);
                Console.Write($"{upgrade.name} | {upgrade.modifier} | {upgrade.price}");
                Console.WriteLine();
                Console.SetCursorPosition(canvas.Width + 2, 4 + i);
            }
        }
    }
}
