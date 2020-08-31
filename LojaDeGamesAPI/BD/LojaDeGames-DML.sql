USE LojaDeGames;

use master;

SET IDENTITY_INSERT [dbo].[Estudio] ON 
INSERT [dbo].[Estudio] ([idEstudio], [NomeEstudio]) VALUES (1, N'RockstarGames')
INSERT [dbo].[Estudio] ([idEstudio], [NomeEstudio]) VALUES (2, N'SquareEnix')
INSERT [dbo].[Estudio] ([idEstudio], [NomeEstudio]) VALUES (3, N'NaughtyDog')
INSERT [dbo].[Estudio] ([idEstudio], [NomeEstudio]) VALUES (4, N'Blizzard')
INSERT [dbo].[Estudio] ([idEstudio], [NomeEstudio]) VALUES (5, N'CD Projeckt Red')
INSERT [dbo].[Estudio] ([idEstudio], [NomeEstudio]) VALUES (6, N'Bioware')
INSERT [dbo].[Estudio] ([idEstudio], [NomeEstudio]) VALUES (7, N'EA')
INSERT [dbo].[Estudio] ([idEstudio], [NomeEstudio]) VALUES (8, N'Ubsoft')
INSERT [dbo].[Estudio] ([idEstudio], [NomeEstudio]) VALUES (9, N'Konami')
INSERT [dbo].[Estudio] ([idEstudio], [NomeEstudio]) VALUES (10, N'2K')
INSERT [dbo].[Estudio] ([idEstudio], [NomeEstudio]) VALUES (11, N'Kojima Productions')
SET IDENTITY_INSERT [dbo].[Estudio] OFF
GO

 Insert into Usuario(Email,Senha,idTipoUsuario,Nome)
 Values ('Douglas@gmail.com','123123',1,'Douglas Silva')

Insert into TipoUsuario(NomeTipoUsuario)Values
('Administrador'),('Comum')


 Insert into Carrinho(idJogo,ValorContido)
 VALUES (4,320)

 Insert into Compra (idUsuario,Valor,DataCompra,)Values
 (1,320,'20-10-2020')



SET IDENTITY_INSERT [dbo].[Jogo] ON 

