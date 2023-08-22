CREATE DATABASE Filmes_manha

USE Filmes_manha


CREATE TABLE Genero
(
	IdGenero INT PRIMARY KEY IDENTITY, 
	Nome VARCHAR(50) NOT NULL
)

CREATE TABLE Filmes
(
	IdFilme INT PRIMARY KEY IDENTITY,
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero),
	Nome VARCHAR(50)
)



INSERT INTO Genero(Nome) VALUES ('Comedia'),('Terror')

INSERT INTO Filmes(IdGenero,Nome) VALUES (2,'Sorria'), (1,'Gente Grande')


SELECT 
Filmes.IdFilme as ID,
Filmes.Nome as Filme,
Genero.Nome as Genero
FROM
	Filmes 
JOIN Genero on Genero.IdGenero = Filmes.IdGenero
