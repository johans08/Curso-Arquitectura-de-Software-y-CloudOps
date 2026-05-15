INSERT INTO academy.Courses
(
    Id,
    Code,
    Name,
    Description,
    Status,
    CreatedAt,
    UpdatedAt
)
VALUES
(
    NEWID(),
    'ARCH-001',
    'Arquitectura de Software y Cloud Ops',
    'Curso base para diseñar aplicaciones modernas con .NET y SQL Server.',
    'Draft',
    SYSDATETIMEOFFSET(),
    NULL
);
