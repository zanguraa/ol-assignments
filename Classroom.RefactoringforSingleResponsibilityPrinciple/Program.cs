public class BookStore
{
    public void ProcessSale(int userId, int bookId)
    {
        var book = GetBookById(bookId);
        if (book.IsAvailable())
        {
            UpdateInventory(book);
            var invoice = GenerateInvoice(book);

            var user = GetUserById(userId);
            SendInvoiceEmail(invoice, user.Email);
        }
    }

    private void SendInvoiceEmail(Invoice invoice, string email)
    {
        // TODO: Send email
    }

    private User GetUserById(int userId)
    {
        // TODO: Get user by id
        return new User();
    }

    private void UpdateInventory(Book book)
    {
        // Update inventory
    }

    private Book GetBookById(int bookId)
    {
        // TODO: Get book by id
        return new Book();
    }

    public Invoice GenerateInvoice(Book book)
    {
        // Generate invoice
    }
}