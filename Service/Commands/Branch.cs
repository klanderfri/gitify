using System.Text;

namespace Service.Commands
{
    internal class Branch : ICommand
    {
        public string ShortCommand => "b";

        public string LongCommand => "branch";

        public bool HandlesCommand(string command)
        {
            return command == ShortCommand || command == LongCommand;
        }

        public string Run(string? instructions)
        {
            if (string.IsNullOrWhiteSpace(instructions))
            {
                return Messages.PrintInvalidInstructions(LongCommand, instructions);
            }

            return GitifyBranch(instructions);
        }

        private static string GitifyBranch(string branchPhrase)
        {
            var gitBranch = new StringBuilder();

            foreach (var letter in branchPhrase)
            {
                gitBranch.Append(Branchify(letter));
            }

            return RemoveDuplicatedDashes(gitBranch.ToString());
        }

        private static string Branchify(char letter)
        {
            var replacements = new Dictionary<string, string>()
            {
                { " ", "-" },
                { "å", "a" },
                { "ä", "a" },
                { "ö", "o" },
                { "æ", "a" },
                { "ø", "o" },
                { "ß", "ss" }
            };

            var gitLetter = char.ToLower(letter).ToString();

            foreach (var pair in replacements)
            {
                gitLetter = gitLetter.Replace(pair.Key, pair.Value);
            }

            if (!IsGitCompatibleLetter(gitLetter))
            {
                gitLetter = "";
            }

            return gitLetter;
        }

        private static bool IsGitCompatibleLetter(string letter)
        {
            foreach (var c in letter)
            {
                if (!IsGitCompatibleLetter(c)) { return false; }
            }

            return true;
        }

        private static bool IsGitCompatibleLetter(char letter)
        {
            if (letter == 45) { return true; } //-
            if (letter >= 48 && letter <= 57) { return true; } //0-9
            if (letter >= 97 && letter <= 122) { return true; } //a-z

            return false;
        }

        private static string RemoveDuplicatedDashes(string letters)
        {
            var branch = new StringBuilder();
            branch.Append(letters[0]);
            var lastLetter = letters[0];
            for (int i = 1; i < letters.Length; i++)
            {
                if (lastLetter == '-' && letters[i] == '-') { continue; }
                branch.Append(letters[i]);
                lastLetter = letters[i];
            }

            return branch.ToString();
        }
    }
}
