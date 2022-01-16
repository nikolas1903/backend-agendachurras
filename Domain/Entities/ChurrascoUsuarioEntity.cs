using System;

namespace Domain.Entities
{
    public class ChurrascoUsuarioEntity : BaseEntity
    {
        public int UsuarioId { get; set; }
        public virtual UsuarioEntity Usuario { get; set; }
        
        public int ChurrascoId { get; set; }
        public virtual ChurrascoEntity Churrasco { get; set; }
        public decimal? ValorPago { get; set; }
        public decimal? ValorPagoBebida { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int PresencaConfirmada { get; set; }
        public DateTime? DataConfirmacao { get; set; }
        public string? Observacoes { get; set; }
    }
}