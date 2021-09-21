using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Service
{
    public interface ICategoryServ<Category>
    {
        public List<Category> getCategories();
    }
}
