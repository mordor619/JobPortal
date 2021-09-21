using JobPortalDI.ProjModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Repository
{
    public class CategoryRepo : ICategoryRepo<Category>
    {
        public static List<Category> categories = new List<Category>();

        public List<Category> getCategories()
        {
            using (var db = new JobportalDIContext())
            {
                categories = db.Categories.ToList();
            }

            return categories;
        }
    }
}
