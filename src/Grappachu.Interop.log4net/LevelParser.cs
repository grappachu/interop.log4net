using System;
using System.Reflection;
using log4net.Core;

namespace Grappachu.Interop.log4net
{
    /// <summary>
    ///     Defines a parser for <see cref="Level" />
    /// </summary>
    public static class LevelParser
    {
        /// <summary>
        ///     Lookup with log levels
        /// </summary>
        private static readonly LevelMap LevelMap;


        static LevelParser()
        {
            LevelMap = new LevelMap();
            foreach (var fieldInfo in typeof(Level).GetFields(BindingFlags.Public | BindingFlags.Static))
                if (fieldInfo.FieldType == typeof(Level))
                    LevelMap.Add((Level) fieldInfo.GetValue(null));
        }

        /// <summary>
        ///     Converts the string into the rispective <see cref="Level" />
        /// </summary>
        /// <param name="value"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool TryParse(string value, out Level level)
        {
            var stronglyTypedLevel = LevelMap[value];
            if (stronglyTypedLevel == null)
            {
                level = null;
                return false;
            }
            level = stronglyTypedLevel;
            return true;
        }

        /// <summary>
        ///     Parse a string into a log level
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">When parameter is not recognized</exception>
        public static Level Parse(string logLevel)
        {
            var stronglyTypedLevel = LevelMap[logLevel];
            if (stronglyTypedLevel == null)
                throw new ArgumentException("Invalid logging level specified: " + logLevel);

            return stronglyTypedLevel;
        }
    }
}