using System;
using Core;
using Infrastructure;

namespace TreeApp
{
    class Program
    {
        private static void RunMySample()
        {
            var tree = new Node(3);
            TreeFunctions.Insert(tree, 1);
            TreeFunctions.Insert(tree, 4);

            AsciiTreeFunctions.DrawTree(tree);
        }

        private static void RunTheirSample()
        {
            var tree = new Node(100);

            TreeFunctions.Insert(tree, 15);
            TreeFunctions.Insert(tree, 190);
            TreeFunctions.Insert(tree, 171);
            TreeFunctions.Insert(tree, 3);
            TreeFunctions.Insert(tree, 91);
            TreeFunctions.Insert(tree, 205);
            TreeFunctions.Insert(tree, 155);
            TreeFunctions.Insert(tree, 13);
            TreeFunctions.Insert(tree, 17);
            TreeFunctions.Insert(tree, 203);

            AsciiTreeFunctions.DrawTree(tree);
        }

        static void Main(string[] args)
        {
            RunTheirSample();
        }
    }
}
