using System;
using System.Linq;
using TesteSWFast.IO.Core.Bus;
using TesteSWFast.IO.Core.Events;
using TesteSWFast.IO.Core.Notifications;
using TesteSWFast.IO.Domain.Categories.Events;
using TesteSWFast.IO.Domain.CommandHandlers;
using TesteSWFast.IO.Domain.Interfaces;
using TesteSWFast.IO.Domain.Products.Events;
using TesteSWFast.IO.Domain.Products.Repository;

namespace TesteSWFast.IO.Domain.Products.Commands
{
    public class ProductCommandHandler : CommandHandler,
        IHandler<ProductInsertCommand>,
        IHandler<ProductUpdateCommand>,
        IHandler<ProductDeleteCommand>
    {
        public readonly IBus _bus;
        public readonly IProductRepository _productRepository;

        public ProductCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notification, IProductRepository productRepository)
            : base(uow, bus, notification)
        {
            _bus = bus;
            _productRepository = productRepository;
        }

        public void Handle(ProductInsertCommand message)
        {
            var product = Product.ProductFactory.NewFullProduct(message.Id, message.IdCategoria, message.Nome, message.Preco);

            if (!product.IsValid())
            {
                AlertValidationsError(product.ValidationResult);
                return;
            }

            var productExists = _productRepository.Find(p => p.Id == product.Id);

            if (productExists.Any())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Produto já cadastrado."));
            }

            // TODO:
            // Validacoes de negocio!
            // Usuário pode registrar?

            _productRepository.Insert(product);

            if (Commit())
            {
                _bus.RaiseEvent(new ProductInsertedEvent(product.Id, product.IdCategoria, product.Nome, product.Preco));
            }
        }

        public void Handle(ProductUpdateCommand message)
        {
            if (!ProductExists(message.Id, message.MessageType)) return;

            var product = Product.ProductFactory.NewFullProduct(message.Id, message.IdCategoria, message.Nome, message.Preco);

            if (!product.IsValid())
            {
                AlertValidationsError(product.ValidationResult);
                return;
            }

            // TODO:
            // Validacoes de negocio!
            // Usuário pode alterar?

            _productRepository.Update(product);

            if (Commit())
            {
                _bus.RaiseEvent(new ProductUpdatedEvent(product.Id, product.IdCategoria, product.Nome, product.Preco));
            }
        }

        public void Handle(ProductDeleteCommand message)
        {
            if (!ProductExists(message.Id, message.MessageType)) return;

            // TODO:
            // Validacoes de negocio!
            // Usuário pode excluir?

            _productRepository.Delete(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new CategoryDeletedEvent(message.Id));
            }
        }

        private bool ProductExists(Guid id, string messageType)
        {
            var product = _productRepository.GetById(id);

            if (product != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Produto inexistente."));
            return false;
        }
    }
}
