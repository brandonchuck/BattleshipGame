using System;
using System.Collections.Generic;
namespace battleship
{
    class Program
    {
        static void Main(string[] args)
        {

            int guesses = 8;
            int battleShipLives = 5;
            bool isPlaying = true;

            Console.WriteLine("Welcome to Battleship!\n");

            List<Coordinate> computerShips = new List<Coordinate>();

            // View the 5 randomly generated ship coordinates
            while (computerShips.Count < 5)
            {
                int x = new Random().Next(0, 11);
                int y = new Random().Next(0, 11);
                Coordinate randomShip = new Coordinate(x, y);
                if (!computerShips.Contains(randomShip))
                {
                    computerShips.Add(randomShip);
                }
            }

            // Computer Generated Ships
            // Should be able to "Hit" these ships
            Console.WriteLine("Computer generated ship:");
            computerShips.ForEach((ship) =>
            {
                Console.WriteLine($"({ship.X}, {ship.Y})");
            });

            List<Coordinate> previousGuesses = new List<Coordinate>();

            do
            {
                Coordinate userGuess = new Coordinate();

                Console.Write("\nGuess X coordinate: ");
                string xCoordinate = Console.ReadLine();
                userGuess.X = int.Parse(xCoordinate);


                Console.Write("Guess Y coordinate: ");
                string yCoordinate = Console.ReadLine();
                userGuess.Y = int.Parse(yCoordinate);

                string guessesLog = logGuesses(userGuess.X, userGuess.Y);


                // Can I not use .Contains() here to check whether the userGuess Coordinate object is within the computerShips list???
                if (computerShips.Contains(userGuess)) // <-------------
                {

                    battleShipLives--;
                    Console.WriteLine($"*** Battleship hit! --> Battleship Lives: {battleShipLives} ***");

                    Console.WriteLine($"Previous Guesses: {guessesLog}");

                    guesses--;
                    Console.WriteLine($" --- {guesses} guesses left! ---\n");

                    if (battleShipLives == 0)
                    {
                        Console.WriteLine("YOU WIN\n");
                        playAgain();
                    }
                    
                    guessesCheck(guesses);

                }
                else
                {
                    Console.WriteLine("\nYou missed! Guess again...");
                    Console.WriteLine($"Previous Guesses: {guessesLog}");

                    guesses--;
                    Console.WriteLine($" --- {guesses} guesses left! ---\n");

                    guessesCheck(guesses);
                }
            } while (isPlaying);




            // ---------------- FUNCTIONS ------------------
            void guessesCheck(int numGuesses)
            {
                if (numGuesses == 0)
                {
                    Console.WriteLine("Game Over!");
                    playAgain();
                }
            }


            string logGuesses(int x, int y)
            {
                previousGuesses.Add(new Coordinate(x, y));

                string prevGuessesString = "";
                previousGuesses.ForEach((coordinate) =>
                {
                    prevGuessesString += $"({coordinate.X}, {coordinate.Y}) ";
                });
                return prevGuessesString;
            }


            void playAgain()
            {
                Console.Write("Play again? y/n: ");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    guesses = 8;
                    battleShipLives = 5;
                    previousGuesses.Clear();
                }
                if (answer == "n")
                {
                    isPlaying = false;
                    Console.WriteLine("Thanks for playing!");
                }
            }

        }
    }
}
