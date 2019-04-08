using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{    
    public class advertisementController : ApiController
    {
        
        public advertisements a = new advertisements();
        public Program p = new Program();
        //GET: api/advertisement
        [Route("api/advertisement/getStatis")]
        public int[] getStatis()
        {
           return p.howMuchAds();
        }

        // GET: api/advertisement/5

        [Route("api/advertisement/GETadvertisement")]
        public List<advertisements> Getadvertisement()
        {
            
            List<advertisements> lst = p.getAdvertisements();
            return lst;
        }


        [Route("api/advertisement/{adCode}")]
        public int Get(int adCode)
        {
             return p.deleteAd(adCode);
        }
        [Route("api/advertisement")]
        public void Get(advertisements ad)
        {

        }


        //public string PostImage(advertisements f)
        //{
        //    try
        //    {
        //        return "f";
        //    }
        //    catch
        //    {
        //        return "nooo";
        //    }
        //}

        //POST: api/advertisement
        [HttpPost]
        [Route("api/advertisement")]
        public string Post([FromBody]advertisements adver)
        {
            //if (adver.adKod!=0)
            //{
            //    p.apdateAd(adver);

            //}
            //else
            //{
            Advertisement ad = new Advertisement();
            //ad.adKod = adver.adKod;
            ad.userKod = adver.userKod;
            ad.category = adver.category;
            ad.date = adver.date;
            ad.area = adver.area;
            ad.color = adver.color;
            ad.shape = null;
            ad.material = adver.material;
            ad.status = adver.status;
            ad.isFound = adver.isFound;
            ad.image = adver.image;
            ad.typeArea = adver.typeArea;
            ad.transportation = adver.transportation;
            p.db.Advertisement.Add(ad);
            p.db.SaveChanges();

            //send mail to user that wont this category
            p.findUsersToGetNewAd(adver);
            //}

            return "מודעתך פורסמה בהצלחה";
        }
        //public void sendToArchives()
        //{
        //    p.sendToArchives();
        //}

        //[Route("api/advertisement/postSaveUpdateAd")]

       

        // PUT: api/advertisement/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/advertisement/5
        public void Delete(int id)
        {
        }
    }
}
