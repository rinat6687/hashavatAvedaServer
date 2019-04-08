using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class loginController : ApiController
    {
    public Category c = new Category();
    public User u = new User();
    public Program p = new Program();
    public static List<User> UsersForGetMail;


        //[HttpGet]
        // GET: api/login
        [Route("api/login")]
        public List<category_1> Get()
        {
            List<Category> ls = p.allCategory();
            List<category_1> lst = new List<category_1>();
            foreach (Category item in ls)
            {
                lst.Add(new category_1()
                {
                    categoryParentsId = item.categoryParentsId,
                    categoryKod = item.categoryKod,
                    categoryName = item.categoryName
                }
                    );
            }
            return lst;            
            
        }

        // GET: api/login/5
        [Route("api/login/{id}")]
        public List<category_1> Get(int id)
        {
            List<Category> ls = c.GetCategories(id);
            List<category_1> lst = new List<category_1>();
            foreach (Category item in ls)
            {
                lst.Add(new category_1()
                {
                    categoryParentsId = item.categoryParentsId,
                    categoryKod = item.categoryKod,
                    categoryName = item.categoryName
                }
                    );
            }
            // List<string> ls = c.GetCategories(id);
            return lst;
        }

        //[HttpPost]
        [Route("api/login/postLogin")]
        public int postLogin(User loginDetails)
        {
            return p.login(loginDetails.mail, loginDetails.password);
            //return Request.GetRouteData().ToString();
                    // return "success";
        }
         //[HttpPost]
        [Route("api/login/postUpdate")]
        public void postUpdate([FromBody]User s)
        {
            Users newUser = p.db.Users.FirstOrDefault(x => x.userKod == s.userKod);
            newUser.friend = true;
            newUser.firstName = s.firstName;
            newUser.lastName = s.lastName;
            newUser.mail = s.mail;
            newUser.city = s.city;
            newUser.street = s.street;
            newUser.house = s.house;
            newUser.mail = s.mail;
            newUser.Tel1 = s.Tel1;
            newUser.Tel2 = s.Tel2;
            newUser.isCompany = true;
            newUser.connectDb = s.connectDb;
            newUser.password = s.password;
                 
            p.db.SaveChanges();

        }
                          

        // PUT: api/login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/login/5
        public void Delete(int id)
        {
        }
    }
}
