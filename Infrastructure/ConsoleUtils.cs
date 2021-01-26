using System;

namespace Infrastructure
{
    public static class ConsoleUtils
    {
        public static void PrintNChars(char a, int n)
        {
            for (var i = 0; i < n; i++) Console.Write(a);
        }
    }
}