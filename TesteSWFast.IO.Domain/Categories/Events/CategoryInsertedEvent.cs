using System;

namespace TesteSWFast.IO.Domain.Categories.Events
{
    public class CategoryInsertedEvent : CategoryBaseEvent
    {
        public CategoryInsertedEvent(Guid id, string nome)
        {
            Id = id;
            Nome = nome;

            AggregateId = id;
        }
    }
}
