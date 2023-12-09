using AdventOfCode;
using AdventOfCode2023.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Year2023.Day9
{
    public class Solution : SolutionBase
    {
        static List<int> ConvertList(List<int> inputList)
        {
            var outputList = new List<int>();

            for (int i = 1; i < inputList.Count; i++)
            {
                int newValue = inputList[i] - inputList[i - 1];
                outputList.Add(newValue);
            }

            return outputList;
        }

        public override string Part1Solver()
        {
            var lines = Input.SplitByNewline();
            var histories = lines.Select(line => line.Split(" ").Select(int.Parse).ToList()).ToList();
            var sequencesOfHistory = new List<List<List<int>>>();
            foreach (var history in histories)
            {
                var temp = history;
                var sequence = new List<List<int>>();
                sequence.Add(temp);
                while (!temp.All(t => t == 0))
                {
                    temp = ConvertList(temp);
                    sequence.Add(temp);
                }
                sequencesOfHistory.Add(sequence);

            }

            var result = sequencesOfHistory.Select(x => x.Select(y => y.Last()).Sum()).Sum();

            return result.ToString();
        }

        static int ProcessList(List<int> inputList)
        {
            var result = 0;

            for (int i = 0; i < inputList.Count - 1; i++)
            {
                if (i % 2 == 0)
                {
                    result += inputList[i];
                }
                else
                {
                    result -= inputList[i];
                }
            }

            return result;
        }


        public override string Part2Solver()
        {
            var lines = Input.SplitByNewline();
            var histories = lines.Select(line => line.Split(" ").Select(int.Parse).ToList()).ToList();
            var sequencesOfHistory = new List<List<List<int>>>();
            foreach (var history in histories)
            {
                var temp = history;
                var sequence = new List<List<int>>();
                sequence.Add(temp);
                while (!temp.All(t => t == 0))
                {
                    temp = ConvertList(temp);
                    sequence.Add(temp);
                }
                sequencesOfHistory.Add(sequence);

            }

            var result = sequencesOfHistory.Select(x => ProcessList(x.Select(y => y.First()).ToList())).Sum();

            return result.ToString();
        }
    }    
}
