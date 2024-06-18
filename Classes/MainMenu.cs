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
                    
                    if (AttemptValues(answer))
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
                    Console.WriteLine("Out of attempts, try again if you dare!");
                }
                break;
            }
        }

        /// <summary>
        /// Checks if the value passed in matches the answer and returns false if not with the input sent in CheckForEachValue when at least one number is wrong or in the wrong position
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public static bool AttemptValues(string answer)
        {
            while (true)
            {
                Console.WriteLine("Your Guess");
                string userEntry = ReadKeys(
                        s => { double.Parse(s); return true; });

                //Check if its an exact match and goes past the logic for each individual value
                if(userEntry == answer)
                {
                    Console.WriteLine();
                    Console.WriteLine("Position 1: +");
                    Console.WriteLine("Position 2: +");
                    Console.WriteLine("Position 3: +");
                    Console.WriteLine("Position 4: +");
                    return true;
                }
                //Runs logic to check each value inputed by the user and compares the value provided to the answer
                else
                {
                    Console.WriteLine();
                    CheckForEachValue(userEntry, answer);
                    return false;
                }
            }
        }

        /// <summary>
        /// Goes through value provided by user and the answer of the mastermind and sends input if correct number and placement, correct number, or neither
        /// </summary>
        /// <param name="userEntry"></param>
        /// <param name="answer"></param>
        public static void CheckForEachValue(string userEntry, string answer)
        {
            //Handles all correct numbers in the correct position
            int indexPlacement = 0;
            int MasterMindPosition = 1;
            while(indexPlacement < answer.Length)
            {
                if (userEntry[indexPlacement] == answer[indexPlacement])
                {
                    Console.WriteLine("Positon {0}: +", MasterMindPosition.ToString());
                }
                MasterMindPosition++;
                indexPlacement++;
            }

            //Handles all correct numbers in the wrong position and not already listed as being in the correct position earlier
            indexPlacement = 0;
            MasterMindPosition = 1;
            while (indexPlacement < answer.Length)
            {
                if (answer.Contains(userEntry[indexPlacement]) && userEntry[indexPlacement] != answer[indexPlacement])
                {
                    Console.WriteLine("Positon {0}: -", MasterMindPosition.ToString());
                }
                MasterMindPosition++;
                indexPlacement++;
            }

            //Handles all numbers not within the answer
            indexPlacement = 0;
            MasterMindPosition = 1;
            while (indexPlacement < answer.Length)
            {
                if (!answer.Contains(userEntry[indexPlacement]) && userEntry[indexPlacement] != answer[indexPlacement])
                {
                    Console.WriteLine("Positon {0}: ", MasterMindPosition.ToString());
                }
                MasterMindPosition++;
                indexPlacement++;
            }
        }

        /// <summary>
        /// Checks each key press, and only allows BACKSPACE, ENTER when criteria is met, or a number between 1 and 6
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        public static string ReadKeys(Predicate<string> check)
        {
            string valid = string.Empty;
            while (true)
            {
                //reads value of pressed key
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    //if ENTER is pressed and the length of the input value is 4 then process the value
                    if (valid.Length == 4)
                    {
                        return valid;
                    }
                }

                if (key.Key == ConsoleKey.Backspace)
                {
                    //if BACKSPACE is pressed and length of value is greater than 0
                    if (valid.Length > 0)
                    {
                        valid = valid.Substring(0, valid.Length - 1); //removes 1 character at the end from the string being evaluated
                        Console.Write("\b \b"); //makes change in console visible to user of backspace being inputed
                    }
                }

                //checks value of key other than backspace or enter
                char keyChar = key.KeyChar;
                string candidate = valid + keyChar; //sets checked value to whatever was already accepted and adds pressed key
                try
                {
                    double checkedValue = double.Parse(char.ToString(keyChar)); //sets value of pressed key to a numeric value
                    if (checkedValue > 0 && checkedValue < 7) //checks value of number is between 1 and 6
                    {
                        Console.Write(keyChar); //add valid number to be visible in the console
                        valid = candidate; //set value of accepted values to new value with previously selected value
                    }
                }
                catch(Exception)
                {
                    //we don't care about exception and don't want to break program if a non-numeric key is selected
                }
            }

        }
    }
}
