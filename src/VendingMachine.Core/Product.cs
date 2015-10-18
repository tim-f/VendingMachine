namespace VendingMachine.Core
{
    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    public class ProductSet
    {
        public ProductSet(Product product)
        {
            
        }         
    }

    public class GoodsStore
    {

    }
}