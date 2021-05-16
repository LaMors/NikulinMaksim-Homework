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
        private List<string> answers;

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
            GetAllAnswers();

            currentBullsAndCows = new BullsAndCows()
            {
                Bulls = 0,
                Cows = 0
            };

            Console.WriteLine("\nThink the four-digit number\n");
        }

        /// <summary>
        /// Populates the collection of answers with all possible answers
        /// </summary>
        private void GetAllAnswers()
        {
            answers = new List<string>();

            for (int i = 0; i < 9999; i++)
            {
                var tempString = i.ToString().PadLeft(4, '0');

                if (tempString.Length < 4)
                    continue;

                answers.Add(tempString);
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

            string newAnswer;
            if (counter == 1)
                newAnswer = GetRandomAnswer();

            else
                newAnswer = GetOneAnswer();

            Console.WriteLine($"Answer options left:{answers.Count}\n");
            Console.WriteLine($"I thinks the answer is: {newAnswer}. Yes or no?\n");

            var playerAnswer = Asking();

            if (playerAnswer.ToLower() == "no")
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

                DeleteBadAnswers(newAnswer);

                return true;
            }

            else
            {
                Console.WriteLine("\nI won you again, leather bag\n");
                return false;
            }
        }

        private string GetRandomAnswer() => answers[new Random().Next(0, answers.Count)];


        /// <summary>
        /// Ask the user if he thought of this number?
        /// </summary>
        /// <param name="answerIsCorrect"></param>
        /// <returns></returns>
        private string Asking()
        {
            var playerAnswer = Console.ReadLine();

            while (playerAnswer.ToLower() != "yes" && playerAnswer.ToLower() != "no")
            {
                Console.WriteLine($"\nSay \"yes\" or \"no\"\n");

                playerAnswer = Console.ReadLine();
            }

            return playerAnswer;
        }

        /// <summary>
        /// Count the number of cows and bulls when comparing two numbers.
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        public BullsAndCows GetQuantityBullsAndCows(string firstNumber, string secondNumber)
        {
            var bullsAndCows = new BullsAndCows() { Bulls = 0, Cows = 0 };

            var tempSecond = secondNumber;

            var tempFirst = firstNumber;


            for (int i = 0; i < firstNumber.Length; i++)
            {
                if (secondNumber.Contains(firstNumber[i]))
                {
                    if (firstNumber[i] == secondNumber[i])
                    {
                        var temp1 = tempFirst.ToCharArray().ToList();
                        temp1.RemoveAt(temp1.IndexOf(firstNumber[i]));

                        var temp2 = tempSecond.ToCharArray().ToList();
                        temp2.RemoveAt(temp2.IndexOf(firstNumber[i]));

                        tempFirst = new string(temp1.ToArray());

                        tempSecond = new string(temp2.ToArray());

                        bullsAndCows.Bulls++;
                    }
                }
            }

            for (int i = 0; i < tempFirst.Length; i++)
            {
                if (tempFirst.Contains(tempSecond[i]))
                {
                    bullsAndCows.Cows++;
                }
            }



            return bullsAndCows;
        }

        /// <summary>
        /// Removes all impossible choices from the answer collection.
        /// </summary>
        /// <param name="currentAnswer"></param>
        private void DeleteBadAnswers(string currentAnswer)
        {
            var tempAnswers = new List<string>(answers);

            foreach (var answer in tempAnswers)
            {
                var newBullsAndCows = GetQuantityBullsAndCows(answer, currentAnswer);

                if (!currentBullsAndCows.Equals(newBullsAndCows))
                    answers.Remove(answer);

            }
        }

        /// <summary>
        /// Gets a "price" that indicates how profitable the intended answer is.
        /// </summary>
        /// <param name="supposedAnswer"></param>
        /// <returns></returns>
        private int GetMovePrice(string supposedAnswer)
        {
            var priceBulls = 0;

            var priceCows = 0;

            foreach (var answer in answers)
            {
                var newBullsAndCows = GetQuantityBullsAndCows(answer, supposedAnswer);

                if (currentBullsAndCows.Bulls == currentBullsAndCows.Bulls)
                    priceBulls++;

                if (currentBullsAndCows.Cows == currentBullsAndCows.Cows)
                    priceCows++;
            }

            return priceBulls*10 + priceCows;
        }

        /// <summary>
        /// Chooses one answer based on "price".
        /// </summary>
        /// <returns></returns>
        private string GetOneAnswer()
        {
            if (answers.Count == 1)
                return answers[0];

            var tempAnswers = new List<string>(answers);

            var answer = answers.
                Select(ans => new { answer = ans, price = GetMovePrice(ans), rep = RepetitionsNumber(ans)}).
                OrderBy(ans => ans.price).ThenByDescending(ans => ans.rep).
                First().answer;

            return answer;
        }

        public int RepetitionsNumber(string str)
        {
            var tempCharArr = str.ToCharArray().Distinct().ToArray();

            var count = new string(tempCharArr).Length;
            return count;
        }
    }
}
