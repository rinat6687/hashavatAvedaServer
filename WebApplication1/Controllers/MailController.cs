using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Models;
using System.Net.Mail;

namespace WebApplication1.Controllers
{
    public class MailController : ApiController
    {
        public Program p = new Program();

        // GET: api/Mail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mail
        //public void Post([FromBody]string value)
        //{
        //}


        [HttpPost]
        public void Post([FromBody]User u)
        {
            if (u.userKod != 0)
            {
                p.addUserForGetMail(u);
     
             }

            else
            {
              mail email = new mail();
               try
               {
                  var fromAddress = new MailAddress("rinat6687@gmail.com", "From Name");
                  var toAddress = new MailAddress(u.mail, "To Name");
                   const string fromPassword = "rinat5510";
                   const string subject = "מייל מאתר השבת אבידה";
                    string body = null;
                    //city=שאלה לרב Tel2= massage
                    if (u.city != null)
                        body = u.city;
                    else
                        body =u.Tel2;

                  var smtp = new SmtpClient
                 {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                 };
                   using (var message = new MailMessage(fromAddress, toAddress)
                  {
                    Subject = subject,
                    Body = body
                  })
                  {
                    smtp.Send(message);
                }
               
                }


                  catch (Exception ex)
                  {
                      //return ex.ToString();
                  }
            }

        }     // PUT: api/user/5

        // PUT: api/Mail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mail/5
        public void Delete(int id)
        {
        }
    }
}
