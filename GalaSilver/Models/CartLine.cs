using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalaSilver.Models;

public class CartLine
{
    [Key]
    public long Id { get; set; }
    [ForeignKey("Product")]
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public int Count { get; set; }
    public decimal Total => Product.Price * Count;
}