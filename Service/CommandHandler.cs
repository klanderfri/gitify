using Service.Commands;

namespace Service
{
    public static class CommandHandler
    {
        public const string Name = "gitify";
        private readonly static HashSet<string> quitCommands = ["q", "quit", "exit", "stop"];

        public static RunResult RunInput(string? userInput)
        {
            //Check that the user has entered a valid command.
            var inputParts = GetInputParts(userInput);
            if (!IsValidCommand(inputParts))
            {
                var invalidCommandMessage = Messages.PrintInvalidCommand(userInput);
                return RunResult.Continue(invalidCommandMessage);
            }

            //Extract the command the user wants to run.
            var command = inputParts[1];

            //Check if the user wants to quit.
            if (quitCommands.Contains(command))
            {
                return RunResult.Stop();
            }

            //Extract the instructions for the method to run.
            var commandHasInstructions = inputParts.Length > 2;
            var instructions = commandHasInstructions ? string.Join(' ', inputParts[2..]) : null;

            //Create the objects handling the commands we support.
            var commandHandlers = new List<ICommand>()
            {
                new Branch(),
                new Help()
            };

            //Run the appropriate command.
            foreach (var handler in commandHandlers)
            {
                if (!handler.HandlesCommand(command)) { continue; }

                var result = handler.Run(instructions);
                return RunResult.Continue(result);
            }

            //If we got here then the command is not supported.
            var unknownCommandMessage = Messages.PrintInvalidCommand(userInput);
            return RunResult.Continue(unknownCommandMessage);
        }

        private static string[] GetInputParts(string? userInput)
        {
            var parts = (userInput ?? "")
                .Split(' ')
                .Where(s => !string.IsNullOrWhiteSpace(s));

            return [.. parts];
        }

        private static bool IsValidCommand(string[] commandParts)
        {
            //Every command needs to have AT LEAST two parts
            // 1. The program name "gitify".
            // 2. The actual command to execute.
            if (commandParts.Length < 2) { return false; }

            //The first part should be the program name "gitify".
            if (commandParts[0] != Name) { return false; }

            //We should also make sure that
            // * the actual command is supported.
            // * the command gets the instructions it needs.
            //The first point is handled by the code searching for a command class
            //to handle the command.
            //The second point should be handled by the command classes. Only they
            //know what instructions they need.

            return true;
        }
    }
}
