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
                catch (Exception)
                {
                    //we don't care about exception and don't want to break program if a non-numeric key is selected
                }
            }

        }
    }
}
