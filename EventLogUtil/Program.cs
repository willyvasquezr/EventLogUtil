// ***********************************************************************
// Assembly         : EventLogUtil
// Author           : william.vasquez
// Created          : 01-24-2019
//
// Last Modified By : william.vasquez
// Last Modified On : 01-24-2019
// ***********************************************************************
// <copyright file="Program.cs" company="">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EventLogUtil
{
    /// <summary>
    /// Class Program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            new ConfigEventLog().RunConfiguration(args);
        }
    }
}