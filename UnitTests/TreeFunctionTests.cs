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
            TreeFunctions.Add(tree, 1);
            TreeFunctions.Add(tree, 4);

            // action
            var found = TreeFunctions.Search(tree ,3);

            // assert
            Assert.AreSame(tree, found);
        }

        [TestMethod]
        public void TestInsert()
        {
            // assign
            var tree = new Node(3);

            //action
            TreeFunctions.Add(tree, 1);
            TreeFunctions.Add(tree, 4);
            TreeFunctions.Add(tree, 5);

            // assert values
            Assert.AreEqual(tree.Value, 3);
            Assert.AreEqual(tree.Left.Value, 1);
            Assert.AreEqual(tree.Right.Value, 4);
            Assert.AreEqual(tree.Right.Right.Value, 5);

            // assert height
            Assert.AreEqual(tree.Height, Node.RootHeight);
            Assert.AreEqual(tree.Left.Height, Node.RootHeight + 1);
            Assert.AreEqual(tree.Right.Right.Height, Node.RootHeight + 1 + 1);
        }

        [TestMethod]
        public void TestCreateFromArray()
        {
            // assign
            // action
            var tree = TreeFunctions.CreateFromArray(new[] {3, 1, 4, 5});

            // assert values
            Assert.AreEqual(tree.Value, 3);
            Assert.AreEqual(tree.Left.Value, 1);
            Assert.AreEqual(tree.Right.Value, 4);
            Assert.AreEqual(tree.Right.Right.Value, 5);

            // assert height
            Assert.AreEqual(tree.Height, Node.RootHeight);
            Assert.AreEqual(tree.Left.Height, Node.RootHeight + 1);
            Assert.AreEqual(tree.Right.Right.Height, Node.RootHeight + 1 + 1);
        }

        [TestMethod]
        public void TestInsertMultiple()
        {
            // assign
            var tree = new Node(3);

            //action
            TreeFunctions.Add(tree, new[] {1,4,5});

            // assert values
            Assert.AreEqual(tree.Value, 3);
            Assert.AreEqual(tree.Left.Value, 1);
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
            Assert.IsNull(TreeFunctions.Search(result, 4));

            Assert.IsNotNull(TreeFunctions.Search(result, 1));
            Assert.IsNotNull(TreeFunctions.Search(result, 2));
            Assert.IsNotNull(TreeFunctions.Search(result, 3));
            Assert.IsNotNull(TreeFunctions.Search(result, 5));
        }

        [TestMethod]
        public void TestConvertToInOrderNodes()
        {
            // assign
            var tree = new Node(3);
            TreeFunctions.Add(tree, 1);
            TreeFunctions.Add(tree, 4);
            TreeFunctions.Add(tree, 5);

            // action
            var inorder = TreeFunctions.ConvertToInOrderNodes(tree);

            // assert
            Assert.AreEqual(inorder.Length, 4);
            Assert.AreEqual(inorder[0].Value, 1);
            Assert.AreEqual(inorder[1].Value, 3);
            Assert.AreEqual(inorder[2].Value, 4);
            Assert.AreEqual(inorder[3].Value, 5);
        }
    }
}
