namespace Jester.Tests.Boot.BootTests
{
    /// <summary>
    /// Provides a test-safe engine configuration for unit tests,
    /// including log cleanup and directory isolation.
    /// </summary>
    public static class EngineConfig
    {
        /// <summary>
        /// Generates a fresh configuration with logging enabled and an isolated log path.
        /// Any existing logs in that path will be wiped before use.
        /// </summary>
        /// <returns>A fully configured <see cref="EngineConfiguration"/> ready for test use.</returns>
        public static EngineConfiguration Get()
        {
            var baseDir = AppContext.BaseDirectory;
            var testLogPath = Path.Combine(baseDir, "Logs", "Boot");

            // Clean previous logs to ensure fresh results
            if (Directory.Exists(testLogPath)) Directory.Delete(testLogPath, recursive: true);

            Directory.CreateDirectory(testLogPath);

            // Enable logging and point to test log directory
            return new EngineConfiguration()
                .UseLogger(testLogPath);
        }
    }
}
