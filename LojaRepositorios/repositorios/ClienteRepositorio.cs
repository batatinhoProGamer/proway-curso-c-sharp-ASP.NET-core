using LojaRepositorios.database;
using LojaRepositorios.entidades;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;

namespace LojaRepositorios.repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly LojaContexto _lojaContexto;
        private readonly DbSet<Cliente> _dbSet;

        public ClienteRepositorio(LojaContexto lojaContexto)
        {
            _lojaContexto = lojaContexto;
            _dbSet = _lojaContexto.Set<Cliente>();
        }

        public Cliente? ObterPorCpf(string Cpf) =>
            _dbSet.FirstOrDefault(x => x.Cpf == Cpf);

        public bool ExisteComCpf(string Cpf) =>
            _dbSet.Any(x => x.Cpf == Cpf);

        public void Cadastrar(Cliente cliente)
        {
            _dbSet.Add(cliente);
            _lojaContexto.SaveChanges();
        }

        public void Apagar(int id)
        {
            var cliente = _dbSet.FirstOrDefault(x => x.Id == id);
            if (cliente == null)
            {
                throw new Exception($"Cliente com id {id} não existe");
            }

            _dbSet.Remove(cliente);
            _lojaContexto.SaveChanges();
        }

        public List<Cliente> ObterTodos(string? pesquisa)
        {
            var query = _dbSet.AsQueryable();

            if (pesquisa != null && pesquisa.Trim() != "") 
            {
                query = query.Where(x => x.Nome.Contains(pesquisa) || 
                    x.Cpf.Replace("-", "").Replace(".", "") == pesquisa.Replace("-", "").Replace(".", ""));
            }
            return query
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public Cliente? ObterPorId(int id)
        {
            var cliente = _dbSet.FirstOrDefault(x => x.Id == id);

            return cliente;
        }

        public void Editar(Cliente cliente)
        {
            _dbSet.Update(cliente);
            _lojaContexto.SaveChanges();
        }

        
    }
}
