using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class TripHistoryList
    {
        public string Title { get; set; }
        public int TripId { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public List<Friends> Friends { get; set; }
        public string Status { get; set; }
        public string CreatedOn { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
    }
}
