CREATE TABLE [dbo].[Pessoa] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nome]     NVARCHAR (50) NOT NULL,
    [Email]    NVARCHAR (50) NOT NULL,
    [Telefone] NCHAR (12)    NOT NULL,
    CONSTRAINT [PK_Pessoa] PRIMARY KEY CLUSTERED ([Id] ASC)
);