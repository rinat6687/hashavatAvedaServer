using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class forUpdateAdController : ApiController
    {
        public Program p = new Program();

        // GET: api/forUpdateAd
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/forUpdateAd/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/forUpdateAd
        [HttpPost]

        public void Post([FromBody]advertisements ad)
       
        {

            Advertisement upDateAd = p.db.Advertisement.FirstOrDefault(x => x.adKod == ad.adKod);
            upDateAd.userKod = ad.userKod;
            upDateAd.category = ad.category;
            upDateAd.date = ad.date;
            upDateAd.area = ad.area;
            upDateAd.color = ad.color;
            upDateAd.shape = null;
            upDateAd.material = ad.material;
            upDateAd.status = ad.status;
            upDateAd.isFound = ad.isFound;
            upDateAd.image = ad.image;
            upDateAd.typeArea = ad.typeArea;
            upDateAd.transportation = ad.transportation;
            p.db.SaveChanges();



            //var deleteOrderDetails =
            //   from details in p.db.Advertisement
            //   where details.adKod == adUpdate.adKod
            //   select details;

            //foreach (var detail in deleteOrderDetails)
            //{
            //    p.db.Advertisement.Remove(detail);
            //}
            //p.db.SaveChanges();
            //this.Post(adUpdate);


        }

        // PUT: api/forUpdateAd/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/forUpdateAd/5
        public void Delete(int id)
        {
        }
    }
}
