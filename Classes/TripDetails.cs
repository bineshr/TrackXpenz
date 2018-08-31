using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class TripDetails
    {
        public string TripTitle { get; set; }
        public string Description { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public int FriendsId { get; set; }
        public int friendsListId { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
        public string EmailId { get; set; }
        public string Name { get; set; }        
        //public string picture { get; set; }
        //public string Location { get; set; }
        public List<FriendList> FriendList { get; set; }
        public int TripId { get; set; }       
        public double Amount { get; set; }
        public string dates { get; set; }
        public string itemName { get; set; }
    }
}
