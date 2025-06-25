namespace Jester.Boot
{
    using Diagnostics.Logging;
    
    public class EngineContext
    {
        public EngineConfiguration? Config { get; set; }
        public Logger? Logger { get; set; }
    }
}
