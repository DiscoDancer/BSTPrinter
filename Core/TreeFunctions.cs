using System.Collections.Generic;

namespace Core
{
    public static class TreeFunctions
    {
        public static Node[] ConvertToInOrderNodes(Node root)
        {
            var list = new List<Node>();
            ConvertToInOrderNodesInner(root, list);
            return list.ToArray();

            static void ConvertToInOrderNodesInner(Node root, ICollection<Node> list)
            {
                var node = root;
                if (node == null) return;
                ConvertToInOrderNodesInner(node.Left, list);
                list.Add(node);
                ConvertToInOrderNodesInner(node.Right, list);
            }
        }

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
            return InsertWithHeightInner(root, value, root.Height);

            static Node InsertWithHeightInner(Node root, int value, int height)
            {
                var node = root;

                if (node == null) return new Node(value, height);

                if (value < node.Value)
                    node.Left = InsertWithHeightInner(node.Left, value, height + 1);

                else if (value > node.Value)
                    node.Right = InsertWithHeightInner(node.Right, value, height + 1);
                else
                    return node;

                return node;
            }
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