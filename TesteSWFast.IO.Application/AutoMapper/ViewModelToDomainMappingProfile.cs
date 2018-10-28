using AutoMapper;
using TesteSWFast.IO.Application.ViewModels;
using TesteSWFast.IO.Domain.Categories.Commands;
using TesteSWFast.IO.Domain.Products.Commands;

namespace TesteSWFast.IO.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region Category
            CreateMap<CategoryViewModel, CategoryInsertCommand>()
                .ConstructUsing(c => new CategoryInsertCommand(c.Id, c.Nome));
            CreateMap<CategoryViewModel, CategoryUpdateCommand>()
                .ConstructUsing(c => new CategoryUpdateCommand(c.Id, c.Nome));
            CreateMap<CategoryViewModel, CategoryDeleteCommand>()
                .ConstructUsing(c => new CategoryDeleteCommand(c.Id));
            #endregion

            #region Product
            CreateMap<ProductViewModel, ProductInsertCommand>()
                .ConstructUsing(p => new ProductInsertCommand(p.Id, p.IdCategory, p.Nome, p.Preco));
            CreateMap<ProductViewModel, ProductUpdateCommand>()
                .ConstructUsing(p => new ProductUpdateCommand(p.Id, p.IdCategory, p.Nome, p.Preco));
            CreateMap<ProductViewModel, ProductDeleteCommand>()
                .ConstructUsing(p => new ProductDeleteCommand(p.Id));
            #endregion

        }
    }
}
