using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace WebApplication1.Models
{
    public class Program
    {
        public hashavatAveda1Entities4 db { get; set; }
        public companyEntities cdb { get; set; }
        


        public Program()
        {
            
            db = new hashavatAveda1Entities4();

            cdb = new companyEntities();

          }
        public List<Category> allCategory()
        {
            List<Category> allCategoryList = new List<Category>();

            db.Categories.ToList().ForEach(c =>
            {
                Category category = new Category()
                {
                    categoryKod = c.categoryKod,
                    categoryName = c.categoryName,
                    categoryParentsId = Convert.ToInt32( c.categoryParentsId)
                };
                allCategoryList.Add(category);
            });
            return allCategoryList; 
        }
        public List<Category> GetCategories(int categoryKod)
        {
            //List<string> catList=new List<string>();
            List<Category> categoryList = new List<Category>();
            if (categoryKod == 0)
            {
                db.Categories.ToList().ForEach(c =>
                {
                    if (c.categoryParentsId == null)
                    {
                        Category category = new Category()
                        {
                            categoryKod = c.categoryKod,
                            categoryName = c.categoryName,
                            categoryParentsId = 0
                        };

                        categoryList.Add(category);
                    }

                });
            }
            else
            {
                db.Categories.ToList().ForEach(c =>
                {
                    if (c.categoryParentsId == categoryKod)
                    {
                        //catList.Add(c.categoryName);


                        Category category = new Category()
                        {
                            categoryKod = c.categoryKod,
                            categoryName = c.categoryName,
                            categoryParentsId = categoryKod
                        };

                        categoryList.Add(category);
                    }
                });
            }
            return categoryList;
            //return catList;
        }

        public List<advertisements> getAdvertisements()
            {
        List<advertisements>lst=    GetAdver(db.Advertisement.ToList());
            List<advertisements> lstOfCompany = GetAdver(cdb.Advertisement.ToList());

            lst.AddRange(lstOfCompany);
            return lst;
            }

        public List<advertisements> GetAdver(List<Advertisement> lst) {
            List<advertisements> adver = new List<advertisements>();
            lst.ToList().ForEach(a =>
            {
                // if (a.category == categoryId)
                // {
                advertisements ad = new advertisements()
                {
                    adKod=a.adKod,
                    userKod = (int)a.userKod,
                    category = (int)a.category,
                    date = (DateTime)a.date,
                    area = a.area,
                    color = a.color,
                    shape = a.shape,
                    material = a.material,
                    status = (bool)a.status,
                   // categoryName = null
                    image=a.image
                };
                adver.Add(ad);
                // }

            });

            return adver;

        }
        public void apdateAd(advertisements adv)
        {
            var query =
            from ad in db.Advertisement
            where ad.adKod == adv.adKod
            select ad;

            foreach (Advertisement ad in query)
            {
                ad.status = adv.status;
                ad.category = adv.category;
            }

        }
        public void findUsersToGetNewAd(advertisements ad)
        {
            UsersForGetMail.ToList().ForEach(a =>
            {
                //userKod mean to category
                if (a.userKod == ad.category && ad.status == false)
                {
                    ad.material = a.mail;
                    ad.image = a.firstName;
                    sendMailWithNewAd(ad);
                }

            });
           
        }

        public string sendMailWithNewAd(advertisements ad)
        {


                mail email = new mail();
                try
                {
                    var fromAddress = new MailAddress("yourMail@gmail.com", "From Name");
        var toAddress = new MailAddress(ad.material, "To Name");
        const string fromPassword = "your gmail pass";
        const string subject = "מייל מאתר lost-found";
             var catName  =   db.Categories.ToList().Find(x => x.categoryKod == ad.category).categoryName;
               catName= catName.Replace(" ","");
                
                string body = ad.image + " שלום! " + " באתרינו נוספה מודעה חדשה מקטגוריית " +catName + " באיזור " + ad.area;


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
                return "משתמש קיבל מודעה רלוונטית חדשה...";
                }


                catch (Exception ex)
                {
                    return ex.ToString();
                }


        }
        public int login(string mail, string password)
        //.Replace(" ","")
         {
            Object o = db.Users.ToList().FirstOrDefault(u => u.mail.Replace(" ", "") == mail && u.password.Replace(" ", "") == password);
            if(o==null)
                return 0;
            return ((Users)o).userKod;
        }

        static int counter=80;
        public int deleteAd(int adCode)
        {

            var deleteOrderDetails =
               from details in db.Advertisement
               where details.adKod == adCode
               select details;

            foreach (var detail in deleteOrderDetails)
            {
                db.Advertisement.Remove(detail);
                counter += 1;
               
                
            }
            db.SaveChanges();
            int countAd = db.Advertisement.Count();
            int found = (counter / 100) * countAd;
            return found;

        }
        static List<User> UsersForGetMail = new List<User>();
        public void addUserForGetMail(User u)
        {
            User user = new User()
            {
                firstName = u.firstName,
                mail = u.mail,
                userKod = u.userKod //category
            };
            UsersForGetMail.Add(user);

        }
        public int newUser(User s)
        {
            //if (db.Users.FirstOrDefault(x => x.mail == s.mail) != null)
            //{
            //    return 0;
            //}
            //else
            //{
            //    if (db.Users.FirstOrDefault(x => x.password == s.password) != null)
            //        return 770;
            //    else
            //    {
                    Users newUser = new Users();
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
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return login(s.mail, s.password);

            //    }

            //}
        }
      
        public User getUser (int userCode)
        {
            Users u = db.Users.ToList().First(x => x.userKod == userCode);
            User user = new User(u.userKod, u.friend, u.firstName, u.lastName, u.city, u.mail, u.Tel1,
                                 u.Tel2, (bool)u.isCompany,u.connectDb,u.password);
           // HttpContext.Current.Session["user"] = user;
            return user;
          
        }

        public User getUserByMail(User mail)
        {
            Users u = db.Users.ToList().First(x => x.mail!=null&&x.mail == mail.mail);
            User user = new User(u.userKod, u.friend, u.firstName, u.lastName, u.city, u.mail, u.Tel1, 
                                 u.Tel2, (bool)u.isCompany, u.connectDb, u.password);
            // HttpContext.Current.Session["user"] = user;
            return user;

        }
        public User getUserbySession() {
            if (HttpContext.Current.Session["user"]== null)
            {
                return null;
            }
            else
                return (HttpContext.Current.Session["user"] as User);
            
               
        }
        public int[] res = new int[5];
        public int[] howMuchAds()
        {
            res[0] = db.Advertisement.Count();
            res[1] = db.Users.Count();
            res[2] = counter; 

            return  res;
        }
        public void sendToArchives()
        {
             DateTime d = DateTime.Now;
            DateTime d2;
            
            //Advertisement adToDelete = db.Advertisement.ToList().ForEach(x =>
            //{
            //  if (DateTime.Now-x.date)
                   

            //}
                      
          
        }
    }
}