namespace Jester.Boot
{
    public class EngineConfiguration
    {
        public string? LoggerPath { get; private set; }
        public bool UsingLogger { get; private set; }

        public EngineConfiguration UseLogger(string? path = null)
        {
            UsingLogger = true;
            LoggerPath = path;
            return this;
        }
    }   
}
