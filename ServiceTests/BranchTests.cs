using Service;
using Service.Enums;
using TextCopy;

namespace GitifyTests
{
    public class BranchTests
    {
        [Theory]
        [InlineData("gitify branch 824123 Nationalitetscertifikat för skeppslegodel", "824123-nationalitetscertifikat-for-skeppslegodel")]
        [InlineData("gitify b Tyßsk räksmörgås på Færøarna", "tysssk-raksmorgas-pa-faroarna")]
        [InlineData("gitify b \t \r\n   lägger in unittest ", "lagger-in-unittest")]
        [InlineData("gitify b Lägg in 🙂🫎 smileys", "lagg-in-smileys")]
        [InlineData("gitify b Lägg@ i€n $k£oµn#s%t{i}g[a]-tecken", "lagg-in-konstiga-tecken")]
        [InlineData("gitify b Handle punctuation, like periods.", "handle-punctuation-like-periods")]
        public void BranchTest(string command, string expected)
        {
            //Set a random string in the clipboard to make sure the command doesn't
            //set anything to the clipboard, nor erases it.
            var clipboardTextUntouchedByTest = Guid.NewGuid().ToString();
            ClipboardService.SetText(clipboardTextUntouchedByTest);

            var runResult = CommandHandler.RunInput(command);

            Assert.Equal(RunCode.Continue, runResult.RunCode);
            Assert.Equal(expected, runResult.DataResult);
            Assert.Equal(clipboardTextUntouchedByTest, ClipboardService.GetText());
        }
    }
}
