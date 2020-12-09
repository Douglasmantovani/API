CREATE DATABASE SocialMidia;

USE SocialMidia;

CREATE TABLE TipoUsuario(
idTipoUsuario INT PRIMARY KEY IDENTITY,
NomeTipoUsuario varchar(35)
);
GO

CREATE TABLE BoxMensagem(
idBoxMensagem INT PRIMARY KEY,
);
GO

CREATE TABLE Usuario(
idUsuario INT PRIMARY KEY IDENTITY,
Email VARCHAR(35)NOT NULL UNIQUE,
Senha VARCHAR(20)NOT NULL,
NomeUsuario VARCHAR(35)NOT NULL,
idTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(idTipoUsuario),
idBoxMensagem INT FOREIGN KEY REFERENCES BoxMensagem(idBoxMensagem)
);
GO


CREATE TABLE Mensagem(
idMensagem INT PRIMARY KEY IDENTITY,
Mensagem VARCHAR(250)NOT NULL,
DataMensagem DATETIME,
idBoxMensagemDestino INT FOREIGN KEY REFERENCES BoxMensagem(idBoxMensagem)NOT NULL,
idUsuario INT FOREIGN KEY REFERENCES Usuario(idUsuario)not null 
);
GO

--Caso queira deletar o banco de dados
Use master;
DROP DATABASE SocialMidia