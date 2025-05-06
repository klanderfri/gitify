using Service;
using Service.Enums;

namespace ServiceTests
{
    public class HelpTests
    {
        [Theory]
        [InlineData("gitify h")]
        [InlineData("gitify help")]
        public void BranchTest(string command)
        {
            var nl = Environment.NewLine;
            var expected = $"usage : gitify <command> [<args>]{nl}{nl}These are the available Gitify commands:{nl}{nl}   branch    Converts a string to a GIT compatible branch name.{nl}             gitify {{b|branch}} <branch phrase>{nl}{nl}   help      Gives this manual page on how to use Gitify.{nl}             gitify {{h|help}}{nl}{nl}   version   Gives the current version number of Gitify.{nl}             gitify {{v|version}}{nl}{nl}   quit      Quits Gitify and returns to the parent program.{nl}             gitify {{q|quit|exit|stop}}{nl}";
            var runResult = CommandHandler.RunInput(command);

            Assert.Equal(RunCode.Continue, runResult.RunCode);
            Assert.Equal(expected, runResult.DataResult);
        }
    }
}
