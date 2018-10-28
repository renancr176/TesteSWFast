using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TesteSWFast.IO.Domain.Products;
using TesteSWFast.IO.Domain.Products.Queries;
using TesteSWFast.IO.Domain.Products.Repository;
using TesteSWFast.IO.Infra.Data.Context;

namespace TesteSWFast.IO.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }
        
        public ProductQuery GetById(Guid id)
        {
            var sql = "SELECT " +
                " p.Id, " +
                " p.IdCategoria, " +
                " p.Nome, " +
                " p.Preco, " +
                " c.Nome as NomeCategoria " +
            " FROM " +
                " dbo.Produtos AS p " +
            " INNER JOIN " +
                " dbo.Categorias AS c ON " +
                    " p.IdCategoria = c.Id " +
            " WHERE p.Id = @Id";

            var product = Db.Database.GetDbConnection().Query<ProductQuery>(sql, new { Id = id });

            return product.FirstOrDefault();
        }

        public IEnumerable<ProductQuery> GetAll()
        {
            var sql = "SELECT "+
                " p.Id, " +
                " p.IdCategoria, " +
                " p.Nome, " +
                " p.Preco, " +
                " c.Nome as NomeCategoria " +
            " FROM " +
                " dbo.Produtos AS p " +
            " INNER JOIN " +
                " dbo.Categorias AS c ON " +
                    " p.IdCategoria = c.Id";

            return Db.Database.GetDbConnection().Query<ProductQuery>(sql);
        }
    }
}
