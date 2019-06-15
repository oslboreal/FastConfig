using FastConfig;

namespace FastConfigConsoleTest
{
    class ConsoleAppConfiguration : Configuration
    {
        public string ProjectName { get; set; }
        public string ProjectAuthor { get; set; }
        public string ProjectVer { get; set; }
    }
}
