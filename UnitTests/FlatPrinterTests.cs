using Core;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class FlatPrinterTests
    {
        [TestMethod]
        public void TestGeneratePrintOutput()
        {
            // assign
            var tree = new Node(3);
            TreeFunctions.Insert(tree, 1);
            TreeFunctions.Insert(tree, 4);
            TreeFunctions.Insert(tree, 5);

            // action
            var output = new FlatPrinter().GeneratePrintOutput(tree);

            // assert
            Assert.AreEqual(output.Length, 3);
            Assert.AreEqual(" 3  ", output[0]);
            Assert.AreEqual("1 4 ", output[1]);
            Assert.AreEqual("   5", output[2]);
        }
    }
}