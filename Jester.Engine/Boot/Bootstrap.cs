namespace Jester.Boot
{
    using Diagnostics.Logging;

    /// <summary>
    /// The Bootstrap class is responsible for initializing core engine services and global context.
    /// It sets up the <see cref="EngineContext"/> and performs any conditional system bootstrapping
    /// based on the given configuration, such as the logger.
    /// </summary>
    public static class Bootstrap
    {
        /// <summary>
        /// Holds a reference to the global engine context after initialization.
        /// This context includes runtime configuration and initialized services like logging.
        /// </summary>
        public static EngineContext Context { get; private set; }

        /// <summary>
        /// Initializes the engine systems based on the provided configuration.
        /// Sets up the <see cref="EngineContext"/>, logger, and any other globally required services.
        /// </summary>
        /// <param name="config">
        /// The configuration object defining which systems to enable and how they should be initialized.
        /// </param>
        public static void Initialize(EngineConfiguration config)
        {
            // Create a new engine context and store the configuration in it.
            // This context acts as a container for engine-wide dependencies.
            Context = new EngineContext()
            {
                Config = config
            };

            // If logging is enabled via config, initialize the logging system.
            if (config.UsingLogger)
            {
                // Determine the directory path to store logs.
                // If none is provided, default to a "Logs" directory in the current working directory.
                var path = config.LoggerPath ?? Path.Combine(Directory.GetCurrentDirectory(), "Logs");

                // Ensure the log directory exists; create it if not.
                Directory.CreateDirectory(path);

                // Create a new Logger instance targeting the resolved path.
                var logger = new Logger(path);

                // Store the logger instance in the global engine context for shared access.
                Context.Logger = logger;

                // Initialize the static Log facade with the new logger instance.
                // This allows other parts of the engine to use static-style logging.
                Log.Initialize(logger);

                // Write an informational message indicating the logger is set up and active.
                Log.Info($"Logger initialized and output path was set to: {path}.\n");
            }

            // Additional boot systems could be initialized here in the future.
        }
    }
}
