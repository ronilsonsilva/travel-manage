using TravelManage.Application.Contracts;
using TravelManage.Domain.Contracts.DomainServices;
using TravelManage.Domain.Entities;

namespace TravelManage.Application.Services
{
    public class SeedDataApplication : ISeedDataApplication
    {
        private readonly IDomainServices<Motoristas> _motoristaService;
        private readonly IDomainServices<Passageiros> _passageiroService;
        private readonly IDomainServices<Proprietarios> _proprietarioService;
        private readonly IDomainServices<Veiculo> _veiculoService;
        private readonly IDomainServices<Viagem> _viagemService;
        private readonly IDomainServices<TipoPagamento> _tipoPagamentoService;

        private IList<string> _bandeirasCartao = new List<string> { "VISA", "MASTERCARD", "SODEXO", "AME" };
        private IList<string> _marcaVeiculo = new List<string> { "Honda", "Hiunday", "Volkswagem", "Toyota" };
        private IList<Passageiros> _passageiros;
        private IList<Proprietarios> _proprietarios;
        private IList<Veiculo> _veiculos;
        private IList<Viagem> _viagens;
        private IList<TipoPagamento> _tipoPagamento;
        private IList<Motoristas> _motoristas;

        public SeedDataApplication(IDomainServices<Motoristas> motoristaService, IDomainServices<Passageiros> passageiroService, IDomainServices<Proprietarios> proprietarioService, IDomainServices<Veiculo> veiculoService, IDomainServices<Viagem> viagemService, IDomainServices<TipoPagamento> tipoPagamentoService)
        {
            _motoristaService = motoristaService;
            _passageiroService = passageiroService;
            _proprietarioService = proprietarioService;
            _veiculoService = veiculoService;
            _viagemService = viagemService;
            _tipoPagamentoService = tipoPagamentoService;
        }

