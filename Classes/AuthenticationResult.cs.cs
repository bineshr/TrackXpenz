using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class AuthenticationResult
    {
        public bool IsAuthenticated { get; set; }
        public bool IsFirstTimeLogin { get; set; }
        public User CurrentUser { get; set; }
    }
}
