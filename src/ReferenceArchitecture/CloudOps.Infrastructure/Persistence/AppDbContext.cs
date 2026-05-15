using CloudOps.Domain.Entities;
using CloudOps.Infrastructure.Persistence.Outbox;
using Microsoft.EntityFrameworkCore;

namespace CloudOps.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Sku).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Sku).IsUnique();
            builder.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<Customer>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
        });

        modelBuilder.Entity<Order>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Total).HasColumnType("decimal(18,2)");
            builder.HasMany(typeof(OrderItem), "_items").WithOne().HasForeignKey(nameof(OrderItem.OrderId));
            builder.Navigation("_items").UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        modelBuilder.Entity<OrderItem>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<OutboxMessage>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Payload).IsRequired();
        });
    }
}
