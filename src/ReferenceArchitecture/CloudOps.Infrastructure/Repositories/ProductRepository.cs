using CloudOps.Application.Abstractions;
using CloudOps.Domain.Entities;
using CloudOps.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CloudOps.Infrastructure.Repositories;

public sealed class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Product>> ListAsync(CancellationToken cancellationToken) =>
        await _dbContext.Products.AsNoTracking().OrderBy(x => x.Name).ToListAsync(cancellationToken);

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        await _dbContext.Products.AddAsync(product, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
