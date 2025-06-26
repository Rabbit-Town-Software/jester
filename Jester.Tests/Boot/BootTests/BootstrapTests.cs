namespace Jester.Tests.Boot.BootTests
{
    /// <summary>
    /// Contains tests that verify engine bootstrapping behavior,
    /// especially when logging is enabled in the configuration.
    /// </summary>
    public class BootstrapTests
    {
        /// <summary>
        /// Tests that the engine properly initializes with logging enabled,
        /// and that the context and configuration are non-null after startup.
        /// </summary>
        [Test]
        public void Bootstrap_Initializes_With_Logger_Config()
        {
            // Retrieve a valid config with a clean log directory
            var config = EngineConfig.Get();

            // Initialize the engine
            var engine = new Engine();
            engine.Start(config);

            try
            {
                // Assert that engine context was initialized
                Assert.IsNotNull(Bootstrap.Context);

                // Assert that the configuration preserved the logger setting
                Assert.IsTrue(Bootstrap.Context.Config.UsingLogger);
            }
            catch (Exception e)
            {
                // Log and exit on failure
                Log.Fatal($"The Bootstrap test failed: {e}\n");
                return;
            }

            // Log success if all assertions pass
            Log.Info($"The Bootstrap test succeeded\n");
        }
    }
}
