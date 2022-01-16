using System;

namespace Domain.Models.Churrasco
{
    public class CadastrarChurrascoRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataRealizacao { get; set; }
        public decimal ValorSugerido { get; set; }
        public decimal ValorSugeridoBebida { get; set; }
        
        public int Ativo { get; set; }
    }
}