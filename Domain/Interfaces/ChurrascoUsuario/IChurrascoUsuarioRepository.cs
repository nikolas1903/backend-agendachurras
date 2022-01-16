using System.Threading.Tasks;
using Domain.Entities;
using Domain.Models.Churrasco;

namespace Domain.Interfaces.ChurrascoUsuario
{
    public interface IChurrascoUsuarioRepository<TChurrascoUsuarioEntity> where TChurrascoUsuarioEntity : ChurrascoUsuarioEntity
    {
        Task<ConvidarUsuarioRequest> ConvidarUsuario(ConvidarUsuarioRequest request);
        Task<ConfirmarConvidadoRequest> ConfirmarConvidado(ConfirmarConvidadoRequest request);
        
        Task<bool> ExcluirConvidado(ExcluirConvidadoRequest request);
        

    }
}