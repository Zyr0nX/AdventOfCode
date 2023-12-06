using AdventOfCode;
using AdventOfCode2023.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Year2023.Day6
{
    public class Race
    {
        public long Time { get; set; }
        public long Distance { get; set; }
    }

    public class Solution : SolutionBase
    {
        public override string Part1Solver()
        {
            var lines = Input.SplitByNewline();

            var times = lines[0].Split(":")[1].Trim().Split(" ").Where(l => !string.IsNullOrWhiteSpace(l)).Select(int.Parse).ToArray();
            var distances = lines[1].Split(":")[1].Trim().Split(" ").Where(l => !string.IsNullOrWhiteSpace(l)).Select(int.Parse).ToArray();

            var races = new List<Race>();
            for (int i = 0; i < times.Count(); i++)
            {
                races.Add(new Race
                {
                    Time = times[i],
                    Distance = distances[i]
                });
            }

            var results = new List<int>();

            foreach (var race in races)
            {
                var numberOfWaysToWin = 0;
                for (global::System.Int32 durationHold = 1; durationHold < race.Time; durationHold++)
                {
                    var durationTravel = race.Time - durationHold;
                    var distanceTravel = durationTravel * durationHold;

                    if (distanceTravel > race.Distance)
                    {
                        numberOfWaysToWin++;
                    }
                }
                results.Add(numberOfWaysToWin);
            }

            return results.Aggregate((a, b) => a * b).ToString();
        }

        public override string Part2Solver()
        {
            var lines = Input.SplitByNewline();

            var time = long.Parse(string.Join("", lines[0].Split(":")[1].Trim().Split(" ").Where(l => !string.IsNullOrWhiteSpace(l))));
            var distance = long.Parse(string.Join("", lines[1].Split(":")[1].Trim().Split(" ").Where(l => !string.IsNullOrWhiteSpace(l))));

            var race  = new Race
            { Time = time, Distance = distance };

            var bound = 0;
            for (int durationHold = 4; durationHold <= race.Time / 2; durationHold++)
            {
                var durationTravel = race.Time - durationHold;
                var distanceTravel = durationTravel * durationHold;

                if (distanceTravel > race.Distance)
                {
                    bound = durationHold;
                    break;
                }
            }

            return (race.Time - 2 * bound + 1).ToString();
        }
    }
}
