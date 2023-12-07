using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.RefactoringforSingleResponsibilityPrinciple
{
    public class InvoiceGenerator
    {
        public Invoice GenerateInvoice(Book book)
        {
            return new Invoice();
        }
    }
}
