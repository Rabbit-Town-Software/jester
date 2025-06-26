namespace Jester.Boot
{
    using Diagnostics.Logging;

    /// <summary>
    /// The central starting point for the Jester engine.
    /// Initializes core systems by passing configuration to the Bootstrapper.
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Starts the engine using the provided configuration.
        /// Will initialize the <see cref="Bootstrap"/> system and log status if logging is enabled.
        /// </summary>
        /// <param name="config">An instance of <see cref="EngineConfiguration"/> that controls engine startup options.</param>
        public void Start(EngineConfiguration config)
        {
            // Run the Bootstrap initializer with user-provided settings
            Bootstrap.Initialize(config);

            // Verify that the context was set. If it's null, something failed during boot.
            if (Bootstrap.Context == null)
            {
                Log.Fatal("Engine failed to initialize. Did you forget to give a config?\n");
                return;
            }

            // Success log — the engine is now considered 'running'.
            Log.Info("Engine started successfully.\n");
        }
    }
}
