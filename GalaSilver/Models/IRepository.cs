namespace GalaSilver.Models;

public interface IRepository
{
    IQueryable<Product> Products { get;}
    void Add(Product product);
    void Remove(long id);
}