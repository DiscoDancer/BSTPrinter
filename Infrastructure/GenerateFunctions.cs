using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using MoreLinq;

namespace Infrastructure
{
    public static class GenerateFunctions
    {
        public static int[] GetZeroArray(int size)
        {
            var arr = new int[size];
            for (var i = 0; i < size; i++)
            {
                arr[i] = 0;
            }

            return arr;
        }

        public static int[] GetRandomNumbers(int size, int min, int max, Random random)
        {
            var randomNumbers = new HashSet<int>();

            for (var i = 0; i < size; i++)
            {
                while (!randomNumbers.Add(random.Next(min, max + 1))) { }
            }
            
            return randomNumbers.ToArray();
        }

        public static (Node, int[]) GenerateTree(int size, int min, int max)
        {
            if (size < 1)
            {
                throw new ArgumentException("Size should be more or equal than one.");
            }

            if (min > max)
            {
                throw new ArgumentException("Min should be less than max.");
            }

            if (max - min < size - 1)
            {
                throw new ArgumentException("Size is too big for this range.");
            }

            var random = new Random();
            var randomArr = GetRandomNumbers(size, min, max, random);

            var root = new Node(randomArr[0]);

            if (size == 1)
            {
                return (root, randomArr);
            }

            var moreValues = randomArr.Skip(1).ToArray();
            moreValues.ForEach(i => TreeFunctions.Add(root, i));

            return (root, randomArr);
        }
    }
}
