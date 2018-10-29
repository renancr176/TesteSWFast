using System;
using TesteSWFast.IO.Core.Events;

namespace TesteSWFast.IO.Domain.Products.Events
{
    public class BaseProductEvent : Event
    {
        public Guid Id { get; protected set; }
        public Guid IdCategoria { get; protected set; }
        public string Nome { get; protected set; }
        public decimal Preco { get; protected set; }
    }
}
