using System.Text;

namespace Service.Commands
{
    internal class Help : ICommand
    {
        public string ShortCommand => "h";

        public string LongCommand => "help";

        public bool HandlesCommand(string command)
        {
            return command == ShortCommand || command == LongCommand;
        }

        public string Run(string? instructions)
        {
            var message = new StringBuilder();
            message.AppendLine("--- Help manual for program 'gitify' ---");
            message.AppendLine();
            message.AppendLine("--- b, branch ---");
            message.AppendLine("Converts a string to a GIT compatible branch name.");
            message.AppendLine("Example: gitify branch Add unit tests");
            message.AppendLine();
            message.AppendLine("--- h, help ---");
            message.AppendLine("Gives this manual page on how to use Gitify.");
            message.AppendLine("Example: gitify help");
            message.AppendLine();
            message.AppendLine("--- v, version ---");
            message.AppendLine("Gives the current verion number of Gitify.");
            message.AppendLine("Example: gitify version");
            message.AppendLine();
            message.AppendLine("--- q, quit, exit ---");
            message.AppendLine("Quits Gitify and returns to the parent program.");
            message.Append("Example: gitify quit");

            return message.ToString();
        }
    }
}
