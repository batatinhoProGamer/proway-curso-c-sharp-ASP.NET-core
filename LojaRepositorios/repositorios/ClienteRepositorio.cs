using LojaRepositorios.database;
using LojaRepositorios.entidades;
using System.Data;

namespace LojaRepositorios.repositorios
{
    public class ClienteRepositorio
    {
        private readonly BancoDadosConexao _bancoDadosConexao;

        public ClienteRepositorio()
        {
            _bancoDadosConexao = new BancoDadosConexao();
        }

        public void Cadastrar(Cliente cliente)
        {
            var comando = _bancoDadosConexao.Conectar();
            comando.CommandText = @"INSERT INTO clientes 
                (nome,  cpf,  data_nascimento,  estado,  cidade,  bairro,  cep,  
                logradouro,  numero,  complemento)
            VALUES 
                (@NOME, @CPF, @DATA_NASCIMENTO, @ESTADO, @CIDADE, @BAIRRO, @CEP, 
                @LOGRADOURO, @NUMERO, @COMPLEMENTO)";

            comando.Parameters.AddWithValue("@NOME", cliente.Nome);
            comando.Parameters.AddWithValue("@CPF", cliente.Cpf);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.DataNascimento);
            comando.Parameters.AddWithValue("@ESTADO", cliente.Endereco.Estado);
            comando.Parameters.AddWithValue("@CIDADE", cliente.Endereco.Cidade);
            comando.Parameters.AddWithValue("@BAIRRO", cliente.Endereco.Bairro);
            comando.Parameters.AddWithValue("@CEP", cliente.Endereco.Cep);
            comando.Parameters.AddWithValue("@LOGRADOURO", cliente.Endereco.Logradouro);
            comando.Parameters.AddWithValue("@NUMERO", cliente.Endereco.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", cliente.Endereco.Complemento);

            comando.ExecuteNonQuery();
        }

        public void Apagar(int id)
        {
            var comando = _bancoDadosConexao.Conectar();
            comando.CommandText = "DELETE FROM clientes WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.ExecuteNonQuery();
        }

        public List<Cliente> ObterTodos()
        {
            var comando = _bancoDadosConexao.Conectar();
            comando.CommandText = "SELECT * FROM clientes";

            var tabelaEmMemoria = new DataTable();
            tabelaEmMemoria.Load(comando.ExecuteReader());

            var clientes = new List<Cliente>();
            foreach (DataRow registro in tabelaEmMemoria.Rows)
            {
                var cliente = new Cliente();

                cliente.Id = Convert.ToInt32(registro["id"]);
                cliente.Nome = registro["nome"].ToString();
                cliente.Cpf = registro["cpf"].ToString();
                cliente.DataNascimento = Convert.ToDateTime(registro["data_nascimento"]);

                cliente.Endereco = new Endereco();
                cliente.Endereco.Cep = registro["cep"].ToString();
                cliente.Endereco.Numero = registro["numero"].ToString();
                cliente.Endereco.Estado = registro["estado"].ToString();
                cliente.Endereco.Cidade = registro["cidade"].ToString();
                cliente.Endereco.Bairro = registro["bairro"].ToString();
                cliente.Endereco.Complemento = registro["complemento"].ToString();

                clientes.Add(cliente);
            }

            return clientes;
        }

        public Cliente ObterPorId(int id)
        {
            var comando = _bancoDadosConexao.Conectar();
            comando.CommandText = "SELECT * FROM clientes WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            var tabelaEmMemoria = new DataTable();
            tabelaEmMemoria.Load(comando.ExecuteReader());

            var linha = tabelaEmMemoria.Rows[0];
            var cliente = ConstruirObjetoCliente(linha);

            return cliente;
        }

        private Cliente ConstruirObjetoCliente(DataRow linha)
        {
            var cliente = new Cliente();
            cliente.Id = Convert.ToInt32(linha["id"]);
            cliente.Nome = linha["nome"].ToString();
            cliente.Cpf = linha["Cpf"].ToString();
            cliente.DataNascimento = (DateTime) linha["data_nascimento"];
            cliente.Endereco.Estado = linha["estado"].ToString();
            cliente.Endereco.Cidade = linha["cidade"].ToString();
            cliente.Endereco.Bairro = linha["bairro"].ToString();
            cliente.Endereco.Cep = linha["cep"].ToString();
            cliente.Endereco.Logradouro = linha["logradouro"].ToString();
            cliente.Endereco.Numero = linha["numero"].ToString();
            cliente.Endereco.Complemento = linha["complemento"].ToString();

            return cliente;
        }

        public void Editar(Cliente cliente)
        {
            var comando = _bancoDadosConexao.Conectar();
            comando.CommandText = @"UPDATE clientes SET 
                nome = @NOME,
                cpf = @CPF,
                data_nascimento = @DATA_NASCIMENTO,
                estado = @ESTADO,
                cidade = @CIDADE,
                bairro = @BAIRRO,
                cep = @CEP,
                logradouro = @LOGRADOURO,
                numero = @NUMERO,
                complemento = @COMPLEMENTO
                WHERE id = @ID";

            comando.Parameters.AddWithValue("@NOME", cliente.Nome);
            comando.Parameters.AddWithValue("@CPF", cliente.Cpf);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.DataNascimento);
            comando.Parameters.AddWithValue("@ESTADO", cliente.Endereco.Estado);
            comando.Parameters.AddWithValue("@CIDADE", cliente.Endereco.Cidade);
            comando.Parameters.AddWithValue("@BAIRRO", cliente.Endereco.Bairro);
            comando.Parameters.AddWithValue("@CEP", cliente.Endereco.Cep);
            comando.Parameters.AddWithValue("@LOGRADOURO", cliente.Endereco.Logradouro);
            comando.Parameters.AddWithValue("@NUMERO", cliente.Endereco.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", cliente.Endereco.Complemento);
            comando.Parameters.AddWithValue("@ID", cliente.Id);

            comando.ExecuteNonQuery();
        }
    }
}
