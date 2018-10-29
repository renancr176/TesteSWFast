using System;

namespace TesteSWFast.IO.Domain.Products.Commands
{
    public class ProductInsertCommand : BaseProductCommand
    {
        public ProductInsertCommand(Guid id, Guid idCategoria, string nome, decimal preco)
        {
            Id = id;
            IdCategoria = idCategoria;
            Nome = nome;
            Preco = preco;
        }
    }
}
