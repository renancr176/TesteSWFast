using System;

namespace TesteSWFast.IO.Domain.Products.Events
{
    public class ProductInsertedEvent : BaseProductEvent
    {
        public ProductInsertedEvent(Guid id, Guid idCategoria, string nome, decimal preco)
        {
            Id = id;
            IdCategoria = idCategoria;
            Nome = nome;
            Preco = preco;

            AggregateId = id;
        }
    }
}
