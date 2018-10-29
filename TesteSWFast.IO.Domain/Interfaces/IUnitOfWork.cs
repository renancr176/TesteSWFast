using System;
using TesteSWFast.IO.Core.Commands;

namespace TesteSWFast.IO.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
