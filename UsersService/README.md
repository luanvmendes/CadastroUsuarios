# Script criação do banco

CREATE DATABASE [UsersDb]

GO

USE [UsersDb]

GO

CREATE TABLE [dbo].[Usuarios](

	[Id] [int] NOT NULL IDENTITY PRIMARY KEY,
	[Nome] [varchar](50) NOT NULL,
	[Sobrenome] [varchar](80) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[DataNascimento] [date] NULL,
	[Escolaridade] [int] NULL)
GO
