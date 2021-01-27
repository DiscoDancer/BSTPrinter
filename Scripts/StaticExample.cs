using System;
using Core;
using Infrastructure;
using Infrastructure.AsciiPrint;

namespace Scripts
{
    public static class StaticExample
    {
        public static void Run()
        {
            var tree = TreeFunctions.CreateFromArray(new[] {100, 15, 190, 171, 3, 91, 205, 155, 13, 17, 203});

            Console.WriteLine("Following Tree:");
            Console.WriteLine();

            new AsciiTreePrinter().PrintTree(tree);

            Console.WriteLine();
            Console.WriteLine("Will look this:");
            Console.WriteLine();

            new FlatPrinter().PrintTree(tree);
        }
    }
}