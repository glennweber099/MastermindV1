using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MastermindV1.Classes
{
    public class UserInputRestriction
    {
        /// <summary>
        /// Checks each key press, and only allows BACKSPACE, ENTER when criteria is met, or a number between 1 and 6
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        public string ReadKeys()
        {
            string validInput = string.Empty;
            while (true)
            {
                double value;
                //reads value of pressed key
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    //if ENTER is pressed and the length of the input value is 4 then process the value
                    if (validInput.Length == 4)
                    {
                        return validInput;
                    }
                }

                if (key.Key == ConsoleKey.Backspace)
                {
                    //if BACKSPACE is pressed and length of value is greater than 0
                    if (validInput.Length > 0)
                    {
                        validInput = validInput.Substring(0, validInput.Length - 1); //removes 1 character at the end from the string being evaluated
                        Console.Write("\b \b"); //makes change in console visible to user of backspace being inputed
                    }
                }

                //checks value of key is a numeric value
                if (Double.TryParse(key.KeyChar.ToString(), out value))
                {
                    string currentInput = validInput + key.KeyChar; //sets checked value to whatever was already accepted and adds pressed key
                    //Prevents user from adding more than 4 numbers into the input
                    if (validInput.Length <= 3)
                    {
                        if (value > 0 && double.Parse(value.ToString()) < 7) //checks value of number is between 1 and 6 due to requirements limiting the numbers of the solution being between 1 and 6 for the 4 digits
                        {
                            Console.Write(key.KeyChar.ToString()); //add valid number to be visible in the console
                            validInput = currentInput; //set value of accepted values to new value with previously selected value
                        }
                    }
                }
            }

        }
    }
}
