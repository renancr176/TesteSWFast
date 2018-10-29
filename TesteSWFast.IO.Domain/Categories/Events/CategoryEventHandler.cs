using TesteSWFast.IO.Core.Events;

namespace TesteSWFast.IO.Domain.Categories.Events
{
    public class CategoryEventHandler :
        IHandler<CategoryInsertedEvent>,
        IHandler<CategoryUpdatedEvent>,
        IHandler<CategoryDeletedEvent>
    {
        public void Handle(CategoryInsertedEvent message)
        {
            // TODO: Ação posterior ao insert?
        }

        public void Handle(CategoryUpdatedEvent message)
        {
            // TODO: Ação posterior ao update?
        }

        public void Handle(CategoryDeletedEvent message)
        {
            // TODO: Ação posterior ao delete?
        }
    }
}
