using Service;
using Service.Enums;

namespace GitifyTests
{
    public class HelpTests
    {
        [Theory]
        [InlineData("gitify h")]
        [InlineData("gitify help")]
        public void BranchTest(string command)
        {
            var nl = Environment.NewLine;
            var expected = $"--- Help manual for program 'gitify' ---{nl}{nl}--- b, branch ---{nl}Converts a string to a GIT compatible branch name.{nl}Example: gitify branch Add unit tests{nl}{nl}--- h, help ---{nl}Gives this manual page on how to use Gitify.{nl}Example: gitify help{nl}{nl}--- v, version ---{nl}Gives the current verion number of Gitify.{nl}Example: gitify version{nl}{nl}--- q, quit, exit ---{nl}Quits Gitify and returns to the parent program.{nl}Example: gitify quit";
            var runResult = CommandHandler.RunInput(command);

            Assert.Equal(RunCode.Continue, runResult.RunCode);
            Assert.Equal(expected, runResult.DataResult);
        }
    }
}
