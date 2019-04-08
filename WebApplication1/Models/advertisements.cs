using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class advertisements
    {
        public int adKod { get; set; }
        public int userKod { get; set; }
        public int category { get; set; }
        public  DateTime date { get; set; }
        public string area { get; set; }
        public string color { get; set; }
        public string shape { get; set; }
        public string material { get; set; }
        public string categoryName { get; set; }
        public bool status { get; set; }
        public bool isFound { get; set; }
        public string image { get; set; }
        public string typeArea { get; set; }
        public string transportation { get; set; }
    }
}