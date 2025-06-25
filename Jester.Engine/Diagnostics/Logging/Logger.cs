namespace Jester.Diagnostics.Logging
{
    using System.IO;

    public class Logger
    {
        private readonly string _filePath;
        private static string _localDateTime = DateTime.Now.ToString("MM-dd-yyyy_HH-mm-ss");
    
        private static Dictionary<Label, string> _consoleLabels = new Dictionary<Label, string>
        {
            { Label.Debug, "\u001b[90m[Debug]\u001b[0m" },
            { Label.Info, "\u001b[97m[Info]\u001b[0m" },
            { Label.Warning, "\u001b[93m[Warning]\u001b[0m" },
            { Label.Critical, "\u001b[95m[Critical]\u001b[0m" },
            { Label.Fatal, "\u001b[91;1m[Fatal]\u001b[0m" }
        };
    
        private static Dictionary<Label, string> _fileLabels = new Dictionary<Label, string>
        {
            { Label.Debug, "[Debug]" },
            { Label.Info, "[Info]" },
            { Label.Warning, "[Warning]" },
            { Label.Critical, "[Critical]" },
            { Label.Fatal, "[Fatal]" }
        };

        public Logger(string rootDirectory)
        {
            _filePath = Path.Combine(rootDirectory, $"jester-log-{_localDateTime}.txt");
        }
        
        public void Log(
            Label label,
            string message,
            string issueFilePath,
            string memberName,
            int lineNumber)
        {
            var consoleLabelText = _consoleLabels[label];
            var consoleText = 
                ($"{consoleLabelText} | {issueFilePath} | Method: {memberName} | Line: {lineNumber} | {message} ");
        
            var fileLabelText = _fileLabels[label];
            var fileText = 
                ($"{fileLabelText} | {issueFilePath} | Method: {memberName} | Line: {lineNumber} | {message} \n");
        
            Console.WriteLine($"{consoleText}");
            File.AppendAllText(_filePath, fileText);
            // add debugger logging here when it is created
        }
    }   
}
