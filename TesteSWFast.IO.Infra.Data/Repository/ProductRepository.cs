using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TesteSWFast.IO.Domain.Products;
using TesteSWFast.IO.Domain.Products.Repository;
using TesteSWFast.IO.Infra.Data.Context;

namespace TesteSWFast.IO.Infra.Data.Repository
{
    class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public override IEnumerable<Product> GetAll()
        {
            var sql = "SELECT * FROM dbo.Produtos";

            return Db.Database.GetDbConnection().Query<Product>(sql);
        }

        public override Product GetById(Guid id)
        {
            var sql = "SELECT * " +
                      "FROM dbo.Produtos AS p " +
                      "WHERE c.Id = @Id";

            var gallery = Db.Database.GetDbConnection().Query<Product>(sql, new { Id = id });

            return gallery.FirstOrDefault();
        }
    }
}
