using System.ComponentModel.DataAnnotations;

namespace LojaMvc.Models.Cliente
{
    public class ClienteCadastroViewModel
    {
        [Required(ErrorMessage = "Campo nome deve ser preenchido")]
        [MinLength(6, ErrorMessage = "Campo deve conter no mínimo 6 caracteres")]
        [MaxLength(100, ErrorMessage = "Campo deve conter no máximo 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo CPF deve ser preenchido")]
        [RegularExpression("[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}", 
            ErrorMessage = "CPF deve seguir o formato 012.345.678-90")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Campo de Data de Nascimento deve ser preenchida")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de nascimento")]
        public DateTime? DataNascimento { get; set; }
        [Required(ErrorMessage = "Campo estado deve ser preenchido")]
        [MinLength(2, ErrorMessage = "Campo estado deve conter 2 caracteres")]
        [MaxLength(2, ErrorMessage = "Campo estado deve conter 2 caracteres")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Campo cidade deve ser preenchido")]
        [MinLength(3, ErrorMessage = "Campo cidade deve conter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "Campo cidade deve conter no máximo 100 caracteres")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Campo bairro deve ser preenchido")]
        [MinLength(3, ErrorMessage = "Campo bairro deve conter no mínimo 3 caracteres")]
        [MaxLength(40, ErrorMessage = "Campo bairro deve conter no máximo 40 caracteres")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Campo CEP deve ser preenchido")]
        [RegularExpression("[0-9]{5}-[0-9]{3}",
            ErrorMessage = "CEP deve seguir o formato 01234-567")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Campo CEP deve ser preenchido")]
        [StringLength(50, MinimumLength =3, 
            ErrorMessage = "Logradouro deve conter no mínimo 3 e no máximo 50 caracteres")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Campo Número deve ser preenchido")]
        [StringLength(10, MinimumLength = 1,
            ErrorMessage = "Número deve conter no mínimo 1 e no máximo 10 caracteres")]
        public string Numero { get; set; }
        public string? Complemento { get; set; }
    }
}
