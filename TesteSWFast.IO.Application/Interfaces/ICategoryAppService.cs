using System;
using System.Collections.Generic;
using TesteSWFast.IO.Application.ViewModels;

namespace TesteSWFast.IO.Application.Interfaces
{
    public interface ICategoryAppService : IDisposable
    {
        CategoryViewModel GetById(Guid id);
        IEnumerable<CategoryViewModel> GetAll();
        void Insert(CategoryViewModel categoryViewModel);
        void Update(CategoryViewModel categoryViewModel);
        void Delete(Guid id);
    }
}
