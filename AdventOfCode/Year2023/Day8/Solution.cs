using AdventOfCode;
using AdventOfCode2023.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Year2023.Day8
{
    public class Solution : SolutionBase
    {
        public class NodeMap
        {
            public string Left { get; set; }
            public string Right { get; set; }
        }

        static long GCF(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static long LCM(long a, long b)
        {
            return (a / GCF(a, b)) * b;
        }

        static long FindLCM(params long[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException("At least two numbers are required.");
            }

            long lcm = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                lcm = LCM(lcm, numbers[i]);
            }

            return lcm;
        }



        public override string Part1Solver()
        {
            //var lines = Input.SplitByNewline();
            //var instructions = lines[0];
            //var network = lines.Skip(1);
            //var networkDic = new Dictionary<string, NodeMap>();
            //foreach (var item in network)
            //{
            //    var node = item.Split(" ")[0].Trim();
            //    var map = item.Split(" = (")[1].Trim().Replace(")", "").Split(",").Select(x => x.Trim()).ToArray();

            //    var nodeMap = new NodeMap()
            //    {
            //        Left = map[0],
            //        Right = map[1],
            //    };

            //    networkDic.Add(node, nodeMap);
            //}

            //var currentElement = "AAA";
            //var numberOfMove = 0;
            //while (true)
            //{
            //    foreach (var instruction in instructions)
            //    {
            //        if (instruction == 'L')
            //        {
            //            currentElement = networkDic[currentElement].Left;
            //        }
            //        if (instruction == 'R')
            //        {
            //            currentElement = networkDic[currentElement].Right;
            //        }
            //        numberOfMove++;
            //        if (currentElement == "ZZZ") break;
                    
            //    }
            //    if (currentElement == "ZZZ") break;
            //}
            return "";
        }

        public override string Part2Solver()
        {
            var lines = Input.SplitByNewline();
            var instructions = lines[0];
            var network = lines.Skip(1);
            var networkDic = new Dictionary<string, NodeMap>();
            foreach (var item in network)
            {
                var node = item.Split(" ")[0].Trim();
                var map = item.Split(" = (")[1].Trim().Replace(")", "").Split(",").Select(x => x.Trim()).ToArray();

                var nodeMap = new NodeMap()
                {
                    Left = map[0],
                    Right = map[1],
                };

                networkDic.Add(node, nodeMap);
            }

            var startingElement = networkDic.Where(x => x.Key.EndsWith('A')).Select(x => x.Key).ToList();
            

            var numberOfMoves = new List<long>();

            foreach (var element in startingElement)
            {
                long numberOfMove = 0;
                var currentElement = element;
                while (true)
                {
                    foreach (var instruction in instructions)
                    {
                        if (instruction == 'L')
                        {
                            currentElement = networkDic[currentElement].Left;
                        }
                        if (instruction == 'R')
                        {
                            currentElement = networkDic[currentElement].Right;
                        }
                        numberOfMove++;
                        if (currentElement.EndsWith('Z')) break;
                    }
                    if (currentElement.EndsWith('Z'))
                    {
                        numberOfMoves.Add(numberOfMove);
                        break;
                    }
                }
            };
            
            return FindLCM(numberOfMoves.ToArray()).ToString();
        }
    }
}
