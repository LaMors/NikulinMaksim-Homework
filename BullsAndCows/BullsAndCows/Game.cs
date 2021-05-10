using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class Game
    {
        /// <summary>
        /// A collection of all possible answers
        /// </summary>
        private List<string> ansvers;

        /// <summary>
        /// Сurrent round counter
        /// </summary>
        private int counter = default;

        /// <summary>
        /// The number of cows and bulls for the current answer
        /// </summary>
        private BullsAndCows currentBullsAndCows;

        public Game()
        {
            GetAllAnsvers();

            currentBullsAndCows = new BullsAndCows()
            {
                Bulls = 0,
                Cows = 0
            };

            Console.WriteLine("\nThink the four-digit number from non-repeating numbers\n");
        }

        /// <summary>
        /// Populates the collection of answers with all possible answers
        /// </summary>
        private void GetAllAnsvers()
        {
            ansvers = new List<string>();

            for (int i = 0; i < 9999; i++)
            {
                var tempString = i.ToString().PadLeft(4, '0');
                var tempCharArr = tempString.ToCharArray().Distinct().ToArray();

                if (tempCharArr.Length < 4)
                    continue;

                ansvers.Add(new string(tempCharArr));
            }
        }

        /// <summary>
        /// Make a move and try to guess the number that the user mind.
        /// </summary>
        /// <returns>Is the game over?</returns>
        public bool MakeMove()
        {
            counter++;

            Console.WriteLine($"\nRound №{counter}\n");

            var newAnsver = GetOneAnsver();

            Console.WriteLine($"Answer options left:{ansvers.Count}\n");
            Console.WriteLine($"I thinks the answer is: {newAnsver}. Yes or no?\n");

            var playerAnsver = Asking();

            if (playerAnsver.ToLower() == "no")
            {
                Console.WriteLine($"\nHow many bulls?\n");
                var bulls = Console.ReadLine();

                Console.WriteLine($"\nHow many cows?\n");
                var cows = Console.ReadLine();

                currentBullsAndCows = new BullsAndCows()
                {
                    Bulls = Convert.ToInt32(bulls),
                    Cows = Convert.ToInt32(cows)
                };

                DeleteBadAnsvers(newAnsver);

                return true;
            }

            else
            {
                Console.WriteLine("\nI won you again, leather bag\n");
                return false;
            }
        }

        /// <summary>
        /// Ask the user if he thought of this number?
        /// </summary>
        /// <param name="answerIsCorrect"></param>
        /// <returns></returns>
        private string Asking()
        {
            var playerAnsver = Console.ReadLine();

            while (playerAnsver.ToLower() != "yes" && playerAnsver.ToLower() != "no")
            {
                Console.WriteLine($"\nSay \"yes\" or \"no\"\n");

                playerAnsver = Console.ReadLine();
            }

            return playerAnsver;
        }

        /// <summary>
        /// Count the number of cows and bulls when comparing two numbers.
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        private BullsAndCows GetQuantityBullsAndCows(string firstNumber, string secondNumber)
        {
            var bullsAndCows = new BullsAndCows() { Bulls = 0, Cows = 0 };

            for (int i = 0; i < firstNumber.Length; i++)
            {

                if (secondNumber.Contains(firstNumber[i]))
                {
                    if (firstNumber[i] == secondNumber[i])
                        bullsAndCows.Bulls++;

                    else
                        bullsAndCows.Cows++;
                }
            }

            return bullsAndCows;
        }

        /// <summary>
        /// Removes all impossible choices from the answer collection.
        /// </summary>
        /// <param name="currentAnsver"></param>
        private void DeleteBadAnsvers(string currentAnsver)
        {
            var tempAnsvers = new List<string>(ansvers);

            foreach (var ansver in tempAnsvers)
            {
                var newBullsAndCows = GetQuantityBullsAndCows(ansver, currentAnsver);

                if (!currentBullsAndCows.Equals(newBullsAndCows))
                    ansvers.Remove(ansver);

            }
        }

        /// <summary>
        /// Gets a "price" that indicates how profitable the intended answer is.
        /// </summary>
        /// <param name="supposedAnsver"></param>
        /// <returns></returns>
        private int GetMovePrice(string supposedAnsver)
        {
            var price = 0;

            foreach (var ansver in ansvers)
            {
                var newBullsAndCows = GetQuantityBullsAndCows(ansver, supposedAnsver);

                if (!currentBullsAndCows.Equals(newBullsAndCows))
                    price++;
            }

            return price;
        }

        /// <summary>
        /// Chooses one answer based on "price".
        /// </summary>
        /// <returns></returns>
        private string GetOneAnsver()
        {
            var maxPrice = ansvers.
                Select(ans => new { ansver = ans, price = GetMovePrice(ans) }).
                OrderBy(ans => ans.price).
                First().price;

            var optimalAnsvers = ansvers.
                Select(ans => new { ansver = ans, price = GetMovePrice(ans) }).
                Where(asn => asn.price == maxPrice).ToList();

            var ansver = optimalAnsvers[new Random().Next(0, optimalAnsvers.Count)].ansver;

            return ansver;
        }
    }
}
