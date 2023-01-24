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

            //game startet
            bool gameOver = false;
            while (!gameOver) 
            {
                Console.WriteLine("{0}'s turn. ", player1.name);
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
                        }
                    }
                   
                }
                Console.ReadKey();
            }
        }
    }
}