        public async Task Seed()
        {
            try
            {
                _tipoPagamento = await _tipoPagamentoService.Get();

                //_proprietarios = CreateProprietarios();
                //await _proprietarioService.AddRange(_proprietarios);
                _proprietarios = await _proprietarioService.Get();

                //_motoristas = CreateMotorista();
                //await _motoristaService.AddRange(_motoristas);
                _motoristas = await _motoristaService.Get();

                //_passageiros = CreatePassageiros();
                //await _passageiroService.AddRange(_passageiros);
                _passageiros = await _passageiroService.Get();

                //_veiculos = CreateVeiculos();
                //await _veiculoService.AddRange(_veiculos);
                _veiculos = await _veiculoService.Get();

                _viagens = CreateViagem();
                await _viagemService.AddRange(_viagens);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private IList<Viagem> CreateViagem()
        {
            Random numberGen = new Random();
            var viagens = new List<Viagem>();

            for (int i = 0; i < 3000; i++)
            {
                var idPassageiro = _passageiros[numberGen.Next(0, _passageiros.Count - 1)].Id;
                var idMotorista = _motoristas[numberGen.Next(0, _motoristas.Count - 1)].Id;
                var idVeiculo = _veiculos[numberGen.Next(0, _veiculos.Count)].Id;
                var dataInicio = new DateTime(year: 2022, month: numberGen.Next(10, 11), day: numberGen.Next(1, 30), hour: numberGen.Next(0, 23), minute: numberGen.Next(0, 59), second: numberGen.Next(0, 59));
                var dataFim = new DateTime(year: 2022, month: dataInicio.Month, day: dataInicio.Day, hour: dataInicio.Hour, minute: dataInicio.Minute, second: dataInicio.Second);
                dataFim.AddHours(numberGen.Next(0, 23));
                dataFim.AddMinutes(numberGen.Next(0, 59));
                dataFim.AddSeconds(numberGen.Next(0, 59));

                var viagem = new Viagem(idPassageiro: idPassageiro, idMotorista: idMotorista, idVeiculo: idVeiculo, localOrigem: RandomString(15), localDestino: RandomString(15), dataHoraInicio: dataInicio, quantidadePassageiros: numberGen.Next(1, 4), _tipoPagamento[numberGen.Next(0, 2)].Codigo);
                viagem.ValorPagamento = numberGen.Next(10,500);
                viagem.DataHoraFim = dataFim;

                viagens.Add(viagem);
            }

            return viagens;
        }

        private IList<Veiculo> CreateVeiculos()
        {
            Random numberGen = new Random();
            var veiculos = new List<Veiculo>();
            for (int i = 0; i < 100; i++)
            {
                veiculos.Add(new Veiculo(placa: RandomNuberAlfanumero(7), marca: _marcaVeiculo[numberGen.Next(0, 3)], modelo: RandomNuberAlfanumero(6), anoFabric: numberGen.Next(2000, 2023), capacidadePass: 4, cor: RandomString(6), tipoCompustivel: (TipoCombustivelEnum)numberGen.Next(1, 4), potenciaMotor: 180, idProprietario: _proprietarios[numberGen.Next(0, _proprietarios.Count - 1)].Id));
            }

            return veiculos;
        }

        private IList<Passageiros> CreatePassageiros()
        {
            Random numberGen = new Random();
            var passageiros = new List<Passageiros>();
            for (int i = 0; i < 200; i++)
            {
                Pessoas pessoa = CreatePessoa(numberGen);
                passageiros.Add(new Passageiros(cartaoCredito: RandomNuberString(12), bandeiraCartao: _bandeirasCartao[numberGen.Next(0, 3)], cidadeOrig: RandomString(10), cpf: numberGen.NextInt64(10000000000, 99999999999).ToString(), nome: RandomString(8) + " " + RandomString(6), endereco: RandomString(15), telefone: RandomNuberString(11), sexo: (SexoEnum)numberGen.Next(1, 2), email: RandomString(15)));
            }

            return passageiros;
        }

        private IList<Proprietarios> CreateProprietarios()
        {
            Random numberGen = new Random();
            var proprietarios = new List<Proprietarios>();

            for (int i = 0; i < 50; i++)
            {
                Pessoas pessoa = CreatePessoa(numberGen);
                proprietarios.Add(new Proprietarios(cnh: numberGen.Next(100000, 999999).ToString(), banco: numberGen.Next(1, 1000), agencia: numberGen.Next(1, 10000), conta: numberGen.Next(1, 100000), cpf: numberGen.NextInt64(10000000000, 99999999999).ToString(), nome: RandomString(8) + " " + RandomString(6), endereco: RandomString(15), telefone: RandomNuberString(11), sexo: (SexoEnum)numberGen.Next(1, 2), email: RandomString(15)));
            }

            return proprietarios;
        }

        private IList<Motoristas> CreateMotorista()
        {
            Random numberGen = new Random();
            var motoristas = new List<Motoristas>();

            for (int i = 0; i < 50; i++)
            {
                Pessoas pessoa = CreatePessoa(numberGen);
                motoristas.Add(new Motoristas(cnh: numberGen.Next(100000, 999999).ToString(), banco: numberGen.Next(1, 1000), agencia: numberGen.Next(1, 10000), conta: numberGen.Next(1, 100000), cpf: numberGen.NextInt64(10000000000, 99999999999).ToString(), nome: RandomString(8) + " " + RandomString(6), endereco: RandomString(15), telefone: RandomNuberString(11), sexo: (SexoEnum)numberGen.Next(1, 2), email: RandomString(15)));
            }

            return motoristas;
        }


        private Pessoas CreatePessoa(Random numberGen)
        {
            return new Pessoas(cpf: numberGen.NextInt64(10000000000, 99999999999).ToString(), nome: RandomString(8) + " " + RandomString(6), endereco: RandomString(15), telefone: RandomNuberString(11), sexo: (SexoEnum)numberGen.Next(1, 2), email: RandomString(15));
        }

        public  string RandomString(int length)
        {
            Random numberGen = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[numberGen.Next(s.Length)]).ToArray());
        }

        public  string RandomNuberString(int length)
        {
            Random numberGen = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[numberGen.Next(s.Length)]).ToArray());
        }

        public  string RandomNuberAlfanumero(int length)
        {
            Random numberGen = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[numberGen.Next(s.Length)]).ToArray());
        }
    }
}
