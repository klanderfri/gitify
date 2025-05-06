using Service;
using Service.Enums;

namespace ServiceTests
{
    public class InvalidCommandTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("git")]
        [InlineData("gitify ")]
        [InlineData("gitify s")]
        [InlineData("gitify he")]
        [InlineData("gitify helpx")]
        [InlineData("gitify summarize")]
        [InlineData("git commit --amend")]
        public void BranchTest(string command)
        {
            var runResult = CommandHandler.RunInput(command);

            Assert.Equal(RunCode.Continue, runResult.RunCode);
            Assert.False(string.IsNullOrWhiteSpace(runResult.DataResult));
            Assert.StartsWith("Invalid command:", runResult.DataResult);
        }
    }
}
