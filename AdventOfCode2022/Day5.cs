using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AdventOfCode2022
{
    internal static class Day5
    {
        internal static string Star1()
        {
            Init(out Dictionary<int, Stack<char>> dict, out List<(int, int, int)> rules);
            return Move(dict, rules, false);
        }

        internal static string Star2()
        {
            Init(out Dictionary<int, Stack<char>> dict, out List<(int, int, int)> rules);
            return Move(dict, rules, true);
        }

        private static string Move(Dictionary<int, Stack<char>> dict, List<(int, int, int)> rules, bool reverse)
        {
            for (int i = 0; i < rules.Count; i++)
            {
                var rule = rules[i];
                var crates = Enumerable.Range(0, rule.Item1).Select(s => dict[rule.Item2].Pop());
                if (reverse)
                {
                    crates = crates.Reverse(); 
                }
                foreach (var item in crates)
                {
                    dict[rule.Item3].Push(item);
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < 10; i++)
            {
                sb.Append(dict[i].Peek());
            }
            return sb.ToString();
        }

        private static void Init(out Dictionary<int, Stack<char>> dict, out List<(int, int, int)> rules)
        {
            rules = new List<(int, int, int)>();

            dict = new Dictionary<int, Stack<char>>()
            {
                { 1, new Stack<char>() },
                { 2, new Stack<char>() },
                { 3, new Stack<char>() },
                { 4, new Stack<char>() },
                { 5, new Stack<char>() },
                { 6, new Stack<char>() },
                { 7, new Stack<char>() },
                { 8, new Stack<char>() },
                { 9, new Stack<char>() },
            };

            var input = File.ReadAllLines("input/input5_1.txt");

            for (int i = 7; i >= 0; i--)
            {
                var line = input[i];
                for (int j = 1, k = 1; j < 10; j++, k += 4)
                {
                    var crate = line[k];
                    if (crate != ' ')
                    {
                        dict[j].Push(crate);
                    }
                }
            }

            for (int i = 10; i < input.Length; i++)
            {
                var sp = input[i].Split(' ');
                rules.Add((int.Parse(sp[1]), int.Parse(sp[3]), int.Parse(sp[5])));
            }
        }
    }
}
