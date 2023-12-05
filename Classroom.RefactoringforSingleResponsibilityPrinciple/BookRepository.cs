using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.RefactoringforSingleResponsibilityPrinciple
{
    public class BookRepository
    {
        public void UpdateInventory(Book book)
        {
            // Update inventory
        }

        public Book GetBookById(int bookId)
        {
            // TODO: Get book by id
            return new Book();
        }
    }
}
