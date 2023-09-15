use inlock_games_CodeFirst_manha

SELECT * FROM Estudio


SELECT * FROM TipoUsuario

SELECT * FROM Usuario

SELECT * FROM Jogo

INSERT INTO Usuario
VALUES (NEWID(),'admin@admin.com','admin', 'DE23C647-4BDF-48FF-93C9-F14E32125484'),(NEWID(),'comum@comum.com','comum','A198ED9B-3903-464B-8F71-AB0148A5FF16');
      



INSERT INTO Jogo
VALUES (NEWID() , 'GTA 5' , 'Jogo Maneiro' , '2012-09-24' , 19.99 , '51670D4E-F623-4A7B-BC62-B6FCE3D55CC4')
	  ,(NEWID() , 'Valorant' , 'Jogo de tiro 5x5' , '2016-08-27' , 15.99 , 'B4F6C3AC-9C59-45ED-8755-DCBAE0EE398B');