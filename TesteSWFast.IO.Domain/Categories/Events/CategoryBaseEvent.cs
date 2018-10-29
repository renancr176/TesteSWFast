using System;
using TesteSWFast.IO.Core.Events;

namespace TesteSWFast.IO.Domain.Categories.Events
{
    public class CategoryBaseEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
    }
}
