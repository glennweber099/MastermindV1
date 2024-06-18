using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MastermindV1.Classes
{
    public class MainMenu
    {
        static void Main()
        {
            while (true)
            {
                int TotalAttempts = 0;
                bool solved = false;
                Console.WriteLine($"\t\t\t\t\tWelcome To Mastermind!");
                Console.WriteLine($"Please enter 4 digits that values are between 1 and 6. Press ENTER to submit guess.");

                //Set Mastermind value to be attempted to be solved for
                string answer = string.Empty;
                while (answer.Length < 4)
                {
                    answer = answer + RandomNumberGenerator.GetInt32(1, 6).ToString();
                }
                Console.WriteLine("Mastermind value: {0}", answer);
                //Limits player to 10 total attempts
                while (TotalAttempts < 10)
                {
                    
                    if (AttemptValues(answer))
                    {
                        //If successfull, set solved to true and break out of loop
                        solved = true;
                        break;
                    }
                    else
                    {
                        //If unsuccessfull, add attempts to count of total attempts taken so far
                        solved = false;
                        TotalAttempts = TotalAttempts + 1;
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
                    if (checkedValue > 0 && checkedValue < 7) //checks if value is between 1 and 6 if number
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
