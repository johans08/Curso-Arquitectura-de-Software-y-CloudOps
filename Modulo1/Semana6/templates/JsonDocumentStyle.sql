CREATE TABLE academy.StudentProfiles
(
    StudentId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    ProfileJson NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIMEOFFSET NOT NULL,
    CONSTRAINT CK_StudentProfiles_IsJson CHECK (ISJSON(ProfileJson) = 1)
);

INSERT INTO academy.StudentProfiles(StudentId, ProfileJson, CreatedAt)
VALUES
(
    NEWID(),
    N'{
        "language": "es",
        "receiveNotifications": true,
        "theme": "dark",
        "interests": ["architecture", "cloud", "dotnet"]
    }',
    SYSDATETIMEOFFSET()
);

SELECT
    StudentId,
    JSON_VALUE(ProfileJson, '$.language') AS Language,
    JSON_VALUE(ProfileJson, '$.theme') AS Theme
FROM academy.StudentProfiles;
