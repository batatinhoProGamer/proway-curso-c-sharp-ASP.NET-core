using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LojaMvc.Models.Produto
{
    public class ProdutoEditarViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Preço unitário")]
        public string PrecoUnitario { get; set; }
    }
}
