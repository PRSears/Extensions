using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Extender.Debugging
{
    /// <remarks>
    /// From Brian Gideon on StackOverflow 
    /// https://stackoverflow.com/questions/3670057/does-console-writeline-block
    /// </remarks>
    public static class NonBlockingConsole
    {
        private static readonly BlockingCollection<string> WriteQueue =
            new BlockingCollection<string>();

        static NonBlockingConsole()
        {
            var thread = new Thread
                (
                 () =>
                 {
                     while (true) Console.WriteLine(WriteQueue.Take());
                 }
                ) { IsBackground = true };

            thread.Start();
        }

        /// <summary>
        /// Uses a background thread to write to the console without blocking.
        /// </summary>
        /// <param name="value">Value to write to the console.</param>
        public static void WriteLine(string value) { WriteQueue.Add(value); }
    }

    // TODO Add support for multiple console output streams

    public static class Debug
    {
        /// <summary>
        /// Generates a string of debug text containing the current time and a 
        /// specified message.
        /// </summary>
        /// <returns>Ex: " [DEBUG @ 12:35 2014-06-11] Something went wrong!"</returns>
        public static string CreateDebugText(string message, string warnLevel = "debug")
        {
            return $"[{warnLevel.ToUpper(),-5} @ {DateTime.Now.ToString()}] {message}";
        }

        /// <summary>
        /// Formats the provided message, and writes it to the currently active Console.
        /// Current system time is automatically added to the message.
        /// </summary>
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="warnLevel">Optionally, specify what type of message this is.</param>
        public static void WriteMessage(string message, string warnLevel = "debug")
        {
            NonBlockingConsole.WriteLine(CreateDebugText(message, warnLevel));
        }


        /// <summary>
        /// Formats the provided message, and writes it to the currently active Console.
        /// Current system time is automatically added to the message.
        /// </summary>
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="condition">Controls whether the message is sent to the console.</param>
        /// <param name="warnLevel">Optionally, specify what type of message this is.</param>
        public static void WriteMessage(string message, bool condition, string warnLevel = "debug")
        {
            if (condition)
                WriteMessage(message, warnLevel);
        }

        /// <summary>
        /// Formats the provided message, and writes it to the currently active Console.
        /// Current system time is automatically added to the message.
        /// </summary>
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="warnLevel">Optionally, specify what type of message this is.</param>
        /// <param name="condition">Controls whether the message is sent to the console.</param>
        public static void WriteMessage(string message, WarnLevel warnLevel, bool condition = true)
        {
            WriteMessage(message, condition, Enum.GetName(typeof(WarnLevel), warnLevel)?.ToUpper());
        }
    }

    public enum WarnLevel
    {
        Debug,
        Info,
        Warn,
        Sql,
        Error,
        Excep
    }

    public static class RectangleDebug
    {
        public static string ToDebugString(this System.Drawing.Rectangle r)
        {
            return $"({r.X}, {r.Y}) [Width {r.Width}, Height {r.Height}]";
        }

        public static void WriteToConsole(this System.Drawing.Rectangle rect)
        {
            NonBlockingConsole.WriteLine(rect.ToDebugString());
        }

        public static void WriteToConsole(this System.Drawing.Rectangle rect, string message)
        {
            NonBlockingConsole.WriteLine($"{message} > {rect.ToDebugString()}");
        }
    }
}