using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;

namespace FastConfig
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
        /// Load the configuration of the specified object.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>True if the configuration was loaded successful otherwise it returns false..</returns>
        public static T LoadConfiguration(Configuration configuration)
        {
            if (configuration == null)
                throw new NullReferenceException();

            string filePath = ((Configuration)(object)configuration).ConfigurationFilePath;

            T result;

            // If the path is null then stablish or own way.
            if (File.Exists(filePath))
                result = JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
            else
                result = default(T);

            return result;
        }

        /// <summary>
        /// Save the current instance of the specified object.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>True if the configuration was saved otherwise it returns false..</returns>
        public static bool SaveConfiguration(Configuration configuration)
        {
            string path = ((Configuration)(object)configuration).ConfigurationFilePath;

            if (configuration == null)
                configuration = new Configuration();

            File.WriteAllText(path, configuration.ToString());

            return true;
        }

        /// <summary>
        /// Update the specified configuration.
        /// </summary>
        /// <param name="configuration">Configuration to be updated.</param>
        /// <param name="actionType">Action to do.</param>
        /// <param name="path">Output path.</param>
        //public static bool UpdateConfiguration<T>(Configuration configuration, ActionType actionType)
        //{
        //    try
        //    {
        //        bool returnValue = false;

        //        // Locking control.
        //        mutex.WaitOne();

        //        switch (actionType)
        //        {
        //            case ActionType.SaveConfiguration:
        //                returnValue = SaveConfiguration(configuration);
        //                break;
        //            case ActionType.LoadConfiguration:
        //                returnValue = LoadConfiguration<T>(configuration) != null ? true : false;
        //                break;
        //        }

        //        // Locking release.
        //        mutex.ReleaseMutex();

        //        return returnValue;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
