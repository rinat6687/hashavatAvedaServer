using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Category
    {
        public hashavatAveda1Entities1 db = new hashavatAveda1Entities1();
        public int categoryKod { get; set; }
        public string categoryName { get; set; }
        public int categoryParentsId { get; set; }
        
        public List<Category> GetCategories( int categoryKod)
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
    }
}