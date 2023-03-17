USE master
CREATE DATABASE DapperPattern
go
USE DapperPattern
go
CREATE SCHEMA Administrador
go
CREATE SCHEMA Vip
GO
CREATE TABLE Administrador.Usuario(
	Id int primary key identity(1,1),
	Nome varchar(100) not null,
	Descricao varchar(450) not null,
	Tipo tinyint default 0 not null
)
GO
CREATE TABLE Vip.Usuario(
	Id int primary key identity(1,1),
	Nome varchar(100) not null,
	Descricao varchar(450) not null,
	Tipo tinyint default 0 not null
)