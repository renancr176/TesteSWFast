using System;
using TesteSWFast.IO.Core.Events;

namespace TesteSWFast.IO.Core.Commands
{
    public class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
