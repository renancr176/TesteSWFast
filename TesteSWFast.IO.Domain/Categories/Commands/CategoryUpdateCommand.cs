using System;

namespace TesteSWFast.IO.Domain.Categories.Commands
{
    public class CategoryUpdateCommand : CategoryBaseCommand
    {
        public CategoryUpdateCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
