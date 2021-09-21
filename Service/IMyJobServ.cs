using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Service
{
    public interface IMyJobServ<Myjob>
    {
        public List<Myjob> getMyJobs();

        public void addToMyJobs(Myjob j);

        public void deleteMyJob(int id);
    }
}
