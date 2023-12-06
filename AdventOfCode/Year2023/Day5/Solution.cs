using AdventOfCode;
using AdventOfCode2023.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Year2023.Day5
{
    public class Solution : SolutionBase
    {
        public override string Part1Solver()
        {
            var lines = Input.SplitByNewline().ToList();
            var seeds = lines[0].Split(":")[1].Trim().Split(" ").Select(long.Parse);

            var seedToSoilMapRaw = lines.GetRange(lines.IndexOf("seed-to-soil map:") + 1, lines.IndexOf("soil-to-fertilizer map:") - lines.IndexOf("seed-to-soil map:") - 1);
            var soilToFertilizerMapRaw = lines.GetRange(lines.IndexOf("soil-to-fertilizer map:") + 1, lines.IndexOf("fertilizer-to-water map:") - lines.IndexOf("soil-to-fertilizer map:") - 1);
            var fertilizerToWaterMapRaw = lines.GetRange(lines.IndexOf("fertilizer-to-water map:") + 1, lines.IndexOf("water-to-light map:") - lines.IndexOf("fertilizer-to-water map:") - 1);
            var waterToLightMapRaw = lines.GetRange(lines.IndexOf("water-to-light map:") + 1, lines.IndexOf("light-to-temperature map:") - lines.IndexOf("water-to-light map:") - 1);
            var lightToTemperatureMapRaw = lines.GetRange(lines.IndexOf("light-to-temperature map:") + 1, lines.IndexOf("temperature-to-humidity map:") - lines.IndexOf("light-to-temperature map:") - 1);
            var temperatureToHumidityMapRaw = lines.GetRange(lines.IndexOf("temperature-to-humidity map:") + 1, lines.IndexOf("humidity-to-location map:") - lines.IndexOf("temperature-to-humidity map:") - 1);
            var humidityToLocationMapRaw = lines.GetRange(lines.IndexOf("humidity-to-location map:") + 1, lines.Count - lines.IndexOf("humidity-to-location map:") - 1);
            var locationList = new List<long>();

            foreach (var seed in seeds)
            {
                var temp = seed;
                foreach (var line in seedToSoilMapRaw)
                {
                    var destinationRangeStart = long.Parse(line.Split(" ")[0]);
                    var sourceRangeStart = long.Parse(line.Split(" ")[1]);
                    var rangeLength = long.Parse(line.Split(" ")[2]);
                    if (temp >= sourceRangeStart && temp <= sourceRangeStart + rangeLength - 1)
                    {
                        temp = destinationRangeStart + temp - sourceRangeStart;
                        break;
                    }
                }

                foreach (var line in soilToFertilizerMapRaw)
                {
                    var destinationRangeStart = long.Parse(line.Split(" ")[0]);
                    var sourceRangeStart = long.Parse(line.Split(" ")[1]);
                    var rangeLength = long.Parse(line.Split(" ")[2]);
                    if (temp >= sourceRangeStart && temp <= sourceRangeStart + rangeLength - 1)
                    {
                        temp = destinationRangeStart + temp - sourceRangeStart;
                        break;
                    }
                }
                foreach (var line in fertilizerToWaterMapRaw)
                {
                    var destinationRangeStart = long.Parse(line.Split(" ")[0]);
                    var sourceRangeStart = long.Parse(line.Split(" ")[1]);
                    var rangeLength = long.Parse(line.Split(" ")[2]);
                    if (temp >= sourceRangeStart && temp <= sourceRangeStart + rangeLength - 1)
                    {
                        temp = destinationRangeStart + temp - sourceRangeStart;
                        break;
                    }
                }
                foreach (var line in waterToLightMapRaw)
                {
                    var destinationRangeStart = long.Parse(line.Split(" ")[0]);
                    var sourceRangeStart = long.Parse(line.Split(" ")[1]);
                    var rangeLength = long.Parse(line.Split(" ")[2]);
                    if (temp >= sourceRangeStart && temp <= sourceRangeStart + rangeLength - 1)
                    {
                        temp = destinationRangeStart + temp - sourceRangeStart;
                        break;
                    }
                }
                foreach (var line in lightToTemperatureMapRaw)
                {
                    var destinationRangeStart = long.Parse(line.Split(" ")[0]);
                    var sourceRangeStart = long.Parse(line.Split(" ")[1]);
                    var rangeLength = long.Parse(line.Split(" ")[2]);
                    if (temp >= sourceRangeStart && temp <= sourceRangeStart + rangeLength - 1)
                    {
                        temp = destinationRangeStart + temp - sourceRangeStart;
                        break;
                    }
                }
                foreach (var line in temperatureToHumidityMapRaw)
                {
                    var destinationRangeStart = long.Parse(line.Split(" ")[0]);
                    var sourceRangeStart = long.Parse(line.Split(" ")[1]);
                    var rangeLength = long.Parse(line.Split(" ")[2]);
                    if (temp >= sourceRangeStart && temp <= sourceRangeStart + rangeLength - 1)
                    {
                        temp = destinationRangeStart + temp - sourceRangeStart;
                        break;
                    }
                }
                foreach (var line in humidityToLocationMapRaw)
                {
                    var destinationRangeStart = long.Parse(line.Split(" ")[0]);
                    var sourceRangeStart = long.Parse(line.Split(" ")[1]);
                    var rangeLength = long.Parse(line.Split(" ")[2]);
                    if (temp >= sourceRangeStart && temp <= sourceRangeStart + rangeLength - 1)
                    {
                        temp = destinationRangeStart + temp - sourceRangeStart;
                        break;
                    }
                }
                locationList.Add(temp);
            }

            return locationList.Min().ToString();
        }

        public override string Part2Solver()
        {
            var lines = Input.SplitByNewline().ToList();
            var pairsOfSeeds = lines[0]
                .Split(":")[1]
                .Trim()
                .Split(" ")
                .Select(long.Parse)
                .Select((value, index) => new { Value = value, Index = index })
                .GroupBy(x => x.Index / 2)
                .Select(group => (group.ElementAt(0).Value, group.ElementAtOrDefault(1)?.Value));

            var seedToSoilMapRaw = lines.GetRange(lines.IndexOf("seed-to-soil map:") + 1, lines.IndexOf("soil-to-fertilizer map:") - lines.IndexOf("seed-to-soil map:") - 1).Select(line => line.Split(" ").Select(long.Parse).ToArray());
            var soilToFertilizerMapRaw = lines.GetRange(lines.IndexOf("soil-to-fertilizer map:") + 1, lines.IndexOf("fertilizer-to-water map:") - lines.IndexOf("soil-to-fertilizer map:") - 1);
            var fertilizerToWaterMapRaw = lines.GetRange(lines.IndexOf("fertilizer-to-water map:") + 1, lines.IndexOf("water-to-light map:") - lines.IndexOf("fertilizer-to-water map:") - 1);
            var waterToLightMapRaw = lines.GetRange(lines.IndexOf("water-to-light map:") + 1, lines.IndexOf("light-to-temperature map:") - lines.IndexOf("water-to-light map:") - 1);
            var lightToTemperatureMapRaw = lines.GetRange(lines.IndexOf("light-to-temperature map:") + 1, lines.IndexOf("temperature-to-humidity map:") - lines.IndexOf("light-to-temperature map:") - 1);
            var temperatureToHumidityMapRaw = lines.GetRange(lines.IndexOf("temperature-to-humidity map:") + 1, lines.IndexOf("humidity-to-location map:") - lines.IndexOf("temperature-to-humidity map:") - 1);
            var humidityToLocationMapRaw = lines.GetRange(lines.IndexOf("humidity-to-location map:") + 1, lines.Count - lines.IndexOf("humidity-to-location map:") - 1);

            var listMin = new List<long>();
            Parallel.ForEach(pairsOfSeeds, pair =>
            {
                long minLocationOfPair = long.MaxValue;
                for (int i = 0; i < pair.Item2; i++)
                {
                    var temp = pair.Item1 + i;
                    foreach (var line in seedToSoilMapRaw)
                    {
                        var destinationRangeStart = line[0];
                        var sourceRangeStart = line[1];
                        var rangeLength = line[2];
                        if (temp >= sourceRangeStart && temp <= sourceRangeStart + rangeLength - 1)
                        {
                            temp = destinationRangeStart + temp - sourceRangeStart;
                            break;
                        }
                    }

                    foreach (var line in soilToFertilizerMapRaw)
                    {
                        var destinationRangeStart = line[0];
                        var sourceRangeStart = line[1];
                        var rangeLength = line[2];
                        if (temp >= sourceRangeStart && temp <= sourceRangeStart + rangeLength - 1)
                        {
                            temp = destinationRangeStart + temp - sourceRangeStart;
                            break;
                        }
                    }
                    foreach (var line in fertilizerToWaterMapRaw)
                    {
                        var destinationRangeStart = line[0];
                        var sourceRangeStart = line[1];
                        var rangeLength = line[2];
                        if (temp >= sourceRangeStart && temp <= sourceRangeStart + rangeLength - 1)
                        {
                            temp = destinationRangeStart + temp - sourceRangeStart;
                            break;
                        }
                    }
                    foreach (var line in waterToLightMapRaw)
                    {
                        var destinationRangeStart = line[0];
                        var sourceRangeStart = line[1];
                        var rangeLength = line[2];
                        if (temp >= sourceRangeStart && temp <= sourceRangeStart + rangeLength - 1)
                        {
                            temp = destinationRangeStart + temp - sourceRangeStart;
                            break;
                        }
                    }
                    foreach (var line in lightToTemperatureMapRaw)
                    {
                        var destinationRangeStart = line[0];
                        var sourceRangeStart = line[1];
                        var rangeLength = line[2];
                        if (temp >= sourceRangeStart && temp <= sourceRangeStart + rangeLength - 1)
                        {
                            temp = destinationRangeStart + temp - sourceRangeStart;
                            break;
                        }
                    }
                    foreach (var line in temperatureToHumidityMapRaw)
                    {
                        var destinationRangeStart = line[0];
                        var sourceRangeStart = line[1];
                        var rangeLength = line[2];
                        if (temp >= sourceRangeStart && temp <= sourceRangeStart + rangeLength - 1)
                        {
                            temp = destinationRangeStart + temp - sourceRangeStart;
                            break;
                        }
                    }
                    foreach (var line in humidityToLocationMapRaw)
                    {
                        var destinationRangeStart = line[0];
                        var sourceRangeStart = line[1];
                        var rangeLength = line[2];
                        if (temp >= sourceRangeStart && temp <= sourceRangeStart + rangeLength - 1)
                        {
                            temp = destinationRangeStart + temp - sourceRangeStart;
                            break;
                        }
                    }

                    if (minLocationOfPair > temp)
                    {
                        minLocationOfPair = temp;
                    }
                }
                listMin.Add(minLocationOfPair);
            });

            return listMin.Min().ToString();
        }
    }
}
