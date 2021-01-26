using System;
using Core;

namespace Infrastructure
{
    public static class AsciiTreeFunctions
    {
        public static int MaxHeight = 1000;
        public static int Infinity = 1 << 20;
        public static int[] Lprofile = GenerateFunctions.GetZeroArray(MaxHeight);
        public static int[] Rprofile = GenerateFunctions.GetZeroArray(MaxHeight);
        public static int Gap = 3;
        // used for printing next node in the same level, this is the x coordinate of the next char printed
        public static int PrintNext = 0;

        /*
         *  # The following function fills in the lprofile array for the given tree.
            # It assumes that the center of the label of the root of this tree
            # is located at a position (x,y).  It assumes that the edge_length
            # fields have been computed for this tree.
         */
        // todo test me
        public static void ComputeLprofile(AsciiNode root, int x, int y)
        {
            var node = root;

            if (node == null)
            {
                return;
            }

            var isleft = node.ParentDir == -1 ? 1 : 0;
            Lprofile[y] = Math.Min(Lprofile[y], x - (node.Lablen - isleft) / 2);

            if (node.Left != null)
            {
                var i = 1;
                while (i <= node.EdgeLength && y + i < MaxHeight)
                {
                    Lprofile[y + i] = Math.Min(Lprofile[y + i], x - i);
                    i += 1;
                }
            }

            ComputeLprofile(node.Left, x - node.EdgeLength - 1, y + node.EdgeLength + 1);
            ComputeLprofile(node.Right, x + node.EdgeLength + 1, y + node.EdgeLength + 1);
        }

        // todo test me
        public static void ComputeRprofile(AsciiNode root, int x, int y)
        {
            var node = root;

            if (node == null)
            {
                return;
            }

            var notleft = node.ParentDir != -1 ? 1 : 0;
            Rprofile[y] = Math.Max(Rprofile[y], x + (node.Lablen - notleft) / 2);
            if (node.Right != null)
            {
                var i = 1;
                while (i <= node.EdgeLength && y + i < MaxHeight)
                {
                    Rprofile[y + i] = Math.Max(Rprofile[y + i], x + i);
                    i += 1;
                }
            }

            ComputeRprofile(node.Left, x - node.EdgeLength - 1, y + node.EdgeLength + 1);
            ComputeRprofile(node.Right, x + node.EdgeLength + 1, y + node.EdgeLength + 1);
        }

        // todo test me
        public static void ComputeEdgeLengths(AsciiNode root)
        {
            var node = root;

            if (node == null)
            {
                return;
            }

            ComputeEdgeLengths(node.Left);
            ComputeEdgeLengths(node.Right);

            if (node.Left == null && node.Right == null)
            {
                node.EdgeLength = 0;
            }
            else
            {
                int hmin;
                if (node.Left != null)
                {
                    var i = 0;
                    while (i < node.Left.Height && i < MaxHeight)
                    {
                        Rprofile[i] = -Infinity;
                        i++;
                    }

                    ComputeRprofile(node.Left, 0, 0);
                    hmin = node.Left.Height;
                }
                else
                {
                    hmin = 0;
                }

                if (node.Right != null)
                {
                    var i = 0;
                    while (i < node.Right.Height && i < MaxHeight)
                    {
                        Lprofile[i] = Infinity;
                        i += 1;
                    }

                    ComputeLprofile(node.Right, 0, 0);
                    hmin = Math.Min(node.Right.Height, hmin);
                }
                else
                {
                    hmin = 0;
                }

                var delta = 4;
                var j = 0;
                while (j < hmin)
                {
                    delta = Math.Max(delta, Gap + 1 + Rprofile[j] - Lprofile[j]);
                    j += 1;
                }

                // If the node has two children of height 1, then we allow the two leaves to be within 1, instead of 2
                if ((node.Left != null && node.Left.Height == 1 || node.Right != null && node.Right.Height == 1) && delta > 4)
                {
                    delta -= 1;
                }

                node.EdgeLength = (delta + 1) / 2 - 1;
            }

            var h = 1;
            if (node.Left != null)
            {
                h = Math.Max(node.Left.Height + node.EdgeLength + 1, h);
            }

            if (node.Right != null)
            {
                h = Math.Max(node.Right.Height + node.EdgeLength + 1, h);
            }

            node.Height = h;
        }

        public static void PrintLevel(AsciiNode root, int x, int level)
        {
            var node = root;

            if (node == null)
            {
                return;
            }

            var isleft = (node.ParentDir == -1) ? 1 : 0;
            int spaces;
            if (level == 0)
            {
                spaces = x - PrintNext - (node.Lablen - isleft) / 2;
                ConsoleUtils.PrintNChars(' ', spaces);

                PrintNext += spaces;
                Console.Write(node.Label);
                PrintNext += node.Lablen;
            }
            else if (node.EdgeLength >= level)
            {
                if (node.Left != null)
                {
                    spaces = x - PrintNext - level;
                    ConsoleUtils.PrintNChars(' ', spaces);
                    PrintNext += spaces;
                    Console.Write('/');
                    PrintNext += 1;
                }

                if (node.Right != null)
                {
                    spaces = x - PrintNext + level;
                    ConsoleUtils.PrintNChars(' ', spaces);
                    PrintNext += spaces;
                    Console.Write('\\');
                    PrintNext += 1;
                }
            }
            else
            {
                PrintLevel(node.Left, x - node.EdgeLength - 1, level - node.EdgeLength - 1);
                PrintLevel(node.Right, x + node.EdgeLength + 1, level - node.EdgeLength - 1);
            }
        }

        public static void DrawTree(Node root)
        {
            var node = root;

            if (node == null)
            {
                return;
            }

            var proot = BuildAsciiTree(node);
            ComputeEdgeLengths(proot);
            var i = 0;
            while (i < proot.Height &&  i < MaxHeight)
            {
                Lprofile[i] = Infinity;
                i += 1;
            }

            ComputeLprofile(proot, 0, 0);
            var xmin = 0;
            i = 0;
            while (i < proot.Height && i < MaxHeight)
            {
                xmin = Math.Min(xmin, Lprofile[i]);
                i += 1;
            }

            i = 0;
            while (i < proot.Height)
            {
                PrintNext = 0;
                PrintLevel(proot, -xmin, i);
                Console.WriteLine();
                i += 1;
            }

            if (proot.Height >= MaxHeight)
            {
                Console.WriteLine($"This tree is taller than {MaxHeight}, and may be drawn incorrectly.");
            }
        }

        public static AsciiNode BuildAsciiTree(Node root)
        {
            var node = root;

            if (node == null)
            {
                return null;
            }

            var asciiNode = BuildAsciiTreeRecursive(root);
            asciiNode.ParentDir = 0;
            return asciiNode;

            static AsciiNode BuildAsciiTreeRecursive(Node root)
            {
                var node = root;

                if (node == null)
                {
                    return null;
                }

                var asciiNode = new AsciiNode
                {
                    Left = BuildAsciiTreeRecursive(node.Left),
                    Right = BuildAsciiTreeRecursive(node.Right)
                };

                if (asciiNode.Left != null)
                {
                    asciiNode.Left.ParentDir = -1;
                }

                if (asciiNode.Right != null)
                {
                    asciiNode.Right.ParentDir = 1;
                }

                asciiNode.Label = node.Value.ToString();
                asciiNode.Lablen = asciiNode.Label.Length;

                return asciiNode;
            }
        }
    }
}