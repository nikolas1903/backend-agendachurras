using System.Threading.Tasks;
using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Models.Usuario.Requests;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Test
{
    public class UsuarioTest : BaseTest, IClassFixture<DatabaseTeste>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioTest(DatabaseTeste databaseTeste)
        {
            _serviceProvider = databaseTeste.ServiceProvider;
        }


        [Fact(DisplayName = "Teste Usuario")]
        [Trait("Teste", "Usuario")]
        public async Task Teste_Usuario()
        {
            await using (var context = _serviceProvider.GetService<DatabaseContext>())
            {
                UsuarioRepository<UsuarioEntity> repository = new UsuarioRepository<UsuarioEntity>(context);
                CadastrarUsuarioRequest entity = new CadastrarUsuarioRequest()
                {
                    Nome = "teste nome",
                    Login = "teste.login",
                    Cpf = "33322211100",
                    Senha = "102030",
                    Email = "teste.teste@teste.com",
                    Ativo = 1
                };


                var registroCriado = await repository.CadastrarUsuario(entity);
                Assert.NotNull(registroCriado);
                Assert.Equal("teste.login", registroCriado.Login);
                Assert.Equal("102030", registroCriado.Senha);
            }
        }
    }
}