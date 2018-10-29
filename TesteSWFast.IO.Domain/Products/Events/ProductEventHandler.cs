﻿using TesteSWFast.IO.Core.Events;

namespace TesteSWFast.IO.Domain.Products.Events
{
    public class ProductEventHandler :
        IHandler<ProductInsertedEvent>,
        IHandler<ProductUpdatedEvent>,
        IHandler<ProductDeletedEvent>
    {
        public void Handle(ProductInsertedEvent message)
        {
            // TODO: Ação posterior ao insert?
        }

        public void Handle(ProductUpdatedEvent message)
        {
            // TODO: Ação posterior ao update?
        }

        public void Handle(ProductDeletedEvent message)
        {
            // TODO: Ação posterior ao delete?
        }
    }
}
