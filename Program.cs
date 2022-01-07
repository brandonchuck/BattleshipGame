using System;
using System.Collections.Generic;
using static System.Console;
namespace battleship
{
    class Program
    {
        static void Main(string[] args)
        {

            int guesses = 8;
            bool isPlaying = true;

            WriteLine("WELCOME TO BATTLESHIP!\n");

            List<Coordinate> computerShipsList = new List<Coordinate>();

            generateShips(computerShipsList);

            List<Coordinate> previousGuesses = new List<Coordinate>();

            do
            {
                // -- For debugging --
                WriteLine("Computer generated ship:");
                computerShipsList.ForEach((ship) =>
                {
                    WriteLine($"({ship.X}, {ship.Y})");
                });

                Write("\nGuess X coordinate: ");
                string xCoordinate = ReadLine();

                Write("Guess Y coordinate: ");
                string yCoordinate = ReadLine();

                Coordinate userGuess = new Coordinate(int.Parse(xCoordinate), int.Parse(yCoordinate));

                string guessesLog = logGuesses(userGuess.X, userGuess.Y);

                // check if user guess matches a computer ship coordinate and return that ship from the computerShips list
                Coordinate match = computerShipsList.Find(ship => userGuess.X == ship.X && userGuess.Y == ship.Y);

                // if the match was found, that means it is contained inside the computerShips list
                if (computerShipsList.Contains(match))
                {
                    computerShipsList.Remove(match);

                    WriteLine($"\nNICE HIT! {computerShipsList.Count} Ships Remaining...\n");
                    WriteLine($"Previous Guesses: {guessesLog}");

                    if (computerShipsList.Count == 0)
                    {
                        WriteLine("\nYOU WIN");
                        playAgain(computerShipsList);
                        return;
                    }

                    guesses--;
                    guessesCheck(guesses);
                    WriteLine($"\n ---------- {guesses} guesses left! ----------\n");

                    
                }
                else
                {

                    WriteLine("\nYOU MISSED! Guess again...\n");
                    WriteLine($"Previous Guesses: {guessesLog}");

                    WriteLine($"\n{computerShipsList.Count} Ships Remaining...\n");

                    guesses--;
                    guessesCheck(guesses);
                    WriteLine($"\n ---------- {guesses} guesses left! ----------\n");

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
                    Coordinate match = computerShips.Find((ship) => randomShip.X == ship.X && randomShip.Y == ship.Y);
                    if (!computerShips.Contains(match))  // Can I just do if(!computerShips.Contains(randomShip)){...} ???
                    {
                        computerShips.Add(randomShip);
                    }
                }
            }

            void guessesCheck(int numGuesses)
            {
                if (numGuesses == 0)
                {
                    WriteLine("\n--- OUT OF GUESSES - GAME OVER! ---");
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
                Write("\nPlay again? y/n: ");
                string answer = ReadLine();
                if (answer == "y")
                {
                    guesses = 8; // reset guesses to 8
                    previousGuesses.Clear(); // clear guesses log

                    //shipsList.Clear(); // clear computerShips list
                    generateShips(shipsList); // generate 5 new ships
                }
                if (answer == "n")
                {
                    isPlaying = false;
                    WriteLine("Thanks for playing! :)");
                }
            }

        }
    }
}
