using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Modules.Tasks;

namespace TaskFlow.Api.Data;

public sealed class TaskFlowDbContext(DbContextOptions<TaskFlowDbContext> options) : DbContext(options)
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}
