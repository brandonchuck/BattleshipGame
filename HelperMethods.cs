using System;
using System.Collections.Generic;
using static System.Console;

namespace battleship
{
    public class HelperMethods
    {
        public int guesses = 8;
        public bool isPlaying = true;

        public void GenerateShips(List<Coordinate> computerShipsList)
        {
            while (computerShipsList.Count < 5)
            {
                int x = new Random().Next(1, 11);
                int y = new Random().Next(1, 11);
                Coordinate randomShip = new Coordinate(x, y);
                Coordinate match = computerShipsList.Find((ship) => randomShip.X == ship.X && randomShip.Y == ship.Y);
                if (!computerShipsList.Contains(match))
                {
                    computerShipsList.Add(randomShip);
                }
            }
        }

        public void CheckGuesses(int numGuesses)
        {
            if (numGuesses == 0)
            {
                WriteLine("\n--- OUT OF GUESSES - GAME OVER! ---");
            }
        }


        public string LogGuesses(int x, int y, List<Coordinate> previousGuesses)
        {
            previousGuesses.Add(new Coordinate(x, y));

            string prevGuessesString = "";
            previousGuesses.ForEach((coordinate) =>
            {
                prevGuessesString += $"({coordinate.X}, {coordinate.Y}) ";
            });
            return prevGuessesString;
        }


        public void PlayAgain(List<Coordinate> computerShipsList, List<Coordinate> previousGuesses)
        {
            Write("\nPlay again? y/n: ");
            string answer = ReadLine();
            if (answer == "y")
            {
                guesses = 8;
                previousGuesses.Clear();
                computerShipsList.Clear();
                GenerateShips(computerShipsList);
            }
            if (answer == "n")
            {
                isPlaying = false;
                WriteLine("Thanks for playing! :)");
            }
        }
    }
}
