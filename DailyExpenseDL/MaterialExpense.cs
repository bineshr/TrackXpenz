//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DailyExpenseDL
{
    using System;
    using System.Collections.Generic;
    
    public partial class MaterialExpense
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> MaterialId { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string MaterialName { get; set; }
        public Nullable<System.DateTime> Created_On { get; set; }
    }
}
