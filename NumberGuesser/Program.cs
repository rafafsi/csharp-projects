internal class Program
{
    private static void Main(string[] args)
    {
        GetAppInfo();
        GetGreeting();

        while (true)
        {
            Random random = new Random();
            int correctNumber = random.Next(1, 10);

            int guess = 0;
            Console.WriteLine("Guess a number between 1 and 10");

            while (guess != correctNumber)
            {
                string inputGuess = Console.ReadLine();

                if (!int.TryParse(inputGuess, out guess))
                {
                    PrintMessage(ConsoleColor.Red, "Please use an actual number");
                    continue;
                }

                guess = Int32.Parse(inputGuess);

                if (guess != correctNumber)
                {
                    PrintMessage(ConsoleColor.Red, "Wrong number, try again!");
                    continue;
                }

                PrintMessage(ConsoleColor.DarkGreen, "CORRECT! You guessed it! :)");

                PrintMessage(ConsoleColor.Yellow, "Do you want to play again? [ Y or N ]");
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y")
                {
                    continue;
                }
                else if (answer == "N")
                {
                    PrintMessage(ConsoleColor.Yellow, "Thank you for playing with me! :)");
                    return;
                }
                else
                {
                    return;
                }
            }
        }
    }

    static void GetAppInfo()
    {
        string appName = "Number Guesser";
        string appVersion = "1.0.0";
        string appAuthor = "Rafaela Inácio";

        string fullMessage = appName + "Version " + appVersion + " by " + appAuthor;
        PrintMessage(ConsoleColor.Green, fullMessage);
    }

    static void GetGreeting()
    {
        PrintMessage(ConsoleColor.Yellow, "What's your name?");
        string userName = Console.ReadLine();
        Console.WriteLine("Welcome, {0}! Let's play?", userName);
    }

    static void PrintMessage(ConsoleColor color, string message)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

}