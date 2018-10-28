using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TesteSWFast.IO.Domain.Categories;
using TesteSWFast.IO.Domain.Categories.Repository;
using TesteSWFast.IO.Infra.Data.Context;

namespace TesteSWFast.IO.Infra.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context) : base(context)
        {
        }

        public override IEnumerable<Category> GetAll()
        {
            var sql = "SELECT * FROM dbo.Categorias";

            return Db.Database.GetDbConnection().Query<Category>(sql);
        }

        public override Category GetById(Guid id)
        {
            var sql = "SELECT * " +
                      "FROM dbo.Categorias AS c " +
                      "WHERE c.Id = @Id";

            var category = Db.Database.GetDbConnection().Query<Category>(sql, new { Id = id });

            return category.FirstOrDefault();
        }
    }
}
