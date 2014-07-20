using System;
using System.Text;

namespace Extender.Debugging
{
    public class ExceptionTools
    {
        /// <summary>
        /// Generates a string containing Exception information for the given exception, 
        /// and all innerexceptions.
        /// </summary>
        /// <param name="e">Exception to debug.</param>
        /// <param name="stacktrace">True if stacktraces are to be included.</param>
        public static string CreateExceptionText(Exception e, bool stacktrace)
        {
            Exception c = e;
            StringBuilder buffer = new StringBuilder();

            while (c != null)
            {
                buffer.AppendLine(c.Message);
                if (stacktrace)
                    buffer.AppendLine(c.StackTrace);

                buffer.AppendLine("--");
                c = c.InnerException;
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Generates a string containing Exception information for the given exception
        /// (and all innerexceptions) and writes it to the console.
        /// </summary>
        /// <param name="e">Exception to debug.</param>
        /// <param name="stacktrace">True if stacktraces are to be included.</param>
        public static string WriteExceptionText(Exception e, bool stacktrace)
        {
            string exTxt = CreateExceptionText(e, stacktrace);
            Console.WriteLine(exTxt);

            return exTxt;
        }


        /// <summary>
        /// Generates a string containing Exception information for the given exception
        /// (and all innerexceptions) and writes it to the console.
        /// </summary>
        /// <param name="e">Exception to debug.</param>
        /// <param name="stacktrace">True if stacktraces are to be included.</param>
        /// <param name="message">Message to display along with the exception text.</param>
        public static string WriteExceptionText(Exception e, bool stacktrace, string message)
        {
            StringBuilder buffer = new StringBuilder();
            buffer.AppendLine(Debug.CreateDebugText(message, "exception"));
            buffer.AppendLine(CreateExceptionText(e, stacktrace));

            Console.Write(buffer.ToString());
            return buffer.ToString();
        }
    }
}
