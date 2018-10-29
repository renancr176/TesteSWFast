using System;

namespace TesteSWFast.IO.Domain.Products.Queries
{
    public class ProductQuery
    {
        public Guid Id { get; set; }
        public Guid IdCategoria { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string NomeCategoria { get; set; }
    }
}
