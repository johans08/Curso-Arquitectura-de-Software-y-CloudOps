using CloudOps.Application.Abstractions;
using CloudOps.Domain.Entities;
using CloudOps.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CloudOps.Infrastructure.Repositories;

public sealed class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _dbContext;

    public OrderRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Order order, CancellationToken cancellationToken)
    {
        await _dbContext.Orders.AddAsync(order, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Order>> ListAsync(CancellationToken cancellationToken) =>
        await _dbContext.Orders.AsNoTracking().OrderByDescending(x => x.CreatedAtUtc).ToListAsync(cancellationToken);
}
