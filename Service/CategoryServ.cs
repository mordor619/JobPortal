using JobPortalDI.ProjModel;
using JobPortalDI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Service
{
    public class CategoryServ : ICategoryServ<Category>
    {
        private readonly ICategoryRepo<Category> repo;

        public CategoryServ() { }

        public CategoryServ(ICategoryRepo<Category> _repo)
        {
            repo = _repo;
        }

        public List<Category> getCategories()
        {
            return repo.getCategories();
        }

    }
}
