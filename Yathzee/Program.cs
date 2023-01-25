using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yathzee
{
    internal class Program
    {
        


        static void Main(string[] args)
        {
            
               
           

            var random = new Random();
            Console.WriteLine("Welcome! [Exit: esc | Start: Enter]");
            while (true)
            {
                

               
               
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        
                        case ConsoleKey.Escape:
                            break;
                        case ConsoleKey.Enter:
                           
                            StartGame();
                            break;
                    }
                }

            }
        }
        public static void StartGame()
        {
            Console.Clear();
            Console.WriteLine("Type name of Player1 ");
            string name = Console.ReadLine();
            Player player1 = new Player(name);
            Console.WriteLine("Type name of Player2 ");
            name = Console.ReadLine();
            Player player2 = new Player(name);

            //make dices and put them in a list
            Die die1= new Die();
            Die die2= new Die();  
            Die die3= new Die();
            Die die4= new Die();
            Die die5 = new Die();
            var dice = new List<Die> {die1,die2, die3, die4, die5};
            var savedDice = new List<Die> ();




            //game startet
            bool gameOver = false;
            string activePlayer = player1.name;
            while (!gameOver) 
            {
                while (true)
                {
                    Console.WriteLine("{0}'s turn. ", activePlayer);
                    Console.WriteLine("[Exit: esc | See scoreboard: s | Roll Dices: Enter]");
                    bool keyPressed = false;


                    while (keyPressed == false)
                    {

                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(true);

                            switch (key.Key)
                            {

                                case ConsoleKey.Escape:
                                    keyPressed = true;
                                    break;
                                case ConsoleKey.S:
                                    player1.PrintScore();
                                    player2.PrintScore();
                                    keyPressed = true;

                                    break;
                                case ConsoleKey.Enter:
                                    Console.Clear();
                                    
                                   
                                    foreach (var die in dice)
                                    {
                                        if (die.IsSelected == false)
                                        {
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                        }
                                        int randomNum = die.Roll();

                                        Console.WriteLine(die.DisplayDie(randomNum));
                                        Console.WriteLine(randomNum);
                                    }
                                    //chose dice to keep
                                    while (keyPressed == false)
                                    {

                                        if (Console.KeyAvailable)
                                        {
                                            var key1 = Console.ReadKey(true);

                                            switch (key1)
                                            {
                                                
                                            }
                                        }

                                    }
                                    break;
                            }
                        }

                    }
                    Console.ReadKey();
                }
                
            }
        }
        public void RollDices(object[] dices)
        {
            foreach (object dice in dices)
            {
                
            }
        }
    }
}
