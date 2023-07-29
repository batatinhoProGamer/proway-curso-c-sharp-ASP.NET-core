using LojaRepositorios.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaRepositorios.Mapeamentos
{
    internal class ClienteMapeamento : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnName("nome");
            builder.Property(x => x.Cpf).HasColumnName("cpf");
            builder.Property(x => x.DataNascimento).HasColumnName("data_nascimento");

            builder.OwnsOne(x => x.Endereco).Property(x => x.Estado).HasColumnName("estado");
            builder.OwnsOne(x => x.Endereco).Property(x => x.Cidade).HasColumnName("cidade");
            builder.OwnsOne(x => x.Endereco).Property(x => x.Bairro).HasColumnName("bairro");
            builder.OwnsOne(x => x.Endereco).Property(x => x.Cep).HasColumnName("cep");
            builder.OwnsOne(x => x.Endereco).Property(x => x.Logradouro).HasColumnName("logradouro");
            builder.OwnsOne(x => x.Endereco).Property(x => x.Numero).HasColumnName("numero");
            builder.OwnsOne(x => x.Endereco).Property(x => x.Complemento).HasColumnName("complemento");

        }
    }
}
