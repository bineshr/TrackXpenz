using Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DailyExpense.Models.Home
{
    public class Login
    {
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
        public List<Country> Country { get; set; }
    }
}