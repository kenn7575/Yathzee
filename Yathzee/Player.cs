using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yathzee
{
    internal class Player
    {


        Dictionary<string, int> Results = new Dictionary<string, int>();
        internal string name { get; set; }
        public Player()
        {

            Results.Add("Ones", 0);
            Results.Add("Twos", 0);
            Results.Add("Threes", 0);
            Results.Add("Fours", 0);
            Results.Add("Fives", 0);
            Results.Add("Sixes", 0);
            Results.Add("TOAK", 0);
            Results.Add("FOAK", 0);
            Results.Add("FullHouse", 0);
            Results.Add("FullStraight", 0);
            Results.Add("SmallStraight", 0);
            Results.Add("Yahtzee", 0);
            Results.Add("Chance", 0);
        }
        internal void PrintScore()
        {
            Console.WriteLine(Environment.NewLine + name + "'s score is");
            foreach (var item in Results)
            {
                if (item.Value == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (item.Value == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                }
                if (item.Value > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                Console.WriteLine(item.Key + " " + item.Value);
            }

        }
        internal void UpdateScore(List<Die> dice)
        {
            bool valid = false;
            while (!valid)
            {
                Console.Clear();
                Program.RenderDice();
                PrintScore();
                Console.WriteLine("Where would you like to store your score?");
                string gameSlot = Console.ReadLine();
                if (new[] { "ones", "twos", "threes", "fours", "fives", "sixes", "toak", "foak", "fullstraight", "smallstraight", "fullhouse", "yahtzee", "chance" }.Contains(gameSlot.ToLower()))
                {
                    List<int> ints = new List<int>();

                    switch (gameSlot.ToLower())
                    {
                        case "ones":
                            if (Results["Ones"] == 0)
                            {
                                valid = true;
                                foreach (Die die in dice)
                                {
                                    if (die.ActiveNumber == 1)
                                    {
                                        ints.Add(die.ActiveNumber);
                                    }
                                }
                                Results["Ones"] = sumOfDice(ints);

                            }
                            break;
                        case "twos":
                            if (Results["Twos"] == 0)
                            {
                                valid = true;

                                foreach (Die die in dice)
                                {
                                    if (die.ActiveNumber == 2)
                                    {
                                        ints.Add(die.ActiveNumber);
                                    }
                                }
                                Results["Twos"] = sumOfDice(ints);

                            }

                            break;
                        case "threes":
                            if (Results["Threes"] == 0)
                            {
                                valid = true;


                                foreach (Die die in dice)
                                {
                                    if (die.ActiveNumber == 3)
                                    {
                                        ints.Add(die.ActiveNumber);
                                    }
                                }
                                Results["Threes"] = sumOfDice(ints);
                            }

                            break;
                        case "fours":
                            if (Results["Fours"] == 0)
                            {
                                valid = true;
                                foreach (Die die in dice)
                                {
                                    if (die.ActiveNumber == 4)
                                    {
                                        ints.Add(die.ActiveNumber);
                                    }
                                }
                                Results["Fours"] = sumOfDice(ints);
                            }
                            break;
                        case "fives":
                            if (Results["Fives"] == 0)
                            {
                                valid = true;
                                foreach (Die die in dice)
                                {
                                    if (die.ActiveNumber == 5)
                                    {
                                        ints.Add(die.ActiveNumber);
                                    }
                                }
                                Results["Fives"] = sumOfDice(ints);
                            }
                            break;
                        case "sixes":
                            if (Results["Sixes"] == 0)
                            {
                                valid = true;
                                foreach (Die die in dice)
                                {
                                    if (die.ActiveNumber == 6)
                                    {
                                        ints.Add(die.ActiveNumber);
                                    }
                                }
                                Results["Sixes"] = sumOfDice(ints);
                            }
                            break;
                        case "toak":
                            if (Results["TFAK"] == 0)
                            {
                                valid = true;
                                Results["TOAK"] = findThreeOfAKind(dice, 3);
                            }
                            break;
                        case "foak":
                            if (Results["FOAK"] == 0)
                            {
                                valid = true;
                                Results["FOAK"] = findThreeOfAKind(dice, 4);
                            }
                            break;
                        case "fullhouse":
                            if (Results["FullHouse"] == 0)
                            {
                                valid = true;
                                Results["FullHouse"] = House(dice);
                            }
                            break;
                        case "fullstraight":
                            if (Results["FullStraight"] == 0)
                            {
                                valid = true;
                                Results["FullStraight"] = findFullStright(dice);
                            }

                            break;
                        case "smallstraight":
                            if (Results["SmallStraight"] == 0)
                            {
                                valid = true;
                                Results["SmallStraight"] = findSmallStright(dice);
                            }
                            break;
                        case "Yahtzee":
                            break;
                        case "chance":
                            if (Results["Chance"] == 0)
                            {
                                valid = true;
                                List<int> ints1 = new List<int>();
                                foreach (Die die in dice)
                                {
                                    ints1.Add(die.ActiveNumber);
                                }
                                Results["Chance"] = sumOfDice(ints1);
                            }
                            break;

                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            PrintScore();
        }
        internal int findThreeOfAKind(List<Die> dice, int number)
        {
            int output = 0;
            int value = 0;


            foreach (Die die in dice)
            {
                value = die.ActiveNumber;
                int count = 0;
                foreach (Die die1 in dice)
                {

                    if (die.ActiveNumber == die1.ActiveNumber)
                    {
                        count++;
                    }
                    if (count > number - 1) { output = value; break; }
                }

            }
            if (output == 0)
            {
                output = -1;
                return output;
            }
            else
            {
                return output * number;
            }


            //return the repeated number
        }
        internal int sumOfDice(List<int> dice)
        {
            int sum = 0;
            foreach (int d in dice)
            {
                sum += d;
            }
            if (sum == 0)
            {
                sum = -1;
            }
            return sum;
        }
        internal int findSmallStright(List<Die> dice)
        {
            int output = 0;

            List<int> list = new List<int>();
            foreach (Die die in dice)
            {
                list.Add(die.ActiveNumber);
            }
            list = list.Distinct().ToList();
            list.Sort();
            if (list.Count >= 4)
            {
                if (list[0] == list[1] - 1 && list[1] == list[2] - 1 && list[2] == list[3] - 1)
                {
                    list.Remove(4);
                    foreach (int i in list)
                    {
                        output += i;
                    }
                }
                if (list[1] == list[2] - 1 && list[2] == list[3] - 1 && list[3] == list[4] - 1)
                {
                    list.Remove(0);
                    foreach (int i in list)
                    {
                        output += i;
                    }
                }
            }

            if (output == 0)
            {
                output = -1;
            }
            return output;
        }
        internal int findFullStright(List<Die> dice)
        {
            int output = 0;

            List<int> list = new List<int>();

            foreach (Die die in dice)
            {
                list.Add(die.ActiveNumber);
            }
            list = list.Distinct().ToList();

            list.Sort();

            if (list.Count >= 4)
            {

                if (list[0] == list[1] - 1 && list[1] == list[2] - 1 && list[2] == list[3] - 1 && list[3] == list[4] - 1)
                {
                    list.Remove(0);
                    foreach (int i in list)
                    {
                        output += i;
                    }
                }
            }
            if (output == 0)
            {
                output = -1;
            }
            return output;
        }
        internal int findYahtzee(List<Die> dice)
        {
            int output = 0;
            List<int> list = new List<int>();

            foreach (Die die in dice)
            {
                list.Add(die.ActiveNumber);
            }


            if (list[0] == list[1] && list[1] == list[2] && list[2] == list[3] && list[3] == list[4])
            {

                foreach (int i in list)
                {
                    output += i;
                }
            }
            if (output == 0)
            {
                output = -1;
            }
            return output;

        }
        internal int House(List<Die> dice)
        {
            int output = 0;
            List<int> throws = new List<int>();
            throws.Sort();
            foreach (Die die in dice)
            {
                throws.Add(die.ActiveNumber);
            }
            int first = throws.Count(X => X == throws[0]);
            int last = throws.Count(X => X == throws[4]);
            if (last <= 1 && first <= 1 && first + last == 10)
            {
                output = -1;
            }

            else if (first + last == 5)
            {
                output += first * throws[0];
                output += last * throws[4];
            }
            else { output = -1; }
            return output;
        }
        internal int Winner( Player player)
        {
            int playerScore = 0;
            foreach (var result in player.Results)
            {
                if (result.Value != -1)
                {

                    playerScore += result.Value;
                }
            }
           
            return playerScore;
        }
    }
}
