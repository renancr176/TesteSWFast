using System;
using System.Collections.Generic;
using TesteSWFast.IO.Domain.Interfaces;
using TesteSWFast.IO.Domain.Products.Queries;

namespace TesteSWFast.IO.Domain.Products.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        ProductQuery GetById(Guid id);
        IEnumerable<ProductQuery> GetAll();
    }
}
