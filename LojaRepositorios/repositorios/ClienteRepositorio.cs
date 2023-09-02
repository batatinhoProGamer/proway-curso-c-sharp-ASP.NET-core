using LojaRepositorios.database;
using LojaRepositorios.entidades;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;

namespace LojaRepositorios.repositorios
{
    public class ClienteRepositorio : RepositorioBase<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(LojaContexto lojaContexto) : base(lojaContexto)
        {
        }

        public Cliente? ObterPorCpf(string Cpf) =>
            _dbSet.FirstOrDefault(x => x.Cpf == Cpf);
        
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
    }
}
