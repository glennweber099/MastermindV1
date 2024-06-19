using System.Security.Cryptography;

namespace MastermindV1.Classes
{
    public class MainMenu
    {
        /// <summary>
        /// Initial setup of console app and sets the value of Mastermind answer
        /// </summary>
        static void Main()
        {
            LogicLayer logicLayer = new LogicLayer();
            while (true)
            {
                int TotalAttempts = 0;
                bool solved = false;
                Console.WriteLine($"\t\t\t\t\tWelcome To Mastermind!");
                //Provides key for result to user
                Console.WriteLine($"Answer Key");
                Console.WriteLine($"\t+ -> Correct Number and Placement of Number");
                Console.WriteLine($"\t- -> Correct Number but Wrong Placement of Number");
                Console.WriteLine($"Please enter 4 digits that values are between 1 and 6. Press ENTER to submit guess.");

                //Set Mastermind value to be attempted to be solved for
                string answer = string.Empty;
                while (answer.Length < 4)
                {
                    answer = answer + RandomNumberGenerator.GetInt32(1, 6).ToString();
                }
                Console.WriteLine("User Attempts Taken: 0/10");
                //Limits player to 10 total attempts
                while (TotalAttempts < 10)
                {

                    if (logicLayer.AttemptValues(answer))
                    {
                        //If successfull, set solved to true and break out of loop
                        TotalAttempts = TotalAttempts + 1;
                        Console.WriteLine("User Attempts Taken: {0}/10", TotalAttempts.ToString());
                        solved = true;
                        break;
                    }
                    else
                    {
                        //If unsuccessfull, add attempts to count of total attempts taken so far
                        TotalAttempts = TotalAttempts + 1;
                        Console.WriteLine("User Attempts Taken: {0}/10", TotalAttempts.ToString());
                        solved = false;
                    }

                }

                if (solved)
                {
                    //Let's user know they won Mastermind
                    Console.WriteLine();
                    Console.WriteLine("Congratulations you solved the Mastermind!");
                }
                else
                {
                    //Let's user know they ran out of attempts and to try again and ends the program
                    Console.WriteLine("Out of attempts, try again!");
                }
                break;
            }
        }
    }
}
