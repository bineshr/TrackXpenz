using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class SearchPersonelExpense
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public List<Product> Product { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public List<ExpenseData> expense { get; set; }
    }
}
