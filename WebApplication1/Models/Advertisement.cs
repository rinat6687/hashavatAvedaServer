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
    
    public partial class Advertisement
    {
        public int adKod { get; set; }
        public Nullable<int> userKod { get; set; }
        public Nullable<int> category { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string area { get; set; }
        public string color { get; set; }
        public string shape { get; set; }
        public string material { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<bool> isFound { get; set; }
        public string typeArea { get; set; }
        public string transportation { get; set; }
        public string image { get; set; }
    
        public virtual Categories Categories { get; set; }
        public virtual Users Users { get; set; }
    }
}
