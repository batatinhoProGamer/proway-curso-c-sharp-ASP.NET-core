using LojaRepositorios.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRepositorios.Mapeamentos
{
    internal class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produtos");

            builder.HasKey(x => x.Id);

            builder.Property(X => X.Nome)
                .HasColumnName("nome");

            builder.Property(X => X.Quantidade)
                .HasColumnName("quantidade");

            builder.Property(X => X.PrecoUnitario)
                .HasColumnName("preco_unitario");
        }
    }
}
