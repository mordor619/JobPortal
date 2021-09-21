using JobPortalDI.ProjModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Service
{
    public interface IJobServ<Job>
    {
        public void createJob(Job j);        

        public Job getJobById(int id);

        public void deleteJob(int id);

        public void editJob(Job j);

        public List<Job> getAllJobs();

    }
}
