-- Define o banco de dados que ser� utilizado
USE Gufi;
GO

-- SELECT ALL FROM TABLES
SELECT * FROM TipoUsuario;
SELECT * FROM TipoEvento;
SELECT * FROM Instituicao;
SELECT * FROM Usuario;
SELECT * FROM Evento;
SELECT * FROM Presenca;
GO

-- LISTAR TODOS OS USU�RIOS CADASTRADOS
SELECT
	U.NomeUsuario AS Usuario,
	TU.TituloTipoUsuario AS Perfil,
	U.Email,
	U.DataNascimento,
	U.Genero 
FROM Usuario U
INNER JOIN TipoUsuario TU 
ON U.IdTipousuario = TU.IdTipoUsuario;
GO

-- OUTRA FORMA
/*
	SELECT 
		Usuario.NomeUsuario AS Usuario, 
		TipoUsuario.TituloTipoUsuario AS Perfil, 
		Usuario.Email, 
		Usuario.DataNascimento, 
		Usuario.Genero 
	FROM Usuario
	INNER JOIN TipoUsuario 
	ON Usuario.IdTipousuario = TipoUsuario.IdTipoUsuario;
	GO
*/

-- LISTAR TODAS AS INSTITUI��ES CADASTRADAS (CNPJ, NOME FANTASIA, ENDERE�O)
SELECT 
	I.CNPJ
	,I.NomeFantasia
	,I.Endereco
FROM Instituicao I;
GO

-- LISTAR TODOS OS TIPOS DE EVENTOS (Titulo)
SELECT TE.TituloTipoEvento AS Tema FROM TipoEvento TE;
GO

-- LISTAR TODOS OS EVENTOS 
-- (NOME EVENTO, TIPO, DATA, PUBLICO OU PRIVADO, DESCRICAO, DADOS DA INSTITUICAO)
SELECT
	E.NomeEvento AS Evento
	,TE.TituloTipoEvento AS Tema
	,E.DataEvento
	,E.AcessoLivre
	,E.Descricao
	,I.NomeFantasia AS [Local]
	,I.Endereco
FROM Evento E
INNER JOIN TipoEvento TE
ON E.IdTipoEvento = TE.IdTipoEvento
INNER JOIN Instituicao I
ON E.IdInstituicao = I.IdInstituicao;
GO

-- LISTAR APENAS OS EVENTOS QUE S�O P�BLICOS 
-- (NOME EVENTO, TIPO, DATA, PUBLICO OU PRIVADO, DESCRICAO, DADOS DA INSTITUICAO)
SELECT
	E.NomeEvento AS Evento
	,TE.TituloTipoEvento AS Tema
	,E.DataEvento
	,E.AcessoLivre
	,E.Descricao
	,I.NomeFantasia AS [Local]
	,I.Endereco
FROM Evento E
INNER JOIN TipoEvento TE
ON E.IdTipoEvento = TE.IdTipoEvento
INNER JOIN Instituicao I
ON E.IdInstituicao = I.IdInstituicao
WHERE E.AcessoLivre = 1;
GO

-- LISTAR TODOS OS EVENTOS QUE UM DETERMINADO USU�RIO PARTICIPA 
-- (NOME EVENTO, TIPO, DATA, PUBLICO OU PRIVADO, DESCRICAO, DADOS DA INSTITUICAO, DADOS DO USUARIO)
SELECT
	E.NomeEvento AS Evento
	,TE.TituloTipoEvento AS Tema
	,E.DataEvento
	,E.AcessoLivre
	,E.Descricao
	,I.NomeFantasia AS [Local]
	,I.Endereco
	,U.NomeUsuario AS Participante,
	TU.TituloTipoUsuario AS Perfil,
	U.Email
FROM Presenca P
INNER JOIN Usuario U
ON P.IdUsuario = U.IdUsuario
INNER JOIN TipoUsuario TU
ON U.IdTipoUsuario = TU.IdTipoUsuario
INNER JOIN Evento E
ON P.IdEvento = E.IdEvento
INNER JOIN TipoEvento TE
ON E.IdTipoEvento = TE.IdTipoEvento
INNER JOIN Instituicao I
ON E.IdInstituicao = I.IdInstituicao
WHERE P.IdUsuario = 2;
GO

-- AO LISTAR OS EVENTOS, MOSTRAR NA COLUNA ACESSOLIVRE O VALOR 'PUBLICO' QUANDO FOR 1 E 'PRIVADO' QUANDO FOR 0
SELECT
	E.NomeEvento AS Evento
	,TE.TituloTipoEvento AS Tema
	,E.DataEvento
	,CASE WHEN E.AcessoLivre = 1 THEN 'P�blico' ELSE 'Privado' END AS Acesso
	,E.Descricao
	,I.NomeFantasia AS [Local]
	,I.Endereco
FROM Evento E
INNER JOIN TipoEvento TE
ON E.IdTipoEvento = TE.IdTipoEvento
INNER JOIN Instituicao I
ON E.IdInstituicao = I.IdInstituicao;
GO

-- AO LISTAR OS EVENTOS QUE UM USU�RIO PARTICIPA, MOSTRAR APENAS OS EVENTOS COM A SITUA��O 'CONFIRMADA'
SELECT
	E.NomeEvento AS Evento
	,TE.TituloTipoEvento AS Tema
	,E.DataEvento
	,CASE E.AcessoLivre WHEN 1 THEN 'P�blico' WHEN 0 THEN 'Privado' END AS Acesso
	,E.Descricao
	,I.NomeFantasia AS [Local]
	,I.Endereco
	,U.NomeUsuario AS Participante,
	TU.TituloTipoUsuario AS Perfil,
	U.Email
FROM Presenca P
INNER JOIN Usuario U
ON P.IdUsuario = U.IdUsuario
INNER JOIN TipoUsuario TU
ON U.IdTipoUsuario = TU.IdTipoUsuario
INNER JOIN Evento E
ON P.IdEvento = E.IdEvento
INNER JOIN TipoEvento TE
ON E.IdTipoEvento = TE.IdTipoEvento
INNER JOIN Instituicao I
ON E.IdInstituicao = I.IdInstituicao
WHERE P.IdUsuario = 2 AND P.Situacao = 'Confirmada';
GO