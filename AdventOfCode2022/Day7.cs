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
    internal static class Day7
    {
        internal static int Star1()
        {
            var lines = File.ReadAllLines("input/input7_1.txt");
            var root = ParseTree(lines);
            var totalSize = 0;
            Sum(root, ref totalSize, new HashSet<string>());
            return totalSize;
        }

        private static Folder ParseTree(string[] lines)
        {
            Folder root = new Folder() { Name = "//" };
            Folder current = root;

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];

                if (line.StartsWith("$ cd "))
                {
                    var spl = line.Split(' ');
                    var arg = spl[spl.Length - 1];
                    if (arg == "..")
                    {
                        current = current.Parent;
                    }
                    else if (arg == "/")
                    {
                        current = root;
                    }
                    else
                    {
                        current = current.Children[current.Name + arg];
                    }
                }
                else if (line != "$ ls")
                {
                    var spl = line.Split(' ');
                    if (spl[0] == "dir")
                    {
                        var name = current.Name + spl[1];
                        current.Children.Add(name, new Folder() { Name = name, Parent = current });
                    }
                    else
                    {
                        current.AddFile(spl[1], int.Parse(spl[0]));
                    }
                }
            }
            return root;
        }

        private static int Sum(Folder root, ref int totalSize, HashSet<string> names)
        {
            if (names.Contains(root.Name))
            {
                return 0;
            }
            var returnSize = 0;
            if (root.Children.Count == 0)
            {
                returnSize = root.Size;
            }
            else
            {
                returnSize = root.Size;
                foreach (var child in root.Children)
                {
                    returnSize += Sum(child.Value, ref totalSize, names);
                }
            }

            names.Add(root.Name);
            if (returnSize <= 100000)
            {
                totalSize += returnSize;
            }
            return returnSize;
        }

        internal static int Star2()
        {
            var lines = File.ReadAllLines("input/input7_1.txt");
            var root = ParseTree(lines);
            var totalSize = 0;
            var sum = Sum(root, ref totalSize, new HashSet<string>());

            var delete = sum;
            MinDelete(root, ref delete, sum - 40000000, new HashSet<string>());
            return delete;
        }

        private static int MinDelete(Folder root, ref int delete, int minDelete, HashSet<string> names)
        {
            if (names.Contains(root.Name))
            {
                return 0;
            }
            var returnSize = 0;
            if (root.Children.Count == 0)
            {
                returnSize = root.Size;
            }
            else
            {
                returnSize = root.Size;
                foreach (var child in root.Children)
                {
                    returnSize += MinDelete(child.Value, ref delete, minDelete, names);
                }
            }

            names.Add(root.Name);
            if (returnSize < delete && returnSize > minDelete)
            {
                delete = returnSize;
            }
            return returnSize;
        }

        private class Folder
        {
            public string Name { get; set; }

            public Dictionary<string, Folder> Children = new Dictionary<string, Folder>();

            public HashSet<string> Files = new HashSet<string>();
            public Folder Parent;

            public int Size;

            public void AddFile(string file, int size)
            {
                if (Files.Add(file))
                {
                    Size += size;
                }
            }
        }
    }
}
