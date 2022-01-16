using System;

namespace Domain.Entities
{
    public class ChurrascoEntity : BaseEntity {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Observacoes { get; set; }
        public DateTime? DataRealizacao { get; set; }
        public decimal ValorArrecadado { get; set; }
        public decimal? ValorSugerido { get; set; }
        public int? Convidados { get; set; }
        public int? ConvidadosConfirmados { get; set; }
        public decimal? ValorSugeridoBebida { get; set; }
        
        public int Ativo { get; set; }
    }
}