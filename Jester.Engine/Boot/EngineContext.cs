namespace Jester.Boot
{
    using Diagnostics.Logging;

    /// <summary>
    /// Represents the shared global state of the engine after initialization.
    /// Stores active configuration and references to core systems like logging.
    /// </summary>
    public class EngineContext
    {
        /// <summary>
        /// The original configuration object passed to the engine during startup.
        /// Used to inspect startup settings at runtime.
        /// </summary>
        public EngineConfiguration? Config { get; set; }

        /// <summary>
        /// The logger instance created during boot (if enabled).
        /// Accessible globally via this context or through the static <see cref="Log"/> facade.
        /// </summary>
        public Logger? Logger { get; set; }

        // Future systems (e.g., audio, input, rendering) can be added here as properties.
    }
}
