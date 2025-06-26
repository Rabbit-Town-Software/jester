namespace Jester.Diagnostics.Logging
{
    using System.IO;

    /// <summary>
    /// The core logging class that handles both console and file output.
    /// Handles formatting, coloring, and file path setup.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Full path to the log file this logger writes to.
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// Timestamp to use for the log file name (once per session).
        /// </summary>
        private static string _localDateTime = DateTime.Now.ToString("MM-dd-yyyy_HH-mm-ss");

        /// <summary>
        /// Console label formatting with ANSI color codes.
        /// Used to visually distinguish logs in the terminal.
        /// </summary>
        private static Dictionary<Label, string> _consoleLabels = new Dictionary<Label, string>
        {
            { Label.Debug, "\u001b[90m[Debug]\u001b[0m" },
            { Label.Info, "\u001b[97m[Info]\u001b[0m" },
            { Label.Warning, "\u001b[93m[Warning]\u001b[0m" },
            { Label.Critical, "\u001b[95m[Critical]\u001b[0m" },
            { Label.Fatal, "\u001b[91;1m[Fatal]\u001b[0m" }
        };

        /// <summary>
        /// Plain text labels used in file logs (no color).
        /// </summary>
        private static Dictionary<Label, string> _fileLabels = new Dictionary<Label, string>
        {
            { Label.Debug, "[Debug]" },
            { Label.Info, "[Info]" },
            { Label.Warning, "[Warning]" },
            { Label.Critical, "[Critical]" },
            { Label.Fatal, "[Fatal]" }
        };

        /// <summary>
        /// Constructs a logger that writes logs to a uniquely timestamped file in the provided directory.
        /// </summary>
        /// <param name="rootDirectory">The directory where the log file should be created.</param>
        public Logger(string rootDirectory)
        {
            // Compose the full path to the output file
            _filePath = Path.Combine(rootDirectory, $"jester-log-{_localDateTime}.txt");
        }

        /// <summary>
        /// Logs a message to both the console and the log file, with context information.
        /// </summary>
        /// <param name="label">The severity label for the log (Debug, Info, Warning, etc).</param>
        /// <param name="message">The message to log.</param>
        /// <param name="issueFilePath">The source file where the log was triggered.</param>
        /// <param name="memberName">The method or property name where the log was triggered.</param>
        /// <param name="lineNumber">The source code line number of the log call.</param>
        public void Log(
            Label label,
            string message,
            string issueFilePath,
            string memberName,
            int lineNumber)
        {
            // Format message for console, including colored label and context
            var consoleLabelText = _consoleLabels[label];
            var consoleText = 
                $"{consoleLabelText} | {issueFilePath} | Method: {memberName} | Line: {lineNumber} | {message}";

            // Format message for file output with plain text
            var fileLabelText = _fileLabels[label];
            var fileText = 
                $"{fileLabelText} | {issueFilePath} | Method: {memberName} | Line: {lineNumber} | {message}\n";

            // Output to terminal
            Console.WriteLine(consoleText);

            // Append to log file (persistent storage)
            File.AppendAllText(_filePath, fileText);

            // Placeholder for debugger logging integration
        }
    }
}
