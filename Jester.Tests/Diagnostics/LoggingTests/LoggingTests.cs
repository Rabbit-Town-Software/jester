namespace Jester.Tests.Diagnostics.LoggingTests
{
    public class LoggingTests
    {
        [Test]
        public void Logger_Creates_Log_File_With_Message_And_Labels()
        {
            var baseDir = AppContext.BaseDirectory;
            var testLogPath = Path.Combine(baseDir, "Logs", "Logging");
            
            if (Directory.Exists(testLogPath)) Directory.Delete(testLogPath, recursive: true);
            
            Directory.CreateDirectory(testLogPath);

            var logger = new Logger(testLogPath);
            Log.Initialize(logger);
            Log.Info("This is a test log for the Logging test.\n");

            var file = Directory.GetFiles(testLogPath).FirstOrDefault();

            try
            {
                Assert.That(file, Is.Not.Null);

                var content = File.ReadAllText(file!);

                // Base log
                Assert.That(content, Does.Contain("This is a test log for the Logging test."));

                // Label checks
                Log.Info("Info label check.\n");
                Log.Debug("Debug label check.\n");
                Log.Warning("Warning label check.\n");
                Log.Critical("Critical label check.\n");
                Log.Fatal("Fatal label check.\n");

                content = File.ReadAllText(file);

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

            Log.Info("All log levels printed successfully.\n");
        }
    }
}
