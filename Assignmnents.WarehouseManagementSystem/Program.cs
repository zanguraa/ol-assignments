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
                    UpdateProductPrice();
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
    }
}