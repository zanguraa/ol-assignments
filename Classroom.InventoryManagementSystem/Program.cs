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
            DeleteProduct(inventoryManager);
            break;
        case 4:
            GetAllProduct(inventoryManager);
            break;
        case 5:
            RecordNewSale(inventoryManager);
            break;
            case 6:
                DisplayTotalSalesReport(inventoryManager);
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

    if (parsedResponse > 0 && parsedResponse <= 9)
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
    Console.WriteLine("Please enter a product name for search: ");
    var name = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Please enter a valid product name!");
        return;
    }

    var searchedProducts = inventoryManager.GetProducts(name);
    if (searchedProducts != null && searchedProducts.Any())
    {
        Console.WriteLine("Your products were found:");
        foreach (var product in searchedProducts)
        {
            Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
        }
    }
    else
    {
        Console.WriteLine($"No products found with the name '{name}'.");
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

static void RecordNewSale(InventoryManager inventoryManager)
{
    Console.WriteLine("Enter the name of the product for the sale: ");
    var productName = Console.ReadLine();

    Console.WriteLine("Enter the quantity sold: ");
    if (int.TryParse(Console.ReadLine(), out int quantitySold))
    {
        var products = inventoryManager.GetProducts(productName).ToList();

        if (products.Any())
        {
            if (products.Count > 1)
            {
                Console.WriteLine("Multiple products found with the same name. Please choose one:");
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {products[i].Name}, Price: {products[i].Price}, Stock: {products[i].Stock}");
                }

                Console.Write("Enter the number corresponding to the desired product: ");
                if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex > 0 && selectedIndex <= products.Count)
                {
                    var selectedProduct = products[selectedIndex - 1];
                    inventoryManager.RecordSale(selectedProduct, quantitySold);
                    Console.WriteLine($"Sale recorded successfully. Remaining stock for {selectedProduct.Name}: {selectedProduct.Stock}");
                }
                else
                {
                    Console.WriteLine("Invalid selection. Sale not recorded.");
                }
            }
            else
            {
                var product = products.First();
                inventoryManager.RecordSale(product, quantitySold);
                Console.WriteLine($"Sale recorded successfully. Remaining stock for {product.Name}: {product.Stock}");
            }
        }
        else
        {
            Console.WriteLine($"Product with name '{productName}' not found.");
        }
    }
    else
    {
        Console.WriteLine("Invalid quantity entered.");
    }
}

static void DeleteProduct(InventoryManager inventory)
{
    Console.WriteLine("Please enter the product ID that you want to delete:");

    if (int.TryParse(Console.ReadLine(), out int productIdToDelete))
    {
        var productToDelete = inventory.GetProductById(productIdToDelete);

        if (productToDelete != null)
        {
            inventory.DeleteProduct(productIdToDelete);
            Console.WriteLine("Product was deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Product with ID {productIdToDelete} does not exist. Deletion failed.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid product ID.");
    }
}

static void DisplayTotalSalesReport(InventoryManager inventoryManager)
{
    var totalSalesReport = inventoryManager.GetTotalSalesReport();

    foreach (var report in totalSalesReport)
    {
        Console.WriteLine($"Product ID: {report.ProductId}");
        Console.WriteLine($"Product Name: {report.ProductName}");
        Console.WriteLine($"Unit Price: {report.UnitPrice:C}");
        Console.WriteLine($"Total Quantity Sold: {report.TotalQuantitySold}");
        Console.WriteLine($"Total Revenue: {report.TotalRevenue:C}");
        Console.WriteLine();
    }
}


