using Service;
using Service.Enums;

namespace ServiceTests
{
    public class QuitTests
    {
        [Theory]
        [InlineData("gitify q")]
        [InlineData("gitify quit")]
        [InlineData("gitify exit")]
        [InlineData("gitify stop")]
        public void BranchTest(string command)
        {
            var runResult = CommandHandler.RunInput(command);

            Assert.Equal(RunCode.Stop, runResult.RunCode);
            Assert.Null(runResult.DataResult);
        }
    }
}
