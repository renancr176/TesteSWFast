using System;

namespace TesteSWFast.IO.Domain.Categories.Events
{
    public class CategoryUpdatedEvent : CategoryBaseEvent
    {
        public CategoryUpdatedEvent(Guid id, string nome)
        {
            Id = id;
            Nome = nome;

            AggregateId = id;
        }
    }
}
