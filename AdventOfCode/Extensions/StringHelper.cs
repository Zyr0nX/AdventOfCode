using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.StringExtensions
{
    public static class StringHelper
    {
        private static readonly string[] separator = ["\r", "\n", "\r\n"];

        public static string[] SplitByNewline(this string str) => str
        .Split(separator, StringSplitOptions.None)
        .Where(s => !string.IsNullOrWhiteSpace(s))
        .ToArray();

    }
}
