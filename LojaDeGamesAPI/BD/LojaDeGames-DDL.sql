CREATE DATABASE LojaDeGames;

Use LojaDeGames;

use master;

CREATE TABLE TipoUsuario(
idTipoUsuario INT PRIMARY KEY IDENTITY,
NomeTipoUsuario VARCHAR(30) UNIQUE not null
);

CREATE TABLE Usuario(
idUsuario INT PRIMARY KEY IDENTITY,
Email VARCHAR(30)UNIQUE not null,
Nome VARCHAR(30)not null,
Senha VARCHAR(20)not null,
Telefone VARCHAR(15),
idCarrinho int Foreign key references Carrinho(idCarrinho),
idTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(idTipoUsuario)not null
);

CREATE TABLE Carrinho(
idCarrinho INT Primary key identity,
idJogo int Foreign key references Jogo(idJogo),
idJogo2 int Foreign key references Jogo(idJogo),
idJogo3 int Foreign key references Jogo(idJogo),
ValorContido DECIMAL DEFAULT(0)
);

CREATE TABLE Estudio (
idEstudio INT PRIMARY KEY IDENTITY,
NomeEstudio VARCHAR(200)Not null
);

CREATE TABLE Jogo(
idJogo INT PRIMARY KEY IDENTITY,
TituloJogo VARCHAR(40)NOT NULL,
Descricao text not null,
DataLan DATE NOT NULL,
Valor Decimal not null,
Capa IMAGE,
Promocao BIT DEFAULT(0),
idEstudio INT FOREIGN KEY REFERENCES Estudio(idEstudio)not null,
Caminho Varchar(300)
);

CREATE TABLE Compra(
idCompra INT primary KEY IDENTITY,
idUsuario INT FOREIGN KEY REFERENCES Usuario(idUsuario)Not null,
idJogo int Foreign key references Jogo(idJogo)NOT NULL,
idJogo2 int Foreign key references Jogo(idJogo),
idJogo3 int Foreign key references Jogo(idJogo),
NomeTitular VARCHAR(30),
NumeroCartao VARCHAR(30),
Validade DATE,
CVV VARCHAR(3),
Valor DECIMAL DEFAULT(0),
DataCompra DATE NOT NULL
);

Select * FROM TipoUsuario
Select * FROM Estudio
Select * FROM Jogo
Select * FROM Usuario
Select * FROM Compra
Select * FROM Carrinho

