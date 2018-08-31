using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int CountryId { get; set; }
        public List<Country> Country { get; set; }
        public string CountryName { get; set; }
        public string Status { get; set; }
        public byte[] Photo { get; set; }
        public string picture { get; set; }
    }
}
