using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Userprofile
    {        
        public List<Country> Country { get; set; }
        public List<User> UserProfile { get; set; }     
        public List<FriendList> Friends { get; set; }
    }
}
