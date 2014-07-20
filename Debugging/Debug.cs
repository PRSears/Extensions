using System;

namespace Extender.Debugging
{
    public class Debug
    {
        /// <summary>
        /// Generates a string of debug text containing the current time and a 
        /// specified message.
        /// </summary>
        /// <returns>Ex: " [DEBUG @ 12:35 2014-06-11] Something went wrong!"</returns>
        public static string CreateDebugText(string message, string warnLevel = "debug")
        {
            return string.Format
                (
                    " [{0} @ {1}] {2}",
                    warnLevel.ToUpper(),
                    DateTime.Now.ToString(),
                    message
                );
        }

        /// <summary>
        /// Formats the provided message, and writes it to the currently active Console.
        /// Current system time is automatically added to the message.
        /// </summary>
        /// <param name="message">Message to write to the Console.</param>
        /// <param name="warnLevel">Optionally, specify what type of message this is.</param>
        public static void WriteMessage(string message, string warnLevel = "debug")
        {
            Console.WriteLine(CreateDebugText(message, warnLevel));
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
    }

    public static class RectangleDebug
    {
        public static string ToDebugString(this System.Drawing.Rectangle r)
        {
            return String.Format
                (
                    "({0}, {1}) [Width {2}, Height {3}]",
                    r.X, r.Y,
                    r.Width, r.Height
                );
        }

        public static void WriteToConsole(this System.Drawing.Rectangle rect)
        {
            Console.WriteLine(rect.ToDebugString());
        }

        public static void WriteToConsole(this System.Drawing.Rectangle rect, string message)
        {
            Console.Write(String.Format("{0} > {1}", message, rect.ToDebugString()));
        }
    }
}
