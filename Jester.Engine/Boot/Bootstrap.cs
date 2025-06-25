namespace Jester.Boot
{
    using Diagnostics.Logging;
    
    public static class Bootstrap
    {
        public static EngineContext Context { get; private set; }

        public static void Initialize(EngineConfiguration config)
        {
            Context = new EngineContext()
            {
                Config = config
            };

            if (config.UsingLogger)
            {
                var path = config.LoggerPath ?? Path.Combine(Directory.GetCurrentDirectory(), "Logs");
                Directory.CreateDirectory(path);

                var logger = new Logger(path);
                Context.Logger = logger;
                Log.Initialize(logger);
                Log.Info($"Logger initialized and output path was set to: {path}.\n");
            }
        }
    }
}
