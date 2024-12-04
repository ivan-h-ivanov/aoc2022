using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2022
{
    internal static class Day4
    {
        internal static int Star1()
        {
            var lines = File.ReadAllLines("input/input4_1.txt");
            int count = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                var ranges = lines[i].Split('-', ',').Select(n => int.Parse(n)).ToArray();
                if (ranges[0] <= ranges[2] && ranges[1] >= ranges[3] || ranges[0] >= ranges[2] && ranges[1] <= ranges[3])
                {
                    count++;
                }
            }
            return count;
        }

        internal static int Star2()
        {
            var lines = File.ReadAllLines("input/input4_1.txt");
            int count = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                var ranges = lines[i].Split('-', ',').Select(n => int.Parse(n)).ToArray();
                if (ranges[0] <= ranges[2] && ranges[2] <= ranges[1] || ranges[0] >= ranges[2] && ranges[0] <= ranges[3])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
