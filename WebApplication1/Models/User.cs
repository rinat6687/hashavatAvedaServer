using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
  //אסון!!!  [Serializable]
    public class User 
    {
        public int userKod { get; set; }
        public bool friend { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public int house { get; set; }
        public string mail { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public bool isCompany { get; set; }
        public string connectDb { get; set; }
        public string password { get; set; }

        public User(int userKod, bool friend, string firstName,string lastName,string city,string mail,string Tel1,string Tel2,bool isCompany, string connectDb, string password)
        {
            this.userKod = userKod;
            this.friend = friend;
            this.firstName = firstName;
            this.lastName = lastName;
            this.city = city;
            this.mail = mail;
            this.Tel1 = Tel1;
            this.Tel2 = Tel2;
            this.isCompany = isCompany;
            this.connectDb = connectDb;
            this.password = password;
            
        }
        public User()
        {
                
        }

    }
}