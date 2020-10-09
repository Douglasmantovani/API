CREATE DATABASE Senatur_Manha;
​
​
USE Senatur_Manha;
​
​
CREATE TABLE TipoUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY
	,TituloTipoUsuario VARCHAR (255) NOT NULL UNIQUE
	);
	
	CREATE TABLE Usuario (
	IdUsuario INT PRIMARY KEY IDENTITY
	,Email VARCHAR (255) NOT NULL UNIQUE
	,Senha VARCHAR (255) NOT NULL
	,IdTipousuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
	);
​
	CREATE TABLE Pacote (
	IdUsuario INT PRIMARY KEY IDENTITY
	,NomePacote VARCHAR (255) NOT NULL
	,Descricao text
	,Dataida DATE NOT NULL
	,Datavolta DATE NOT NULL
	,Valor DECIMAL NOT NULL
	,Cidade VARCHAR (255)
	,Ativo BIT DEFAULT (1) NOT NULL
	);

	drop table Pacote
