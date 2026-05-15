public interface IProgressStrategy
{
    decimal CalculateProgress(int completedLessons, int totalLessons);
}

public sealed class StandardProgressStrategy : IProgressStrategy
{
    public decimal CalculateProgress(int completedLessons, int totalLessons)
    {
        if (totalLessons <= 0)
            return 0;

        return Math.Round((decimal)completedLessons / totalLessons * 100, 2);
    }
}

public sealed class StrictProgressStrategy : IProgressStrategy
{
    public decimal CalculateProgress(int completedLessons, int totalLessons)
    {
        if (totalLessons <= 0)
            return 0;

        var progress = (decimal)completedLessons / totalLessons * 100;

        return progress >= 100 ? 100 : Math.Floor(progress);
    }
}
