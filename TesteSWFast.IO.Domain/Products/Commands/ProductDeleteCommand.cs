using System;

namespace TesteSWFast.IO.Domain.Products.Commands
{
    public class ProductDeleteCommand : BaseProductCommand
    {
        public ProductDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}
