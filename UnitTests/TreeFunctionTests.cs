using Core;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TreeFunctionTests
    {

        [TestMethod]
        public void TestFindMin()
        {
            // assign
            var (tree, numbers) = GenerateFunctions.GenerateTree(10, 1, 10);

            // action
            var min = TreeFunctions.FindMin(tree).Value;

            // assert
            Assert.AreEqual(min, 1);
        }

        [TestMethod]
        public void TestFindMax()
        {
            // assign
            var (tree, numbers) = GenerateFunctions.GenerateTree(10, 1, 10);

            // action
            var min = TreeFunctions.FindMax(tree).Value;

            // assert
            Assert.AreEqual(min, 10);
        }

        [TestMethod]
        public void TestFind()
        {
            // assign
            var tree = new Node(3);
            TreeFunctions.Insert(tree, 1);
            TreeFunctions.Insert(tree, 4);

            // action
            var found = TreeFunctions.Find(tree ,3);

            // assert
            Assert.AreSame(tree, found);
        }

        [TestMethod]
        public void TestInsert()
        {
            // assign
            var tree = new Node(3);

            //action
            TreeFunctions.Insert(tree, 1);
            TreeFunctions.Insert(tree, 4);
            TreeFunctions.Insert(tree, 5);

            // assert values
            Assert.AreEqual(tree.Left.Value, 1);
            Assert.AreEqual(tree.Value, 3);
            Assert.AreEqual(tree.Right.Value, 4);
            Assert.AreEqual(tree.Right.Right.Value, 5);

            // assert height
            Assert.AreEqual(tree.Height, Node.RootHeight);
            Assert.AreEqual(tree.Left.Height, Node.RootHeight + 1);
            Assert.AreEqual(tree.Right.Right.Height, Node.RootHeight + 1 + 1);
        }

        [TestMethod]
        public void TestDelete()
        {
            // assign
            var (tree, numbers) = GenerateFunctions.GenerateTree(5, 1, 5);

            // action
            var result = TreeFunctions.Delete(tree, 4);

            // assert
            Assert.IsNull(TreeFunctions.Find(result, 4));

            Assert.IsNotNull(TreeFunctions.Find(result, 1));
            Assert.IsNotNull(TreeFunctions.Find(result, 2));
            Assert.IsNotNull(TreeFunctions.Find(result, 3));
            Assert.IsNotNull(TreeFunctions.Find(result, 5));
        }
    }
}
