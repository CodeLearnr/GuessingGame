using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA25_GuessingGame
{
    public class GuessingGame
    {
        public static int guessMe { get; protected set; } 
        public static Random r { get; private set; } 
        public static int steps { get; private set; } 
        public static int LOW { get; private set; } 
        public static int HIGH { get; private set; }  
        public static int totalPlayers { get; private set; }
        public string playerName { get; private set; } 
        static GuessingGame()  
        {
            r = new Random();
            steps = 1;
            LOW = 0;
            HIGH = 50; 
            totalPlayers = 0;
            guessMe = r.Next(LOW, HIGH);
        }

        public GuessingGame(string Name) 
        {
            this.playerName = Name;
            totalPlayers++;
        }
        public static int CheckWin(int currentGuess)
        {
            
            if (currentGuess == GuessingGame.guessMe)
                return 0;
            else if (currentGuess < GuessingGame.guessMe)
                return 1;
            else
                return -1;
        }
        public static void GiveHints(int guess) 
        {
            if (guess < GuessingGame.guessMe)
                Console.WriteLine("Guess Higher");
            else if (guess > GuessingGame.guessMe)
                Console.WriteLine("Guess Lower");
            else 
                Console.WriteLine("");
        }
        public static int PlusStep()
        {
            return steps++;
        }
        public static int MinusStep()
        {
            return steps--;
        }
        public static int WhoseTurn() 
        {
            //Console.WriteLine("current step =" + steps);
            if (steps % totalPlayers != 0)
                return (steps % totalPlayers);
            else 
                return totalPlayers;
            
        }
        public static int GetWinningPlayerID() 
        {
            return (steps - 1) % totalPlayers + 1;  
        }
        public string GetPlayerName() 
        {
            return playerName;
        }

        public int Play() 
        {
                Console.WriteLine($"Please enter your guess {GetPlayerName()}");
                return Int32.Parse(Console.ReadLine());
        }
         /*Learning Activity 1: Design a Turn Taking Number Guessing Game
         Write a simple guessing game for multiple players. Your program should pick a random number between 0 and 100 (inclusive) and ask the players to guess the number. Each player will guess, in turn, in a round-robin fashion. If a player guesses wrong, print either “Guess Higher” or “Guess Lower” to indicate if the correct answer is higher or lower than the player’s guess, then prompt them to guess again for the next player. When the user guesses the right number, print “Congratulations!” and mention the winning player ID and name. Your program should also print the total attempts made by all players.
         By. Napapan W., December 2021 */
    }
}
