using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.RefactoringforSingleResponsibilityPrinciple
{
    public class BookRepository: IBookRepository
    {
        public Book GetBookById(int bookId)
        {
            return new Book();
        }
    }
}
