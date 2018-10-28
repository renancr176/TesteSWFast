using AutoMapper;
using TesteSWFast.IO.Application.ViewModels;
using TesteSWFast.IO.Domain.Categories;
using TesteSWFast.IO.Domain.Products;

namespace TesteSWFast.IO.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
