CREATE TABLE academy.OutboxMessages
(
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Type NVARCHAR(250) NOT NULL,
    Payload NVARCHAR(MAX) NOT NULL,
    OccurredAt DATETIMEOFFSET NOT NULL,
    ProcessedAt DATETIMEOFFSET NULL,
    Attempts INT NOT NULL CONSTRAINT DF_Outbox_Attempts DEFAULT 0,
    Error NVARCHAR(MAX) NULL
);

CREATE INDEX IX_Outbox_Pending
ON academy.OutboxMessages(ProcessedAt, OccurredAt)
WHERE ProcessedAt IS NULL;
