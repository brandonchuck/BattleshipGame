using System;
using System.Collections.Generic;
using static System.Console;

namespace battleship
{
    public class GameLogic
    {

        public void StartGame()
        {
            List<Coordinate> computerShipsList = new List<Coordinate>();
            List<Coordinate> previousGuesses = new List<Coordinate>();

            HelperMethods helperMethods = new HelperMethods();

            WriteLine("WELCOME TO BATTLESHIP!\n");

            helperMethods.GenerateShips(computerShipsList);

            WriteLine("Computer generated ship:");
            computerShipsList.ForEach((ship) =>
            {
                WriteLine($"({ship.X}, {ship.Y})");
            });

            do
            {
                Write("\nGuess X coordinate from 1 to 10: ");
                string xCoordinate = ReadLine();

                Write("Guess Y coordinate from 1 to 10: ");
                string yCoordinate = ReadLine();

                Coordinate userGuess = new Coordinate(int.Parse(xCoordinate), int.Parse(yCoordinate));

                string guessesLog = helperMethods.LogGuesses(userGuess.X, userGuess.Y, previousGuesses);

                Coordinate match = computerShipsList.Find(ship => userGuess.X == ship.X && userGuess.Y == ship.Y);

                if (computerShipsList.Contains(match))
                {
                    computerShipsList.Remove(match);

                    WriteLine($"\nNICE HIT! {computerShipsList.Count} Ships Remaining...\n");
                    WriteLine($"Previous Guesses: {guessesLog}");

                    if (computerShipsList.Count == 0)
                    {
                        WriteLine("\nYOU WIN");
                        helperMethods.PlayAgain(computerShipsList, previousGuesses);
                    } else
                    {
                        helperMethods.guesses--;
                        helperMethods.CheckGuesses(helperMethods.guesses);
                        WriteLine($"\n ---------- {helperMethods.guesses} guesses left! ----------\n");
                    }
                }
                else
                {

                    WriteLine("\nYOU MISSED! Guess again...\n");
                    WriteLine($"Previous Guesses: {guessesLog}");

                    WriteLine($"\n{computerShipsList.Count} Ships Remaining...\n");

                    helperMethods.guesses--;
                    helperMethods.CheckGuesses(helperMethods.guesses);
                    if (helperMethods.guesses == 0)
                    {
                        helperMethods.PlayAgain(computerShipsList, previousGuesses);
                    }

                    WriteLine($"\n ---------- {helperMethods.guesses} guesses left! ----------\n");
                }
            } while (helperMethods.isPlaying);
        }



    }
}
