using LojaRepositorios.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaRepositorios.Mapeamentos
{
    internal class ClienteMapeamento : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("Nome");

            builder.Property(x => x.Cpf)
                .HasColumnType("VARCHAR")
                .HasMaxLength(14)
                .IsRequired()
                .HasColumnName("Cpf");

            builder.Property(x => x.DataNascimento)
                .HasColumnType("DATETIME2")
                .IsRequired()
                .HasColumnName("DataNascimento");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Estado)
                .HasColumnType("CHAR")
                .HasMaxLength(2)
                .IsFixedLength()
                .IsRequired()
                .HasColumnName("Estado");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Cidade)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("Cidade");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Bairro)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("Bairro");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Cep)
                .HasColumnType("CHAR")
                .HasMaxLength(10)
                .IsFixedLength()
                .IsRequired()
                .HasColumnName("Cep");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Logradouro)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("Logradouro");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Numero)
                .HasColumnType("VARCHAR")
                .HasMaxLength(30)
                .IsRequired()
                .HasColumnName("Numero");

            builder.OwnsOne(x => x.Endereco)
                .Property(x => x.Complemento)
                .HasColumnType("VARCHAR")
                .HasMaxLength(200)
                .HasColumnName("Complemento");

            builder.HasData(new Cliente
            {
                Id = 2,
                Nome = "Pedro da Silva",
                Cpf = "123.456.789-00",
                DataNascimento = new DateTime(1990, 3, 20)
            });
            builder
                .OwnsOne(x => x.Endereco)
                .HasData(
                    new Endereco
                    {
                        ClienteId = 2,
                        Estado = "SC",
                        Cidade = "Blumenau",
                        Bairro = "Badenfurt",
                        Cep = "89070-250",
                        Logradouro = "Rua dos Pedra",
                        Numero = "200",
                        Complemento = "Sem complemento"
                    });
        }
    }
}
