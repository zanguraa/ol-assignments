namespace Assignmnents.WarehouseManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Please choose operation!");

            Console.WriteLine("1) Register Product");
            Console.WriteLine("2) Edit Product");
            Console.WriteLine("3) Delete Product");
            Console.WriteLine("4) List of Products");

            var response = int.TryParse(Console.ReadLine(), out int parsedResponse);
            Console.WriteLine(parsedResponse);

            switch (parsedResponse)
            {
                case 1:
                    AddProductToTheList();
                    break;
                case 2:
                    UpddateProduct();
                    break;
                case 3:
                    DeleteProductFromTheList();
                    break;
                case 4:
                    ListOfProducts();
                    break;
                default:
                    Console.WriteLine("choose from 1 to 4");
                    return;

            }
        }

        static void AddProductToTheList()
        {
            Warehouse warehouse = new Warehouse();

            Console.WriteLine("Add product name");
            var name = Console.ReadLine();
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
            var price = decimal.TryParse(Console.ReadLine(), out decimal parsedPrice);
            Console.WriteLine("Add quantity: ");
            var quantity = int.TryParse(Console.ReadLine(), out int quantityResponse);

            warehouse.RegisterProduct(name, selectedCategory, parsedPrice, quantityResponse);
        }
        static void UpddateProduct()
        {
            Console.WriteLine("Please enter new price: ");


        }
    }
}