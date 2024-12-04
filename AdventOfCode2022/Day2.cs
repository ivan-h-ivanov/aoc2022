using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2022
{
    internal static class Day2
    {
        private static Dictionary<string, int> res1 = new Dictionary<string, int>()
        {
            { "A X", 4 }, { "A Y", 8 }, { "A Z", 3 },
            { "B X", 1 }, { "B Y", 5 }, { "B Z", 9 },
            { "C X", 7 }, { "C Y", 2 }, { "C Z", 6 }
        };

        private static Dictionary<string, int> res2 = new Dictionary<string, int>()
        {
            { "A X", 3 }, { "A Y", 4 }, { "A Z", 8 },
            { "B X", 1 }, { "B Y", 5 }, { "B Z", 9 },
            { "C X", 2 }, { "C Y", 6 }, { "C Z", 7 }
        };

        internal static int Star1()
        {
           return File.ReadAllLines("input/input2_1.txt").Select(s => res1[s]).Sum();
        }

        internal static int Star2()
        {
            return File.ReadAllLines("input/input2_1.txt").Select(s => res2[s]).Sum();
        }
    }
}
