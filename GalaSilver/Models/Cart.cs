namespace GalaSilver.Models;

public class Cart
{
    private List<CartLine> _cartItems = new List<CartLine>();

    public virtual IEnumerable<CartLine> Items => _cartItems;
    public virtual decimal SubTotal() => _cartItems.Sum(p => p.Product.Price*p.Count);

    public virtual void Clear() => _cartItems.Clear();

    public virtual void AddItem(Product product, int count)
    {
        CartLine cartItem = _cartItems
            .FirstOrDefault(c => c.Product.Id == product.Id);

        if (cartItem == null)
        {
            _cartItems.Add(new CartLine()
            {
                Product = product,
                Count = count
            });
        }
        else
        {
            cartItem.Count += count;
        }
    }

    public virtual void Remove(Product product)
    {
        _cartItems.RemoveAll(p => p.Product.Id == product.Id);
    }

}