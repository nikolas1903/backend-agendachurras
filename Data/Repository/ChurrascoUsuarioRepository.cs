using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.ChurrascoUsuario;
using Domain.Models.Churrasco;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class
        ChurrascoUsuarioRepository<TChurrascoUsuarioEntity> : IChurrascoUsuarioRepository<TChurrascoUsuarioEntity>
        where TChurrascoUsuarioEntity : ChurrascoUsuarioEntity
    {
        protected readonly DatabaseContext _context;
        private DbSet<ChurrascoUsuarioEntity> _dataSet;

        public ChurrascoUsuarioRepository(DatabaseContext context)
        {
            _context = context;
            _dataSet = _context.Set<ChurrascoUsuarioEntity>();
        }


        public async Task<ConvidarUsuarioRequest> ConvidarUsuario(ConvidarUsuarioRequest request)
        {
            try
            {
                var convidarUsuario = new ChurrascoUsuarioEntity();

                convidarUsuario.UsuarioId = request.IdUsuario;
                convidarUsuario.ChurrascoId = request.IdChurrasco;
                convidarUsuario.DataCriacao = DateTime.Now;
                _dataSet.Add(convidarUsuario);

                await _context.SaveChangesAsync();
                
                return request;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<ConfirmarConvidadoRequest> ConfirmarConvidado(ConfirmarConvidadoRequest request)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p =>
                    p.UsuarioId.Equals(request.IdUsuario) && p.ChurrascoId.Equals(request.IdChurrasco) &&
                    p.PresencaConfirmada.Equals(0));
                if (result == null)
                {
                    return null;
                }

                var churrascoUsuario = new ChurrascoUsuarioEntity();
                churrascoUsuario.Id = result.Id;
                churrascoUsuario.ValorPago = request.ValorPago;
                churrascoUsuario.ValorPagoBebida = request.ValorPagoBebida;
                churrascoUsuario.DataPagamento = request.DataPagamento;
                churrascoUsuario.PresencaConfirmada = 1;
                churrascoUsuario.ChurrascoId = request.IdChurrasco;
                churrascoUsuario.UsuarioId = request.IdUsuario;
                churrascoUsuario.DataConfirmacao = DateTime.Now;
                churrascoUsuario.Observacoes = request.Observacoes;
                churrascoUsuario.DataCriacao = result.DataCriacao;

                _context.Entry(result).CurrentValues.SetValues(churrascoUsuario);
                await _context.SaveChangesAsync();

                return request;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ChurrascoUsuarioEntity>> BuscarConvidadosPorChurrasco(int idChurrasco)
        {
            try
            {
                var lConvidados = await _dataSet.ToListAsync();
                var convidados = new List<ChurrascoUsuarioEntity>();
                
                foreach (var convidado in lConvidados)
                {
                    if (convidado.ChurrascoId == idChurrasco)
                        convidados.Add(convidado);
                }

                return convidados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ExcluirConvidado(ExcluirConvidadoRequest request)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p =>
                    p.UsuarioId.Equals(request.IdUsuario) && p.ChurrascoId.Equals(request.IdChurrasco));
                if (result == null)
                    return false;

                _dataSet.Remove(result);
                await _context.SaveChangesAsync();
                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}