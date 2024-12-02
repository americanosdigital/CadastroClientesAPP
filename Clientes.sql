CREATE TABLE [dbo].[Clientes] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Name]     NVARCHAR (MAX)   NOT NULL,
    [Lastname] NVARCHAR (MAX)   NOT NULL,
    [Age]      INT              NOT NULL,
    [Address]  NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

