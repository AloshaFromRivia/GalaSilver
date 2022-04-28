namespace GalaSilver.Models;

public class EfRepository : IRepository
{
    private ApplicationDbContext _context;

    public EfRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public IQueryable<Product> Products => _context.Products;
    public IQueryable<Category> Categories => _context.Categories;

    public async void Add(Product product)
    {
        if (!_context.Products.Any(p=>p.Id==product.Id))
        {
            await _context.AddAsync(product);
        }

       await _context.SaveChangesAsync();
    }

    public async void Remove(Product product)
    {
        if (_context.Products.Contains(product))
        { 
            _context.Products.Remove(product);
        }

        await _context.SaveChangesAsync();

    }
}