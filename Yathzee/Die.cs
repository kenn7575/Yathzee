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
        internal int ActiveNumber { get; set; }
        internal bool IsSelected { get; set; }


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
                case 1:
                    output = " -------\n|       |\n|   *   |\n|       |\n -------";
                    break;
                case 2:
                    output = " -------\n| *     |\n|       |\n|     * |\n -------";
                    break;
                case 3:
                    output = " -------\n| *     |\n|   *   |\n|     * |\n -------";
                    break;
                case 4:
                        output = " -------\n| *   * |\n|       |\n| *   * |\n -------";
                        break;
                case 5:
                        output = " -------\n| *   * |\n|   *   |\n| *   * |\n -------";
                        break;
                    case 6:
                        output = " -------"+ Environment.NewLine + "| *   * |"+ Environment.NewLine + "| *   * |"+ Environment.NewLine + "| *   * |"+ Environment.NewLine + " -------";
                        break;

            }
            
            return output;
            

           
        }

        public static implicit operator Die(List<Die> v)
        {
            throw new NotImplementedException();
        }
    }
}
