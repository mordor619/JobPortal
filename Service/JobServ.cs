using JobPortalDI.ProjModel;
using JobPortalDI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Service
{
    public class JobServ : IJobServ<Job>
    {
        private readonly IJobRepo<Job> repo;

        public JobServ() { }

        public JobServ(IJobRepo<Job> _repo)
        {
            repo = _repo;
        }

        public void createJob(Job j)
        {
            repo.createJob(j);
        }

        public void deleteJob(int id)
        {
            repo.deleteJob(id);
        }

        public void editJob(Job j)
        {
            repo.editJob(j);
        }

        public List<Job> getAllJobs()
        {
            return repo.getAllJobs();
        }

        public Job getJobById(int id)
        {
            return repo.getJobById(id);
        }

    }
}
