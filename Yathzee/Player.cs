using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Yathzee
{
    internal class Player
    {
		

		Dictionary<string, int> Results  = new Dictionary<string, int>();
		internal string name;
		public Player(string name)
		{
			this.name = name;
			Results.Add("Ones", 0);
			Results.Add("Twos", 0);
			Results.Add("Threes", 0);
			Results.Add("Fours", 0);
			Results.Add("Fives", 0);
			Results.Add("Sixes", 0);
			Results.Add("TOAK", 0);
			Results.Add("FOAK", 0);
			Results.Add("FullStraight", 0);
			Results.Add("SmallStraight", 0);
			Results.Add("Yahtzee", 0);
			Results.Add("Chance", 0);
		}
		internal void PrintScore()
		{
			Console.WriteLine(Environment.NewLine + name+"'s score is");
			foreach (var item in Results) 
			{
				Console.WriteLine(item.Key + " " + item.Value );
			}

        }
    }
}
