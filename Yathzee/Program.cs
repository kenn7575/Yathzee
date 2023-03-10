using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yathzee
{

    internal class Program
    {

        //game fields
        //dice
        public static Die die1 = new Die();
        public static Die die2 = new Die();
        public static Die die3 = new Die();
        public static Die die4 = new Die();
        public static Die die5 = new Die();
        public static List<Die> dice = new List<Die> { die1, die2, die3, die4, die5 };
        public static List<Die> savedDice = new List<Die>();

        //players
        public static Player player1 = new Player();
        public static Player player2 = new Player();
        bool playerTurn = true;

        //game info and proccess
        public static bool gameOver = false;
        public static Player activePlayer;
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

                            SetupGame();
                            PlayGame();
                            break;
                    }
                }
            }
        }
        public static void SetupGame()
        {
            Console.Clear();
            Console.WriteLine("Type name of Player1 ");
            string name = Console.ReadLine();
            player1.name = name;
            Console.WriteLine("Type name of Player2 ");
            name = Console.ReadLine();
            player2.name = name;
        }
        public static void PlayGame()
        {
            //game startet

            activePlayer = player1;
            while (!gameOver)
            {
                int turns = 26;
                while (turns > 0)
                {
                    turns--;
                    Console.Clear();
                    Console.WriteLine("{0}'s turn. ", activePlayer.name);
                    Console.WriteLine("[Exit: esc | See scoreboard: s | Roll Dices: Enter]");
                    bool keyPressed = false;
                    //runs until key is pressed
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
                                    Console.WriteLine("The winnre is {0}. Congratulations", player1.name);

                                    StartRound();
                                    keyPressed= true;
                                    break;
                            }
                           
                        }

                    }
                    Console.ReadKey();
                }
                //calculate score and reset game
                int player1Scoore = player1.Winner(player1);
                int player2Scoore = player2.Winner(player2);
                player1.PrintScore();
                player2.PrintScore();
                if (player1Scoore > player2Scoore)
                {
                   
                   
                    Console.ForegroundColor= ConsoleColor.White;
                    Console.WriteLine("The winnre is {0}. Congratulations", player1.name);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("The winnre is {0}. Congratulations", player2.name);
                }
                Console.WriteLine("Tap any key three times to comtinue.");
                Console.ReadKey();
                Console.ReadKey();
                Console.ReadKey();
            }
        }
        public static void StartRound()
        {
            while (dice.ToArray().Length > 0)
            {
                RollAllDice();
                ChooseDiceToKeep();
            }
            //Update player score and reset round
            activePlayer.UpdateScore(savedDice);
            if (activePlayer == player1)
            {
                activePlayer = player2;
            }
            else
            {
                activePlayer = player1;
            }
            dice.AddRange(savedDice);
            savedDice.Clear();
            foreach (Die die in dice)
            {
                die.IsSelected = false;
            }
        }
        public static void RollAllDice()
        {
            Console.Clear();
            //roll all dice
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Active dice" + Environment.NewLine + "--------------------------------------");
            foreach (Die die in dice)
            {
                if (die.IsSelected == false)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Thread.Sleep(2);
                die.ActiveNumber = die.Roll();
                Console.WriteLine(die.DisplayDie(die.ActiveNumber));
            }
            Console.WriteLine("Saved dice" + Environment.NewLine + "--------------------------------------");
            //render save dice
            foreach (Die die in savedDice)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(die.DisplayDie(die.ActiveNumber));
            }
        }
        public static void ChooseDiceToKeep()
        {
            bool selectMode1 = true;
            while (selectMode1)
            {
                bool selectMode = true;
                //what for keypress
                while (selectMode)
                {
                    if (Console.KeyAvailable)
                    {
                        var key1 = Console.ReadKey(true);

                        switch (key1.Key)
                        {
                            case ConsoleKey.D1:
                                if (dice.ToArray().Length >= 1) {
                                
                                dice[0].IsSelected = !dice[0].IsSelected;
                                selectMode = false;
                                }
                                break;
                            case ConsoleKey.D2:
                                if (dice.ToArray().Length >= 2) { 
                                dice[1].IsSelected = !dice[1].IsSelected;
                                selectMode = false;
                                }
                                break;
                            case ConsoleKey.D3:
                                if (dice.ToArray().Length >= 3) {
                                dice[2].IsSelected = !dice[2].IsSelected;
                                selectMode = false;
                                }
                                break;
                            case ConsoleKey.D4:
                                if (dice.ToArray().Length >= 4) {
                                dice[3].IsSelected = !dice[3].IsSelected;
                                selectMode = false;
                                }
                                break;
                            case ConsoleKey.D5:
                                if (dice.ToArray().Length >= 5) { 
                                dice[4].IsSelected = !dice[4].IsSelected;
                                selectMode = false;
                                }
                                break;
                            case ConsoleKey.Enter:
                                int updates = 0;
                                foreach (Die die in dice)
                                {
                                    if (die.IsSelected)
                                    {
                                        updates++;
                                    }
                                }
                                if (updates > 0)
                                {
                                    selectMode = false;
                                    selectMode1= false;
                                }
                                else
                                {
                                    Console.WriteLine("Select at least 1 die to comtinue");
                                }
                                break;
                        }
                    }
                }
                RenderDice();
            }
            var updatedDice = new List<Die>();
            //update saved dice
            foreach (Die die in dice)
            {

                if (die.IsSelected)
                {
                    savedDice.Add(die);
                    die.IsSelected = false;
                }
                else
                {
                    updatedDice.Add(die);
                }
            }
            dice = updatedDice;
            RenderDice();
        }
        public static void RenderDice()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Active dice" + Environment.NewLine + "--------------------------------------");
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
                Console.WriteLine(die.DisplayDie(die.ActiveNumber));
            }
            //render save dice
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Saved dice" + Environment.NewLine + "--------------------------------------");

            foreach (Die die in savedDice)
            {
                Console.WriteLine(die.DisplayDie(die.ActiveNumber));
            }
        }
    }
}

