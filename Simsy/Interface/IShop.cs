using Simsy.Models;

namespace Simsy.Interfaces
{
    public interface IShop
    {
        List<Product> Products { get; set; }
        bool Buy(Person character, Product product);
    }
}
