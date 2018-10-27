using TesteSWFast.IO.Core.Commands;
using TesteSWFast.IO.Core.Events;

namespace TesteSWFast.IO.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}
