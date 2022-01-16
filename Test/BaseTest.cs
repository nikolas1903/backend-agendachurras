using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
        }
    }

    public class DatabaseTeste : IDisposable
    {
        private readonly string _dataBaseName = $"dbApiTest {Guid.NewGuid().ToString().Replace("-", String.Empty)}";
        public ServiceProvider ServiceProvider { get; set; }

        public DatabaseTeste()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<DatabaseContext>(o =>
                    o.UseSqlServer(
                        $"Server=tcp:agendachurras.database.windows.net,1433;Database={_dataBaseName};User ID=trinca;Password=Sup0rt3@;Trusted_Connection=False;Encrypt=True;"),
                ServiceLifetime.Transient);

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<DatabaseContext>())
            {
                context!.Database.EnsureCreated();
            }
        }


        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<DatabaseContext>())
            {
                context!.Database.EnsureCreated();
            }
        }
    }
}