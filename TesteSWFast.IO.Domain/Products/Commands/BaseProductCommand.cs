using System;
using TesteSWFast.IO.Core.Commands;

namespace TesteSWFast.IO.Domain.Products.Commands
{
    public class BaseProductCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid IdCategoria { get; protected set; }
        public string Nome { get; protected set; }
        public decimal Preco { get; protected set; }
    }
}
