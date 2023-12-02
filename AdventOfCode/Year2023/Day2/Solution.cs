using AdventOfCode;
using AdventOfCode2023.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day2
{
    internal class Solution : SolutionBase
    {
        public override string Part1Solver()
        {
            var lines = Input.SplitByNewline();
            var ids = lines.Select(i => i.Split(":")[0]).Select(i => i.Split(" ")[1]);
            var configuration = lines.Select(i => i.Split(":")[1]);

            var stringAfterColon = lines.Select(i => i.Split(":")[1].Trim());
            var splitStringAfterColon = stringAfterColon.Select(i => i.Split(";").Select(j => j.Trim()));


            var possibleGames = new List<int>();

            var index = 0;

            foreach(var line in splitStringAfterColon)
            {
                index++;
                var impossible = false;
                foreach (var item in line)
                {
                    
                    var x = item.Split(",").Select(j => j.Trim());
                    foreach (var item1 in x)
                    {
                        if (item1.Contains("green") && int.Parse(item1.Split(" ")[0]) > 13)
                        {
                            impossible = true;
                            break;
                        }

                        if (item1.Contains("red") && int.Parse(item1.Split(" ")[0]) > 12)
                        {
                            impossible = true;
                            break;
                        }

                        if (item1.Contains("blue") && int.Parse(item1.Split(" ")[0]) > 14)
                        {
                            impossible = true;
                            break;
                        }
                    }
                }
                if (!impossible) possibleGames.Add(index);

            }


            return possibleGames.Sum().ToString();
        }

        public override string Part2Solver()
        {
            var lines = Input.SplitByNewline();
            var ids = lines.Select(i => i.Split(":")[0]).Select(i => i.Split(" ")[1]);
            var configuration = lines.Select(i => i.Split(":")[1]);

            var stringAfterColon = lines.Select(i => i.Split(":")[1].Trim());
            var splitStringAfterColon = stringAfterColon.Select(i => i.Split(";").Select(j => j.Trim()));


            var powerOfSets = new List<int>();

            var index = 0;

            foreach (var line in splitStringAfterColon)
            {
                index++;
                var highestRed = 0;
                var highestGreen = 0;
                var highestBlue = 0;
                foreach (var item in line)
                {
                    var x = item.Split(",").Select(j => j.Trim());
                    foreach (var item1 in x)
                    {
                        if (item1.Contains("green") && int.Parse(item1.Split(" ")[0]) > highestGreen)
                        {
                            highestGreen = int.Parse(item1.Split(" ")[0]);
                        }

                        if (item1.Contains("red") && int.Parse(item1.Split(" ")[0]) > highestRed)
                        {
                            highestRed = int.Parse(item1.Split(" ")[0]);
                        }

                        if (item1.Contains("blue") && int.Parse(item1.Split(" ")[0]) > highestBlue)
                        {
                            highestBlue = int.Parse(item1.Split(" ")[0]);
                        }
                    }
                }
                powerOfSets.Add(highestRed * highestGreen * highestBlue);
            }


            return powerOfSets.Sum().ToString();
        }
    }
}
