using System.ComponentModel.DataAnnotations;

namespace LojaMvc.Models.Produto
{
    public class ProdutoCadastroViewModel
    {
        public string Nome { get; set; }
        [Display(Name = "Preço unitário")]
        public string PrecoUnitario { get; set; }
    }
}
