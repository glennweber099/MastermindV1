namespace MastermindV1.Classes
{
    public static class Presentation
    {
        public static void InitialMenuSetUp()
        {
            Console.WriteLine($"\t\t\t\t\tWelcome To Mastermind!");
            Console.WriteLine($"Answer Key");
            Console.WriteLine($"\t+ -> Correct Number and Placement of Number");
            Console.WriteLine($"\t- -> Correct Number but Wrong Placement of Number");
            Console.WriteLine($"Please enter 4 digits that values are between 1 and 6. Press ENTER to submit guess.");
            Console.WriteLine("User Attempts Taken: 0/10");
        }

        public static void SuccessfulGame()
        {
            Console.WriteLine();
            Console.WriteLine("Position 1: +");
            Console.WriteLine("Position 2: +");
            Console.WriteLine("Position 3: +");
            Console.WriteLine("Position 4: +");
            Console.WriteLine();
            Console.WriteLine("Congratulations you solved the Mastermind!");
        }

        public static void UnsuccessfulGame()
        {
            Console.WriteLine("Out of attempts, try again!");
        }

        public static void UserAttemptsMessage(int currentAttemptsUsed)
        {
            Console.WriteLine("User Attempts Taken: {0}/10", currentAttemptsUsed.ToString());
        }

        public static void CorrectNumberAndPlacementMessage(int digitPosition)
        {
            Console.WriteLine("Positon {0}: +", (digitPosition).ToString());
        }

        public static void CorrectNumberAndIncorrectPlacementMessage(int digitPosition)
        {
            Console.WriteLine("Positon {0}: -", (digitPosition).ToString());
        }
    }
}
