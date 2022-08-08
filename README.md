# Script criação banco
CREATE DATABASE [UsersDb]

GO

USE [UsersDb]

GO

CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Nome] [varchar](50) NOT NULL,
	[Sobrenome] [varchar](80) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[DataNascimento] [date] NULL,
	[Escolaridade] [int] NULL)
	
GO
