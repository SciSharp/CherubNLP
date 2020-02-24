using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace CherubNLP.UnitTest
{
    public abstract class TestEssential
    {
        protected IConfiguration Configuration { get; }
        protected string rootDir;
        protected string dataDir;
        protected string settingsDir;

        public TestEssential()
        {
            rootDir = Path.GetFullPath($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}");
            settingsDir = Path.Combine(rootDir, "Settings");
            dataDir = Path.Combine(rootDir, "data");

            // x64
            if (!Directory.Exists(settingsDir))
            {
                rootDir = Path.GetFullPath($"{rootDir}{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}");
                settingsDir = Path.Combine(rootDir, "Settings");
                dataDir = Path.Combine(rootDir, "data");
            }

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            var settings = Directory.GetFiles(settingsDir, "*.json");
            settings.ToList().ForEach(setting =>
            {
                configurationBuilder.AddJsonFile(setting, optional: false, reloadOnChange: true);
            });
            Configuration = configurationBuilder.Build();
        }
    }


}
