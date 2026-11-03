namespace SimpleStore.Admin.Core.Entities;

public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty; // Артикул товару
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
}