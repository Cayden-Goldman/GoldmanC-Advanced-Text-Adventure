﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Text_Adventure
{
    internal class Position
    {
        public int x { get; set; }
        public int y { get; set; }
        public Position()
        {

        }
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
