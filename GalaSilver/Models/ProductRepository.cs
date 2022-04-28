namespace GalaSilver.Models;

public class ProductRepository : IRepository
{
    private List<Product> _products;

    public IQueryable<Product> Products => _products.AsQueryable();


    public ProductRepository()
    {
        _products = new List<Product>()
        {
            new Product()
            {
                Name = "Test Name",
                Description = "Test description",
                Price = 12000,
                Stock = Stock.InStock
            },
            new Product()
            {
                Name = "Test Name2",
                Description = "Test description",
                Price = 12000,
                Stock = Stock.OutOfStock
            },
            new Product()
            {
                Name = "Test Name",
                Price = 12000,
                Stock = Stock.InStock
            },
            new Product()
            {
                Name = "Test Name",
                Description = "Test description",
                Price = 12000,
                Stock = Stock.InStock
            },
            new Product()
            {
                Name = "Test Name",
                Description = "Test description",
                Price = 12000,
                Stock = Stock.InStock
            },
            new Product()
            {
                Name = "Test Name",
                Description = "Test description",
                Price = 12000,
                Stock = Stock.InStock
            },
        };
    }
    
    public void Add(Product product)
    {
        if (!_products.Any(p => p.Id == product.Id))
        {
            _products.Add(product);
        }
        else throw new Exception("Product already exist");
    }

    public void Remove(long id)
    {
        if (!_products.Remove(_products.First(p=>p.Id==id)))
        {
            throw new Exception("Product not found");
        }
    }
}