//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public Users()
        {
            this.Advertisement = new HashSet<Advertisement>();
        }
    
        public int userKod { get; set; }
        public bool friend { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public Nullable<int> house { get; set; }
        public string mail { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public Nullable<bool> isCompany { get; set; }
        public string connectDb { get; set; }
        public string password { get; set; }
    
        public virtual ICollection<Advertisement> Advertisement { get; set; }
    }
}
