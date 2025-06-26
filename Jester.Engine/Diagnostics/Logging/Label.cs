namespace Jester.Diagnostics.Logging
{
    /// <summary>
    /// Represents the severity or category of a log message.
    /// Determines formatting and usage context.
    /// </summary>
    public enum Label
    {
        /// <summary>
        /// Used for debugging information only. Not shown in production builds.
        /// </summary>
        Debug,

        /// <summary>
        /// General-purpose information about system events.
        /// </summary>
        Info,

        /// <summary>
        /// Something unexpected occurred, but it's not fatal.
        /// </summary>
        Warning,

        /// <summary>
        /// A serious issue that may impact functionality but doesn't crash the engine.
        /// </summary>
        Critical,

        /// <summary>
        /// An unrecoverable failure. Usually leads to engine shutdown or crash.
        /// </summary>
        Fatal
    }
}