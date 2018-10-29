using System;
using TesteSWFast.IO.Core.Models;
using FluentValidation;
using TesteSWFast.IO.Domain.Categories;

namespace TesteSWFast.IO.Domain.Products
{
    public class Product : Entity<Product>
    {
        public Guid IdCategoria { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }

        // EF propriedades de navegacao
        public virtual Category Category { get; private set; }

        public Product(Guid idCategoria, string nome, decimal preco)
        {
            Id = Guid.NewGuid();
            IdCategoria = idCategoria;
            Nome = nome;
            Preco = preco;
        }

        protected Product()
        {
        }

        #region Validation
        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }
        private void Validate()
        {
            ValidateNome();
            ValidatePrice();
        }
        private void ValidateNome()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do produto deve ser informado.")
                .MinimumLength(10).WithMessage("O nome do produto deve ter pelo menos 10 caracteres.")
                .MaximumLength(255).WithMessage("O nome do produto deve ter até 255 caracteres.");
        }
        private void ValidatePrice()
        {
            RuleFor(p => p.Preco)
                .NotEmpty().WithMessage("O valor do produto deve ser informado.")
                .GreaterThan(0).WithMessage("O valor do produto deve ser maior que 0 (zero).");
        }
        #endregion

        public static class ProductFactory
        {
            public static Product NewFullProduct(Guid id, Guid idCategoria, string nome, decimal preco)
            {
                var product = new Product()
                {
                    Id = id,
                    IdCategoria = idCategoria,
                    Nome = nome,
                    Preco = preco
                };

                return product;
            }
        }
    }
}
