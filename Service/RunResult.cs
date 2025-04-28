using Service.Enums;

namespace Service
{
    public class RunResult
    {
        public RunCode RunCode { get; set; }

        public string? DataResult { get; set; }

        public static RunResult Stop()
        {
            return new RunResult
            {
                RunCode = RunCode.Stop
            };
        }

        public static RunResult Continue(string? resultData = null)
        {
            return new RunResult
            {
                RunCode = RunCode.Continue,
                DataResult = resultData
            };
        }
    }
}
