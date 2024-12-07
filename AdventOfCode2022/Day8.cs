using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode2022
{
    internal static class Day8
    {
        internal static int Star2()
        {
            var lines = File.ReadAllLines("input/input8_1.txt").
                Select(s => s.ToCharArray().Select(s1 => int.Parse(s1.ToString())).ToArray())
                .ToArray();

            int maxTree = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    var height = lines[i][j];
                    int tV = 0, bV = 0, lV = 0, rV = 0;

                    for (int t = i - 1; t >= 0; t--)
                    {
                        tV++;
                        if (lines[t][j] >= height)
                        {
                            break;
                        }
                    }
                    for (int l = j - 1; l >= 0; l--)
                    {
                        lV++;
                        if (lines[i][l] >= height)
                        {
                            break;
                        }
                    }
                    for (int r = j + 1; r < lines[i].Length; r++)
                    {
                        rV++;
                        if (lines[i][r] >= height)
                        {
                            break;
                        }
                    }
                    for (int b = i + 1; b < lines.Length; b++)
                    {
                        bV++;
                        if (lines[b][j] >= height)
                        {
                            break;
                        }
                    }
                    var score = lV * tV * rV * bV;
                    maxTree = Math.Max(maxTree, score);
                }
            }
            return maxTree;
        }

        internal static int Star1()
        {
            var lines = File.ReadAllLines("input/input8_1.txt").
                Select(s => s.ToCharArray().Select(s1 => int.Parse(s1.ToString())).ToArray())
                .ToArray();

            HashSet<(int, int)> visible = new HashSet<(int, int)>();
            for (int i = 0; i < lines.Length; i++)
            {
                int lMax = -1; int rMax = -1;
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] > lMax)
                    {
                        lMax = lines[i][j];
                        visible.Add((i, j));
                    }
                }

                for (int j = lines[i].Length - 1; j >= 0; j--)
                {
                    if (lines[i][j] == lMax)
                    {
                        visible.Add((i, j));
                        break;
                    }

                    if (lines[i][j] > rMax)
                    {
                        rMax = lines[i][j];
                        visible.Add((i, j));
                    }
                }
            }

            for (int i = 0; i < lines[0].Length; i++)
            {
                int lMax = -1; int rMax = -1;
                for (int j = 0; j < lines.Length; j++)
                {
                    if (lines[j][i] > lMax)
                    {
                        lMax = lines[j][i];
                        visible.Add((j, i));
                    }
                }

                for (int j = lines.Length - 1; j >= 0; j--)
                {
                    if (lines[j][i] == lMax)
                    {
                        visible.Add((j, i));
                        break;
                    }

                    if (lines[j][i] > rMax)
                    {
                        rMax = lines[j][i];
                        visible.Add((j, i));
                    }
                }
            }
            return visible.Count;
        }
    }
}
