using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode2022
{
    internal static class Day1
    {
        internal static int Star1()
        {
            var lines = File.ReadAllLines("input/input1_1.txt");
            List<int> aggr = new List<int>();
            int sum = 0;
            int max = 0;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    aggr.Add(sum);
                    if (max < sum)
                    {
                        max = sum;
                    }
                    sum = 0;
                    continue;
                }
                sum += int.Parse(line);
            }

            return max;
        }

        internal static int Star2()
        {
            var lines = File.ReadAllLines("input/input1_1.txt");
            List<int> aggr = new List<int>();
            int sum = 0;
            int max1 = 0;
            int max2 = 0;
            int max3 = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    aggr.Add(sum);
                    if (sum > max1)
                    {
                        max3 = max2;
                        max2 = max1;
                        max1 = sum;
                    }
                    else if (sum > max2)
                    {
                        max3 = max2;
                        max2 = sum;
                    }
                    else if (sum > max3)
                    {
                        max3 = sum;
                    }
                    sum = 0;
                    continue;
                }
                sum += int.Parse(line);
            }
            return max1 + max2 + max3;
        }
    }
}
