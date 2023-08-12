using LojaRepositorios.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaWebTestes.Builders.Entidades
{
    public class ClienteBuilder
    {
        private int _id = 9999;
        private string _nome = "Allan de Souza";
        private string _cpf = "123.456.789-00";
        private DateTime _datanascimento = new DateTime(1990, 12, 10);
        private string _estado = "SC";
        private string _cidade = "Gaspar";
        private string _bairro = "Bairro de Gaspar";
        private string _logradouro = "Rua de Gaspar";
        private string _numero = "0001";
        private string _complemento = "Casa vermelha";
        private string _cep = "89070-200";

        public Cliente Construir()
        {
            return new Cliente
            {
                Id = _id,
                Nome = _nome,
                Cpf = _cpf,
                DataNascimento = _datanascimento,
                Endereco = new Endereco
                {
                    Estado = _estado,
                    Cidade = _cidade,
                    Bairro = _bairro,
                    Cep = _cep,
                    Logradouro = _logradouro,
                    Numero = _numero,
                    Complemento = _complemento
                }
            };
        }

        public ClienteBuilder ComId(int id)
        {
            _id = id;

            return this;
        }

        public ClienteBuilder ComNome(string nome)
        {
            _nome = nome;

            return this;
        }

        public ClienteBuilder ComCpf(string cpf)
        {
            _cpf = cpf;

            return this;
        }

        public ClienteBuilder ComDataNascimento(DateTime datanascimento)
        {
            _datanascimento = datanascimento;

            return this;
        }

        public ClienteBuilder ComEstado(string estado)
        {
            _estado = estado;

            return this;
        }

        public ClienteBuilder ComCidade(string cidade)
        {
            _cidade = cidade;

            return this;
        }

        public ClienteBuilder ComBairro(string bairro)
        {
            _bairro = bairro;

            return this;
        }

        public ClienteBuilder ComCep(string cep)
        {
            _cep = cep;

            return this;
        }

        public ClienteBuilder ComLogradouro(string logradouro)
        {
            _logradouro = logradouro;

            return this;
        }

        public ClienteBuilder ComNumero(string numero)
        {
            _numero = numero;

            return this;
        }

        public ClienteBuilder ComComplemento(string complemento)
        {
            _complemento = complemento;

            return this;
        }

    }
}
