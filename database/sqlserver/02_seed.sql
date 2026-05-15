USE CloudOpsCourseDb;
GO

INSERT INTO dbo.Customers (Id, FullName, Email)
VALUES
('11111111-1111-1111-1111-111111111111', 'Estudiante Demo', 'estudiante@example.com');

INSERT INTO dbo.Products (Id, Name, Sku, UnitPrice, MetadataJson)
VALUES
('22222222-2222-2222-2222-222222222222', 'Curso Arquitectura Cloud Ops', 'COURSE-CLOUDOPS', 100.00, '{"category":"training","level":"professional"}'),
('33333333-3333-3333-3333-333333333333', 'Laboratorio .NET SQL Server', 'LAB-DOTNET-SQL', 50.00, '{"category":"lab","stack":"dotnet"}');
GO
