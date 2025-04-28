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
            var expected = "--- Help manual for program 'gitify' ---\r\n\r\n--- b, branch ---\r\nConverts a string to a GIT compatible branch name.\r\nExample: gitify branch Add unit tests\r\n\r\n--- h, help ---\r\nGives this manual page on how to use Gitify.\r\nExample: gitify help\r\n\r\n--- q, quit, exit ---\r\nQuits Gitify and returns to the parent program.\r\nExample: gitify quit";
            var runResult = CommandHandler.RunInput(command);

            Assert.Equal(RunCode.Continue, runResult.RunCode);
            Assert.Equal(expected, runResult.DataResult);
        }
    }
}
