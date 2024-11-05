using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Text_Adventure
{
    class Upgrade
    {
        public string name;
        public float modifier;
        public float price;
        public float priceScalar;

        public Upgrade(string name, float modifier, float price, float priceScalar)
        {
            this.name = name;
            this.modifier = modifier;
            this.price = price;
            this.priceScalar = priceScalar;
        }

    }
}
