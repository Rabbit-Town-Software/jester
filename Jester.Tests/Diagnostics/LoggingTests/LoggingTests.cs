namespace Jester.Tests.Diagnostics.LoggingTests
{
    /// <summary>
    /// Tests the core functionality of the Logger class and the static Log facade.
    /// Ensures all labels are written correctly to file.
    /// </summary>
    public class LoggingTests
    {
        /// <summary>
        /// Verifies that a logger instance:
        /// - Creates a log file in the correct location
        /// - Writes messages
        /// - Applies all label types (Info, Debug, Warning, Critical, Fatal)
        /// </summary>
        [Test]
        public void Logger_Creates_Log_File_With_Message_And_Labels()
        {
            var baseDir = AppContext.BaseDirectory;
            var testLogPath = Path.Combine(baseDir, "Logs", "Logging");

            // Clear old logs to start fresh
            if (Directory.Exists(testLogPath)) Directory.Delete(testLogPath, recursive: true);

            Directory.CreateDirectory(testLogPath);

            // Set up logger and initialize static Log
            var logger = new Logger(testLogPath);
            Log.Initialize(logger);

            // Base log entry for later verification
            Log.Info("This is a test log for the Logging test.\n");

            // Locate the generated log file
            var file = Directory.GetFiles(testLogPath).FirstOrDefault();

            try
            {
                // Ensure the log file was created
                Assert.That(file, Is.Not.Null);

                var content = File.ReadAllText(file!);

                // Assert that the main test log message exists
                Assert.That(content, Does.Contain("This is a test log for the Logging test."));

                // Emit all supported log levels
                Log.Info("Info label check.\n");
                Log.Debug("Debug label check.\n");
                Log.Warning("Warning label check.\n");
                Log.Critical("Critical label check.\n");
                Log.Fatal("Fatal label check.\n");

                // Reload content to check all levels
                content = File.ReadAllText(file);

                // Assert presence of each log message
                Assert.That(content, Does.Contain("Info label check."));
                Assert.That(content, Does.Contain("Debug label check."));
                Assert.That(content, Does.Contain("Warning label check."));
                Assert.That(content, Does.Contain("Critical label check."));
                Assert.That(content, Does.Contain("Fatal label check."));
            }
            catch (Exception e)
            {
                Log.Fatal($"The Logging test failed: {e}\n");
                return;
            }

            // Indicate that all tests passed cleanly
            Log.Info("All log levels printed successfully.\n");
        }
    }
}
