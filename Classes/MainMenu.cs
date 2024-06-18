using System;
using System.Collections.Generic;
using System.Linq;
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
                Console.WriteLine($"\t\t\t\t\tWelcome To Mastermind!");
                Console.WriteLine($"Please enter 4 digits that values are between 1 and 6. Press ENTER to submit guess.");

                //Set Mastermind value to be attempted to be solved for
                string randomValue = string.Empty;
                while (randomValue.Length < 4)
                {
                    randomValue = randomValue + RandomNumberGenerator.GetInt32(1, 6).ToString();
                }
                Console.WriteLine("Mastermind value: {0}", randomValue);

                //Limits player to 10 total attempts
                while (TotalAttempts < 10)
                {

                    if (AttemptValues(randomValue))
                    {
                        //If successfull, print message notifying user and end program
                        Console.WriteLine();
                        Console.WriteLine("Congratulations you solved the Mastermind!");
                        break;
                    }
                    else
                    {
                        //If unsuccessfull, add attempts to count of total attempts taken so far
                        TotalAttempts = TotalAttempts + 1;
                    }

                }
                //Let's user know they ran out of attempts and to try again and ends the program
                Console.WriteLine("Out of attempts, try again if you dare!");
                break;
            }
        }

        public static bool AttemptValues(string randomValue)
        {
            while (true)
            {
                string entry = ReadKeys(
                        s => { StringToDouble(s); return true; });

                double result = StringToDouble(entry);

                //Check if its an exact match
                if(result.ToString() == randomValue)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Incorrect! You tried the following value: {0}", result);
                    return false;
                }
            }
        }

        public static double StringToDouble(string s)
        {
            try
            {
                return double.Parse(s);
            }
            catch (FormatException)
            {
                // handle trailing E and +/- signs
                return double.Parse(s + '0');
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
