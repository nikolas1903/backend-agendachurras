using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Churrasco;
using Domain.Interfaces.ChurrascoUsuario;
using Domain.Interfaces.Usuario;
using Domain.Models.Churrasco;
using Domain.Utils;

namespace Services.Services.Churrasco
{
    public class ChurrascoAppService : IChurrascoAppService
    {
        private readonly IChurrascoRepository<ChurrascoEntity> _churrascoRepository;
        private readonly IChurrascoUsuarioRepository<ChurrascoUsuarioEntity> _churrascoUsuarioRepository;
        private readonly IUsuarioRepository<UsuarioEntity> _usuarioRepository;

        public ChurrascoAppService(IChurrascoRepository<ChurrascoEntity> churrascoRepository,
            IChurrascoUsuarioRepository<ChurrascoUsuarioEntity> churrascoUsuarioRepository,
            IUsuarioRepository<UsuarioEntity> usuarioRepository)
        {
            _churrascoRepository = churrascoRepository;
            _churrascoUsuarioRepository = churrascoUsuarioRepository;
            _usuarioRepository = usuarioRepository;
        }
        
        /*
         * Método responsável por cadastrar um churrasco.
         * Não há restrição para o cadastro do mesmo, além de que os campos obrigatórios tenham sido preenchidos.
         */
        public async Task<RespostaPadrao> Cadastrar(CadastrarChurrascoRequest request)
        {
            try
            {
                if (String.IsNullOrEmpty(request.Nome))
                    return new RespostaPadrao().Falha("Nome deve ser preenchido.", null);

                await _churrascoRepository.CadastrarChurrasco(request);
                
                return new RespostaPadrao().Sucesso("Churrasco cadastrado com sucesso!", request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
         * Método responsável por convidar um usuário para o evento.
         * É criada uma relação na tabela ChurrascoUsuario, além de atualizar o número de convidados para o evento.
         * É também validada a existência de um usuário e um evento para os ID's da Request.
         */
        public async Task<RespostaPadrao> ConvidarUsuario(ConvidarUsuarioRequest request)
        {
            try
            {
                var lChurrasco = await _churrascoRepository.BuscarChurrascoPorId(request.IdChurrasco);
                if (lChurrasco == null)
                    return new RespostaPadrao().Falha("Nenhum evento encontrado!", null);

                var lUsuario = await _usuarioRepository.BuscarUsuarioPorId(request.IdUsuario);
                if (lUsuario == null)
                    return new RespostaPadrao().Falha("Nenhum usuário encontrado!", null);
                
                await _churrascoUsuarioRepository.ConvidarUsuario(request);
                await _churrascoRepository.AlterarConvidados(request);
                
                return new RespostaPadrao().Sucesso("Usuário convidado com sucesso!", request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
         * Método responsável por confirmar a presença do convidado ao evento.
         * É atualizada a tabela ChurrascoUsuario, e também a tabela Churrasco, alterando o número de presenças no evento.
         * São feitas as validações necessárias para que o aplicativo não trave.
         */
        public async Task<RespostaPadrao> ConfirmarConvidado(ConfirmarConvidadoRequest request)
        {
            try
            {
                if (request.ValorPago == 0 && request.ValorPagoBebida == 0)
                    return new RespostaPadrao().Falha("Informe pelo menos um valor de pagamento!", null);

                var lChurrascoUsuario = await _churrascoUsuarioRepository.ConfirmarConvidado(request);
                if (lChurrascoUsuario == null)
                    return new RespostaPadrao().Falha(
                        "Este usuário não foi convidado para este churrasco, ou sua presença já está confirmada.",
                        null);

                await _churrascoRepository.AlterarValorArrecadado(request);
                await _churrascoRepository.AlterarConfirmados(request);

                return new RespostaPadrao().Sucesso("Convidado confirmado com sucesso!", request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
         * Método responsável por buscar um churrasco pelo seu ID.
         * É feita a validação se o churrasco existe.
         */
        public async Task<RespostaPadrao> BuscarChurrascoPorId(int idChurrasco)
        {
            try
            {
                var lChurrasco = await _churrascoRepository.BuscarChurrascoPorId(idChurrasco);
                if (lChurrasco == null)
                    return new RespostaPadrao().Falha("Nenhum churrasco encontrado.", null);

                return new RespostaPadrao().Sucesso("Churrasco listado com sucesso!", lChurrasco);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
         * Método responsável por buscar os churrascos pendentes.
         * É feita a validação se a data de realização do churrasco é maior do que a data de hoje, e só são mostrados os churrascos que ainda não ocorreram.
         */
        public async Task<RespostaPadrao> BuscarChurrascos()
        {
            try
            {
                var lChurrascos = await _churrascoRepository.BuscarChurrascos();
                if (lChurrascos == null)
                    return new RespostaPadrao().Falha("Não há churrascos disponíveis no momento.", null);

                return new RespostaPadrao().Sucesso("Churrascos listados com sucesso!", lChurrascos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RespostaPadrao> BuscarConvidadosPorChurrasco(int idChurrasco)
        {
            try
            {
                var lConvidados = await _churrascoUsuarioRepository.BuscarConvidadosPorChurrasco(idChurrasco);
                if (lConvidados == null)
                    return new RespostaPadrao().Falha("Nenhum convidado para este evento.", null);
                
                return new RespostaPadrao().Sucesso("", lConvidados);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /*
         * Método responsável por excluir um convidado do churrasco.
         * É feita a validação se este usuário foi convidado para o churrasco ou não, e se o churrasco e usuário existem.
         */
        public async Task<RespostaPadrao> ExcluirConvidado(ExcluirConvidadoRequest request)
        {
            try
            {
                var lChurrasco = await _churrascoRepository.BuscarChurrascoPorId(request.IdChurrasco);
                if (lChurrasco == null)
                    return new RespostaPadrao().Falha("Nenhum evento encontrado!", null);

                var lUsuario = await _usuarioRepository.BuscarUsuarioPorId(request.IdUsuario);
                if (lUsuario == null)
                    return new RespostaPadrao().Falha("Nenhum usuário encontrado!", null);

                await _churrascoUsuarioRepository.ExcluirConvidado(request);

                return new RespostaPadrao().Sucesso("Convidado excluído' com sucesso!", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}