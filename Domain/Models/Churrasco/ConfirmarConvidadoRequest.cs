using System;

namespace Domain.Models.Churrasco
{
    public class ConfirmarConvidadoRequest
    {
        public int IdUsuario { get; set; }
        public int IdChurrasco { get; set; }
        public decimal ValorPago{ get; set; }
        public decimal ValorPagoBebida{ get; set; }
        public DateTime DataPagamento{ get; set; }
        public string Observacoes{ get; set; }
    }
}