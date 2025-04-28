namespace Service.Commands
{
    public class Version : ICommand
    {
        public static readonly string VersionNumber = "0.1";

        public string ShortCommand => "v";

        public string LongCommand => "version";

        public bool HandlesCommand(string command)
        {
            return command == ShortCommand || command == LongCommand;
        }

        public string Run(string? instructions)
        {
            return VersionNumber;
        }
    }
}
