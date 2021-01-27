using Core;
using Infrastructure;
using Infrastructure.AsciiPrint;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class AsciiTreeFunctionTests
    {
        [TestMethod]
        public void TestBuildAsciiTree()
        {
            // assign
            var tree = new Node(3);
            TreeFunctions.Add(tree, 1);
            TreeFunctions.Add(tree, 4);

            // action
            var root = AsciiTreePrinter.BuildAsciiTree(tree);

            // assert
            Assert.AreEqual(root.Label, "3");
            Assert.AreEqual(root.Label.Length, 1);

            Assert.AreEqual(root.Left.Label, "1");
            Assert.AreEqual(root.Left.Label.Length, 1);

            Assert.AreEqual(root.Right.Label, "4");
            Assert.AreEqual(root.Right.Label.Length, 1);
        }
    }
}