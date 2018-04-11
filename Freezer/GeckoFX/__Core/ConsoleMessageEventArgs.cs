using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gecko
{
    internal class ConsoleMessageEventArgs : EventArgs
    {
        public string Message { get; protected set; }

        public ConsoleMessageEventArgs(string message)
        {
            Message = message;
        }
    }
}