using System.Text;

namespace Service
{
    internal static class Messages
    {
        public static string PrintInvalidCommand(string? userInput)
        {
            var message = new StringBuilder();
            message.AppendLine($"Invalid command: '{userInput}'.");
            message.Append("Run 'gitify help' for instructions.");

            return message.ToString();
        }

        public static string PrintInvalidInstructions(string longCommand, string? instructions)
        {
            var message = new StringBuilder();
            message.AppendLine($"Invalid instructions for command {longCommand}: '{instructions}'.");
            message.Append("Run 'gitify help' for instructions.");

            return message.ToString();
        }
    }
}
