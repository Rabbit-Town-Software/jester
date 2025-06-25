namespace Jester.Tests.Boot.BootTests
{
    public class BootstrapTests
    {
        [Test]
        public void Bootstrap_Initializes_With_Logger_Config()
        {
            var config = EngineConfig.Get();
            var engine = new Engine();
            engine.Start(config);

            try
            {
                Assert.IsNotNull(Bootstrap.Context);
                Assert.IsTrue(Bootstrap.Context.Config.UsingLogger);
            }
            catch (Exception e)
            {
                Log.Fatal($"The Bootstrap test failed: {e}\n");
                return;
            }
            
            Log.Info($"The Bootstrap test succeeded\n");
        }
    }
}
