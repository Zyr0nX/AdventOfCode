using AdventOfCode2023.StringExtensions;
using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day1;

public class Solution : SolutionBase
{
    public override string Part1Solver()
    {
        var values = Input.SplitByNewline();
        var listNumber = new List<int>();
        foreach (var value in values)
        {
            char firstDigit = new();
            char lastDigit = new();
            foreach (char character in value)
            {
                if (char.IsDigit(character))
                {
                    firstDigit = character;
                    break;
                }
            }
            foreach (char character in value.Reverse())
            {
                if (char.IsDigit(character))
                {
                    lastDigit = character;
                    break;
                }
            }

            var numberStr = firstDigit.ToString() + lastDigit.ToString();
            listNumber.Add(int.Parse(numberStr));
        }
        return listNumber.Sum().ToString();
    }

    public override string Part2Solver()
    {
        var numberDictionary = new Dictionary<string, int>() {
            {"one", 1}, {"two", 2}, {"three", 3 },
            {"four", 4}, {"five", 5}, {"six", 6 },
            {"seven", 7}, {"eight", 8}, {"nine", 9 }
        };
        var values = Input.SplitByNewline();
        List<int> listNumber = new();
        foreach (var value in values)
        {
            
            List<int> listNumberInValue = new();
            for (var i = 0; i < value.Length; i++)
            {
                if (char.IsDigit(value[i]))
                {
                    listNumberInValue.Add(int.Parse(value[i].ToString()));
                    continue;
                }
                for (var j = i; j < value.Length; j++)
                {
                    if (numberDictionary.TryGetValue(value.Substring(i, j - i + 1), out var number))
                    {
                        listNumberInValue.Add(number);
                        break;
                    }
                }
            }

            int firstDigit = listNumberInValue.First();
            int lastDigit = listNumberInValue.Last();

            var numberStr = firstDigit.ToString() + lastDigit.ToString();
            listNumber.Add(int.Parse(numberStr));
        }
        return listNumber.Sum().ToString();
    }
}