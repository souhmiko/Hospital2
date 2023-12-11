CREATE TABLE [dbo].[WorkTitles] (
    [Id]            INT NOT NULL IDENTITY(1, 1),
    [WorkTitleName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_WorkTitles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

