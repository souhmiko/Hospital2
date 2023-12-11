CREATE TABLE [dbo].[ShiftTypes] (
    [Id]            INT NOT NULL IDENTITY(1, 1),
    [ShiftTypeName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ShiftTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

