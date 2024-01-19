using Assignmnents.WarehouseManagementSystem;

namespace Assignments.WarehouseManagementSystem
{
    internal class Program
    {
        static Warehouse warehouse = new Warehouse();

        static void Main(string[] args)
        {
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine(" ");
                Console.WriteLine("----------");
                Console.WriteLine("Hello, Please choose operation!");
                Console.WriteLine("----------");
                Console.WriteLine("1) Register Product");
                Console.WriteLine("2) Edit Product");
                Console.WriteLine("3) Delete Product");
                Console.WriteLine("4) List of Products");
                Console.WriteLine("5) Quit");

                var response = int.TryParse(Console.ReadLine(), out int parsedResponse);

                switch (parsedResponse)
                {
                    case 1:
                        AddProductToTheList();
                        break;
                    case 2:
                        UpdateProduct();
                        break;
                    case 3:
                        DeleteProductFromTheList();
                        break;
                    case 4:
                        warehouse.ListAllProduct();
                        break;
                    case 5:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Choose from 1 to 5");
                        break;
                }
            }
        }

        static void AddProductToTheList()
        {
            Console.WriteLine("Add product name");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name) || name.Length > 50 || char.IsDigit(name[0]) || name.Trim() != name)
            {
                Console.WriteLine("Invalid name. Please provide a valid name.");
                return;
            }

            Console.WriteLine("Choose category of product: ");
            Console.WriteLine($"1) {ProductCategory.Food}");
            Console.WriteLine($"2) {ProductCategory.Electronic}");
            Console.WriteLine($"3) {ProductCategory.SportInventar}");
            Console.WriteLine($"4) {ProductCategory.Book}");

            if (!int.TryParse(Console.ReadLine(), out int parsedResponse) || !Enum.IsDefined(typeof(ProductCategory), parsedResponse))
            {
                Console.WriteLine("Invalid category selection. Please choose a valid category number.");
                return;
            }

            ProductCategory selectedCategory = (ProductCategory)parsedResponse;
            Console.WriteLine("Add product price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal parsedPrice) || parsedPrice < 0)
            {
                Console.WriteLine("Invalid price input. Please enter a valid non-negative decimal number.");
                return;
            }

            Console.WriteLine("Add quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantityResponse) || quantityResponse < 0)
            {
                Console.WriteLine("Invalid quantity input. Please enter a valid non-negative integer.");
                return;
            }


            warehouse.RegisterProduct(name, selectedCategory, parsedPrice, quantityResponse);
            Console.WriteLine("Product added successfully.");
        }

        static void UpdateProduct()
        {
            Console.WriteLine("Please enter product name to update: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid name. Please provide a valid name.");
                return;
            }

            Console.WriteLine("Please enter new price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal newPriceResponse))
            {
                Console.WriteLine("Invalid price input. Please enter a valid decimal number.");
                return;
            }

            Console.WriteLine("Please enter new quantity");
            if (!int.TryParse(Console.ReadLine(), out int parsedQuantity))
            {
                Console.WriteLine("Invalid quantity input. Please enter a valid integer.");
                return;
            }
            warehouse.UpdateProducts(name, newPriceResponse, parsedQuantity);
        }

        static void DeleteProductFromTheList()
        {
            Console.WriteLine("Please enter name of the product to delete: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid name. Please provide a valid name.");
                return;
            }

            warehouse.DeleteProducts(name);
        }
    }
}
