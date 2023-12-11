CREATE TABLE [dbo].[Departments] (
    [Id]             INT NOT NULL IDENTITY(1, 1),
    [DepartmentName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED ([Id] ASC)
);

