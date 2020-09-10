USE Filmes
GO

INSERT INTO Genero(NomeGenero)
VALUES ('Ação'),
       ('Romance'), 
	   ('Terror'),
	   ('Comedia')


INSERT INTO Filme(NomeFilme, DataLancamento, Diretor, IdGenero)
VALUES ('A volta dos que não foram', '1987-09-14', 'Carlos Alberto de Nobrega', 3),
	   ('Star Wars IV', '1977-11-18', 'George Lucas', 4)


INSERT INTO Usuario(Nome, Email, Senha, IdTipoUsuario)
VALUES ('Douglas Mantovani', 'Douglas@email.com', 'Dougrinhas', 1),
	   ('Marcos', 'Marcos@email.com', 'Marcão', 2),
	   ('Andre', 'Andre@email.com', 'Andrezão', 2)

	   INSERT INTO TipoUsuario(NomeTipoUsuario)VALUES
	   ('Administrador'),('Comum')