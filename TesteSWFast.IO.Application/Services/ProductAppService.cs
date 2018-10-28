using System;
using System.Collections.Generic;
using AutoMapper;
using TesteSWFast.IO.Application.Interfaces;
using TesteSWFast.IO.Application.ViewModels;
using TesteSWFast.IO.Core.Bus;
using TesteSWFast.IO.Domain.Products.Commands;
using TesteSWFast.IO.Domain.Products.Repository;

namespace TesteSWFast.IO.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductAppService(IBus bus, IMapper mapper, IProductRepository productRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public ProductViewModel GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(_productRepository.GetById(id));
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(_productRepository.GetAll());
        }

        public IEnumerable<ProductViewModel> GetProductByCategory(Guid idCategory)
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(_productRepository.Find(c => c.IdCategoria.Equals(idCategory)));
        }

        public void Insert(ProductViewModel productViewModel)
        {
            var insertCommand = _mapper.Map<ProductInsertCommand>(productViewModel);
            _bus.SendCommand(insertCommand);
        }

        public void Update(ProductViewModel productViewModel)
        {
            var updateCommand = _mapper.Map<ProductUpdateCommand>(productViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Delete(Guid id)
        {
            var deleteCommand = _mapper.Map<ProductDeleteCommand>(id);
            _bus.SendCommand(deleteCommand);
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}
