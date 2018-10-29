using System;
using TesteSWFast.IO.Core.Commands;

namespace TesteSWFast.IO.Domain.Categories.Commands
{
    public class CategoryBaseCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
    }
}
