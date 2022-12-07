using Microsoft.EntityFrameworkCore;
using TravelManage.Domain.Contracts.Repositories;
using TravelManage.Domain.Entities;
using TravelManage.Domain.Shared.ReportModels;
using TravelManage.Infra.Data.Context;

namespace TravelManage.Infra.Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
        protected readonly TravelManageContext _context;

        public ReportRepository(TravelManageContext context)
        {
            _context = context;
        }

        public async Task<IList<FaturamentoVeiculoReport>> FaturamentoVeiculo(int ano, int mes)
        {
            var retorno = new List<FaturamentoVeiculoReport>();
            var inicio = new DateTime(ano, mes, 1);
            var fim = new DateTime(ano, mes, 30);
            var viagens = await _context.Set<Viagem>()
                .Where(x => x.DataHoraInicio >= inicio && x.DataHoraFim <= fim)
                .Include(x => x.Veiculo)
                    .ThenInclude(x => x.Proprietario)
                .ToListAsync();
            var veiculosFaturamento = viagens.Select(x => new { x.Veiculo.Placa, x.Veiculo.IdProprietario, x.Veiculo.Proprietario.Nome }).GroupBy(x => x.Placa).ToList();
            foreach (var veiculo in veiculosFaturamento)
            {
                retorno.Add(new FaturamentoVeiculoReport
                {
                    IdProprietario = veiculo.First().IdProprietario,
                    NomeProprietario = veiculo.First().Nome,
                    PlacaVeiculo = veiculo.First().Placa,
                    QuantidadeViagem = viagens.Where(x => x.Veiculo.IdProprietario == veiculo.First().IdProprietario).Count(),
                    TotalFaturamento = viagens.Where(x => x.Veiculo.IdProprietario == veiculo.First().IdProprietario).Sum(x => x.ValorPagamento)
                });
            }
            return retorno.OrderBy(x => x.NomeProprietario).ThenBy(x => x.PlacaVeiculo).ToList();
        }

        public async Task<IList<MediaMensalViagemReport>> MediaMensalViagemReports()
        {
            var retorno = new List<MediaMensalViagemReport>();
            var mesesAnos = await _context.Set<Viagem>()
                .Select(x => new { x.DataHoraInicio.Year, x.DataHoraInicio.Month })
                .GroupBy(x => new { x.Year, x.Month })
                .ToListAsync();

            foreach (var item in mesesAnos)
            {
                var year = item.First().Year;
                var month = item.First().Month;
                retorno.Add(new MediaMensalViagemReport
                {
                    Ano = year,
                    Mes = month,
                    ViagensMasculino = _context.Set<Viagem>().Where(x => x.Passageiro.Sexo == SexoEnum.Masculino && x.DataHoraInicio.Year == year && x.DataHoraInicio.Month == month).Count(),
                    ViagensFeminino = _context.Set<Viagem>().Where(x => x.Passageiro.Sexo == SexoEnum.Feminino && x.DataHoraInicio.Year == year && x.DataHoraInicio.Month == month).Count()
                });
            }
            return retorno.OrderBy(x => x.Ano).ThenBy(x => x.Mes).ToList();
        }

        public async Task<IList<TopFaturamentoReport>> TopFaturamento(int ano, int mes)
        {
            var retorno = new List<TopFaturamentoReport>();
            var inicio = new DateTime(ano, mes, 1);
            var fim = new DateTime(ano, mes, 30);
            var viagens = await _context.Set<Viagem>()
                .Where(x => x.DataHoraInicio >= inicio && x.DataHoraFim <= fim)
                .Include(x => x.Veiculo)
                    .ThenInclude(x => x.Proprietario)
                 .ToListAsync();

            var proprietariosFaturamento = viagens.Select(x => new { x.Veiculo.IdProprietario, x.Veiculo.Proprietario.Nome }).GroupBy(x => x.IdProprietario).ToList();
            foreach (var propietario in proprietariosFaturamento)
            {
                retorno.Add(new TopFaturamentoReport
                {
                    IdProprietario = propietario.First().IdProprietario,
                    NomeProprietario = propietario.First().Nome,
                    QuantidadeViagem = viagens.Where(x => x.Veiculo.IdProprietario == propietario.First().IdProprietario).Count(),
                    Faturamento = viagens.Where(x => x.Veiculo.IdProprietario == propietario.First().IdProprietario).Sum(x => x.ValorPagamento)
                });
            }
            return retorno.OrderBy(x => x.Faturamento).Take(20).ToList();
        }

        public async Task<IList<VeiculosByViagemReport>> VeiculosByViagem(string placa, DateTime inicio, DateTime fim)
        {
            var retorno = await _context.Set<Viagem>()
                .Where(x => x.DataHoraInicio >= inicio && x.DataHoraFim <= fim && x.Veiculo.Placa == placa)
                .Include(x => x.Passageiro)
                .Include(x => x.Motorista)
                .Include(x => x.Veiculo)
                .Select(viagem => new VeiculosByViagemReport
                {
                    LocalDestino = viagem.LocalDestino,
                    LocalOrigem = viagem.LocalOrigem,
                    Marca = viagem.Veiculo.Marca,
                    MotoristaId = viagem.IdMotorista,
                    NomePassageiro = viagem.Passageiro.Nome,
                    NomeMotorista = viagem.Motorista.Nome,
                    PassageiroId = viagem.IdPassageiro,
                    Placa = viagem.Veiculo.Placa,
                    VeiculoId = viagem.IdVeiculo,
                    ViagemId = viagem.Id
                }).ToListAsync();
            return retorno;
        }
    }
}
