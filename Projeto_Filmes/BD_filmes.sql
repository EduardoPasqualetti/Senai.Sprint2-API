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
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero) NOT NULL,
	Nome VARCHAR(50) NOT NULL
)

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR(256) NOT NULL UNIQUE,
	Senha VARCHAR(50) NOT NULL,
	Permissao VARCHAR(20) NOT NULL
)



INSERT INTO Genero(Nome) VALUES ('Terror'),('Comedia'),('Acao'),('Suspense')

INSERT INTO Filmes(IdGenero,Titulo) VALUES (3,'Jumanji'),(4,'Panico'),(3,'Velozes e Furiosos'),(2,'Sorria'), (1,'Gente Grande') 

INSERT INTO Usuario(Email, Senha, Permissao) VALUES ('edu@gmail.com','12345','Comum'),('admin@gmail.com','adm000','Administrador')


SELECT * FROM Filmes 

SELECT * FROM Genero

SELECT * FROM Usuario