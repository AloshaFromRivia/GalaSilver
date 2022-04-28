namespace GalaSilver.Models;

public interface IRepository
{
    IQueryable<Product> Products { get;}
    IQueryable<Category> Categories { get; }
    void Add(Product product);
    void Remove(Product product);
}