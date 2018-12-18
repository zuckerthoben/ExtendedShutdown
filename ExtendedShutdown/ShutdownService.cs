// <copyright file="ShutdownService.cs" company="Christoph Nienaber">
// Copyright (c) Christoph Nienaber. All rights reserved.
// </copyright>

namespace ExtendedShutdown
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Service 
    /// </summary>
    public static class ShutdownService
    {
        public static void Cancel()
        {
            var argument = "/a";

            StartShutdownCommand(argument);
        }

        /// <summary>
        /// Logs off the current user
        /// </summary>
        /// <param name="inSeconds">The amount of seconds to wait</param>
        public static void LogOff(int inSeconds)
        {
            var argument = "/l";

            if (inSeconds > 0)
            {
                argument += $"/t {inSeconds}";
            }

            StartShutdownCommand(argument);
        }

        /// <summary>
        /// Restarts the computer
        /// </summary>
        /// <param name="inSeconds">the amount of seconds to wait</param>
        public static void Restart(int inSeconds)
        {
            var argument = "/r";

            if (inSeconds > 0)
            {
                argument += $"/t {inSeconds}";
            }

            StartShutdownCommand(argument);
        }

        /// <summary>
        /// Shuts down the computer
        /// </summary>
        /// <param name="inSeconds">amount of seconds to wait</param>
        /// <param name="isHybrid">indicates if its hybrid</param>
        public static void Shutdown(int inSeconds, bool isHybrid)
        {
            var argument = "/s ";

            if (isHybrid)
            {
                argument += "/h ";
            }

            if (inSeconds > 0)
            {
                argument += $"/t {inSeconds}";
            }

            StartShutdownCommand(argument);
        }
        private static void StartShutdownCommand(string argument)
        {
            var processInfo = new ProcessStartInfo("shutdown", argument)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
            };

            var process = Process.Start(processInfo);
            Debug.WriteLine(process.StartTime);
        }
    }
}
