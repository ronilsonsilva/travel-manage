

CREATE DATABASE CMP1611_RONILSON3;

CREATE TABLE Veiculo 
(
    Id  serial primary key,
    IdProprietario int null references Proprietarios(Id),
    Placa varchar(7) not null,
    Marca varchar(30) not null,
    Modelo varchar(30) not null,
    AnoFabric int not null,
    CapacidadePass int not null,
    Cor varchar(30) not null,
    TipoCombustivel int not null,
    PotenciaMotor int null
);

CREATE TABLE Pessoas 
(
    Id  serial primary key,
    Cpf varchar(11) not null unique,
    Nome varchar(50) not null,
    Endereco varchar(50) null,
    Telefone varchar(20) null,
    Sexo int null,
    Email varchar(50) null
);


CREATE TABLE Passageiros 
(
    Id  serial primary key references Pessoas(Id),
    CartaoCredito varchar(20) null,
    BandeiraCartao varchar(20) null,
    CidadeOrig varchar(30) null
);

CREATE TABLE Motoristas
(
    Id  serial primary key references Pessoas(Id),
    Cnh varchar(15) not null,
    Banco int not null,
    Agencia int not null,
    Conta int not null
);


CREATE TABLE Proprietarios
(
    Id  serial primary key references Pessoas(Id),
    Cnh varchar(15) not null,
    Banco int not null,
    Agencia int not null,
    Conta int not null
);


CREATE TABLE TipoPagamento 
(
    Codigo serial primary key,
    Descricao varchar(20) not null
);


CREATE TABLE Viagem
(
    Id  serial primary key,
    IdPassageiro int not null references Passageiros(Id),
    IdMotorista int null references Motoristas(Id),
    IdVeiculo int null references Veiculo(Id),
    LocalOrigem varchar(30) not null,
    LocalDestino varchar(30) not null,
    DataHoraInicio timestamp not null,
    DataHoraFim timestamp null,
    QuantidadePassageiros int null,
    FormaPagamento int references TipoPagamento(Codigo),
    ValorPagamento numeric (10,2) null,
    CanceladoMotorista boolean null,
    CanceladoPassageiro boolean null
);

CREATE TABLE MotoristaVeiculo
(
    Id  serial primary key, 
    IdMotorista int null references Motoristas(Id),
    IdVeiculo int null references Veiculo(Id)
);