INSERT [dbo].[Jogo] ([idJogo], [TituloJogo], [Descricao], [DataLan], [Valor], [Capa], [Promocao], [idEstudio], [Caminho]) VALUES (2, N'Red Dead Redemption 2', N'Red Dead Redemption II é um jogo eletrônico de ação-aventura western desenvolvido pela Rockstar Studios.', CAST(N'0001-01-01' AS Date), CAST(120 AS Decimal(18, 0)), NULL, 0, 1, N'https://3er1viui9wo30pkxh1v2nh4w-wpengine.netdna-ssl.com/wp-content/uploads/prod/sites/42/2020/04/RDR_XBOX_1920X1080-WIRE-5ea198f09b883-960x640.jpg')
INSERT [dbo].[Jogo] ([idJogo], [TituloJogo], [Descricao], [DataLan], [Valor], [Capa], [Promocao], [idEstudio], [Caminho]) VALUES (3, N'Diablo3', N' é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.', CAST(N'2018-05-15' AS Date), CAST(99 AS Decimal(18, 0)), NULL, 0, 4, N'https://s3-us-west-2.amazonaws.com/gplaygames/diablo_3.jpg')
INSERT [dbo].[Jogo] ([idJogo], [TituloJogo], [Descricao], [DataLan], [Valor], [Capa], [Promocao], [idEstudio], [Caminho]) VALUES (4, N'The Last of Us Part II', N' The Last of Us Part II é um jogo eletrônico de ação-aventura e sobrevivência desenvolvido pela Naughty Dog e publicado pela Sony Interactive Entertainment. É uma sequência de The Last of Us.', CAST(N'2020-06-19' AS Date), CAST(320 AS Decimal(18, 0)), NULL, 0, 3, N'http://www.suacidade.com/sites/default/files/2020/The%20last%20Of%20Us%202%20Foto.Naughty%20Dog%20%28Facebook%29._1.jpg')
INSERT [dbo].[Jogo] ([idJogo], [TituloJogo], [Descricao], [DataLan], [Valor], [Capa], [Promocao], [idEstudio], [Caminho]) VALUES (5, N'Final Fantasy VII Remake', N' Final Fantasy VII Remake é um jogo eletrônico de RPG de ação desenvolvido e publicado pela Square Enix.', CAST(N'2020-04-10' AS Date), CAST(200 AS Decimal(18, 0)), NULL, 0, 2, N'https://images-na.ssl-images-amazon.com/images/I/51NUSDR6DQL._SX331_BO1,204,203,200_.jpg')
INSERT [dbo].[Jogo] ([idJogo], [TituloJogo], [Descricao], [DataLan], [Valor], [Capa], [Promocao], [idEstudio], [Caminho]) VALUES (6, N'The witcher 3', N' The Witcher 3: Wild Hunt é um jogo eletrônico de ação do subgênero RPG desenvolvido pela CD Projekt RED', CAST(N'2015-05-19' AS Date), CAST(120 AS Decimal(18, 0)), NULL, 0, 5, N'https://upload.wikimedia.org/wikipedia/pt/0/06/TW3_Wild_Hunt.png')
INSERT [dbo].[Jogo] ([idJogo], [TituloJogo], [Descricao], [DataLan], [Valor], [Capa], [Promocao], [idEstudio], [Caminho]) VALUES (7, N'Dragon Age Inquisition', N' Dragon Age: Inquisition é um jogo eletrônico de RPG de ação desenvolvido pela BioWare e publicado pela Electronic Arts', CAST(N'2014-11-19' AS Date), CAST(100 AS Decimal(18, 0)), NULL, 0, 6, N'https://upload.wikimedia.org/wikipedia/pt/5/58/Dragon_Age_Inquisition_capa.png')
INSERT [dbo].[Jogo] ([idJogo], [TituloJogo], [Descricao], [DataLan], [Valor], [Capa], [Promocao], [idEstudio], [Caminho]) VALUES (8, N'FIFA 19', N' FIFA 19 é um jogo eletrônico de futebol desenvolvido publicado pela EA Sports', CAST(N'2014-09-28' AS Date), CAST(150 AS Decimal(18, 0)), NULL, 0, 7, N'https://static-wp-tor15-prd.torcedores.com/wp-content/uploads/2018/09/FIFA-19-oficial-cover.jpg')
INSERT [dbo].[Jogo] ([idJogo], [TituloJogo], [Descricao], [DataLan], [Valor], [Capa], [Promocao], [idEstudio], [Caminho]) VALUES (9, N'Assasin´s Creed II', N' Assassin''s Creed II é um jogo eletrônico de ação-aventura desenvolvido pela Ubisoft ', CAST(N'2009-09-11' AS Date), CAST(70 AS Decimal(18, 0)), NULL, 0, 8, N'https://upload.wikimedia.org/wikipedia/pt/a/ac/Assassins_Creed_2_capa.png')
INSERT [dbo].[Jogo] ([idJogo], [TituloJogo], [Descricao], [DataLan], [Valor], [Capa], [Promocao], [idEstudio], [Caminho]) VALUES (10, N'Assasin´s Creed Black Flag IV', N' Assassin''s Creed IV: Black Flag é um videojogo de ação-aventura desenvolvido pela Ubisoft  ', CAST(N'2013-10-29' AS Date), CAST(70 AS Decimal(18, 0)), NULL, 0, 8, N'https://upload.wikimedia.org/wikipedia/pt/c/ca/Assassins_Creed_4_Black_Flag_capa.png')
INSERT [dbo].[Jogo] ([idJogo], [TituloJogo], [Descricao], [DataLan], [Valor], [Capa], [Promocao], [idEstudio], [Caminho]) VALUES (11, N'Metal gear Solid v The phanton Pain', N'Metal Gear Solid V: The Phantom Pain é um jogo eletrônico de ação-aventura furtiva desenvolvido pela Kojima Productions, co-produzido pela Kojima Productions Los Angeles e realizado, desenhado, co-produzido e co-escrito por Hideo Kojima.', CAST(N'2015-09-29' AS Date), CAST(100 AS Decimal(18, 0)), NULL, 0, 11, N'https://upload.wikimedia.org/wikipedia/pt/1/19/MGS5_TPP.jpg')
INSERT [dbo].[Jogo] ([idJogo], [TituloJogo], [Descricao], [DataLan], [Valor], [Capa], [Promocao], [idEstudio], [Caminho]) VALUES (12, N'Bioshock', N'BioShock é uma série de videogames retrofuturística publicada pela 2K Games e desenvolvida por vários estúdios, incluindo Irrational Games e 2K Marin.', CAST(N'2008-07-29' AS Date), CAST(100 AS Decimal(18, 0)), NULL, 0, 10, N'https://upload.wikimedia.org/wikipedia/pt/6/6d/BioShock_cover.jpg')
INSERT [dbo].[Jogo] ([idJogo], [TituloJogo], [Descricao], [DataLan], [Valor], [Capa], [Promocao], [idEstudio], [Caminho]) VALUES (13, N'Silent Hill', N'Silent Hill é uma série de jogos eletrônicos produzida pela Konami. É classificada como um survival horror.', CAST(N'1999-01-31' AS Date), CAST(30 AS Decimal(18, 0)), NULL, 0, 9, N'https://i.pinimg.com/236x/f3/c5/a2/f3c5a2512f1b215afcf5049bd04fe687.jpg')
INSERT [dbo].[Jogo] ([idJogo], [TituloJogo], [Descricao], [DataLan], [Valor], [Capa], [Promocao], [idEstudio], [Caminho]) VALUES (16, N'The Last Of Us', N'The Last of Us é um jogo eletrônico de ação-aventura e survival horror desenvolvido pela Naughty Dog e publicado pela Sony Computer Entertainment. Ele foi lançado exclusivamente para PlayStation 3 em 14 de junho de 2013. É o primeiro jogo da franquia The Last of Us.', CAST(N'2013-06-14' AS Date), CAST(59 AS Decimal(18, 0)), NULL, 0, 3, N'http://1.bp.blogspot.com/-rKEVwHl5X5s/Ud3X3hWnbyI/AAAAAAAADic/u0BaaqqLoxo/s1600/The-Last-of-Us-key-art.jpg')
SET IDENTITY_INSERT [dbo].[Jogo] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoUsuario] ON 