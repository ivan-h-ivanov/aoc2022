using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode2022
{
    internal static class Day6
    {
        internal static int Star1()
        {
            return FinfNonRep(4);
        }

        internal static int Star2()
        {
            return FinfNonRep(14);
        }

        private static int FinfNonRep(int length)
        {
            var line = File.ReadAllLines("input/input6_1.txt")[0];
            Dictionary<char, int> d = new Dictionary<char, int>();
            int start = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (i - start == length)
                {
                    break;
                }
                var ch = line[i];

                if (d.TryGetValue(ch, out int k) && k >= start)
                {
                    start = k + 1;
                }
                d[ch] = i;
            }
            return start + length;
        }
    }
}
