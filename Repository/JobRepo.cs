using JobPortalDI.ProjModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Repository
{
    public class JobRepo : IJobRepo<Job>
    {
        public static List<Job> jobs = new List<Job>();

        public JobRepo() { }

        public void createJob(Job j)
        {
            using (var db = new JobportalDIContext())
            {
                db.Jobs.Add(j);
                db.SaveChanges();
            }

        }


        public Job getJobById(int id)
        {
            using (var db = new JobportalDIContext())
            {
                Job j = db.Jobs.Find(id);

                return j;
            }

        }

        public void deleteJob(int id)
        {
            using (var db = new JobportalDIContext())
            {
                Job j = getJobById(id);
                db.Jobs.Remove(j);

                db.SaveChanges();

            }

        }

        public void editJob(Job j)
        {
            using (var db = new JobportalDIContext())
            {

                db.Entry(j).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                db.SaveChanges();

            }
        }

        public List<Job> getAllJobs()
        {
            using (var db = new JobportalDIContext())
            {
                jobs = db.Jobs.ToList();
            }

            return jobs;
        }


    }
}
