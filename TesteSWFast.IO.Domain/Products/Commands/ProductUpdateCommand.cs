using System;
using System.Collections.Generic;
using System.Text;

namespace TesteSWFast.IO.Domain.Products.Commands
{
    public class ProductUpdateCommand : BaseProductCommand
    {
        public ProductUpdateCommand(Guid id, Guid idCategoria, string nome, decimal preco)
        {
            Id = id;
            IdCategoria = idCategoria;
            Nome = nome;
            Preco = preco;
        }
    }
}
