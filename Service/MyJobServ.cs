using JobPortalDI.ProjModel;
using JobPortalDI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Service
{
    public class MyJobServ : IMyJobServ<Myjob>
    {
        private readonly IMyJobRepo<Myjob> repo;

        public MyJobServ() { }

        public MyJobServ(IMyJobRepo<Myjob> _repo)
        {
            repo = _repo;
        }

        public List<Myjob> getMyJobs()
        {
            return repo.getMyJobs();
        }

        public void addToMyJobs(Myjob j)
        {
            repo.addToMyJobs(j);
        }

        public void deleteMyJob(int id)
        {
            repo.deleteMyJob(id);
        }
    }
}
