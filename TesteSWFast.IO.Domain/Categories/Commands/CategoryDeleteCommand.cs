using System;

namespace TesteSWFast.IO.Domain.Categories.Commands
{
    public class CategoryDeleteCommand : CategoryBaseCommand
    {
        public CategoryDeleteCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
