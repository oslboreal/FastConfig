using Newtonsoft.Json;
using System;

namespace FastConfig
{
    public class Configuration
    {
        public string ConfigurationFile { get; set; }
        public Type ConfigurationType { get; set; }

        public Configuration()
        {
            ConfigurationFile = this.GetType().Name;
            ConfigurationType = this.GetType();
        }

        /// <summary>
        /// Returns a text that represents the current Configuration instance.
        /// </summary>
        /// <returns>JSON Text</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
