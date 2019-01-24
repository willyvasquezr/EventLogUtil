// ***********************************************************************
// Assembly         : EventLogUtil
// Author           : william.vasquez
// Created          : 01-24-2019
//
// Last Modified By : william.vasquez
// Last Modified On : 01-24-2019
// ***********************************************************************
// <copyright file="ConfigEventLog.cs" company="">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EventLogUtil
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    /// <summary>
    /// Class ConfigEventLog.
    /// </summary>
    internal class ConfigEventLog
    {
        /// <summary>
        /// The log name
        /// </summary>
        private readonly string _logName = Settings.Default.LogName;

        /// <summary>
        /// The sources names
        /// </summary>
        private readonly string[] _sourcesNames = Settings.Default.SourcesNames.Split(',');

        /// <summary>
        /// Runs the configuration.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public void RunConfiguration(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    Console.WriteLine("You must to specified an option: \n\t/i\tInstall\n\t/u\tUninstall\n");
                    break;

                case 1:
                    switch (args[0])
                    {
                        case "/i":
                            CreateLog();
                            return;

                        case "/u":
                            RemoverLogs();
                            return;

                        default:
                            Console.WriteLine("Invalid option.");
                            return;
                    }
                default:
                    Console.WriteLine("Only one option can be specified.");
                    break;
            }
        }

        /// <summary>
        /// Configures the log properties.
        /// </summary>
        private void ConfigureLogProperties()
        {
            new EventLog(_logName)
            {
                MaximumKilobytes = 8192L
            }.ModifyOverflowPolicy(OverflowAction.OverwriteAsNeeded, 0);
            Console.WriteLine("Configured properties.");
        }

        /// <summary>
        /// Creates the log.
        /// </summary>
        private void CreateLog()
        {
            foreach (string source in _sourcesNames)
            {
                CreateSource(source);
            }

            Thread.Sleep(1000);
            ConfigureLogProperties();
        }

        /// <summary>
        /// Creates the source.
        /// </summary>
        /// <param name="sourceName">Name of the source.</param>
        private void CreateSource(string sourceName)
        {
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, _logName);
                Console.WriteLine($"Source {(object)sourceName} configured");
                EventLog.WriteEntry(sourceName, $"Test {(object)sourceName}");
                Console.WriteLine($"Test event set in {(object)sourceName}");
            }
            else
            {
                Console.WriteLine($"Source {(object)sourceName} already exits.");
            }
        }

        /// <summary>
        /// Removes the log.
        /// </summary>
        /// <param name="logName">Name of the log.</param>
        private void RemoveLog(string logName)
        {
            if (EventLog.Exists(logName))
            {
                EventLog.Delete(logName);
                Console.WriteLine($"Log {(object)logName} deleted.");
            }
            else
            {
                Console.WriteLine($"Log {(object)logName} does not exits.");
            }
        }

        /// <summary>
        /// Removers the logs.
        /// </summary>
        private void RemoverLogs()
        {
            foreach (string source in _sourcesNames)
            {
                RemoveSource(source);
            }

            RemoveLog(_logName);
        }

        /// <summary>
        /// Removes the source.
        /// </summary>
        /// <param name="sourceName">Name of the source.</param>
        private void RemoveSource(string sourceName)
        {
            if (EventLog.SourceExists(sourceName))
            {
                EventLog.DeleteEventSource(sourceName);
                Console.WriteLine($"Source {(object)sourceName} deleted.");
            }
            else
            {
                Console.WriteLine($"Source {(object)sourceName} does not exists.");
            }
        }
    }
}