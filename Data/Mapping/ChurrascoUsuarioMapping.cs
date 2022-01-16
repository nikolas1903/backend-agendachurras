using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ChurrascoUsuarioMapping : IEntityTypeConfiguration<ChurrascoUsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<ChurrascoUsuarioEntity> builder)
        {
            builder.ToTable("ChurrascoUsuario");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Observacoes).HasMaxLength(150);
            builder.Property(a => a.DataConfirmacao).HasMaxLength(150);
            builder.Property(a => a.DataPagamento).HasMaxLength(150);
            builder.Property(a => a.PresencaConfirmada).HasMaxLength(150);
            builder.Property(a => a.ValorPago).HasMaxLength(150);
            builder.Property(a => a.ValorPagoBebida).HasMaxLength(150);


            builder.HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId);
            
            builder.HasOne(c => c.Churrasco)
                .WithMany()
                .HasForeignKey(c => c.ChurrascoId);
        }
    }
}