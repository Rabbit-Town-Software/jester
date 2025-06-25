namespace Jester.Tests.Boot.BootTests
{
    public static class EngineConfig
    {
        public static EngineConfiguration Get()
        {
            var baseDir = AppContext.BaseDirectory;
            var testLogPath = Path.Combine(baseDir, "Logs", "Boot");
            
            if (Directory.Exists(testLogPath)) Directory.Delete(testLogPath, recursive: true);
            
            Directory.CreateDirectory(testLogPath);

            return new EngineConfiguration()
                .UseLogger(testLogPath);
        }
    }
}
