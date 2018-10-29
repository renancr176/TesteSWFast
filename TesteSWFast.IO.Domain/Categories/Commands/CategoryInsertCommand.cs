using System;

namespace TesteSWFast.IO.Domain.Categories.Commands
{
    public class CategoryInsertCommand : CategoryBaseCommand
    {
        public CategoryInsertCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
