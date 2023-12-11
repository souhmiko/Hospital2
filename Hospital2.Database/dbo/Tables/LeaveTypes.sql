CREATE TABLE [dbo].[LeaveTypes] (
    [Id]            INT NOT NULL IDENTITY(1, 1),
    [LeaveTypeName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_LeaveTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

