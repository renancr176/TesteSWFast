using System;
using System.ComponentModel.DataAnnotations;

namespace TesteSWFast.IO.Application.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria é requerido.")]
        [Display(Name = "Nome da categoria")]
        [MinLength(5, ErrorMessage = "O nome da categoria deve conter ao menos 5 caracteres.")]
        [MaxLength(255, ErrorMessage = "O nome da categoria deve conter no máximo 255 caracteres.")]
        public string Nome { get; set; }

        public CategoryViewModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
