using JobPortalDI.ProjModel;
using JobPortalDI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Service
{
    public class LogintblServ : ILogintblServ<Logintbl>
    {

        private readonly ILogintblRepo<Logintbl> repo;

        public LogintblServ(ILogintblRepo<Logintbl> _repo)
        {
            repo = _repo;
        }


        public void AddUser(Logintbl u)
        {
            repo.AddUser(u);
        }

        public Logintbl GetUser(Logintbl obj)
        {
            return repo.GetUser(obj);
        }



    }
}
