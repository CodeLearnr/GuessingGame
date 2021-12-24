using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LA25_GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== LA 25. Multi-players Number Guessing game =====\n");
            string choice;
            string playerName;
            List<GuessingGame> players = new List<GuessingGame>();  

            do  
            {
                Console.WriteLine("Please enter a player name: ");
                playerName = Console.ReadLine();

                GuessingGame newPlayer = new GuessingGame(playerName); 
                players.Add(newPlayer);                              

                Console.WriteLine("Another player? :Y/N ");
                choice = Console.ReadLine();
            } while (choice == "y" || choice == "Y");

            //Console.WriteLine("The random number is " + GuessingGame.guessMe);  --- for checking purpose only
            

            int currentGuess;
            do
            {
                Console.Clear();
                Console.WriteLine("Guess a number in range {0} to {1}: ", GuessingGame.LOW, GuessingGame.HIGH); 
                Console.WriteLine("Now playing player: {0}", GuessingGame.WhoseTurn()); 
                currentGuess = players[GuessingGame.WhoseTurn()-1].Play();    
                
                GuessingGame.GiveHints(currentGuess);  //accessing through class, shared message for all objects
                GuessingGame.PlusStep();
                Thread.Sleep(1000);
            } while (GuessingGame.CheckWin(currentGuess) != 0); //common/shared message

            GuessingGame.MinusStep();
            Console.WriteLine("Congratulations! Player {0}: {1} Wins...", GuessingGame.GetWinningPlayerID(), players[GuessingGame.GetWinningPlayerID() - 1].GetPlayerName());
            Console.WriteLine("Total attempt counted for all players was {0}.", GuessingGame.steps); 
        }
    }
}
