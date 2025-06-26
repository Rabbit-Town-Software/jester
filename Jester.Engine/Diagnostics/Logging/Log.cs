namespace Jester.Diagnostics.Logging
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Static logging interface used throughout the engine.
    /// Automatically injects call site info like file, method, and line number.
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// The actual logger instance in use. This is injected via <see cref="Initialize"/>.
        /// </summary>
        private static Logger? _logger;

        /// <summary>
        /// Initializes the logging system with a logger instance.
        /// Must be called before logging methods will work.
        /// </summary>
        /// <param name="logger">The logger instance to bind globally.</param>
        public static void Initialize(Logger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        public static void Info(
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = "",
            [CallerLineNumber] int line = 0)
        {
            _logger?.Log(Label.Info, message, file, member, line);
        }

        /// <summary>
        /// Logs a debug message for internal inspection.
        /// </summary>
        public static void Debug(
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = "",
            [CallerLineNumber] int line = 0)
        {
            _logger?.Log(Label.Debug, message, file, member, line);
        }

        /// <summary>
        /// Logs a warning that indicates something unexpected occurred,
        /// but the engine can continue.
        /// </summary>
        public static void Warning(
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = "",
            [CallerLineNumber] int line = 0)
        {
            _logger?.Log(Label.Warning, message, file, member, line);
        }

        /// <summary>
        /// Logs a critical issue. These usually require user awareness but may not crash the engine.
        /// </summary>
        public static void Critical(
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = "",
            [CallerLineNumber] int line = 0)
        {
            _logger?.Log(Label.Critical, message, file, member, line);
        }

        /// <summary>
        /// Logs a fatal error that typically indicates a startup failure or unrecoverable state.
        /// </summary>
        public static void Fatal(
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = "",
            [CallerLineNumber] int line = 0)
        {
            _logger?.Log(Label.Fatal, message, file, member, line);
        }
    }
}
