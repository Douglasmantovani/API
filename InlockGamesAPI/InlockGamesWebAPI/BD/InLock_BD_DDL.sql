
Create Database InlockGames;
use InlockGames;

SELECT *from Jogo

CREATE TABLE TipoUsuario(
idTipoUsuario INT PRIMARY KEY IDENTITY,
Titulo VARCHAR(200)not null
);

CREATE TABLE Usuario(
idUsuario INT PRIMARY KEY IDENTITY,
Email VARCHAR(200)not null,
Senha VARCHAR(200)not null,
idTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(idTipoUsuario)not null
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
idEstudio INT FOREIGN KEY REFERENCES Estudio(idEstudio)not null
);

Select * FROM TipoUsuario
Select * FROM Usuario
Select * FROM Estudio
Select * FROM Jogo
 
 Insert into Usuario(Email,Senha,idTipoUsuario)
 Values ('Douglas@gmail.com','123123',1)

 Insert into TipoUsuario(Titulo)
 Values ('Admin'),('Comum')

