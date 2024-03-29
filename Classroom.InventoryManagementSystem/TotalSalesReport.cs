﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.InventoryManagementSystem
{
    public class TotalSalesReport
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public decimal UnitPrice { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalRevenue { get; set; }
        public int SaleId { get; set; }
        public int SaleQuantity { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
