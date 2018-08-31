using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Homepage
    {
        public List<Notification> notification { get; set; }
        public List<IncomeDetail> IncomeDetails { get; set; }
        public List<User> UserProfile { get; set; }
        public List<FriendList> GetFriendslist { get; set; }
        public double amount { get; set; }
        public double LastmonthAmount { get; set; }
        public List<ChartData> chartByProd { get; set; }
    }
}
