using System;

namespace TesteSWFast.IO.Domain.Categories.Events
{
    public class CategoryDeletedEvent : CategoryBaseEvent
    {
        public CategoryDeletedEvent(Guid id)
        {
            Id = id;

            AggregateId = id;
        }
    }
}
