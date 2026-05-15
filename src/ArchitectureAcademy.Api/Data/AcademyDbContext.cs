using ArchitectureAcademy.Api.Features.Courses;
using ArchitectureAcademy.Api.Messaging;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureAcademy.Api.Data;

public sealed class AcademyDbContext(DbContextOptions<AcademyDbContext> options)
    : DbContext(options)
{
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(builder =>
        {
            builder.ToTable("Courses", "academy");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(x => x.Code)
                .IsUnique();

            builder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.Status)
                .HasMaxLength(30)
                .IsRequired();
        });

        modelBuilder.Entity<OutboxMessage>(builder =>
        {
            builder.ToTable("OutboxMessages", "academy");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Payload)
                .IsRequired();

            builder.HasIndex(x => new { x.ProcessedAt, x.OccurredAt });
        });
    }
}
