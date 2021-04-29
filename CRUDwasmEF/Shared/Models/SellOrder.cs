using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDwasmEF.Shared.Models
{
    public class SellOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal OrderSumWithVAT { get; set; }
        public decimal OrderSumVAT { get; set; }
    }
}