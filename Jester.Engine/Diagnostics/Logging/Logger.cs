using System.Runtime.CompilerServices;

namespace Jester.Logging;

using System.IO;

// Update to use streamWriter
public class Logger
{
    private static string _root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
    private static string _filePath = Path.Combine(_root, "test-log.txt");
    private static Dictionary<Label, string> _labels = new Dictionary<Label, string>
    {
        { Label.Debug, "\u001b[90m[Debug]\u001b[0m" },
        { Label.Info, "\u001b[97m[Info]\u001b[0m" },
        { Label.Warning, "\u001b[93m[Warning]\u001b[0m" },
        { Label.Critical, "\u001b[95m[Critical]\u001b[0m" },
        { Label.Fatal, "\u001b[91;1m[Fatal]\u001b[0m" }
    };
    public static void Log(
        Label label, 
        string message, 
        [CallerFilePath] string issueFilePath = "", 
        [CallerMemberName] string memberName = "", 
        [CallerLineNumber] int lineNumber = 0)
    {
        string labelText = _labels[label];
        string logText = ($"{labelText} | {issueFilePath} | Method: {memberName} | Line: {lineNumber} | {message} "); // add new line
        Console.WriteLine($"{logText}");
        File.WriteAllText(_filePath, logText);
        // add debugger logging here when it is created
    }
    
}
