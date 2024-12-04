using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2022
{
    internal static class Day3
    {
        internal static int Star1()
        {
            var lines = File.ReadAllLines("input/input3_1.txt");
            int count = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                count = Calc1(lines, count, i);
            }
            return count;
        }

        private static int Calc1(string[] lines, int count, int i)
        {
            char ch;
            for (int j = 0; j < lines[i].Length / 2; j++)
            {
                for (int k = lines[i].Length / 2; k < lines[i].Length; k++)
                {
                    ch = lines[i][j];
                    if (ch == lines[i][k])
                    {
                        if (ch < 96)
                        {
                            count += ch - 38;
                        }
                        else
                        {
                            count += ch - 96;
                        }
                        return count;
                    }
                }
            }

            return count;
        }

        internal static int Star2()
        {
            var lines = File.ReadAllLines("input/input3_1.txt");
            int count = 0;
            for (int i = 0; i < lines.Length; i += 3)
            {
                var chars = lines[i].ToCharArray().Intersect(lines[i + 1].ToCharArray()).ToArray();
                count = Calc2(lines, count, lines[i + 2], chars);
            }
            return count;
        }

        private static int Calc2(string[] lines, int count, string thirdLine, char[] chars)
        {
            for (int j = 0; j < chars.Length; j++)
            {
                for (int k = 0; k < thirdLine.Length; k++)
                {
                    var ch = chars[j];
                    if (ch == thirdLine[k])
                    {
                        if (ch < 96)
                        {
                            count += ch - 38;
                        }
                        else
                        {
                            count += ch - 96;
                        }
                        return count;
                    }
                }
            }
            return count; 
        }
    }
}
