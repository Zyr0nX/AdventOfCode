using AdventOfCode;
using AdventOfCode2023.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Year2023.Day3
{
    public class Solution : SolutionBase
    {
        static int[] dx = [1, 1, 0, -1, -1, -1, 0, 1];
        static int[] dy = [0, 1, 1, 1, 0, -1, -1, -1];
        public override string Part1Solver()
        {
            var lines = Input.SplitByNewline();
            char[][] matrix = new char[lines.Length][];
            var lineIndex = 0;
            var starRegex = new Regex("[*]");
            foreach (var line in lines)
            {
                var characterIndex = 0;
                foreach (var item in line)
                {
                    if (matrix[lineIndex] is null)
                    {
                        matrix[lineIndex] = new char[line.Length];
                    }
                    matrix[lineIndex][characterIndex] = item;
                    characterIndex++;
                };
                lineIndex++;
            }

            var matrixLineIndex = 0;

            var finalList = new List<int>();

            foreach (var line in matrix)
            {
                var matrixCharacterIndex = 0;
                var charNumberIndex = new List<int>();
                foreach (var item in line)
                {
                    var isTheEndOfCharNumber = true;
                    
                    
                    if (char.IsDigit(item))
                    {
                        isTheEndOfCharNumber = matrixCharacterIndex == line.Length - 1;
                        charNumberIndex.Add(matrixCharacterIndex);
                        matrixCharacterIndex++;
                        if (!isTheEndOfCharNumber) continue;

                    }

                    if (isTheEndOfCharNumber && charNumberIndex.Any())
                    {
                        var isAddToFinalList = true;
                        foreach (var index in charNumberIndex)
                        {
                            for (var i = 0; i < 8; i++)
                            {
                                var xIndex = matrixLineIndex + dx[i] < 0 ? 0 : matrixLineIndex + dx[i] > line.Length - 1 ? line.Length - 1 : matrixLineIndex + dx[i];
                                var yIndex = index + dy[i] < 0 ? 0 : index + dy[i] > matrix.Length - 1 ? matrix.Length - 1 : index + dy[i];
                                if (starRegex.IsMatch(matrix[xIndex][yIndex].ToString()))
                                {
                                    var xAroundStarIndex = xIndex + dx[i] < 0 ? 0 : xIndex + dx[i] > line.Length - 1 ? line.Length - 1 : xIndex + dx[i];
                                    var yAroundStarIndex = yIndex + dy[i] < 0 ? 0 : yIndex + dy[i] > matrix.Length - 1 ? matrix.Length - 1 : yIndex + dy[i];
                                }
                            }
                            if (!isAddToFinalList)
                            {
                                break;
                            }
                        }

                        if (!isAddToFinalList)
                        {
                            var numberStr = "";
                            foreach (var index in charNumberIndex)
                            {
                                numberStr += line[index].ToString();
                            }
                            finalList.Add(int.Parse(numberStr));
                        }
                        charNumberIndex = new();
                    }
                    matrixCharacterIndex++;
                }
                matrixLineIndex++;
            }
            return finalList.Sum().ToString();
        }

        public override string Part2Solver()
        {
            var lines = Input.SplitByNewline();
            char[][] matrix = new char[lines.Length][];
            var lineIndex = 0;
            var notNumberOrDotRegex = new Regex("[^0-9.]");
            foreach (var line in lines)
            {
                var characterIndex = 0;
                foreach (var item in line)
                {
                    if (matrix[lineIndex] is null)
                    {
                        matrix[lineIndex] = new char[line.Length];
                    }
                    matrix[lineIndex][characterIndex] = item;
                    characterIndex++;
                };
                lineIndex++;
            }

            var matrixLineIndex = 0;

            var finalList = new List<List<int>>();

            foreach (var line in matrix)
            {
                var matrixCharacterIndex = 0;
                var charNumberIndex = new List<int>();
                foreach (var item in line)
                {
                    if (item == '*')
                    {
                        finalList.Add(PartFinder(matrixLineIndex, matrixCharacterIndex, matrix));
                        //for (var i = 0; i < 8; i++)
                        //{
                        //    var xIndex = matrixLineIndex + dx[i] < 0 ? 0 : matrixLineIndex + dx[i] > line.Length - 1 ? line.Length - 1 : matrixLineIndex + dx[i];
                        //    var yIndex = matrixCharacterIndex + dy[i] < 0 ? 0 : matrixCharacterIndex + dy[i] > matrix.Length - 1 ? matrix.Length - 1 : matrixCharacterIndex + dy[i];
                        //    if (char.IsDigit(matrix[xIndex][yIndex]))
                        //    {
                        //        finalList.Add(PartFinder(xIndex, yIndex, matrix));
                        //    }
                        //}
                    }
                    matrixCharacterIndex++;
                }
                matrixLineIndex++;
            }
            return finalList.Where(x => x.Count == 2).Select(x => x.Aggregate((a,b) => a*b)).Sum().ToString();
        }

        private List<int> PartFinder(int x, int y, char[][] matrix)
        {
            var parts = new List<int>();
            for (var i = 0; i < 8; i++)
            {
                var xIndex = x + dx[i] < 0 ? 0 : x + dx[i] > matrix.First().Length - 1 ? matrix.First().Length - 1 : x + dx[i];
                var yIndex = y + dy[i] < 0 ? 0 : y + dy[i] > matrix.Length - 1 ? matrix.Length - 1 : y + dy[i]; ;
                var j = 0;
                var numberCharList = new List<char>();
                var samelineSeparate = false;
                var moreLeft = true;
                var moreRight = true;
                if (char.IsDigit(matrix[xIndex][yIndex])) numberCharList.Add(matrix[xIndex][yIndex]);
                else if (dx[i] == 0) 
                    continue;

                if (dx[i] == 1) moreLeft = false;
                if (dx[i] == -1) moreRight = false;


                while (true)
                {
                    j++;
                    if ((yIndex + j >= matrix.Length || !char.IsDigit(matrix[xIndex][yIndex + j]) || !moreRight) && (yIndex - j < 0 || !char.IsDigit(matrix[xIndex][yIndex - j]) || !moreLeft)) break;

                    if (yIndex + j < matrix.Length)
                    {
                        if (moreRight && char.IsDigit(matrix[xIndex][yIndex + j]))
                        {
                            numberCharList.Add(matrix[xIndex][yIndex + j]);
                            
                        }
                        else
                        {
                            moreRight = false;
                        }    
                    }
                    if (yIndex - j >= 0)
                    {
                        if (moreLeft && char.IsDigit(matrix[xIndex][yIndex - j]))
                        {
                            numberCharList.Insert(0, matrix[xIndex][yIndex - j]);
                        }
                        else
                        {
                            moreLeft = false;
                        }
                    }
                }
                if (numberCharList.Any())
                {
                    parts.Add(int.Parse(new string(numberCharList.ToArray())));
                }
            }
            return parts.Distinct().ToList();
        }
    }
}
