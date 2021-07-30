using SRTPluginBase;
using System;
using System.Diagnostics;
using System.Linq;

namespace SRTExampleProvider64
{
    public class SRTExampleProvider64 : IPluginProvider
    {
        private Process process;
        private GameMemoryExampleScanner gameMemoryScanner;
        private IPluginHostDelegates hostDelegates;
        public IPluginInfo Info => new PluginInfo();
        public bool GameRunning
        {
            get
            {
                if (gameMemoryScanner != null && !gameMemoryScanner.ProcessRunning)
                {
                    process = GetProcess();
                    if (process != null)
                        gameMemoryScanner.Initialize(process); // Re-initialize and attempt to continue.
                }

                return gameMemoryScanner != null && gameMemoryScanner.ProcessRunning;
            }
        }

        public int Startup(IPluginHostDelegates hostDelegates)
        {
            this.hostDelegates = hostDelegates;
            process = GetProcess();
            gameMemoryScanner = new GameMemoryExampleScanner(process);
            return 0;
        }

        public int Shutdown()
        {
            gameMemoryScanner?.Dispose();
            gameMemoryScanner = null;
            return 0;
        }

        public object PullData()
        {
            try
            {
                if (!GameRunning) // Not running? Bail out!
                    return null;

                return gameMemoryScanner.Refresh();
            }
            catch (Exception ex)
            {
                hostDelegates.OutputMessage("[{0}] {1} {2}", ex.GetType().Name, ex.Message, ex.StackTrace);
                return null;
            }
        }

        private Process GetProcess() => Process.GetProcessesByName("GameEXENameGoesHere")?.FirstOrDefault();
    }
}
