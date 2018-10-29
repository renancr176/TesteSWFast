using System;

namespace TesteSWFast.IO.Domain.Products.Events
{
    public class ProductUpdatedEvent : BaseProductEvent
    {
        public ProductUpdatedEvent(Guid id, Guid idCategoria, string nome, decimal preco)
        {
            Id = id;
            IdCategoria = idCategoria;
            Nome = nome;
            Preco = preco;

            AggregateId = id;
        }
    }
}
