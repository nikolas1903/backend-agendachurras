using System.Threading.Tasks;
using Domain.Interfaces.Churrasco;
using Domain.Models.Churrasco;
using Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace AgendaChurras.Controllers
{
    
    [Route("Churrasco")]
    public class ChurrascoController : ControllerBase
    {
        private readonly IChurrascoAppService _churrascoAppService;
        
        public ChurrascoController(IChurrascoAppService churrascoAppService)
        {
            _churrascoAppService = churrascoAppService;
        }


        [Produces("application/json")]
        [HttpPost("Cadastrar")]
        public async Task<RespostaPadrao> Cadastrar([FromBody] CadastrarChurrascoRequest request)
        {
            return await _churrascoAppService.Cadastrar(request);
        }
        
        [Produces("application/json")]
        [HttpPost("ConvidarUsuario")]
        public async Task<RespostaPadrao> ListarChurrascos([FromBody]ConvidarUsuarioRequest request)
        {
            return await _churrascoAppService.ConvidarUsuario(request);
        }
        
        [Produces("application/json")]
        [HttpPut("ConfirmarConvidado")]
        public async Task<RespostaPadrao> ConfirmarConvidado([FromBody]ConfirmarConvidadoRequest request)
        {
            return await _churrascoAppService.ConfirmarConvidado(request);
        }
        
        [Produces("application/json")]
        [HttpGet("BuscarChurrascoPorId")]
        public async Task<RespostaPadrao> BuscarChurrascoPorId(int idChurrasco)
        {
            return await _churrascoAppService.BuscarChurrascoPorId(idChurrasco);
        }
        
        [Produces("application/json")]
        [HttpGet("BuscarChurrascos")]
        public async Task<RespostaPadrao> BuscarChurrascos()
        {
            return await _churrascoAppService.BuscarChurrascos();
        }
        
        [Produces("application/json")]
        [HttpGet("BuscarConvidadosPorChurrasco")]
        public async Task<RespostaPadrao> BuscarConvidadosPorChurrasco(int idChurrasco)
        {
            return await _churrascoAppService.BuscarConvidadosPorChurrasco(idChurrasco);
        }
        
        [Produces("application/json")]
        [HttpDelete("ExcluirConvidado")]
        public async Task<RespostaPadrao> ExcluirConvidado([FromBody] ExcluirConvidadoRequest request)
        {
            return await _churrascoAppService.ExcluirConvidado(request);
        }
    }
}