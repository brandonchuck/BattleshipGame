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

            Console.WriteLine("Welcome to Battleship!\n");

            //Coordinate computerShipCoordinates = new Coordinate(new Random().Next(0, 11), new Random().Next(0, 11));
            //Coordinate computerShipCoordinates = new Coordinate(8, 5);

            string computerX = new Random().Next(0, 11).ToString();
            string computerY = new Random().Next(0, 11).ToString();

            void playAgain(string answer)
            {
                if (answer == "y") guesses = 8;

                if (answer == "n")
                {
                    isPlaying = false;
                    Console.WriteLine("Thanks for playing!");
                }
            }

            //List<string> previousGuess = new List<string>();
            do
            {
                //Coordinate userCoordinate = new Coordinate();

                Console.Write("Guess X coordinate: ");
                string userX = Console.ReadLine();
                //string xCoordiante = Console.ReadLine();
                //userCoordinate.X = int.Parse(xCoordinate);

                Console.Write("Guess Y coordinate: ");
                string userY = Console.ReadLine();
                //string yCoordinate = Console.ReadLine();
                //userCoordinate.Y = int.Parse(yCoordinate)

                //userCoordinate.X == computerCoordinate.X && userCoordinate.X == computerCoordinate.Y
                if (computerX == userX && computerY == userY)
                {
                    Console.WriteLine("Battleship hit!");
                    Console.WriteLine("YOU WIN\n");
                    Console.Write("Play again? y/n: ");
                    string answer = Console.ReadLine();
                    playAgain(answer);
                }
                else
                {
                    //previousGuess.Add(new Coordinate(userCoordinate.X, userCoordinate.Y));
                    Console.WriteLine("\nYou missed! Guess again...");
                    //Console.WriteLine($"Your previous guesses: {previousGuess.ToArray().ToString
                    guesses--;
                    Console.WriteLine($" --- {guesses} guesses left! ---\n");
                    if (guesses == 0)
                    {
                        Console.WriteLine("Game Over!");
                        Console.Write("Play again? y/n: ");
                        string answer = Console.ReadLine();
                        playAgain(answer);
                    }
                }
            } while (isPlaying);

        }
    }
}
