using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Models.Churrasco;

namespace Domain.Interfaces.Churrasco
{
    public interface IChurrascoRepository<TChurrascoEntity> where TChurrascoEntity : ChurrascoEntity
    {
        Task<CadastrarChurrascoRequest> CadastrarChurrasco(CadastrarChurrascoRequest request);
        Task<ConfirmarConvidadoRequest> AlterarValorArrecadado(ConfirmarConvidadoRequest request);
        Task<ChurrascoEntity> BuscarChurrascoPorId(int idChurrasco);
        Task<ConvidarUsuarioRequest> AlterarConvidados(ConvidarUsuarioRequest request);
        Task<ConfirmarConvidadoRequest> AlterarConfirmados(ConfirmarConvidadoRequest request);
        Task<IEnumerable<ChurrascoEntity>> BuscarChurrascos();
        
    }
}