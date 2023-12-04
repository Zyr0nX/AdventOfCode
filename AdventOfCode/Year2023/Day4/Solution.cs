using AdventOfCode;
using AdventOfCode2023.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Year2023.Day4
{
    public class Solution : SolutionBase
    {
        public override string Part1Solver()
        {
            var lines = Input.SplitByNewline();

            var result = 0;

            foreach (var line in lines)
            {
                var card = line.Split(":")[1].Trim();

                var listOfWinningNumbers = card.Split("|")[0].Trim().Split(" ").Where(n => !string.IsNullOrWhiteSpace(n)).Select(int.Parse);
                var listOfNumberYouHave = card.Split("|")[1].Trim().Split(" ").Where(n => !string.IsNullOrWhiteSpace(n)).Select(int.Parse);

                var numberOfWinningNumbers = 0;

                foreach (var number in listOfNumberYouHave)
                {
                    if (listOfWinningNumbers.Contains(number))
                    {
                        numberOfWinningNumbers++;
                    }
                }

                result += (int)Math.Pow(2, numberOfWinningNumbers - 1);
            }

            return result.ToString();
        }

        public override string Part2Solver()
        {
            var lines = Input.SplitByNewline();

            var dictionaryOfNumberOfScratchCards = new Dictionary<int, int>();

            for (var i = 0; i < lines.Length; i++)
            {
                dictionaryOfNumberOfScratchCards.Add(i, 1);
            }

            var cardIndex = 0;

            foreach (var line in lines)
            {

                var card = line.Split(":")[1].Trim();

                var listOfWinningNumbers = card.Split("|")[0].Trim().Split(" ").Where(n => !string.IsNullOrWhiteSpace(n)).Select(int.Parse);
                var listOfNumberYouHave = card.Split("|")[1].Trim().Split(" ").Where(n => !string.IsNullOrWhiteSpace(n)).Select(int.Parse);

                var winningIndex = 0;

                foreach (var number in listOfNumberYouHave)
                {
                    var numberOfRepeat = dictionaryOfNumberOfScratchCards[cardIndex];
                    for (global::System.Int32 i = 0; i < numberOfRepeat; i++)
                    {
                        
                        if (listOfWinningNumbers.Contains(number))
                        {
                            dictionaryOfNumberOfScratchCards[cardIndex + 1 + winningIndex] += 1;
                        }
                    }

                    if (listOfWinningNumbers.Contains(number))
                    {
                        winningIndex++;
                    }

                }
                cardIndex++;
                winningIndex = 0;
            }

            var result = dictionaryOfNumberOfScratchCards.Values.Sum();

            return result.ToString();
        }
    }
}
