using System;

namespace VeraDemoNet.Helper
{
    public static class ToolsHelper
    {
        public static void AssertIsSingleArgument(string argument)
        {
            if (argument.Trim().Contains(" "))
            {
                throw new ArgumentException($"Argument value {argument} is not valid. Whitespaces are not allowed.");
            }
        }
    }
}