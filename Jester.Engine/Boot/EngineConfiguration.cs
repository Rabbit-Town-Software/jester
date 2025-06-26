namespace Jester.Boot
{
    /// <summary>
    /// Configuration object used to determine which systems the engine should initialize.
    /// Users can fluently chain settings to customize their engine startup behavior.
    /// </summary>
    public class EngineConfiguration
    {
        /// <summary>
        /// Optional path where logs should be written, if logging is enabled.
        /// </summary>
        public string? LoggerPath { get; private set; }

        /// <summary>
        /// Flag indicating whether the logging system should be enabled at startup.
        /// </summary>
        public bool UsingLogger { get; private set; }

        /// <summary>
        /// Enables logging for the engine. Optionally, a custom log path may be provided.
        /// </summary>
        /// <param name="path">The directory path to write logs to. If null, defaults will be used.</param>
        /// <returns>Returns the updated <see cref="EngineConfiguration"/> for fluent chaining.</returns>
        public EngineConfiguration UseLogger(string? path = null)
        {
            UsingLogger = true;
            LoggerPath = path;
            return this;
        }

        // Additional configuration methods can be added here for other systems.
    }
}
