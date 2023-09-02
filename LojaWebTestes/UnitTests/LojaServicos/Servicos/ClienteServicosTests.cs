// using FluentAssertions;
// using LojaRepositorios.database;
// using LojaRepositorios.entidades;
// using LojaRepositorios.repositorios;
// using LojaServicos.Dtos.Clientes;
// using LojaServicos.servicos;
// using LojaWebTestes.Builders.Entidades;
// using NSubstitute;
// using NSubstitute.ReturnsExtensions;
// using System.Runtime.ConstrainedExecution;
// using Xunit;
//
// namespace LojaWebTestes.UnitTests.LojaServicos.Servicos
// {
//     public class ClienteServicosTests
//     {
//         private readonly ClienteServico _clienteServico;
//         private readonly IClienteRepositorio _clienteRepositorio;
//
//         public ClienteServicosTests()
//         {
//             _clienteRepositorio = Substitute.For<IClienteRepositorio>();
//             _clienteServico = new ClienteServico(_clienteRepositorio);
//         }
//
//         [Fact]
//         public void TestCadastrarClienteNaoCadastradoAnteriormenteSucesso()
//         {
//             var clienteDto = new ClienteCadastroDto 
//             { 
//                 Nome = "Júlio",
//                 Cpf = "123.456.789-10",
//                 DataNascimento = new DateTime(2000, 6, 20),
//                 Estado = "PA",
//                 Cidade = "Boa Vista",
//                 Bairro = "Bairro das Avenidas",
//                 Cep = "90909-90",
//                 Complemento = "Casa Verde",
//                 Logradouro = "Rua XV de Outubro",
//                 Numero = "200"
//             };
//
//             _clienteRepositorio.ObterPorCpf(Arg.Is(clienteDto.Cpf)).ReturnsNull();
//
//             _clienteServico.Cadastrar(clienteDto);
//
//             _clienteRepositorio.Received(1).ObterPorCpf(Arg.Is(clienteDto.Cpf));
//
//             _clienteRepositorio
//                 .Received(1)
//                 .Cadastrar(Arg.Is<Cliente>(clienteParametro =>
//                     ReccebeuClienteEsperado(clienteParametro)
//                     ));
//         }
//
//         [Fact]
//         public void TesteCadastrarClienteJaExistente()
//         {
//             var clienteCadastroDto = new ClienteCadastroDto
//             {
//                 Nome = "Pedro",
//                 Cpf = "234.567.890-12"
//             };
//
//             var clienteExistente = new Cliente();
//             _clienteRepositorio.ObterPorCpf(Arg.Is("234.567.890-12")).Returns<Cliente>(clienteExistente);
//
//             Action acao = () => _clienteServico.Cadastrar(clienteCadastroDto);
//
//             var excecaoLancada = acao.Should().Throw<Exception>();
//             excecaoLancada.WithMessage("Cliente já cadastrado com CPF 234.567.890-12");
//
//             _clienteRepositorio.DidNotReceive().Cadastrar(Arg.Any<Cliente>());
//         }
//
//         [Fact]
//         public void TesteObterTodosSucesso()
//         {
//             var clientesEsperados = new List<Cliente>
//             {
//                 new ClienteBuilder()
//                     .ComNome("Pedro")
//                     .ComId(8001)
//                     .ComCpf("123.456.789-10")
//                     .ComEstado("SC")
//                     .ComCidade("Timbó")
//                     .Construir(),
//
//                 new ClienteBuilder().Construir()
//             };
//
//             _clienteRepositorio.ObterTodos(Arg.Is("")).Returns(clientesEsperados);
//
//             var clientes = _clienteServico.ObterTodos("");
//
//             clientes.Should().HaveCount(2);
//
//             clientes[0].Nome.Should().Be("Pedro");
//             clientes[0].Cpf.Should().Be("123.456.789-10");
//             clientes[0].Id.Should().Be(8001);
//             clientes[0].Endereco.Should().Be("SC - Timbó");
//
//             clientes[1].Nome.Should().Be("Allan de Souza");
//             clientes[1].Cpf.Should().Be("123.456.789-00");
//             clientes[1].Id.Should().Be(9999);
//             clientes[1].Endereco.Should().Be("SC - Gaspar");
//         }
//
//         public bool ReccebeuClienteEsperado(Cliente cliente)
//         {
//             cliente.Nome.Should().Be("Júlio");
//
//             cliente.Nome.Should().Be("Júlio");
//             cliente.Cpf.Should().Be("123.456.789-10");
//             cliente.DataNascimento.Should().Be(new DateTime(2000, 6, 20));
//             cliente.Endereco.Estado.Should().Be("PA");
//             cliente.Endereco.Cidade.Should().Be("Boa Vista");
//             cliente.Endereco.Bairro.Should().Be("Bairro das Avenidas");
//             cliente.Endereco.Cep.Should().Be("90909-90");
//             cliente.Endereco.Complemento.Should().Be("Casa Verde");
//             cliente.Endereco.Logradouro.Should().Be("Rua XV de Outubro");
//             cliente.Endereco.Numero.Should().Be("200");
//             cliente.Id.Should().Be(0);
//
//             return true;
//         }
//     }
// }
