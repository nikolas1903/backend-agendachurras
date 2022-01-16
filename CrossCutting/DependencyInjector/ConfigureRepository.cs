﻿using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Interfaces.Churrasco;
using Domain.Interfaces.ChurrascoUsuario;
using Domain.Interfaces.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjector
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IUsuarioRepository<UsuarioEntity>), typeof(UsuarioRepository<UsuarioEntity>));
            serviceCollection.AddScoped(typeof(IChurrascoRepository<ChurrascoEntity>), typeof(ChurrascoRepository<ChurrascoEntity>));
            serviceCollection.AddScoped(typeof(IChurrascoUsuarioRepository<ChurrascoUsuarioEntity>), typeof(ChurrascoUsuarioRepository<ChurrascoUsuarioEntity>));

            
            
            serviceCollection.AddDbContext<DatabaseContext>(
                options => options.UseSqlServer(
                    "Server=tcp:agendachurras.database.windows.net,1433;Database=Agenda;User ID=trinca;Password=Sup0rt3@;Trusted_Connection=False;Encrypt=True;"),
                ServiceLifetime.Transient
            );
        }
    }
}