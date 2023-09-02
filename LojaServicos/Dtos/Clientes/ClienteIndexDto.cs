using LojaRepositorios.entidades;

namespace LojaServicos.Dtos.Clientes
{
    public class ClienteIndexDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }

        public static ClienteIndexDto ConstruirComEntidade(Cliente cliente)
        {
            return new ClienteIndexDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Endereco = $"{cliente.Endereco.Estado} - {cliente.Endereco.Cidade}",
                Cpf = cliente.Cpf
            };
        }

        private ClienteIndexDto() { }
    }
}
