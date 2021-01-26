namespace Core
{
    public class Node
    {
        public Node(int value)
        {
            Left = null;
            Right = null;
            Value = value;
        }

        public Node Left { get;  set; }
        public Node Right { get;  set; }
        public int Value { get;  set; }
    }
}