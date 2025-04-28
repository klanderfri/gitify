using Service;
using Service.Enums;

namespace ServiceTests
{
    public class VersionTests
    {
        [Theory]
        [InlineData("gitify v")]
        [InlineData("gitify version")]
        public void VersionTest(string command)
        {
            const string currentVersion = "0.1";
            var runResult = CommandHandler.RunInput(command);

            Assert.Equal(RunCode.Continue, runResult.RunCode);
            Assert.Equal(currentVersion, runResult.DataResult);
        }
    }
}
