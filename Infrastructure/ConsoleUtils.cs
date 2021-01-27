using System;
using System.Text;

namespace Infrastructure
{
    public static class ConsoleUtils
    {
        public static string GetNSpaces(int n)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < n; i++)
            {
                sb.Append(' ');
            }

            return sb.ToString();
        }

        public static void PrintNChars(char a, int n)
        {
            for (var i = 0; i < n; i++) Console.Write(a);
        }
    }
}