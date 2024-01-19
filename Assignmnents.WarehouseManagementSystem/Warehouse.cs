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

        public static void RegistrarProducts(string name, ProductCategory category, decimal price, int quantity)
        {
            if (products.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Product with the same name already exists. Please provide a unique name.");
                return;
            }
        }
    }
}
