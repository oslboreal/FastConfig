using Newtonsoft.Json;
using System;

namespace FastConfig
{
    public class Configuration
    {
        private string configurationFilePath;

        public string ConfigurationFilePath
        {
            get
            {
                return configurationFilePath;
            }
            set
            {
                if (value == null)
                    this.configurationFilePath = this.GetType().Name;
                else
                    this.configurationFilePath = value;
            }
        }
        public Type ConfigurationType { get; set; }

        public Configuration()
        {
            ConfigurationFilePath = this.GetType().Name;
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
