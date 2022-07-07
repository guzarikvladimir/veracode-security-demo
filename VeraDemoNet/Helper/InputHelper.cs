using System;
using System.Text.RegularExpressions;

namespace VeraDemoNet.Helper
{
    public static class InputHelper
    {
        public static void AssertDoesNotContainSpecialCharacters(string input)
        {
            if (Regex.IsMatch(input, @"[^A-Za-z0-9]"))
            {
                throw new ArgumentException($"Argument value {input} contains not allowed characters.");
            }
        }
    }
}