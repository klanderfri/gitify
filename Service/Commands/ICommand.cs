namespace Service.Commands
{
    internal interface ICommand
    {
        public string ShortCommand { get; }
        public string LongCommand { get; }

        public bool HandlesCommand(string command);
        public string Run(string? instructions);
    }
}
