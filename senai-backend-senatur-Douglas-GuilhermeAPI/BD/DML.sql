

USE Senatur_Manha;
select * from Usuario


Insert into TipoUsuario(TituloTipoUsuario)
Values ('Administrador'),('Comum');

Insert into Usuario(Email,Senha,idTipoUsuario)
VALUES ('admin@admin.com','admin123',1),('cliente@cliente.com','cliente',2);

SElect * from Pacote
SElect * from TipoUsuario
SElect * from Usuario



Insert into Pacote(NomePacote,Descricao,Dataida,Datavolta,Valor,Cidade,Ativo)
Values('SALVADOR - 5 DIAS / 4 DIÁRIAS','O Litoral Norte da Bahia conta com inúmeras praias emolduradas por coqueiros, além de piscinas naturais de águas mornas que são protegidas por recifes e habitadas por peixes coloridos. Banhos de mar em águas calmas ou agitadas, mergulho com snorkel, caminhada pela orla e calçadões, passeios de bicicleta, pontos turísticos históricos, interação com animais e até baladas estão entre as atrações da região. Destacam-se as praias de Guarajuba, Imbassaí, Praia do Forte e Costa do Sauipe',
'06/05/2020','10/05/2020',854.00,'Salvador',1),
('SRESORTS NA BAHIA - LITORAL NORTE - 5 DIAS / 4 DIÁRIAS',' O Litoral Norte da Bahia conta com inúmeras praias emolduradas por coqueiros, além de piscinas naturais de águas mornas que são protegidas por recifes e habitadas por peixes coloridos. Banhos de mar em águas calmas ou agitadas, mergulho com snorkel, caminhada pela orla e calçadões, passeios de bicicleta, pontos turísticos históricos, interação com animais e até baladas estão entre as atrações da região. Destacam-se as praias de Guarajuba, Imbassaí, Praia do Forte e Costa do Sauipe',
'14/05/2020','18/05/2020',1826.00,'Salvador',1),
(' BONITO VIA CAMPO GRANDE - 1 PASSEIO - 5 DIAS / 4 DIÁRIAS',' Localizado no estado de Mato Grosso do Sul e ao sul do Pantanal, Bonito possui centenas de cachoeiras, rios e lagos de águas cristalinas, além de cavernas inundadas, paredões rochosos e uma infinidade de peixes. Os aventureiros costumam render-se facilmente a esse destino regado por trilhas ecológicas, passeios de bote e descidas de rapel pelas inúmeras quedas dágua da região',
'28/03/2020','01/04/2020',1004.00,'Bonito',1);



