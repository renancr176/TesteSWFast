using TesteSWFast.IO.Core.Commands;
using TesteSWFast.IO.Domain.Interfaces;
using TesteSWFast.IO.Infra.Data.Context;

namespace TesteSWFast.IO.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
