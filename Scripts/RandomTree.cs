using System;
using Infrastructure;
using Infrastructure.AsciiPrint;

namespace Scripts
{
    public static class RandomTree
    {
        public static void Run()
        {
            var (tree, _) = GenerateFunctions.GenerateTree(20, 1, 1000);

            Console.WriteLine("Following Random Tree:");
            Console.WriteLine();

            new AsciiTreePrinter().PrintTree(tree);

            Console.WriteLine();
            Console.WriteLine("Will look this:");
            Console.WriteLine();

            new FlatPrinter().PrintTree(tree);
        }
    }
}