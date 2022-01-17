using System.Threading.Tasks;
using Domain.Models.Churrasco;
using Domain.Utils;

namespace Domain.Interfaces.Churrasco
{
    public interface IChurrascoAppService
    {
        Task<RespostaPadrao> Cadastrar(CadastrarChurrascoRequest request);
        Task<RespostaPadrao> ConvidarUsuario(ConvidarUsuarioRequest request);
        Task<RespostaPadrao> ConfirmarConvidado(ConfirmarConvidadoRequest request);
        Task<RespostaPadrao> BuscarChurrascoPorId(int idChurrasco);
        Task<RespostaPadrao> BuscarChurrascos();
        Task<RespostaPadrao> BuscarConvidadosPorChurrasco(int idChurrasco);
        Task<RespostaPadrao> ExcluirConvidado(ExcluirConvidadoRequest request);
    }
}