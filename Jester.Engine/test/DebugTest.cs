namespace jester.test;

using Jester.Logging;

public class DebugTest
{
    static void Main(string[] args)
    {
        TestDebugLog();
        TestInfoLog();
        TestWarningLog();
        TestCriticalLog();
        TestFatalLog();
    }
    private static void TestDebugLog()
    {
        Logger.Log(Label.Debug, "Testing Debug log");
    }

    private static void TestInfoLog()
    {
        Logger.Log(Label.Info, "Testing Info log");
    }

    private static void TestWarningLog()
    {
        Logger.Log(Label.Warning, "Testing Warning log");
    }

    private static void TestCriticalLog()
    {
        Logger.Log(Label.Critical, "Testing Critical log");
    }

    private static void TestFatalLog()
    {
        Logger.Log(Label.Fatal, "Testing Fatal log");
    }
}