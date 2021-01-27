using System;
using System.Threading.Channels;
using Core;
using Infrastructure;

namespace TreeApp
{
    class Program
    {
        private static void InorderTraversal(Node root)
        {
            var node = root;
            if (node != null)
            {
                InorderTraversal(node.Left);
                Console.WriteLine(node.Value);
                InorderTraversal(node.Right);
            }
        }

        private static void PreorderTraversal(Node root)
        {
            var node = root;
            if (node != null)
            {
                Console.WriteLine(node.Value);
                PreorderTraversal(node.Left);
                PreorderTraversal(node.Right);
            }
        }

        private static void PostorderTraversal(Node root)
        {
            var node = root;
            if (node != null)
            {
                PostorderTraversal(node.Left);
                PostorderTraversal(node.Right);
                Console.WriteLine(node.Value);
            }
        }

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
            TreeFunctions.Insert(tree, 303);

            // InorderTraversal(tree);

            AsciiTreeFunctions.DrawTree(tree);
        }

        static void Main(string[] args)
        {
            RunTheirSample();
        }
    }
}
