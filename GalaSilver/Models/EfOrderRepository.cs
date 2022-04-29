using Microsoft.EntityFrameworkCore;

namespace GalaSilver.Models;

public class EfOrderRepository : IOrderRepository
{
    private ApplicationDbContext context;

    public EfOrderRepository(ApplicationDbContext ctx) {
        context = ctx;
    }

    public IQueryable<Order> Orders => context.Orders;
    

    public void SaveOrder(Order order) {
        if (order.OrderID == 0) {
            context.Orders.Add(order);
        }
        context.SaveChanges();
    }
}