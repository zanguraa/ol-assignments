using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignmnents.WarehouseManagementSystem
{
    public class Warehouse
    {
        private List<Product> products;

        public Warehouse()
        {
            products = new List<Product>();
        }

        public void RegisterProduct(string name, ProductCategory category, decimal price, int quantity)
        {
            if (products.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Product with the same name already exists. Please provide a unique name.");
                return;
            }

            Product newProduct = new Product(name, category, price, quantity);
            products.Add(newProduct);
            Console.WriteLine("Product registered successfully.");
        }

        public void UpdateProducts(string name, decimal newPrice, int quantity)
        {
            Product product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                product.Price = newPrice;
                product.Quantity = quantity;
                Console.WriteLine("Product updated successfully!");
            }
            else
            {
                Console.WriteLine("Product was not found!");
            }
        }


        public void DeleteProducts(string name)
        {
            Product product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            
            if(product != null)
            {
                products.Remove(product);
                Console.WriteLine("Product deleted successfully!");
            }
            else
            {
                Console.WriteLine("Product was not found!");
            }
        }

        public void ListAllProduct()
        {
            Console.WriteLine("Name\t\tCategory\tPrice\tQuantity\tStatus");

            foreach (Product product in products)
            {
                Console.WriteLine($"{product.Name}\t\t{product.Category}\t\t{product.Price:C}\t{product.Quantity}\t\t{(product.IsOutOfStock() ? "Out Of Stock" : "Available")}");
            }
        }
    }
}
