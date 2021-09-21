using JobPortalDI.ProjModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Repository
{
    public class MyJobRepo : IMyJobRepo<Myjob>
    {
        public static List<Myjob> myJobs = new List<Myjob>();

        public List<Myjob> getMyJobs()
        {
            using (var db = new JobportalDIContext())
            {
                myJobs = db.Myjobs.ToList();
            }

            return myJobs;
        }


        public void addToMyJobs(Myjob j)
        {
            using (var db = new JobportalDIContext())
            {
                db.Myjobs.Add(j);
                db.SaveChanges();
            }
        }

        public Myjob getMyJobById(int id)
        {
            using (var db = new JobportalDIContext())
            {
                Myjob j = db.Myjobs.Find(id);

                return j;
            }

        }

        public void deleteMyJob(int id)
        {
            using (var db = new JobportalDIContext())
            {
                Myjob j = getMyJobById(id);
                db.Myjobs.Remove(j);

                db.SaveChanges();

            }
        }
    }
}
