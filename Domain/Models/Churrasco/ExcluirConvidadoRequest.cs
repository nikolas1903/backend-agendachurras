using System;

namespace Domain.Models.Churrasco
{
    public class ExcluirConvidadoRequest
    {

        public int IdUsuario { get; set; }
        public int IdChurrasco { get; set; }
    }
}