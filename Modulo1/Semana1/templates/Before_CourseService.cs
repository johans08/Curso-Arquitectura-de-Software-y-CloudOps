// Ejemplo intencionalmente problemático.
// Sirve para analizar violaciones a SOLID y Clean Code.

public sealed class CourseService
{
    public async Task CreateCourse(string code, string name, string description)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new Exception("Invalid code");

        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Invalid name");

        // Problema: aquí se mezclaría validación, reglas, SQL, correo y auditoría.
        // Este método tendría demasiadas razones para cambiar.
    }
}
