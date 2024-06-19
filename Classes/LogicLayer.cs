using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastermindV1.Classes
{
    public class LogicLayer
    {
        /// <summary>
        /// Goes through value provided by user and the answer of the mastermind and sends input if correct number and placement, correct number, or neither
        /// </summary>
        /// <param name="userEntry"></param>
        /// <param name="answer"></param>
        public void CheckForEachValue(string userEntry, string answer)
        {
            //Handles all correct numbers in the correct position
            int indexPlacement = 0;
            while (indexPlacement < answer.Length)
            {
                if (userEntry[indexPlacement] == answer[indexPlacement])
                {
                    Console.WriteLine("Positon {0}: +", (indexPlacement + 1).ToString());
                }
                indexPlacement++;
            }

            //Handles all correct numbers in the wrong position and not already listed as being in the correct position earlier
            indexPlacement = 0;
            while (indexPlacement < answer.Length)
            {
                if (answer.Contains(userEntry[indexPlacement]) && userEntry[indexPlacement] != answer[indexPlacement])
                {
                    Console.WriteLine("Positon {0}: -", (indexPlacement + 1).ToString());
                }
                indexPlacement++;
            }

            //Handles all numbers not within the answer
            indexPlacement = 0;
            while (indexPlacement < answer.Length)
            {
                if (!answer.Contains(userEntry[indexPlacement]) && userEntry[indexPlacement] != answer[indexPlacement])
                {
                    Console.WriteLine("Positon {0}: ", (indexPlacement + 1).ToString());
                }
                indexPlacement++;
            }
        }

        /// <summary>
        /// Checks if the value passed in matches the answer and returns false if not with the input sent in CheckForEachValue when at least one number is wrong or in the wrong position
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public bool AttemptValues(string answer)
        {
            UserInputRestriction userInputRestriction = new UserInputRestriction();
            while (true)
            {
                Console.WriteLine("Your Guess");
                string userEntry = userInputRestriction.ReadKeys(
                        s => { double.Parse(s); return true; });

                //Check if its an exact match and goes past the logic for each individual value
                if (userEntry == answer)
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
    }
}
