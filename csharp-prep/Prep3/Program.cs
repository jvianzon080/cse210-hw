using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        bool playAgain = true;

        while (playAgain)
        {
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;
            int guess = 0;

            Console.WriteLine("Welcome to Guess My Number Game!");
            Console.WriteLine("I have picked a magic number from 1-100. Guess it.");

            while (guess != magicNumber)
            {
                Console.Write("Enter your guess: ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("That's right!");
                }
            }

            Console.WriteLine($"Congratulations! You guessed the magic number {magicNumber} in {guessCount} guesses.");

            Console.WriteLine("Do you want to play again? (Yes/No): ");
            string playAgainInput = Console.ReadLine().ToLower();
            playAgain = (playAgainInput == "yes");
        }

        Console.WriteLine("Thank you for playing Guess the Magic Number Game. ");
    }
}