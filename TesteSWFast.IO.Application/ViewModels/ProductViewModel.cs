using System;
using System.ComponentModel.DataAnnotations;

namespace TesteSWFast.IO.Application.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        //[ForeignKey("CategoryViewModel.Id")]
        [Required(ErrorMessage = "A categoria do produto é requerida.")]
        [Display(Name = "Categoria")]
        public Guid IdCategory { get; set; }

        [Required(ErrorMessage = "O nome do produto é querido.")]
        [Display(Name = "Nome do produto")]
        [MinLength(5, ErrorMessage = "O nome do produto deve conter ao menos 5 caracteres.")]
        [MaxLength(255, ErrorMessage = "O nome do produto deve conter no máximo 255 caracteres.")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "O valor do produto é requerido.")]
        [Display(Name = "Preço unitário")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Preco { get; set; }

        public CategoryViewModel Category { get; set; }

        public ProductViewModel()
        {
            Id = Guid.NewGuid();
            Category = new CategoryViewModel();
        }
    }
}
