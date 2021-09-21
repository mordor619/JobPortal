using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Repository
{
    public interface ICategoryRepo<Category>
    {
        public List<Category> getCategories();
    }
}
