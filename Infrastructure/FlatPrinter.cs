using System;
using System.Linq;
using Core;
using MoreLinq;

namespace Infrastructure
{
    public class FlatPrinter : ITreePrinter
    {
        public const int MaxHeight = 1000;

        public string[] GeneratePrintOutput(Node root)
        {
            if (root == null)
            {
                return Array.Empty<string>();
            }

            var nodes = TreeFunctions.ConvertToInOrderNodes(root);
            var h = nodes.Max(x => x.Height) + 1;

            if (h > MaxHeight)
            {
                Console.WriteLine($"Height is too big, max value is {MaxHeight}");
                return Array.Empty<string>();
            }

            var output = new string[h];
            for (var i = 0; i < h; i++)
            {
                output[i] = string.Empty;
            }

            foreach (var node in nodes)
            {
                var str = node.Value.ToString();

                for (var i = 0; i < h; i++)
                {
                    if (node.Height == i)
                    {
                        output[i] += str;
                    }
                    else
                    {
                        output[i] += ConsoleUtils.GetNSpaces(str.Length);
                    }
                }
            }

            return output;
        }

        public void PrintTree(Node root)
            => GeneratePrintOutput(root).ForEach(str => Console.WriteLine(str));
    }
}