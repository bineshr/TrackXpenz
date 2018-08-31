using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class SearchTourExpense
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int UserListId { get; set; }
        public int TripListId { get; set; }
        public List<UserList> UserList { get; set; }
        public List<Product> Product { get; set; }
        public List<TripHistoryList> TripList { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
}
