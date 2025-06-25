namespace Jester.Diagnostics.Logging
{
    using System.Runtime.CompilerServices;
    
    public static class Log
    {
        private static Logger? _logger;

        public static void Initialize(Logger logger)
        {
            _logger = logger;
        }

        public static void Info(
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = "",
            [CallerLineNumber] int line = 0)
        {
            _logger?.Log(Label.Info, message, file, member, line);
        }
    
        public static void Debug(
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = "",
            [CallerLineNumber] int line = 0)
        {
            _logger?.Log(Label.Debug, message, file, member, line);
        }
    
        public static void Warning(
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = "",
            [CallerLineNumber] int line = 0)
        {
            _logger?.Log(Label.Warning, message, file, member, line);
        }
    
        public static void Critical(
            string message,
            [CallerFilePath] string file = "",
            [CallerMemberName] string member = "",
            [CallerLineNumber] int line = 0)
        {
            _logger?.Log(Label.Critical, message, file, member, line);
        }
    
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
