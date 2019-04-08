using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Login
    {
       private hashavatAveda1Entities1 db = new hashavatAveda1Entities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            Users u2 = db.Users.FirstOrDefault();
            var f = u2.city;

            foreach (Users u in db.Users.ToList())
            {
                //u.city=;
            }
        }
    }
}