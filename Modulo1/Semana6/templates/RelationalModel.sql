CREATE TABLE academy.Students
(
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Email NVARCHAR(320) NOT NULL UNIQUE,
    FullName NVARCHAR(200) NOT NULL,
    CreatedAt DATETIMEOFFSET NOT NULL
);

CREATE TABLE academy.StudentPreferences
(
    StudentId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Language NVARCHAR(10) NOT NULL,
    ReceiveNotifications BIT NOT NULL,
    Theme NVARCHAR(30) NOT NULL,
    CONSTRAINT FK_StudentPreferences_Students
        FOREIGN KEY (StudentId) REFERENCES academy.Students(Id)
);
