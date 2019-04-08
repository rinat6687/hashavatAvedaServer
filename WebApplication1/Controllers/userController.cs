using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{

    // [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class userController : ApiController
    {
        public Program p = new Program();
        // GET: api/user
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //GET: api/user/5
        //public string Get(int id)
        //public Users[] Get(int id)
        //{
        //    return "value";
        //    return p.db.Users.ToArray();
        //}



        //// POST: api/user
        //[Route("api/user/getUserByMail")]

        //[HttpPost]
        //public User getUserByMail([FromBody]User s)
        //{
        //    return p.getUserByMail(s);
        //}

        [Route("api/user/{userCode}")]
        public User Get(int userCode)
        {
            return p.getUser(userCode);

        }

        //// POST: api/user
        // [Route("api/user/{neww}")]
        //[HttpPost]
        //public T Post<T>([FromBody]User s)
        //{
        //   var res= p.newUser(s);


        //    if (res == 0)
        //    {
        //        var value="כתובת מייל זו בשימוש";
        //        return (T)Convert.ChangeType(value, typeof(T));        
        //    }

        //    if(res==80)
        //    {
        //        var value="סיסמא זו בשימוש";
        //        return (T)Convert.ChangeType(value, typeof(T));

        //    }
        //    else
        //    {
        //        return (T)Convert.ChangeType(res, typeof(T));
        //    }

        //}
        [HttpPost]
        public int Post([FromBody]User s)
        {
             var res= p.newUser(s);
             return res;

           
        }


        public void Put()
        {
         
        }

        // DELETE: api/user/5
        public void Delete(int id)
        {
        }
    }
}
