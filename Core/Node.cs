namespace Core
{
    public class Node
    {
        public const int RootHeight = 0;

        public Node(int value)
        {
            Left = null;
            Right = null;
            Value = value;
            Height = RootHeight;
        }

        public Node(int value, int height)
        {
            Left = null;
            Right = null;
            Value = value;
            Height = height;
        }

        public Node Left { get;  set; }
        public Node Right { get;  set; }
        public int Value { get;  set; }
        public int Height { get; set; }
    }
}