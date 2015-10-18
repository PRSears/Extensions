using System;
using System.IO;
using System.Text;

namespace Extender.IO
{
    /// <summary>
    /// 
    /// </summary>
    public class ActionTextWriter : TextWriter
    {
        private readonly Action<string> _Action;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public ActionTextWriter(Action<string> action)
        {
            this._Action = action;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        public override void Write(char[] buffer, int index, int count)
        {
            Write(new string(buffer, index, count));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public override void Write(string value)
        {
            _Action.Invoke(value);
        }

        /// <summary>
        /// 
        /// </summary>
        public override Encoding Encoding => System.Text.Encoding.Default;
    }
}
