using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class PersonelExpense
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public List<Product> Product { get; set; }
    }
}
