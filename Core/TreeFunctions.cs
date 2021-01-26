using System;

namespace Core
{
    public static class TreeFunctions
    {
        public static Node FindMin(Node root)
        {
            var node = root;

            while (node?.Left != null) node = node.Left;

            return node;
        }

        public static Node FindMax(Node root)
        {
            var node = root;

            while (node?.Right != null) node = node.Right;

            return node;
        }

        public static Node Find(Node root, int value)
        {
            var node = root;

            while (node != null)
                if (value < node.Value)
                    node = node.Left;
                else if (value > node.Value)
                    node = node.Right;
                else
                    return node;

            return null;
        }

        public static Node Insert(Node root, int value)
        {
            var node = root;

            if (node == null) return new Node(value);

            if (value < node.Value)
                node.Left = Insert(node.Left, value);

            else if (value > node.Value)
                node.Right = Insert(node.Right, value);
            else
                return node;

            return node;
        }

        public static Node Delete(Node root, int value)
        {
            var node = root;

            if (node == null) return null;

            if (value < node.Value)
            {
                node.Left = Delete(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = Delete(node.Right, value);
            }
            else if (node.Left != null && node.Right != null)
            {
                var tmpCell = FindMin(node.Right);
                node.Value = tmpCell.Value;
                node.Right = Delete(node.Right, node.Value);
            }
            else
            {
                if (node.Left == null)
                    node = node.Right;
                else if (node.Right == null) node = node.Left;
            }

            return node;
        }
    }
}