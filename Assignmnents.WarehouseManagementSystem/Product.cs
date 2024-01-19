using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmnents.WarehouseManagementSystem
{
    public enum ProductCategory
    {
        Food,
        Electronic,
        SportInventar,
        Book
    }
    public class Product
    {
        private string _name;
        public string Name { get { return _name; } set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 50 || char.IsDigit(value[0]) || value.Trim() != value)
                {
                    Console.WriteLine("Invalid name. Please provide a valid name.");
                }
                else
                {
                    _name = value;
                }
            } }
        public ProductCategory Category { get; set; }
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Invalid price. Please provide a non-negative value.");
                }
                else
                {
                    _price = value;
                }
            }
        }
        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Invalid quantity. Please provide a non-negative value.");
                }
                else
                {
                    _quantity = value;
                }
            }
        }

        public Product(string name, ProductCategory category, decimal price, int quantity)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
        }

        public bool IsOutOfStock()
        {
            return Quantity == 0;
        }

    }
}
