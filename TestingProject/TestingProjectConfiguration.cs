using FastConfig;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestingProject
{
    public class TestingProjectConfiguration : Configuration
    {
        public int Version { get; set; } = 28;
        public string AppName { get; set; } = "Testing APP";
        public double DoubleProp { get; set; } = 0.38;
        public long LongProp { get; set; } = 123123123123213112;
        public short ShortProp { get; set; } = 3;

        public TestingProjectConfiguration()
        {
           
        }
    }
}
