namespace Infrastructure.AsciiPrint
{
    public class AsciiNode
    {
        public AsciiNode Left { get; set; }

        public AsciiNode Right { get; set; }

        // length of the edge from this node to its children
        public int EdgeLength { get; set; } = 0;

        public int Height { get; set; } = 0;

        public int Lablen { get; set; } = 0;

        // -1 = left, 0 = root, 1 = right
        public int ParentDir { get; set; } = 0;

        // max supported unit32 in dec, 10 digits max
        public string Label { get; set; } = "";
    }
}