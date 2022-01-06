using System;
using System.Collections.Generic;
namespace battleship
{
    class Program
    {
        static void Main(string[] args)
        {

            int guesses = 8;
            bool isPlaying = true;

            Console.WriteLine("WELCOME TO BATTLESHIP!\n");

            List<Coordinate> computerShipsList = new List<Coordinate>();

            generateShips(computerShipsList);

            List<Coordinate> previousGuesses = new List<Coordinate>();

            do
            {

                Console.WriteLine("Computer generated ship:");
                computerShipsList.ForEach((ship) =>
                {
                    Console.WriteLine($"({ship.X}, {ship.Y})");
                });

                Coordinate userGuess = new Coordinate();

                Console.Write("\nGuess X coordinate: ");
                string xCoordinate = Console.ReadLine();
                userGuess.X = int.Parse(xCoordinate);

                Console.Write("Guess Y coordinate: ");
                string yCoordinate = Console.ReadLine();
                userGuess.Y = int.Parse(yCoordinate);

                string guessesLog = logGuesses(userGuess.X, userGuess.Y);

                // check if user guess matches a computer ship coordinate and return that ship from the computerShips list
                Coordinate match = computerShipsList.Find(ship => userGuess.X == ship.X && userGuess.Y == ship.Y);

                // if the match was found, that means it is contained inside the computerShips list
                if (computerShipsList.Contains(match))
                {
                    computerShipsList.Remove(match);

                    Console.WriteLine("Computer generated ship:");
                    computerShipsList.ForEach((ship) =>
                    {
                        Console.WriteLine($"({ship.X}, {ship.Y})");
                    });

                    Console.WriteLine($"*** Battleship hit! --> Battleships Remaining: {computerShipsList.Count} ***");
                    Console.WriteLine($"Previous Guesses: {guessesLog}");

                    guesses--;
                    guessesCheck(guesses);
                    Console.WriteLine($" --- {guesses} guesses left! ---\n");

                    if (computerShipsList.Count == 0)
                    {
                        Console.WriteLine("YOU WIN\n");
                        playAgain(computerShipsList);
                    }        
                }
                else
                {
                    Console.WriteLine("\nYou missed! Guess again...");
                    Console.WriteLine($"Previous Guesses: {guessesLog}");

                    guesses--;
                    guessesCheck(guesses);
                    Console.WriteLine($" --- {guesses} guesses left! ---\n");

                }
            } while (isPlaying);







            // ---------------- FUNCTIONS ------------------

            void generateShips(List<Coordinate> computerShips)
            {
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
            }

            void guessesCheck(int numGuesses)
            {
                if (numGuesses == 0)
                {
                    Console.WriteLine("Game Over!");
                    playAgain(computerShipsList);
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


            void playAgain(List<Coordinate> shipsList)
            {
                Console.Write("Play again? y/n: ");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    guesses = 8; // reset guesses to 8
                    previousGuesses.Clear(); // clear guesses log

                    //ships.Clear(); // clear computerShips list
                    generateShips(shipsList); // generate 5 new ships
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
