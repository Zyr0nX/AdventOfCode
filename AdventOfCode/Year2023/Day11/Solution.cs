using AdventOfCode;
using AdventOfCode2023.StringExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Year2023.Day11
{
    internal class Solution : SolutionBase
    {
        public override string Part1Solver()
        {
            var lines = Input.SplitByNewline();
            var dic = new Dictionary<int, int[]>();
            var startIndex = 0;
            var matrix = new List<List<char>>();

            foreach (var line in lines)
            {
                matrix.Add([.. line.ToCharArray()]);
            }

            for (int y = 0; y < matrix.Count; y++)
            {
                if (matrix[y].All(x => x == '.'))
                {
                    matrix.Insert(y, new string('.', matrix[y].Count).ToList());
                    y++;
                }
            }

            for (global::System.Int32 x = 0; x < matrix[0].Count; x++)
            {
                var yList = new List<char>();
                for (int y = 0; y < matrix.Count; y++)
                {
                    yList.Add(matrix[y][x]);
                }

                if (yList.All(y => y == '.'))
                {
                    for (int y1 = 0; y1 < matrix.Count; y1++)
                    {
                        matrix[y1].Insert(x, '.');
                    }
                    x++;
                }
            }

            for (int y = 0; y < matrix.Count; y++)
            {
                for (int x = 0; x < matrix[y].Count; x++)
                {
                    if (matrix[y][x] == '#')
                    {
                        dic.Add(startIndex, [x, y]);
                        startIndex++;
                    }
                }
            }

            var result = 0;

            for (int i = 0; i < dic.Count; i++)
            {
                for (int j = i + 1; j < dic.Count; j++)
                {
                    result += Math.Abs(dic[i][0] - dic[j][0]) + Math.Abs(dic[i][1] - dic[j][1]);
                }
            }

            return result.ToString();
        }

        public override string Part2Solver()
        {
            var lines = Input.SplitByNewline();
            var dic = new Dictionary<int, int[]>();
            var startIndex = 0;
            var matrix = new List<List<char>>();

            foreach (var line in lines)
            {
                matrix.Add([.. line.ToCharArray()]);
            }

            for (int y = 0; y < matrix.Count; y++)
            {
                for (int x = 0; x < matrix[y].Count; x++)
                {
                    if (matrix[y][x] == '#')
                    {
                        dic.Add(startIndex, [x, y]);
                        startIndex++;
                    }
                }
            }

            long result = 0;

            for (int i = 0; i < dic.Count; i++)
            {
                for (int j = i + 1; j < dic.Count; j++)
                {
                    if (dic[i][0] < dic[j][0])
                    {
                        for (global::System.Int32 kx = dic[i][0] + 1; kx <= dic[j][0]; kx++)
                        {
                            var yList = new List<char>();

                            for (int y = 0; y < matrix.Count; y++)
                            {
                                yList.Add(matrix[y][kx]);
                            }

                            if (yList.All(y => y == '.'))
                            {
                                result += 1000000;
                            }
                            else
                            {
                                result++;
                            }
                        }
                    }
                    else
                    {
                        for (global::System.Int32 kx = dic[i][0] - 1; kx >= dic[j][0]; kx--)
                        {
                            var yList = new List<char>();

                            for (int y = 0; y < matrix.Count; y++)
                            {
                                yList.Add(matrix[y][kx]);
                            }

                            if (yList.All(y => y == '.'))
                            {
                                result += 1000000;
                            }
                            else
                            {
                                result++;
                            }
                        }
                    }

                    for (int ky = dic[i][1] + 1; ky <= dic[j][1]; ky++)
                    {
                        if (matrix[ky].All(x => x != '#'))
                        {
                            result += 1000000;
                        }
                        else
                        {
                            result++;
                        }
                        
                    }

                }
            }

            return result.ToString();
        }
    }
}
