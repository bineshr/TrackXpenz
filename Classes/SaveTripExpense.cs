using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class SaveTripExpense
    {
        public int ExpenseOnId { get; set; }
        public string Description { get; set; }
        public string Dates { get; set; }
        public int friendsListId { get; set; }
        public int UserId { get; set; }      
        public List<TripFriends> FriendList { get; set; }
        public List<FriendList> GetFriends { get; set; }
        public List<TripExpenseItem> TripItems { get; set; }
        public int tripItemListId { get; set; }
        public int tripId { get; set; }
        public int friendId { get; set; }
        public int Amount { get; set; }
        public List<TripDetails> tripExpbyTotal { get; set; }
        public List<TripDetails> tripExpbyUser { get; set; }
    }
}
