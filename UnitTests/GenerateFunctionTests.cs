using System;
using System.Linq;
using Core;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class GenerateFunctionTests
    {
        [TestMethod]
        public void TestGetZeroArray()
        {
            // assign
            // action
            var zeroes = GenerateFunctions.GetZeroArray(10);

            // assert
            Assert.IsTrue(zeroes.All(x => x == 0));
            Assert.IsTrue(zeroes.Length == 10);
        }

        [TestMethod]
        public void TestGetRandomNumbers1()
        {
            // assign
            // action
            var result = GenerateFunctions.GetRandomNumbers(1, 1, 1, new Random());

            // assert
            Assert.AreEqual(result.Length, 1);
            Assert.AreEqual(result.First(), 1);
        }

        [TestMethod]
        public void TestGetRandomNumbers2()
        {
            // assign
            // action
            var result = GenerateFunctions.GetRandomNumbers(3, 1, 5, new Random());

            // assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(result.Distinct().Count(), 3);
            Assert.IsTrue(result.Min() >= 1);
            Assert.IsTrue(result.Max() <= 5);
        }

        [TestMethod]
        public void TestGenerateTree1()
        {
            // assign
            // action
            var result = GenerateFunctions.GenerateTree(2, 1, 5);
            var (root, array) = result;

            // assert
            Assert.IsNotNull(root);
            Assert.IsTrue(root.Value <= 5);
            Assert.IsTrue(root.Value >= 1);
            Assert.IsTrue(array.Contains(root.Value));

            var leaf = root.Left ?? root.Right;
            Assert.IsNotNull(leaf);
            Assert.IsTrue(leaf.Value <= 5);
            Assert.IsTrue(leaf.Value >= 1);
            Assert.IsTrue(array.Contains(leaf.Value));
        }

        [TestMethod]
        public void TestGenerateTree2()
        {
            // assign
            // action
            var result = GenerateFunctions.GenerateTree(5, 1, 5);
            var (root, array) = result;

            // assert
            Assert.IsNotNull(TreeFunctions.Find(root, 1));
            Assert.IsNotNull(TreeFunctions.Find(root, 2));
            Assert.IsNotNull(TreeFunctions.Find(root, 3));
            Assert.IsNotNull(TreeFunctions.Find(root, 4));
            Assert.IsNotNull(TreeFunctions.Find(root, 5));
        }
    }
}