using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yathzee
{
    internal class Die
    {
        private int sides;
        public Die()
        {
            this.sides= 6;
        }
        public Die(int sides)
        {
        this.sides = sides;
        }
        internal int Roll()
        {
            int output = 0;

            Random num = new Random();
            output = num.Next(1, sides+1);

            return output;
        }
        internal string DisplayDie(int input)
        {
            string output = string.Empty;
            
                switch (input)
                {
                    case 5:
                        output = " -------\n| *   * |\n|   *   |\n| *   * |\n -------";
                        break;
                   
                        
                }
            
            return output;
            

           
        }
    }
}
