using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Churrasco;
using Domain.Models.Churrasco;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class ChurrascoRepository<TChurrascoEntity> : IChurrascoRepository<TChurrascoEntity>
        where TChurrascoEntity : ChurrascoEntity
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<ChurrascoEntity> _dataSet;

        public ChurrascoRepository(DatabaseContext context)
        {
            _context = context;
            _dataSet = _context.Set<ChurrascoEntity>();
        }

        public async Task<CadastrarChurrascoRequest> CadastrarChurrasco(CadastrarChurrascoRequest request)
        {
            try
            {
                var churrasco = new ChurrascoEntity();

                churrasco.Nome = request.Nome;
                churrasco.Descricao = request.Descricao;
                churrasco.Observacoes = request.Observacoes;
                churrasco.DataRealizacao = request.DataRealizacao;
                churrasco.ValorSugerido = request.ValorSugerido;
                churrasco.ValorSugeridoBebida = request.ValorSugeridoBebida;
                churrasco.Ativo = request.Ativo;
                churrasco.DataCriacao = DateTime.Now;
                _dataSet.Add(churrasco);

                await _context.SaveChangesAsync();
                
                return request;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ConfirmarConvidadoRequest> AlterarValorArrecadado(ConfirmarConvidadoRequest request)
        {
            try
            {
                // Implementado às 1:40 AM kkkk
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(request.IdChurrasco));
                var valorTotal = result.ValorArrecadado + request.ValorPago + request.ValorPagoBebida;

                var churrasco = new ChurrascoEntity();
                churrasco.Id = result.Id;
                churrasco.Nome = result.Nome;
                churrasco.Descricao = result.Descricao;
                churrasco.Observacoes = result.Observacoes;
                churrasco.DataRealizacao = result.DataRealizacao;
                churrasco.ValorArrecadado = valorTotal;
                churrasco.ValorSugerido = result.ValorSugerido;
                churrasco.Convidados = result.Convidados;
                churrasco.ConvidadosConfirmados = result.ConvidadosConfirmados;
                churrasco.ValorSugeridoBebida = result.ValorSugeridoBebida;
                churrasco.Ativo = result.Ativo;
                churrasco.DataCriacao = result.DataCriacao;

                _context.Entry(result).CurrentValues.SetValues(churrasco);
                await _context.SaveChangesAsync();
                
                return request;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ChurrascoEntity> BuscarChurrascoPorId(int idChurrasco)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(idChurrasco));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ConvidarUsuarioRequest> AlterarConvidados(ConvidarUsuarioRequest request)
        {
            try
            {
                // Implementado às 1:40 AM kkkk
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(request.IdChurrasco));
                var convidado = result.Convidados + 1;

                var churrasco = new ChurrascoEntity();
                churrasco.Id = result.Id;
                churrasco.Nome = result.Nome;
                churrasco.Descricao = result.Descricao;
                churrasco.Observacoes = result.Observacoes;
                churrasco.DataRealizacao = result.DataRealizacao;
                churrasco.ValorArrecadado = result.ValorArrecadado;
                churrasco.ValorSugerido = result.ValorSugerido;
                churrasco.Convidados = convidado;
                churrasco.ConvidadosConfirmados = result.ConvidadosConfirmados;
                churrasco.ValorSugeridoBebida = result.ValorSugeridoBebida;
                churrasco.Ativo = result.Ativo;
                churrasco.DataCriacao = result.DataCriacao;

                _context.Entry(result).CurrentValues.SetValues(churrasco);
                await _context.SaveChangesAsync();

                return request;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ConfirmarConvidadoRequest> AlterarConfirmados(ConfirmarConvidadoRequest request)
        {
            try
            {
                // Implementado às 1:40 AM kkkk zZzZzZz
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(request.IdChurrasco));
                var confirmados = result.ConvidadosConfirmados + 1;

                var churrasco = new ChurrascoEntity();
                churrasco.Id = result.Id;
                churrasco.Nome = result.Nome;
                churrasco.Descricao = result.Descricao;
                churrasco.Observacoes = result.Observacoes;
                churrasco.DataRealizacao = result.DataRealizacao;
                churrasco.ValorArrecadado = result.ValorArrecadado;
                churrasco.ValorSugerido = result.ValorSugerido;
                churrasco.Convidados = result.Convidados;
                churrasco.ConvidadosConfirmados = confirmados;
                churrasco.ValorSugeridoBebida = result.ValorSugeridoBebida;
                churrasco.Ativo = result.Ativo;
                churrasco.DataCriacao = result.DataCriacao;

                _context.Entry(result).CurrentValues.SetValues(churrasco);
                await _context.SaveChangesAsync();
                
                return request;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public async Task<IEnumerable<ChurrascoEntity>> BuscarChurrascos()
        {
            try
            {
                var lChurrascos = await _dataSet.ToListAsync();
                var churrascos = new List<ChurrascoEntity>();
                
                foreach (var churrasco in lChurrascos)
                {
                    if (churrasco.DataRealizacao > DateTime.Today)
                        churrascos.Add(churrasco);
                }

                return churrascos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}