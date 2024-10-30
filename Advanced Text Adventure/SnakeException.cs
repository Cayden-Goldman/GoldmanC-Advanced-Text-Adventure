using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Text_Adventure
{
    class SnakeException : ApplicationException
    {

        public SnakeException(string message) : base(message)
        {

        }
    }
}
