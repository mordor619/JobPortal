using JobPortalDI.ProjModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Service
{
    public interface ILogintblServ<Logintbl>
    {
        public void AddUser(Logintbl u);

        public Logintbl GetUser(Logintbl obj);

    }
}
