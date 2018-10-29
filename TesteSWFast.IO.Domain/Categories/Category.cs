using System;
using System.Collections.Generic;
using FluentValidation;
using TesteSWFast.IO.Core.Models;
using TesteSWFast.IO.Domain.Products;

namespace TesteSWFast.IO.Domain.Categories
{
    public class Category : Entity<Category>
    {
        public string Nome { get; private set; }

        // EF propriedades de navegacao
        public virtual ICollection<Product> Products { get; private set; }

        public Category(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }

        protected Category()
        {
        }

        #region Validation
        public override bool IsValid()
        {
            ValidateNome();
            return ValidationResult.IsValid;
        }
        private void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome da categoria deve ser informado.")
                .MinimumLength(5).WithMessage("O nome da categoria deve ter pelo menos 5 caracteres.")
                .MaximumLength(255).WithMessage("O nome da categoria deve ter até 255 caracteres.");
        }
        #endregion

        public static class CategoryFactory
        {
            public static Category NewFullCategory(Guid id, string nome)
            {
                var category = new Category()
                {
                    Id = id,
                    Nome = nome
                };

                return category;
            }
        }
    }
}
