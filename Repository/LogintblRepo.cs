using JobPortalDI.ProjModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Repository
{
    public class LogintblRepo : ILogintblRepo<Logintbl>
    {
        public LogintblRepo() { }



        public void AddUser(Logintbl obj)
        {

                using (var db = new JobportalDIContext())
                {
                    db.Logintbls.Add(obj);
                    db.SaveChanges();
                }


        }

        public Logintbl GetUser(Logintbl obj)
        {
            using (var db = new JobportalDIContext())
            {
                Logintbl result = (from i in db.Logintbls
                                   where i.Username == obj.Username && i.Userpass == obj.Userpass && i.Usertype == obj.Usertype
                                   select i).FirstOrDefault();

                return result;
            }

        }

    }
}
