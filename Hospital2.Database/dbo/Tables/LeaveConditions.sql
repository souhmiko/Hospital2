CREATE TABLE [dbo].[LeaveConditions] (
    [Id]                      INT NOT NULL IDENTITY(1, 1),
    [LeaveConditionName]      NVARCHAR (MAX) NULL,
    [WorkTitleId]             INT NOT NULL,
    [MaxAmountofStaffAllowed] NVARCHAR (450) NULL,
    CONSTRAINT [PK_LeaveConditions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LeaveConditions_WorkTitles] FOREIGN KEY ([WorkTitleId]) REFERENCES [dbo].[WorkTitles] ([Id])
);

