using System;
using System.Collections.Generic;
using TesteSWFast.IO.Application.ViewModels;

namespace TesteSWFast.IO.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        ProductViewModel GetById(Guid id);
        IEnumerable<ProductViewModel> GetAll();
        IEnumerable<ProductViewModel> GetProductByCategory(Guid idCategory);
        void Insert(ProductViewModel productViewModel);
        void Update(ProductViewModel productViewModel);
        void Delete(Guid id);
    }
}
