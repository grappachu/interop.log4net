using log4net;
using log4net.Core;
using log4net.Repository.Hierarchy;

namespace Grappachu.Interop.log4net.Helpers
{
    /// <summary>
    ///     A simple helper for log operations
    /// </summary>
    public static class RootConfigurator
    {
        private static void SetRootLevel(Level level)
        {
            ((Hierarchy) LogManager.GetRepository()).Root.Level = level;
        }


        /// <summary>
        ///     Sets the root log level at the specified level
        /// </summary>
        /// <param name="logLevel"></param>
        public static bool SetLogLevel(string logLevel)
        {
            var logLevelString = logLevel;
            Level lev;
            if (LevelParser.TryParse(logLevelString, out lev))
            {
                SetRootLevel(lev);
                return true;
            }
            return false;
        }
    }
}