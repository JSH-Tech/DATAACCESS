USE master
GO
IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'ApprendreCsharp'
)
CREATE DATABASE [ApprendreCsharp]
GO

USE ApprendreCsharp
CREATE TABLE [Personnes]
(
    Id INT IDENTITY PRIMARY KEY NOT NULL,
    Nom NVARCHAR(256),
    Prenom NVARCHAR(256)
)
GO
