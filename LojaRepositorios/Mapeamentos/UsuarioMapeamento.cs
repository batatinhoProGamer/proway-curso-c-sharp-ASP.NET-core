using LojaRepositorios.entidades;
using LojaRepositorios.ExtensionsMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaRepositorios.Mapeamentos;

public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("Nome");
        
        builder.Property(x => x.Email)
            .HasColumnType("VARCHAR")
            .HasMaxLength(150)
            .IsRequired()
            .HasColumnName("Email");
        
        builder.Property(x => x.Senha)
            .HasColumnType("VARCHAR")
            .HasMaxLength(200)
            .IsRequired()
            .HasColumnName("Senha");

        builder.HasData(new Usuario
        {
            Id = 1,
            Nome = "Edshow da Silva",
            Email = "edshow.silva@gmail.com",
            Senha = "1234".Hash512()
        });
    }
}