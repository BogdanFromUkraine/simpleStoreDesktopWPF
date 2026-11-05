using SimpleStore.Admin.Core.Entities;
using SimpleStore.Admin.Core.Interfaces;

namespace SimpleStore.Admin.Core.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new()
    {
        new Product { Id = Guid.NewGuid(), Name = "Клавіатура Hator", Sku = "KB-001", Price = 2499, Quantity = 10 },
        new Product { Id = Guid.NewGuid(), Name = "Миша Hator Pulsar 3", Sku = "MS-002", Price = 1899, Quantity = 15 },
        new Product { Id = Guid.NewGuid(), Name = "Монітор 27\"", Sku = "MN-003", Price = 8500, Quantity = 5 }
    };

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Product>>(_products);
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(product);
    }

    public Task AddAsync(Product product)
    {
        _products.Add(product);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Product product)
    {
        var existing = _products.FirstOrDefault(p => p.Id == product.Id);
        if (existing != null)
        {
            existing.Name = product.Name;
            existing.Sku = product.Sku;
            existing.Price = product.Price;
            existing.Quantity = product.Quantity;
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
        }
        return Task.CompletedTask;
    }
}