using LojaRepositorios.database;
using LojaRepositorios.entidades;
using LojaRepositorios.repositorios;
using LojaServicos.Dtos.Clientes;
using LojaServicos.servicos;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Runtime.ConstrainedExecution;
using Xunit;

namespace LojaWebTestes.UnitTests.LojaServicos.Servicos
{
    public class ClienteServicosTests
    {
        [Fact]
        public void TestCadastrarClienteNaoCadastradoAnteriormenteSucesso()
        {
            var clienteRepositorioMock = Substitute.For<IClienteRepositorio>();
            var clienteServico = new ClienteServico(clienteRepositorioMock);

            var clienteDto = new ClienteCadastroDto 
            { 
                Nome = "Júlio",
                Cpf = "123.456.789-10",
                DataNascimento = new DateTime(2000, 6, 20),
                Estado = "PA",
                Cidade = "Boa Vista",
                Bairro = "Bairro das Avenidas",
                Cep = "90909-90",
                Complemento = "Casa Verde",
                Logradouro = "Rua XV de Outubro",
                Numero = "200"
            };

            clienteRepositorioMock.ObterPorCpf(Arg.Is(clienteDto.Cpf)).ReturnsNull();

            clienteServico.Cadastrar(clienteDto);

            clienteRepositorioMock.Received(1).ObterPorCpf(Arg.Is(clienteDto.Cpf));

            clienteRepositorioMock
                .Received(1)
                .Cadastrar(Arg.Is<Cliente>(clienteParametro =>
                    ReccebeuClienteEsperado(clienteParametro)
                    ));

        }

        [Fact]
        public void TesteCadastrarClienteJaExistente()
        {
            var clienteRepositorio = Substitute.For<IClienteRepositorio>();

            var clienteServico = new ClienteServico(clienteRepositorio);

            var clienteCadastroDto = new ClienteCadastroDto
            {
                Nome = "Pedro",
                Cpf = "234.567.890-12"
            };

            var clienteExistente = new Cliente();
            clienteRepositorio.ObterPorCpf(Arg.Is("234.567.890-12")).Returns<Cliente>(clienteExistente);

            Action acao = () => clienteServico.Cadastrar(clienteCadastroDto);

            var excecao = Assert.Throws<Exception>(acao);
            Assert.Equal("Cliente já cadastrado com CPF 234.567.890-12", excecao.Message);

            clienteRepositorio.DidNotReceive().Cadastrar(Arg.Any<Cliente>());
        }

        [Fact]
        public void TesteObterTodosSucesso()
        {
            var clienteRepositorio = Substitute.For<IClienteRepositorio>();

            var clienteServico = new ClienteServico(clienteRepositorio);

            var clientesEsperados = new List<Cliente>
            {
                new Cliente
                {
                    Nome = "Pedro",
                    Id = 8001,
                    Cpf = "123.456.789-10",
                    Endereco = new Endereco
                    {
                        Estado = "SC",
                        Cidade = "Timbó"
                    }
                },
                new Cliente
                {
                    Nome = "Júlia",
                    Id = 8002,
                    Cpf = "234.567.890-12",
                    Endereco = new Endereco
                    {
                        Estado = "SC",
                        Cidade = "Blumenau"
                    }
                }
            };

            clienteRepositorio.ObterTodos(Arg.Is("")).Returns(clientesEsperados);

            var clientes = clienteServico.ObterTodos("");

            Assert.Equal(2, clientes.Count());

            Assert.Equal("Pedro", clientes[0].Nome);
            Assert.Equal("123.456.789-10", clientes[0].Cpf);
            Assert.Equal(8001, clientes[0].Id);
            Assert.Equal("SC - Timbó", clientes[0].Endereco);

            Assert.Equal("Júlia", clientes[1].Nome);
            Assert.Equal("234.567.890-12", clientes[1].Cpf);
            Assert.Equal(8002, clientes[1].Id);
            Assert.Equal("SC - Blumenau", clientes[1].Endereco);
        }

        public bool ReccebeuClienteEsperado(Cliente cliente)
        {
            Assert.Equal("Júlio", cliente.Nome);
            Assert.Equal("123.456.789-10", cliente.Cpf);
            Assert.Equal(new DateTime(2000, 6, 20), cliente.DataNascimento);
            Assert.Equal("PA", cliente.Endereco.Estado);
            Assert.Equal("Boa Vista", cliente.Endereco.Cidade);
            Assert.Equal("Bairro das Avenidas", cliente.Endereco.Bairro);
            Assert.Equal("90909-90", cliente.Endereco.Cep);
            Assert.Equal("Casa Verde", cliente.Endereco.Complemento);
            Assert.Equal("Rua XV de Outubro", cliente.Endereco.Logradouro);
            Assert.Equal("200", cliente.Endereco.Numero);
            Assert.Equal(0, cliente.Id);

            return true;
        }
    }
}
