using System.ComponentModel.DataAnnotations;

namespace LojaMvc.Models.Autenticacao;

public class AutenticacaoViewModel
{
    [Required(ErrorMessage = "E-mail é obrigatório")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required(ErrorMessage = "Senha é obrigatória")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }
}