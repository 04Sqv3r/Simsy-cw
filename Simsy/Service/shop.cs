using Simsy.Interface;
using Simsy.Models;

namespace Simsy.Service
{
    public class Shop : IShop
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public bool Buy(Person character, Product product)
        {
            if (character.Wallet.Balance >= product.Price)
            {
                character.Wallet.Spend(product.Price);
                return true;
            }
            return false;
        }
    }
}
