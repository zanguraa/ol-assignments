namespace Classroom.RefactoringforSingleResponsibilityPrinciple
{
    public class BookStore
    {
        private readonly BookRepository bookRepository;

        public BookStore(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void ProcessSale(int userId, int bookId)
        {

            var book = bookRepository.GetBookById(userId);
            if (book.IsAvailable())
            {
                bookRepository.UpdateInventory(book);
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



        public Invoice GenerateInvoice(Book book)
        {
            return new Invoice();
            // Generate invoice
        }
    }
}
