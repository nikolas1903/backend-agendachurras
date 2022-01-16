using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Usuario;
using Domain.Models.Usuario.Requests;
using Domain.Utils;

namespace Services.Services.Usuario
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository<UsuarioEntity> _usuarioRepository;
        private const string Hash = "|2d331cca-f6c0-40c0-bb43-6e32989c2881";

        public UsuarioAppService(IUsuarioRepository<UsuarioEntity> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        /*
         * Método responsável por cadastrar um usuário.
         * Há restrição na criação do usuário, caso o mesmo tente inserir um Login que já existe no banco.
         */
        public async Task<RespostaPadrao> Cadastrar(CadastrarUsuarioRequest request)
        {
            var lUsuario = _usuarioRepository.BuscarUsuario(request);
            if (lUsuario.Result != null)
                return new RespostaPadrao().Falha("Usuário já cadastrado! Utilize outro Login para continuar.", null);

            // Criptografando a senha para mandar para o DB.
            request.Senha = MD5Hash.Hash($"{request.Senha}{Hash}");
            await _usuarioRepository.CadastrarUsuario(request);

            return new RespostaPadrao().Sucesso("Usuário cadastrado com sucesso!", null);
        }

        /*
         * Método responsável por fazer Login.
         * É verificada a existência do usuário e a equivalência da senha com o banco.
         */
        public async Task<RespostaPadrao> Login(LoginRequest request)
        {
            request.Senha = MD5Hash.Hash($"{request.Senha}{Hash}");
            var lUsuario = _usuarioRepository.BuscarUsuarioLogin(request);
            if (lUsuario.Result == null)
                return new RespostaPadrao().Falha("Usuário ou senha incorretos! Tente novamente.", null);

            if (lUsuario.Result.Ativo == 0)
                return new RespostaPadrao().Falha("Usuário inativo! Entre em contato com o suporte para reativar.", null);


            return new RespostaPadrao().Sucesso("Login efetuado com sucesso!", null);
        }
    }
}