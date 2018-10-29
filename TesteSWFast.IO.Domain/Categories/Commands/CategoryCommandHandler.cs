using System;
using System.Linq;
using TesteSWFast.IO.Core.Bus;
using TesteSWFast.IO.Core.Events;
using TesteSWFast.IO.Core.Notifications;
using TesteSWFast.IO.Domain.Categories.Events;
using TesteSWFast.IO.Domain.CommandHandlers;
using TesteSWFast.IO.Domain.Interfaces;
using TesteSWFast.IO.Domain.Categories.Repository;

namespace TesteSWFast.IO.Domain.Categories.Commands
{
    public class CategoryCommandHandler
        : CommandHandler,
        IHandler<CategoryInsertCommand>,
        IHandler<CategoryUpdateCommand>,
        IHandler<CategoryDeleteCommand>
    {
        public readonly IBus _bus;
        public readonly ICategoryRepository _categoryRepository;

        public CategoryCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notification, ICategoryRepository categoryRepository)
            : base(uow, bus, notification)
        {
            _bus = bus;
            _categoryRepository = categoryRepository;
        }

        public void Handle(CategoryInsertCommand message)
        {
            var category = Category.CategoryFactory.NewFullCategory(message.Id, message.Nome);

            if (!category.IsValid())
            {
                AlertValidationsError(category.ValidationResult);
                return;
            }

            var categoryExists = _categoryRepository.Find(p => p.Id == category.Id || p.Nome.ToLower() == category.Nome.ToLower());

            if (categoryExists.Any())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Categoria já cadastrada."));
            }

            // TODO:
            // Validacoes de negocio!
            // Usuário pode registrar?

            _categoryRepository.Insert(category);

            if (Commit())
            {
                _bus.RaiseEvent(new CategoryInsertedEvent(category.Id, category.Nome));
            }
        }

        public void Handle(CategoryUpdateCommand message)
        {
            if (!CategoryExists(message.Id, message.MessageType)) return;

            var category = Category.CategoryFactory.NewFullCategory(message.Id, message.Nome);

            if (!category.IsValid())
            {
                AlertValidationsError(category.ValidationResult);
                return;
            }

            // TODO:
            // Validacoes de negocio!
            // Usuário pode alterar?

            _categoryRepository.Update(category);

            if (Commit())
            {
                _bus.RaiseEvent(new CategoryUpdatedEvent(category.Id, category.Nome));
            }
        }

        public void Handle(CategoryDeleteCommand message)
        {
            if (!CategoryExists(message.Id, message.MessageType)) return;

            // TODO:
            // Validacoes de negocio!
            // Usuário pode excluir?

            _categoryRepository.Delete(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new CategoryDeletedEvent(message.Id));
            }
        }

        private bool CategoryExists(Guid id, string messageType)
        {
            var category = _categoryRepository.GetById(id);

            if (category != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Categoria inexistente."));
            return false;
        }
    }
}
