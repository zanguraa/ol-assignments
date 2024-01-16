using Classroom.InventoryManagementSystem;

InventoryManager inventoryManager = new InventoryManager("Data Source=DESKTOP-7OLVUTI;Initial Catalog=Inventory_db;Integrated Security=SSPI;TrustServerCertificate=True");

Console.WriteLine("Hello, Please choose operation: ");
Console.WriteLine("1) Add Products");
Console.WriteLine("2) Search Products");
Console.WriteLine("3) Delete Products");
Console.WriteLine("4) Find All Product");
Console.WriteLine("5) Record new sale");
Console.WriteLine("6) [Reports] Total sales amount");
Console.WriteLine("7) [Reports] Sales per product");



string userInput = Console.ReadLine();


inventoryManager.InsertIfNotExist();

if (string.IsNullOrWhiteSpace(userInput))
{
    Console.WriteLine("Invalid input. Please enter a valid choice.");
}
else if (!int.TryParse(userInput, out int parsedResponse))
{
    Console.WriteLine("Invalid input. Please enter a valid integer choice.");
}
else
{
    switch (parsedResponse)
    {
        case 1:
            AddProduct(inventoryManager);
            break;
        case 2:
            SearchProduct(inventoryManager);
            break;
        case 3:
            
            break;
        case 4:
            GetAllProduct(inventoryManager);
            break;
        default:
            Console.WriteLine("Invalid choice. Please enter a valid option.");
            break;
    }
}
static void AddProduct(InventoryManager inventoryManager)
{
    Console.WriteLine("Please enter product name: ");
    var name = Console.ReadLine();
    Console.WriteLine("Please enter price: ");
    var priceDecimal = decimal.TryParse(Console.ReadLine(), out var price);
    Console.WriteLine("please enter amount of stock: ");
    var stockInt = int.TryParse(Console.ReadLine(), out var stock);
    Console.WriteLine("Please Choose Category: ");
    Console.WriteLine("1) Electronics");
    Console.WriteLine("2) Clothing");
    Console.WriteLine("3) Home Appliances");
    Console.WriteLine("4) Books");
    Console.WriteLine("5) Sports & Fitness");
    Console.WriteLine("6) Groceries");
    Console.WriteLine("7) Health & Beauty");
    Console.WriteLine("8) Toys & Games");
    Console.WriteLine("9) Automotive");
    var response = int.TryParse(Console.ReadLine(), out int parsedResponse);

    if(parsedResponse > 0 && parsedResponse <= 9)
    {
        Products newProduct = new Products
        {
            Name = name,
            Price = price,
            Stock = stock,
            CategoryId = parsedResponse
        };

        inventoryManager.AddProduct(newProduct);
        Console.WriteLine("Product was added successfully.");
    }


    
}

static void SearchProduct(InventoryManager inventoryManager)
{
    Console.WriteLine("please enter product name for search: ");
    var name = Console.ReadLine();

    var searchedName = inventoryManager.GetProducts(name);

    if(searchedName != null)
    {
        Console.WriteLine($"Your product was found: {searchedName.Name}");
    }
    else
    {
        Console.WriteLine("pleas enter some value! ");
    }



}


static void GetAllProduct(InventoryManager inventoryManager)
{
    var allProducts = inventoryManager.GetAllProducts();

    foreach (var product in allProducts)
    {
        Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
    }
}
