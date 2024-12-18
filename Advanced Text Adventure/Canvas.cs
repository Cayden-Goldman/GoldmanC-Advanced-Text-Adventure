﻿using System;
namespace Advanced_Text_Adventure
{
    public class Canvas
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Canvas()
        {
            Width = 20;
            Height = (int)MathF.Round(Width / 2);
            Console.CursorVisible = false;
            
        }

        public void DrawBorder()
        {
            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("▀");
            }
            for (int i = 0; i <= Width; i++)
            {
                Console.SetCursorPosition(i, Height);
                Console.Write("▀");
            }
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("█");
            }
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(Width, i);
                Console.Write("█");
            }
        }
    }
}

