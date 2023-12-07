using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.RefactoringforSingleResponsibilityPrinciple
{
    public interface IPaymentProcess
    {
        void ProcessPayment(int userId, int bookId);
    }
}
