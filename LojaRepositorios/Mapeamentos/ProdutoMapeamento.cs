using LojaRepositorios.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaRepositorios.Mapeamentos
{
    internal class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        private int id = 0;

        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produtos");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Ativo)
                .HasColumnType("BIT")
                .HasDefaultValue(true)
                .IsRequired()
                .HasColumnName("Ativo");

            builder.Property(X => X.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(150)
                .IsRequired()
                .HasColumnName("Nome");

            builder.Property(X => X.PrecoUnitario)
                .HasColumnType("DECIMAL")
                .HasPrecision(14, 2)
                .IsRequired()
                .HasColumnName("PrecoUnitario");

            builder.HasData(
                ConstruirProduto("TV QLED Samsung 4k 50", 5949.72m),
                ConstruirProduto("TV OLED Lg 50", 5300.10m));
        }

        public Produto ConstruirProduto(string nome, decimal precoUnitario)
        {
            return new Produto
            {
                Id = ++id,
                Nome = nome,
                PrecoUnitario = precoUnitario
            };
        }
    }
}
