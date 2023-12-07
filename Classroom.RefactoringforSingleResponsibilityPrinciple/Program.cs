using Classroom.RefactoringforSingleResponsibilityPrinciple;

class Program
{
    static void Main(string[] args)
    {
        var bookRepository = new BookRepository();
        var inventorymanager = new InventoryManager();
        var emailService = new EmailService();

        var saleProcessor = new SaleProcessor(bookRepository, inventorymanager, emailService);
        saleProcessor.ProcessPayment(userId: 123, bookId: 456);
    }
}