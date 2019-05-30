using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;

namespace ConfigurationManager
{
    public enum ActionType
    {
        SaveConfiguration,
        LoadConfiguration
    }

    public static class Manager<T>
    {
        private static Mutex mutex = new Mutex();
        public static string MyProperty { get; set; }

        /// <summary>
        /// Update the specified configuration.
        /// </summary>
        /// <param name="configuration">Configuration to be updated.</param>
        /// <param name="actionType">Action to do.</param>
        public static T UpdateConfiguration(Configuration configuration, ActionType actionType)
        {
            return UpdateConfiguration(configuration, actionType, null);
        }

        /// <summary>
        /// Update the specified configuration.
        /// </summary>
        /// <param name="configuration">Configuration to be updated.</param>
        /// <param name="actionType">Action to do.</param>
        /// <param name="path">Output path.</param>
        public static T UpdateConfiguration(Configuration configuration, ActionType actionType, string path = null)
        {
            try
            {
                T returnedObject;

                // Locking control.
                mutex.WaitOne();

                // If the path is null then stablish or own way.
                path = (path == null) ? configuration.ConfigurationFile : path;

                switch (actionType)
                {
                    case ActionType.SaveConfiguration:

                        File.WriteAllText(path, configuration.ToString());
                        returnedObject = JsonConvert.DeserializeObject<T>(configuration.ToString());
                        break;
                    case ActionType.LoadConfiguration:
                        if (File.Exists(path))
                            returnedObject = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
                        else
                            returnedObject = default(T);
                        break;
                    default:
                        throw new ApplicationException("The specified ActionType does not exist.");
                }

                // Locking release.
                mutex.ReleaseMutex();

                return returnedObject;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
