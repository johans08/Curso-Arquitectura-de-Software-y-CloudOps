CREATE SCHEMA academy;
GO

CREATE TABLE academy.Courses
(
    Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_Courses PRIMARY KEY,
    Code NVARCHAR(30) NOT NULL,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(1000) NULL,
    Status NVARCHAR(30) NOT NULL,
    CreatedAt DATETIMEOFFSET NOT NULL,
    UpdatedAt DATETIMEOFFSET NULL,
    CONSTRAINT UQ_Courses_Code UNIQUE (Code),
    CONSTRAINT CK_Courses_Status CHECK (Status IN ('Draft', 'Published'))
);
GO

CREATE TABLE academy.OutboxMessages
(
    Id UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_OutboxMessages PRIMARY KEY,
    Type NVARCHAR(250) NOT NULL,
    Payload NVARCHAR(MAX) NOT NULL,
    OccurredAt DATETIMEOFFSET NOT NULL,
    ProcessedAt DATETIMEOFFSET NULL,
    Error NVARCHAR(MAX) NULL
);
GO

CREATE INDEX IX_OutboxMessages_ProcessedAt_OccurredAt
ON academy.OutboxMessages(ProcessedAt, OccurredAt);
GO
