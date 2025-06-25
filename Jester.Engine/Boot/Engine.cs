namespace Jester.Boot
{
    using Diagnostics.Logging;
    
    public class Engine
    {
        public void Start(EngineConfiguration config)
        {
            Bootstrap.Initialize(config);
        
            if (Bootstrap.Context == null)
            {
                Log.Fatal("Engine failed to initialize. Did you forget to give a config?\n");
                return;
            }

            Log.Info("Engine started successfully.\n");
        }
    }
}
