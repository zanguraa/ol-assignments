using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.InventoryManagementSystem
{
    internal class Sales
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Quantity { get; set; }
        public DateTime SaleDate { get; set; }

    }
}
