using System;
using System.Collections.Generic;
using AutoMapper;
using TesteSWFast.IO.Application.Interfaces;
using TesteSWFast.IO.Application.ViewModels;
using TesteSWFast.IO.Core.Bus;
using TesteSWFast.IO.Domain.Categories.Commands;
using TesteSWFast.IO.Domain.Categories.Repository;

namespace TesteSWFast.IO.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAppService(IBus bus, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public CategoryViewModel GetById(Guid id)
        {
            return _mapper.Map<CategoryViewModel>(_categoryRepository.GetById(id));
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(_categoryRepository.GetAll());
        }

        public void Insert(CategoryViewModel categoryViewModel)
        {
            var insertCommand = _mapper.Map<CategoryInsertCommand>(categoryViewModel);
            _bus.SendCommand(insertCommand);
        }

        public void Update(CategoryViewModel categoryViewModel)
        {
            var updateCommand = _mapper.Map<CategoryUpdateCommand>(categoryViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Delete(Guid id)
        {
            var deleteCommand = _mapper.Map<CategoryDeleteCommand>(id);
            _bus.SendCommand(deleteCommand);
        }

        public void Dispose()
        {
            _categoryRepository.Dispose();
        }
    }
}
