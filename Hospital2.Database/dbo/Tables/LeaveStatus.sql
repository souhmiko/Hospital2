CREATE TABLE [dbo].[LeaveStatus] (
    [Id]              INT NOT NULL IDENTITY(1, 1),
    [LeaveStatusName] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_LeaveStatus] PRIMARY KEY CLUSTERED ([Id] ASC)
);

