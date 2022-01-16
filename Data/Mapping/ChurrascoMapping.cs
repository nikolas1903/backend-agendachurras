using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ChurrascoMapping : IEntityTypeConfiguration<ChurrascoEntity>
    {
        public void Configure(EntityTypeBuilder<ChurrascoEntity> builder)
        {
            builder.ToTable("Churrasco");
            builder.HasKey(a => a.Id);
            
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Descricao).HasMaxLength(150);
            builder.Property(a => a.Observacoes).HasMaxLength(150);
            builder.Property(a => a.DataRealizacao).HasMaxLength(150);
            builder.Property(a => a.ValorArrecadado).HasMaxLength(50).HasDefaultValue(0);
            builder.Property(a => a.ValorSugerido).HasMaxLength(50);
            builder.Property(a => a.ValorSugeridoBebida).HasMaxLength(50);
            builder.Property(a => a.Convidados).HasMaxLength(4).HasDefaultValue(0);
            builder.Property(a => a.ConvidadosConfirmados).HasMaxLength(4).HasDefaultValue(0);
            builder.Property(a => a.Ativo).IsRequired().HasMaxLength(2);
            
        }
    }
}