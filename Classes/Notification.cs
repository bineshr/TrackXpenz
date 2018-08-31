using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Notification
    {
        public int notificationId { get; set; }       
        public string friendEmailId { get; set; }
        public string friendUserName { get; set; }
        public string requestDate { get; set; }
        public int acceptId { get; set; }
    }
}
