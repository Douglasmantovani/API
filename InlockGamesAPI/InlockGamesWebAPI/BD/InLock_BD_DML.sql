use InlockGames_Manh�;


SELECT *From Jogo

Select Jogo.TituloJogo,Jogo.Descricao,jogo.DataLan,Jogo.Valor,Estudio.NomeEstudio from Jogo
inner join Estudio on Estudio.idEstudio=Jogo.idEstudio;
