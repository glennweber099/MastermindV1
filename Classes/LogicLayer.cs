using System.Security.Cryptography;

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
                    Presentation.CorrectNumberAndPlacementMessage(indexPlacement + 1);
                }
                indexPlacement++;
            }

            //Handles all correct numbers in the wrong position and not already listed as being in the correct position earlier
            indexPlacement = 0;
            while (indexPlacement < answer.Length)
            {
                if (answer.Contains(userEntry[indexPlacement]) && userEntry[indexPlacement] != answer[indexPlacement])
                {
                    Presentation.CorrectNumberAndIncorrectPlacementMessage(indexPlacement + 1);
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
                string userEntry = userInputRestriction.ReadKeys();

                //Check if its an exact match and goes past the logic for each individual value
                if (userEntry == answer)
                {
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

        public string SetMastermindAnswer()
        {
            string answer = string.Empty;
            while (answer.Length < 4)
            {
                answer = answer + RandomNumberGenerator.GetInt32(1, 6).ToString();
            }
            return answer;
        }
    }
}
