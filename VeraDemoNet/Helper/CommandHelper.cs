using System;
using System.Linq;
using VeraDemoNet.Commands;

namespace VeraDemoNet.Helper
{
    public static class CommandHelper
    {
        private static readonly string[] AllowedCommands =
        {
            nameof(IgnoreCommand).Replace("Command", string.Empty),
            nameof(ListenCommand).Replace("Command", string.Empty)
        };

        public static void AssertIsValid(string command)
        {
            bool match = AllowedCommands.Any(allowedCommand =>
                allowedCommand.Equals(command, StringComparison.InvariantCultureIgnoreCase));
            if (!match)
            {
                throw new InvalidOperationException($"Command {command} is not allowed.");
            }
        }
    }
}