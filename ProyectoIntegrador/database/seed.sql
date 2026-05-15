INSERT INTO academy.Courses(Id, Code, Name, Status, CreatedAt)
VALUES
(NEWID(), 'ARCH-001', 'Arquitectura de Software y Cloud Ops', 'Draft', SYSDATETIMEOFFSET());

INSERT INTO academy.Students(Id, Email, FullName, IsActive, CreatedAt)
VALUES
(NEWID(), 'student@example.com', 'Estudiante Demo', 1, SYSDATETIMEOFFSET());
