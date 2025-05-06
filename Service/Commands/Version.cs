namespace Service.Commands
{
    public class Version : ICommand
    {
        private const string VersionNumber = "0.2";

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
