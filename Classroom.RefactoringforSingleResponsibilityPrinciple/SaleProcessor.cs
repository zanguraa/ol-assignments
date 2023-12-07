using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.RefactoringforSingleResponsibilityPrinciple
{
    public class SaleProcessor : IPaymentProcess
    {
        private readonly BookRepository _bookRepository;
        private readonly InventoryManager _inventoryManager;
        private readonly EmailService _emailService;

        public SaleProcessor(BookRepository bookRepository, InventoryManager inventoryManager, EmailService emailService)
        {
            _bookRepository = bookRepository;
            _inventoryManager = inventoryManager;
            _emailService = emailService;
        }
        public void ProcessPayment(int userId, int bookId)
        {
            var book = _bookRepository.GetBookById(bookId);
            if(book.IsAvailable())
            {
                _inventoryManager.UpdateInventory(book);
                var invoice = new InvoiceGenerator().GenerateInvoice(book);

                var user = new User().GetUserById(userId);
                _emailService.SendInvoiceEmail(invoice, user.Email);
            }
        }
    }
}
