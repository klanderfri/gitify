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
            message.AppendLine("usage : gitify <command> [<args>]");
            message.AppendLine();
            message.AppendLine("These are the available Gitify commands:");
            message.AppendLine();
            message.AppendLine("   branch    Converts a string to a GIT compatible branch name.");
            message.AppendLine("             gitify {b|branch} <branch phrase>");
            message.AppendLine();
            message.AppendLine("   help      Gives this manual page on how to use Gitify.");
            message.AppendLine("             gitify {h|help}");
            message.AppendLine();
            message.AppendLine("   version   Gives the current version number of Gitify.");
            message.AppendLine("             gitify {v|version}");
            message.AppendLine();
            message.AppendLine("   quit      Quits Gitify and returns to the parent program.");
            message.AppendLine("             gitify {q|quit|exit|stop}");

            return message.ToString();
        }
    }
}
