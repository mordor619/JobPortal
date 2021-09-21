using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortalDI.Repository
{
    public interface ILogintblRepo<Logintbl>
    {
        public void AddUser(Logintbl u);

        public Logintbl GetUser(Logintbl obj);

    }
}
