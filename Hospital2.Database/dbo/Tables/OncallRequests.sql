CREATE TABLE [dbo].[OncallRequests] (
    [Id]                     INT NOT NULL IDENTITY(1, 1),
    [UserDetailId]           INT NOT NULL,
    [DepartmentId]           INT NOT NULL,
    [DateTimeOnCall]         DATETIME       NULL,
    [ApprovedByUserDetailId] NVARCHAR (450) NULL,
    [DateApproved]           DATETIME       NULL,
    [RejectedByUserDetailId] NVARCHAR (450) NULL,
    [DateRejected]           DATETIME       NULL,
    [LeaveStatusId]          INT NOT NULL,
    CONSTRAINT [PK_OncallRequests] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OncallRequests_Departments] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([Id]),
    CONSTRAINT [FK_OncallRequests_LeaveStatus] FOREIGN KEY ([LeaveStatusId]) REFERENCES [dbo].[LeaveStatus] ([Id]),
    CONSTRAINT [FK_OncallRequests_UserDetails] FOREIGN KEY ([UserDetailId]) REFERENCES [dbo].[UserDetails] ([Id])
);

